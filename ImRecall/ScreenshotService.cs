using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using Windows.Graphics.Capture;
using SixLabors.ImageSharp.PixelFormats;

namespace ImRecall;

public interface IScreenshotService
{
    public Task<LibraryIndependentImage<Bgr24>?> CaptureScreenshotAsync(GraphicsCaptureItem captureItem);
}

public sealed class ScreenshotService : IScreenshotService, IDisposable
{
    private readonly WindowsCapture _windowsCapture = new();
    public async Task<LibraryIndependentImage<Bgr24>?> CaptureScreenshotAsync(GraphicsCaptureItem captureItem)
    {
        // Capture HDR image
        using var nullableHdrImage = await _windowsCapture.CaptureFullscreen(captureItem);
        
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
            
        var sdrImage = LibraryIndependentImage<Bgr24>.Alloc(hdrImage.Width, hdrImage.Height);
        try
        {
            HdrTonemapper.TonemapToSdr(hdrImage, sdrImage, tonemapSettings);

            stopwatch.Stop();
            Console.WriteLine($"Tonemapping completed in {stopwatch.ElapsedMilliseconds} ms.");

            return sdrImage;
        }
        catch
        {
            sdrImage.Dispose();
            throw;
        }
    }

    public void Dispose()
    {
        _windowsCapture.Dispose();
    }
}