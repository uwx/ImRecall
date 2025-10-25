using System.Numerics;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace SnapX.Core.SharpCapture.Windows;

/// <summary>
/// Provides HDR to SDR tonemapping functionality for screen captures
/// </summary>
public class HdrTonemapper
{
    public enum TonemapOperator
    {
        /// <summary>Simple clipping at SDR white level</summary>
        Clip,
        /// <summary>Reinhard tonemapping</summary>
        Reinhard,
        /// <summary>Hable/Uncharted 2 filmic tonemapping</summary>
        Filmic,
        /// <summary>ACES filmic tonemapping</summary>
        ACES
    }

    public class TonemapSettings
    {
        /// <summary>The tonemapping operator to use</summary>
        public TonemapOperator Operator { get; set; } = TonemapOperator.ACES;
        
        /// <summary>HDR peak brightness in nits (default: 1000)</summary>
        public float HdrPeakNits { get; set; } = 1000f;
        
        /// <summary>SDR white level in nits (default: 80)</summary>
        public float SdrWhiteNits { get; set; } = 80f;
        
        /// <summary>Exposure adjustment (default: 1.0, increase to brighten)</summary>
        public float Exposure { get; set; } = 1.0f;
        
        /// <summary>Gamma correction (default: 2.2 for sRGB)</summary>
        public float Gamma { get; set; } = 2.2f;
    }

    /// <summary>
    /// Tonemap an HDR image to SDR
    /// </summary>
    public static Image<Rgb24> TonemapToSdr(Image<DirectXHalfVector4> hdrImage, TonemapSettings? settings = null)
    {
        settings ??= new TonemapSettings();
        
        var sdrImage = new Image<Rgb24>(hdrImage.Width, hdrImage.Height);
        
        // Calculate scale factor from HDR to normalized linear
        float hdrScale = settings.SdrWhiteNits / settings.HdrPeakNits;
        
        hdrImage.ProcessPixelRows(sdrImage, (hdrAccessor, sdrAccessor) =>
        {
            for (int y = 0; y < hdrAccessor.Height; y++)
            {
                Span<DirectXHalfVector4> hdrRow = hdrAccessor.GetRowSpan(y);
                Span<Rgb24> sdrRow = sdrAccessor.GetRowSpan(y);
                
                for (int x = 0; x < hdrRow.Length; x++)
                {
                    // Convert from half to float
                    Vector4 hdrColor = hdrRow[x].ToVector4();
                    
                    // Remove alpha, apply exposure
                    Vector3 linear = new Vector3(hdrColor.X, hdrColor.Y, hdrColor.Z) * settings.Exposure;
                    
                    // Apply tonemapping
                    Vector3 mapped = settings.Operator switch
                    {
                        TonemapOperator.Clip => TonemapClip(linear, hdrScale),
                        TonemapOperator.Reinhard => TonemapReinhard(linear, hdrScale),
                        TonemapOperator.Filmic => TonemapFilmic(linear),
                        TonemapOperator.ACES => TonemapAces(linear),
                        _ => linear
                    };
                    
                    // Apply gamma correction (linear to sRGB)
                    mapped = ApplyGamma(mapped, 1.0f / settings.Gamma);
                    
                    // Clamp and convert to 8-bit
                    sdrRow[x] = new Rgb24(
                        (byte)Math.Clamp(mapped.X * 255f, 0f, 255f),
                        (byte)Math.Clamp(mapped.Y * 255f, 0f, 255f),
                        (byte)Math.Clamp(mapped.Z * 255f, 0f, 255f)
                    );
                }
            }
        });
        
        return sdrImage;
    }

    private static Vector3 TonemapClip(Vector3 color, float scale)
    {
        color *= scale;
        return Vector3.Clamp(color, Vector3.Zero, Vector3.One);
    }

    private static Vector3 TonemapReinhard(Vector3 color, float scale)
    {
        color *= scale;
        // Extended Reinhard: color / (1 + color)
        return color / (Vector3.One + color);
    }

    private static Vector3 TonemapFilmic(Vector3 x)
    {
        // Hable/Uncharted 2 filmic tonemapping
        const float a = 0.15f;
        const float b = 0.50f;
        const float c = 0.10f;
        const float d = 0.20f;
        const float e = 0.02f;
        const float f = 0.30f;
        
        Vector3 FilmicCurve(Vector3 v)
        {
            return ((v * (a * v + new Vector3(c * b)) + new Vector3(d * e)) / 
                    (v * (a * v + new Vector3(b)) + new Vector3(d * f))) - new Vector3(e / f);
        }
        
        const float w = 11.2f; // Linear white point
        Vector3 curr = FilmicCurve(x * 2.0f);
        Vector3 whiteScale = Vector3.One / FilmicCurve(new Vector3(w));
        
        return curr * whiteScale;
    }

    private static Vector3 TonemapAces(Vector3 x)
    {
        // ACES filmic tone mapping curve
        const float a = 2.51f;
        const float b = 0.03f;
        const float c = 2.43f;
        const float d = 0.59f;
        const float e = 0.14f;
        
        Vector3 numerator = x * (a * x + new Vector3(b));
        Vector3 denominator = x * (c * x + new Vector3(d)) + new Vector3(e);
        
        return Vector3.Clamp(numerator / denominator, Vector3.Zero, Vector3.One);
    }

    private static Vector3 ApplyGamma(Vector3 color, float gamma)
    {
        return new Vector3(
            MathF.Pow(Math.Max(color.X, 0f), gamma),
            MathF.Pow(Math.Max(color.Y, 0f), gamma),
            MathF.Pow(Math.Max(color.Z, 0f), gamma)
        );
    }
    
    /// <summary>
    /// Converts linear RGB to sRGB gamma space
    /// </summary>
    public static Vector3 LinearToSrgb(Vector3 linear)
    {
        static float LinearToSrgbChannel(float value)
        {
            if (value <= 0.0031308f)
                return value * 12.92f;
            return 1.055f * MathF.Pow(value, 1.0f / 2.4f) - 0.055f;
        }
        
        return new Vector3(
            LinearToSrgbChannel(linear.X),
            LinearToSrgbChannel(linear.Y),
            LinearToSrgbChannel(linear.Z)
        );
    }
}

