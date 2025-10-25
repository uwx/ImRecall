using System.Numerics;
using System.Runtime.CompilerServices;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.PixelFormats;

namespace ImRecall;

/// <summary>
/// Provides HDR to SDR tonemapping functionality for screen captures
/// </summary>
public class HdrTonemapper
{
    public enum TonemapOperator : byte
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
    public static void TonemapToSdr(
        LibraryIndependentImage<DirectXHalfVector4> hdrImage,
        LibraryIndependentImage<Bgr24> sdrImage,
        TonemapSettings? settings = null
    )
    {
        settings ??= new TonemapSettings();

        // Calculate scale factor from HDR to normalized linear
        var hdrScale = settings.SdrWhiteNits / settings.HdrPeakNits;
        
        var operation = new RowOperation(hdrImage, sdrImage, settings, hdrScale);

        SimplifiedRowIterator.IterateRows(
            hdrImage.Bounds,
            in operation
        );
    }

    private readonly struct RowOperation(
        LibraryIndependentImage<DirectXHalfVector4> source,
        LibraryIndependentImage<Bgr24> destination,
        TonemapSettings settings,
        float hdrScale
    ) : IRowOperation
    {
        public void Invoke(int y)
        {
            var hdrRow = source.DangerousGetRowSpan(y);
            var sdrRow = destination.DangerousGetRowSpan(y);
            var exposure = settings.Exposure;
            var gamma = settings.Gamma;
            var @operator = settings.Operator;
            switch (@operator)
            {
                case TonemapOperator.Clip:
                    TonemapClip(exposure, hdrScale, gamma, hdrRow, sdrRow);
                    break;
                case TonemapOperator.Reinhard:
                    TonemapReinhard(exposure, hdrScale, gamma, hdrRow, sdrRow);
                    break;
                case TonemapOperator.Filmic:
                    TonemapFilmic(exposure, hdrScale, gamma, hdrRow, sdrRow);
                    break;
                case TonemapOperator.ACES:
                    TonemapAces(exposure, hdrScale, gamma, hdrRow, sdrRow);
                    break;
                default:
                    return;
            }

            return;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            static void TonemapClip(float exposure, float hdrScale, float gamma, Span<DirectXHalfVector4> hdrRow, Span<Bgr24> sdrRow)
            {
                for (var x = 0; x < sdrRow.Length; x++)
                {
                    sdrRow[x] = PixelOp<ClipTonemapper>(exposure, hdrScale, gamma, hdrRow[x]);
                }
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            static void TonemapReinhard(float exposure, float hdrScale, float gamma, Span<DirectXHalfVector4> hdrRow, Span<Bgr24> sdrRow)
            {
                for (var x = 0; x < sdrRow.Length; x++)
                {
                    sdrRow[x] = PixelOp<ReinhardTonemapper>(exposure, hdrScale, gamma, hdrRow[x]);
                }
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            static void TonemapFilmic(float exposure, float hdrScale, float gamma, Span<DirectXHalfVector4> hdrRow, Span<Bgr24> sdrRow)
            {
                for (var x = 0; x < sdrRow.Length; x++)
                {
                    sdrRow[x] = PixelOp<FilmicTonemapper>(exposure, hdrScale, gamma, hdrRow[x]);
                }
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            static void TonemapAces(float exposure, float hdrScale, float gamma, Span<DirectXHalfVector4> hdrRow, Span<Bgr24> sdrRow)
            {
                for (var x = 0; x < sdrRow.Length; x++)
                {
                    sdrRow[x] = PixelOp<AcesTonemapper>(exposure, hdrScale, gamma, hdrRow[x]);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Bgr24 PixelOp<TTonemapper>(
            float exposure,
            float hdrScale,
            float gamma,
            DirectXHalfVector4 hdrPixel
        ) where TTonemapper : ITonemapper
        {
            // Convert from half to float
            var hdrColor = hdrPixel.ToVector4();

            // Remove alpha, apply exposure
            var linear = new Vector3(hdrColor.X, hdrColor.Y, hdrColor.Z) * exposure;

            // Apply tonemapping
            var mapped = TTonemapper.Tonemap(linear, hdrScale);
                    
            // Apply gamma correction (linear to sRGB)
            mapped = ApplyGamma(mapped, 1.0f / gamma);
                    
            // Clamp and convert to 8-bit
            return new Bgr24(
                (byte)Math.Clamp(mapped.X * 255f, 0f, 255f),
                (byte)Math.Clamp(mapped.Y * 255f, 0f, 255f),
                (byte)Math.Clamp(mapped.Z * 255f, 0f, 255f)
            );
        }
    }

    private interface ITonemapper
    {
        public static abstract Vector3 Tonemap(Vector3 color, float scale);
    }
    
    private class ClipTonemapper : ITonemapper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Tonemap(Vector3 color, float scale) => TonemapClip(color, scale);
    }
    
    private class ReinhardTonemapper : ITonemapper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Tonemap(Vector3 color, float scale) => TonemapReinhard(color, scale);
    }
    
    private class FilmicTonemapper : ITonemapper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Tonemap(Vector3 color, float scale) => TonemapFilmic(color);
    }
    
    private class AcesTonemapper : ITonemapper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Tonemap(Vector3 color, float scale) => TonemapAces(color);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Vector3 TonemapClip(Vector3 color, float scale)
    {
        color *= scale;
        return Vector3.Clamp(color, Vector3.Zero, Vector3.One);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Vector3 TonemapReinhard(Vector3 color, float scale)
    {
        color *= scale;
        // Extended Reinhard: color / (1 + color)
        return color / (Vector3.One + color);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Vector3 TonemapFilmic(Vector3 x)
    {
        // Hable/Uncharted 2 filmic tonemapping
        const float a = 0.15f;
        const float b = 0.50f;
        const float c = 0.10f;
        const float d = 0.20f;
        const float e = 0.02f;
        const float f = 0.30f;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        Vector3 FilmicCurve(Vector3 v)
        {
            return ((v * (a * v + new Vector3(c * b)) + new Vector3(d * e)) / 
                    (v * (a * v + new Vector3(b)) + new Vector3(d * f))) - new Vector3(e / f);
        }
        
        const float w = 11.2f; // Linear white point
        var curr = FilmicCurve(x * 2.0f);
        var whiteScale = Vector3.One / FilmicCurve(new Vector3(w));
        
        return curr * whiteScale;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Vector3 TonemapAces(Vector3 x)
    {
        // ACES filmic tone mapping curve
        const float a = 2.51f;
        const float b = 0.03f;
        const float c = 2.43f;
        const float d = 0.59f;
        const float e = 0.14f;
        
        var numerator = x * (a * x + new Vector3(b));
        var denominator = x * (c * x + new Vector3(d)) + new Vector3(e);
        
        return Vector3.Clamp(numerator / denominator, Vector3.Zero, Vector3.One);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3 LinearToSrgb(Vector3 linear)
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

