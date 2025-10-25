using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;

namespace SnapX.Core.SharpCapture.Windows
{
    /// <summary>
    /// Example showing how to use different tonemapping operators
    /// </summary>
    public class TonemappingExamples
    {
        /// <summary>
        /// Capture and save with all tonemapping operators for comparison
        /// </summary>
        public static async Task CompareTonemapOperators()
        {
            Console.WriteLine("Capturing HDR screenshot...");
            using var hdrImage = await new WindowsCapture().CaptureFullscreen2();
            
            if (hdrImage == null)
            {
                Console.WriteLine("Failed to capture HDR image.");
                return;
            }
            
            Console.WriteLine($"Captured {hdrImage.Width}x{hdrImage.Height} HDR image");
            
            // Test each tonemapping operator
            var operators = new[]
            {
                HdrTonemapper.TonemapOperator.ACES,
                HdrTonemapper.TonemapOperator.Filmic,
                HdrTonemapper.TonemapOperator.Reinhard,
                HdrTonemapper.TonemapOperator.Clip
            };
            
            foreach (var op in operators)
            {
                Console.WriteLine($"Processing with {op} tonemapping...");
                
                var settings = new HdrTonemapper.TonemapSettings
                {
                    Operator = op,
                    HdrPeakNits = 1000f,
                    SdrWhiteNits = 80f,
                    Exposure = 1.0f,
                    Gamma = 2.2f
                };
                
                using var sdrImage = HdrTonemapper.TonemapToSdr(hdrImage, settings);
                var filename = $"tonemap_{op.ToString().ToLower()}.webp";
                
                await sdrImage.SaveAsWebpAsync(filename, new WebpEncoder
                {
                    FileFormat = WebpFileFormatType.Lossless
                });
                
                Console.WriteLine($"Saved: {filename}");
            }
            
            Console.WriteLine("Comparison complete! Check the generated images.");
        }
        
        /// <summary>
        /// Capture with custom exposure adjustment
        /// </summary>
        public static async Task CaptureWithExposureBracketing()
        {
            Console.WriteLine("Capturing HDR screenshot...");
            using var hdrImage = await new WindowsCapture().CaptureFullscreen2();
            
            if (hdrImage == null)
            {
                Console.WriteLine("Failed to capture HDR image.");
                return;
            }
            
            // Test different exposure values
            var exposures = new[] { 0.5f, 0.7f, 1.0f, 1.3f, 1.5f };
            
            foreach (var exposure in exposures)
            {
                Console.WriteLine($"Processing with exposure {exposure}...");
                
                var settings = new HdrTonemapper.TonemapSettings
                {
                    Operator = HdrTonemapper.TonemapOperator.ACES,
                    HdrPeakNits = 1000f,
                    SdrWhiteNits = 80f,
                    Exposure = exposure,
                    Gamma = 2.2f
                };
                
                using var sdrImage = HdrTonemapper.TonemapToSdr(hdrImage, settings);
                var filename = $"exposure_{exposure:F1}.webp";
                
                await sdrImage.SaveAsWebpAsync(filename, new WebpEncoder
                {
                    FileFormat = WebpFileFormatType.Lossless
                });
                
                Console.WriteLine($"Saved: {filename}");
            }
            
            Console.WriteLine("Exposure bracketing complete!");
        }
        
        /// <summary>
        /// Capture optimized for a specific display type
        /// </summary>
        public static async Task CaptureForDisplay(string displayType = "HDR1000")
        {
            Console.WriteLine($"Capturing for {displayType} display...");
            using var hdrImage = await new WindowsCapture().CaptureFullscreen2();
            
            if (hdrImage == null)
            {
                Console.WriteLine("Failed to capture HDR image.");
                return;
            }
            
            // Configure based on display type
            var settings = displayType.ToUpper() switch
            {
                "SDR" => new HdrTonemapper.TonemapSettings
                {
                    Operator = HdrTonemapper.TonemapOperator.ACES,
                    HdrPeakNits = 100f,
                    SdrWhiteNits = 80f,
                    Exposure = 1.0f,
                    Gamma = 2.2f
                },
                "HDR400" => new HdrTonemapper.TonemapSettings
                {
                    Operator = HdrTonemapper.TonemapOperator.ACES,
                    HdrPeakNits = 400f,
                    SdrWhiteNits = 80f,
                    Exposure = 1.0f,
                    Gamma = 2.2f
                },
                "HDR1000" => new HdrTonemapper.TonemapSettings
                {
                    Operator = HdrTonemapper.TonemapOperator.ACES,
                    HdrPeakNits = 1000f,
                    SdrWhiteNits = 80f,
                    Exposure = 1.0f,
                    Gamma = 2.2f
                },
                "HDR1400" => new HdrTonemapper.TonemapSettings
                {
                    Operator = HdrTonemapper.TonemapOperator.ACES,
                    HdrPeakNits = 1400f,
                    SdrWhiteNits = 80f,
                    Exposure = 1.0f,
                    Gamma = 2.2f
                },
                _ => new HdrTonemapper.TonemapSettings() // Default
            };
            
            using var sdrImage = HdrTonemapper.TonemapToSdr(hdrImage, settings);
            var filename = $"capture_{displayType.ToLower()}.webp";
            
            await sdrImage.SaveAsWebpAsync(filename, new WebpEncoder
            {
                FileFormat = WebpFileFormatType.Lossless
            });
            
            Console.WriteLine($"Saved: {filename}");
        }
    }
}

