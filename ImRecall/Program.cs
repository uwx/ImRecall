using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using Windows.Graphics.Display;
using Windows.Win32;
using Windows.Win32.Foundation;
using SixLabors.ImageSharp.PixelFormats;
using GraphicsCaptureItem = Windows.Graphics.Capture.GraphicsCaptureItem;

namespace ImRecall
{
    public partial class Program
    {
        [GeneratedRegex(
            """
            [\0-\u001F"*/:<>?\\\|]
            """
        )]
        private static partial Regex InvalidFileNameCharsRegex { get; }
        
        private static string SanitizeFileName(string fileName)
        {
            return InvalidFileNameCharsRegex.Replace(fileName, "_");
        }

        public static async Task Main(string[] args)
        {
            // TODO remove disconnected displays from here
            var lastBitmapByDisplayName = new Dictionary<string, Bitmap>();

            try
            {
                while (true)
                {
                    foreach (var (index, displayId) in DisplayServices.FindAll().Index())
                    {
                        var captureItem = GraphicsCaptureItem.TryCreateFromDisplayId(displayId);
                        if (captureItem == null)
                        {
                            Console.WriteLine($"[{index}] WindowsCapture was provided with a invalid item (null) for Windows.Graphics.Capture to capture window... :(");
                            continue;
                        }

                        var bitmap = await CaptureSdr(captureItem);
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

                                // Save the tonemapped SDR image
                                var stopwatch = Stopwatch.StartNew();
                                bitmap.Save($"{SanitizeFileName(captureItem.DisplayName)}-{SanitizeFileName(GetForegroundWindowName())}-{DateTimeOffset.Now:yyyy-MM-dd_HH-mm-ss}.png", ImageFormat.Png);
                                stopwatch.Stop();
                                Console.WriteLine($"[{index}] Image saved in {stopwatch.ElapsedMilliseconds} ms.");
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

                    await Task.Delay(TimeSpan.FromSeconds(3));
                }
            }
            finally
            {
                foreach (var bitmap in lastBitmapByDisplayName.Values)
                {
                    bitmap.Dispose();
                }
            }
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

        private static async Task<Bitmap?> CaptureSdr(GraphicsCaptureItem captureItem)
        {
            Bitmap? bitmap = null;
            try
            {
                // Capture HDR image
                using var nullableHdrImage = await new WindowsCapture().CaptureFullscreen2(captureItem);
            
                if (nullableHdrImage is not {} hdrImage)
                {
                    return null;
                }

                // Tonemap HDR to SDR
                var tonemapSettings = new HdrTonemapper.TonemapSettings
                {
                    Operator = HdrTonemapper.TonemapOperator.Clip, // You can change this to Reinhard, Filmic, or Clip
                    HdrPeakNits = 203f,  // Adjust based on your display
                    SdrWhiteNits = 100f,
                    Exposure = 1f,       // Increase if image is too dark
                    Gamma = 2.2f
                };

                var stopwatch = Stopwatch.StartNew();
                
                bitmap = new Bitmap(hdrImage.Width, hdrImage.Height, PixelFormat.Format24bppRgb);
                using var sdrImage = LibraryIndependentImage<Bgr24>.FromBitmap(bitmap);
                HdrTonemapper.TonemapToSdr(hdrImage, sdrImage, tonemapSettings);

                stopwatch.Stop();
                Console.WriteLine($"Tonemapping completed in {stopwatch.ElapsedMilliseconds} ms.");

                return bitmap;
            }
            catch
            {
                bitmap?.Dispose();
                throw;
            }
        }
    }
}