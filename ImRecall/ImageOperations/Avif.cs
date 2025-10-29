#if USE_AVIF
using System.Buffers;
using System.Drawing;
using System.Drawing.Imaging;
using LibAvifSharp;
using LibAvifSharp.NativeTypes;
using WebPWrapper;

namespace ImRecall;

internal class Avif
{
    public static unsafe IMemoryOwner<byte> Encode(Bitmap bmp, Action<EncoderSetttings>? settings = null)
    {
        //test bmp
        if (bmp.Width == 0 || bmp.Height == 0)
            throw new ArgumentException("Bitmap contains no data.", nameof(bmp));
        if (bmp.PixelFormat != PixelFormat.Format24bppRgb && bmp.PixelFormat != PixelFormat.Format32bppArgb)
            throw new NotSupportedException("Only support Format24bppRgb and Format32bppArgb pixelFormat.");

        var bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);

        try
        {
            //Compress the bmp data
            return bmp.PixelFormat == PixelFormat.Format24bppRgb
                ? AvifEncoder.Encode((byte*)bmpData.Scan0, (uint)bmpData.Width, (uint)bmpData.Height, 8, (uint)bmpData.Stride, AvifRGBFormat.AVIF_RGB_FORMAT_BGR, settings)
                : AvifEncoder.Encode((byte*)bmpData.Scan0, (uint)bmpData.Width, (uint)bmpData.Height, 8, (uint)bmpData.Stride, AvifRGBFormat.AVIF_RGB_FORMAT_BGRA, settings);
        }
        finally
        {
            //Unlock the pixels
            bmp.UnlockBits(bmpData);
        }
    }
}
#endif