using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using Windows.Graphics.Capture;
using Windows.Graphics.Display;
using Windows.Win32;
using Windows.Win32.Foundation;
using Microsoft.Extensions.Hosting;
using SixLabors.ImageSharp.PixelFormats;
using WebPWrapper;

namespace ImRecall;

public partial class ScreenshotProgram(IScreenshotService screenshotService, IImmichUploadService immichUploadService) : IHostedService, IDisposable
{
    [GeneratedRegex(
        """
        [\0-\u001F"*/:<>?\\\|]
        """,
        RegexOptions.Compiled | RegexOptions.CultureInvariant
    )]
    private static partial Regex InvalidFileNameCharsRegex { get; }

    // TODO remove disconnected displays from here
    private Dictionary<string, Bitmap> lastBitmapByDisplayName = new();
        
    private static string SanitizeFileName(string fileName)
    {
        return InvalidFileNameCharsRegex.Replace(fileName, "_");
    }

    public async Task StartAsync(CancellationToken cancellationToken)
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

            var bitmap = await screenshotService.CaptureScreenshotAsync(captureItem);
            if (bitmap == null)
            {
                Console.WriteLine($"[{index}] Failed to capture screenshot.");
                continue;
            }

            try
            {
                if (!lastBitmapByDisplayName.TryGetValue(captureItem.DisplayName, out var lastBitmap) ||
                    !AreBitmapsSimilar(bitmap, lastBitmap))
                {
                    lastBitmap?.Dispose();
                    lastBitmapByDisplayName[captureItem.DisplayName] = bitmap;

                    // Upload to Immich
                    var stopwatch = Stopwatch.StartNew();
                    using var bitmapMemoryOwner = WebP.EncodeLossless(bitmap);
                    await immichUploadService.UploadAsync(
                        $"{SanitizeFileName(captureItem.DisplayName)}-{SanitizeFileName(GetForegroundWindowName())}-{DateTimeOffset.Now:yyyy-MM-dd_HH-mm-ss}.webp",
                        bitmapMemoryOwner.Memory,
                        cancellationToken
                    );
                    stopwatch.Stop();
                    Console.WriteLine($"[{index}] Image uploaded in {stopwatch.ElapsedMilliseconds} ms.");
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

            static bool AreBitmapsSimilar(Bitmap currentBitmap, Bitmap lastBitmap)
            {
                using var currentImg = LibraryIndependentImage<Bgr24>.FromBitmap(currentBitmap);
                using var lastImg = LibraryIndependentImage<Bgr24>.FromBitmap(lastBitmap);
                return SsimUtils.IsSimilar(currentImg, lastImg);
            }
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

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