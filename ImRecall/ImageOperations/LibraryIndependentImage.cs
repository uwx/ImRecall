using System.Buffers;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using SixLabors.ImageSharp.PixelFormats;

namespace ImRecall;

public readonly record struct LibraryIndependentImage<T>(IMemoryOwner<byte> MemoryOwner, int Width, int Height) : IDisposable where T : unmanaged, IPixel<T>
{
    public void Dispose()
    {
        MemoryOwner.Dispose();
    }

    public Rectangle Bounds => new(0, 0, Width, Height);

    public Span<T> PixelBuffer => MemoryMarshal.Cast<byte, T>(MemoryOwner.Memory.Span);

    public Span<T> DangerousGetRowSpan(int y)
    {
        return PixelBuffer.Slice(y * Width, Width);
    }
    
    public static LibraryIndependentImage<T> FromBitmap(Bitmap bmp)
    {
        var memoryOwner = new BitmapMemoryOwner(bmp);
        return new LibraryIndependentImage<T>(memoryOwner, bmp.Width, bmp.Height);
    }

    public static unsafe LibraryIndependentImage<T> Alloc(int width, int height)
    {
        return new LibraryIndependentImage<T>(new UnmanagedMemoryOwner<byte>(width * height * sizeof(T)), width, height);
    }
}

file unsafe class BitmapMemoryOwner(Bitmap bmp) : MemoryManager<byte>
{
    private readonly BitmapData _data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
    private readonly int _depth = Image.GetPixelFormatSize(bmp.PixelFormat) / 8;

    protected override void Dispose(bool disposing)
    {
        bmp.UnlockBits(_data);
    }

    public override Span<byte> GetSpan()
    {
        return new Span<byte>((byte*)_data.Scan0.ToPointer(), _data.Width * _data.Height * _depth);
    }

    public override MemoryHandle Pin(int elementIndex = 0)
    {
        return new MemoryHandle((byte*)_data.Scan0.ToPointer() + elementIndex);
    }

    public override void Unpin()
    {
    }
}