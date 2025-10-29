using System.Buffers;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using Windows.Graphics.Capture;
using Windows.Graphics.Display;
using Windows.Win32;
using Windows.Win32.Foundation;
using LibAvifSharp.NativeTypes;
using Microsoft.Extensions.Hosting;
using Microsoft.IO;
using SixLabors.ImageSharp.PixelFormats;
using WebPWrapper;

namespace ImRecall;

public partial class ScreenshotProgram(IScreenshotService screenshotService, IImmichUploadService immichUploadService, ImRecallOptions opts) : BackgroundService, IDisposable
{
    [GeneratedRegex(
        """
        [\0-\u001F"*/:<>?\\\|]
        """,
        RegexOptions.Compiled | RegexOptions.CultureInvariant
    )]
    private static partial Regex InvalidFileNameCharsRegex { get; }

    // TODO remove disconnected displays from here
    private Dictionary<string, LibraryIndependentImage<Bgr24>> lastBitmapByDisplayName = new();
        
    private static string SanitizeFileName(string fileName)
    {
        return InvalidFileNameCharsRegex.Replace(fileName, "_");
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                await RunScreenshotOperationAsync(cancellationToken);

                await Task.Delay(TimeSpan.FromSeconds(3), cancellationToken);
            }
            catch (TaskCanceledException)
            {
                // Ignore
            }
        }
        
        Console.WriteLine("Bye-bye!");
    }

    private async Task RunScreenshotOperationAsync(CancellationToken cancellationToken)
    {
        foreach (var (index, displayId) in DisplayServices.FindAll().Index())
        {
            var captureItem = GraphicsCaptureItem.TryCreateFromDisplayId(displayId);
            if (captureItem == null)
            {
                Console.WriteLine($"[{index}] WindowsCapture was provided with a invalid item (null) for Windows.Graphics.Capture to capture window... :(");
                continue;
            }

            var bitmapNullable = await screenshotService.CaptureScreenshotAsync(captureItem);
            if (bitmapNullable is not {} bitmap)
            {
                Console.WriteLine($"[{index}] Failed to capture screenshot.");
                continue;
            }

            try
            {
                if (!lastBitmapByDisplayName.TryGetValue(captureItem.DisplayName, out var lastBitmap) ||
                    !SsimUtils.IsSimilar(bitmap, lastBitmap))
                {
                    if (lastBitmap != default)
                        lastBitmap.Dispose();

                    lastBitmapByDisplayName[captureItem.DisplayName] = bitmap;

                    // Encode to WebP
                    var stopwatch = Stopwatch.StartNew();
                    #if USE_AVIF
                    using var bitmapMemoryOwner = Avif.Encode(bitmap, encoder =>
                    {
                        encoder.Quality = 100;
                        encoder.CodecChoice = AvifCodecChoice.AVIF_CODEC_CHOICE_AOM;
                        // encoder.PixelFormat = AvifPixelFormat.AVIF_PIXEL_FORMAT_YUV420;
                    });
                    #elif USE_GDI
                    using var bitmapMemoryOwner = GDIEncode(bitmap);
                    #else
                    using var bitmapMemoryOwner = WebP.EncodeLossless(bitmap);
                    #endif
                    
                    stopwatch.Stop();
                    Console.WriteLine($"[{index}] Encoded to WebP in {stopwatch.ElapsedMilliseconds} ms.");
                    
                    // Upload to Immich
                    var filename = $"{SanitizeFileName(captureItem.DisplayName)}-{SanitizeFileName(GetForegroundWindowName())}-{DateTimeOffset.Now:yyyy-MM-dd_HH-mm-ss}.webp";
                    if (!opts.EnableUpload)
                    {
                        stopwatch = Stopwatch.StartNew();
                        await using var stream = File.Create(filename);
                        await stream.WriteAsync(bitmapMemoryOwner.Memory, cancellationToken);
                        stopwatch.Stop();
                        Console.WriteLine($"[{index}] Image saved in {stopwatch.ElapsedMilliseconds} ms.");
                    }
                    else
                    {
                        stopwatch = Stopwatch.StartNew();
                        await immichUploadService.UploadAsync(filename, bitmapMemoryOwner.Memory, cancellationToken);
                        stopwatch.Stop();
                        Console.WriteLine($"[{index}] Image uploaded in {stopwatch.ElapsedMilliseconds} ms.");
                    }
                }
                else
                {
                    bitmap.Dispose();
                }
            }
            catch
            {
                bitmap.Dispose();
                throw;
            }

            continue;
        }
    }

#if USE_GDI
    private readonly RecyclableMemoryStreamManager _manager = new();
    
    private unsafe IMemoryOwner<byte> GDIEncode(LibraryIndependentImage<Bgr24> bitmap)
    {
        using var ms = _manager.GetStream();

        fixed (byte* ptr = bitmap.MemoryOwner.Memory.Span)
        {
            using var bmp = new Bitmap(bitmap.Width, bitmap.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            
            var bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, bmp.PixelFormat);
            try
            {
                Buffer.MemoryCopy(ptr, (void*)bmpData.Scan0, bmpData.Width * bmpData.Height * 3, bitmap.Width * bitmap.Height * 3);
            }
            finally
            {
                bmp.UnlockBits(bmpData);
            }

            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            var buf = new UnmanagedMemoryOwner<byte>((int)ms.Length);
            ms.GetReadOnlySequence().CopyTo(buf.Memory.Span);
            return buf;
        }
    }
#endif

    private static string GetForegroundWindowName()
    {
        var hwnd = PInvoke.GetForegroundWindow();
        if (hwnd != HWND.Null)
        {
            Span<char> title = stackalloc char[256];
            var length = PInvoke.GetWindowText(hwnd, title);
            if (length > 0)
            {
                return new string(title[..length]);
            }
        }
        return "Desktop";
    }

    public void Dispose()
    {
        foreach (var bitmap in lastBitmapByDisplayName.Values)
        {
            bitmap.Dispose();
        }
    }
}