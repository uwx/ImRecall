using System.Buffers;
using System.Runtime.InteropServices;

namespace ImRecall;

public class UnmanagedMemoryOwner<T>(int size) : MemoryManager<T> where T : unmanaged
{
    private unsafe IntPtr _handle = Marshal.AllocHGlobal(size * sizeof(T));
    
    protected override void Dispose(bool disposing)
    {
        if (_handle != IntPtr.Zero)
        {
            Marshal.FreeHGlobal(_handle);
            _handle = 0;
        }
    }

    public override unsafe Span<T> GetSpan()
    {
        return new Span<T>((T*)_handle, size);
    }

    public override unsafe MemoryHandle Pin(int elementIndex = 0)
    {
        return new MemoryHandle((T*)_handle + size);
    }

    public override void Unpin()
    {
    }
}