using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using Windows.Graphics.Capture;
using SixLabors.ImageSharp.PixelFormats;

namespace ImRecall;

public interface IScreenshotService
{
    public Task<Bitmap?> CaptureScreenshotAsync(GraphicsCaptureItem captureItem);
}

public class ScreenshotService : IScreenshotService
{
    public async Task<Bitmap?> CaptureScreenshotAsync(GraphicsCaptureItem captureItem)
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