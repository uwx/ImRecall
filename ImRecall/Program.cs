using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Webp;

namespace SnapX.Core.SharpCapture.Windows
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var i = 0;
            
            // Capture HDR image
            using var hdrImage = await new WindowsCapture().CaptureFullscreen2();
            
            if (hdrImage == null)
            {
                Console.WriteLine("Failed to capture HDR image.");
                return;
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

            using var sdrImage = HdrTonemapper.TonemapToSdr(hdrImage, tonemapSettings);
            
            // Save the tonemapped SDR image
            await sdrImage.SaveAsWebpAsync($"image{i}_tonemapped.webp", new WebpEncoder()
            {
                FileFormat = WebpFileFormatType.Lossless,
            });
            
            Console.WriteLine($"Saved tonemapped image: image{i}_tonemapped.webp");
            i++;
        }
    }
}