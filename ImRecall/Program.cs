using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using Windows.Graphics.Display;
using SixLabors.ImageSharp.PixelFormats;
using GraphicsCaptureItem = Windows.Graphics.Capture.GraphicsCaptureItem;

namespace ImRecall
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var i = 0;
            
            foreach (var (index, displayId) in DisplayServices.FindAll().Index())
            {
                var captureItem = GraphicsCaptureItem.TryCreateFromDisplayId(displayId);
                if (captureItem == null)
                {
                    Console.WriteLine("WindowsCapture was provided with a invalid item (null) for Windows.Graphics.Capture to capture window... :(");
                    continue;
                }
                
                // Capture HDR image
                using var nullableHdrImage = await new WindowsCapture().CaptureFullscreen2(captureItem);
            
                if (nullableHdrImage is not {} hdrImage)
                {
                    Console.WriteLine("Failed to capture HDR image.");
                    continue;
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
                
                using var bitmap = new Bitmap(hdrImage.Width, hdrImage.Height, PixelFormat.Format24bppRgb);
                using (var sdrImage = LibraryIndependentImage<Bgr24>.FromBitmap(bitmap))
                {
                    HdrTonemapper.TonemapToSdr(hdrImage, sdrImage, tonemapSettings);
                }

                stopwatch.Stop();
                Console.WriteLine($"Tonemapping completed in {stopwatch.ElapsedMilliseconds} ms.");
        
                // Save the tonemapped SDR image
                stopwatch = Stopwatch.StartNew();
                bitmap.Save($"{captureItem.DisplayName}-{DateTimeOffset.Now:yyyy-MM-dd_HH-mm-ss}.png", ImageFormat.Png);
                // await sdrImage.SaveAsWebpAsync($"{captureItem.DisplayName}-{DateTimeOffset.Now:yyyy-MM-dd_HH-mm-ss}.webp", new WebpEncoder
                // {
                //     FileFormat = WebpFileFormatType.Lossless,
                // });
                stopwatch.Stop();
                Console.WriteLine($"Image saved in {stopwatch.ElapsedMilliseconds} ms.");
            }
        }
    }
}