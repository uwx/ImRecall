using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Runtime.Versioning;
using Windows.Graphics.Capture;
using Windows.Graphics.DirectX;
using Windows.Graphics.DirectX.Direct3D11;
using Windows.Win32;
using Windows.Win32.UI.WindowsAndMessaging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using Vortice.Direct3D;
using Vortice.Direct3D11;
using Vortice.DXGI;
using WinRT;

namespace ImRecall;

[SupportedOSPlatform("windows10.0.19045")]
public sealed partial class WindowsCapture : IDisposable
{
    private readonly ID3D11Device _d3d11Device = D3D11.D3D11CreateDevice(DriverType.Hardware, DeviceCreationFlags.BgraSupport);
    private readonly IDirect3DDevice _device;

    public WindowsCapture()
    {
        _device = CreateDirect3DDeviceFromVorticeDevice(_d3d11Device)
                  ?? throw new InvalidOperationException("WindowsCapture was provided with a invalid IDirect3DDevice (null) for Windows.Graphics.Capture to capture window... :( ");
    }

    [LibraryImport("d3d11.dll", EntryPoint = "CreateDirect3D11DeviceFromDXGIDevice", SetLastError = true)]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvStdcall)])]
    // ReSharper disable once InconsistentNaming
    private static partial uint CreateDirect3D11DeviceFromDXGIDevice(IntPtr dxgiDevice, out IntPtr graphicsDevice);
    
    private static IDirect3DDevice? CreateDirect3DDeviceFromVorticeDevice(ID3D11Device d3dDevice)
    {
        if (CreateDirect3D11DeviceFromDXGIDevice(d3dDevice.NativePointer, out var ptr) != 0)
            return null;

        return MarshalInterface<IDirect3DDevice>.FromAbi(ptr);
    }
    
    // ReSharper disable once InconsistentNaming
    internal static readonly Guid ID3D11Texture2D = new("6f15aaf2-d208-4e89-9ab4-489535d34f9c");

    [GeneratedComInterface]
    [Guid("A9B3D012-3DF2-4EE3-B8D1-8695F457D3C1")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    public partial interface IDirect3DDxgiInterfaceAccess
    {
        IntPtr GetInterface(in Guid iid);
    }

    private static ID3D11Texture2D Texture2DFromSurface(IDirect3DSurface surface)
    {
        var access = ((IWinRTObject) surface).NativeObject.AsInterface<IDirect3DDxgiInterfaceAccess>();
        return new ID3D11Texture2D(access.GetInterface(in ID3D11Texture2D));
    }
    
    public async ValueTask<LibraryIndependentImage<DirectXHalfVector4>?> CaptureFullscreen(GraphicsCaptureItem captureItem)
    {
        if (!GraphicsCaptureSession.IsSupported())
        {
            throw new InvalidOperationException("WindowsCapture: GraphicsCaptureSession is not supported on this device. Perhaps update your Windows?");
        }

        var size = captureItem.Size;
        Console.WriteLine($"Capture Item Size... Width: {size.Width}, Height: {size.Height}");
        
        Direct3D11CaptureFrame result;
        using (var framePool = Direct3D11CaptureFramePool.CreateFreeThreaded(_device, DirectXPixelFormat.R16G16B16A16Float, 1, size))
        {
            var asyncFrame = new TaskCompletionSource<Direct3D11CaptureFrame>();
            framePool.FrameArrived += (sender, args) =>
            {
                Console.WriteLine("Frame arrived");
                var nextFrame = sender.TryGetNextFrame();
                if (!asyncFrame.TrySetResult(nextFrame))
                {
                    nextFrame.Dispose();
                }
            };

            using (var session = framePool.CreateCaptureSession(captureItem))
            {
                if (session == null)
                {
                    throw new InvalidOperationException($"Capture Session could not be created from {captureItem}");
                }

                session.IsBorderRequired = false;
                // session.IncludeSecondaryWindows = true;
                session.IsCursorCaptureEnabled = true;
                session.StartCapture();
                Console.WriteLine("Waiting for frame...");
                result = await asyncFrame.Task.WaitAsync(TimeSpan.FromSeconds(10));
            }
            if (result == null)
            {
                throw new InvalidOperationException($"The frame from the framePool was null for {captureItem} :(");
            }
        }

        using (result)
        {
            Console.WriteLine("Moving to Texture2D from Surface");
            using var frameTexture = Texture2DFromSurface(result.Surface);
            
            Console.WriteLine($"{frameTexture.Dimension} {size.Width} {size.Height}");
            var desc = frameTexture.Description;
            desc.BindFlags = BindFlags.None;
            desc.Usage = ResourceUsage.Staging;
            desc.CPUAccessFlags = CpuAccessFlags.Read;
            desc.MiscFlags = ResourceOptionFlags.None;
            
            Console.WriteLine("=== Desc Info ===");
            Console.WriteLine($"Width: {size.Width}, Height: {size.Height}");
            Console.WriteLine($"CPUAccessFlags: {desc.CPUAccessFlags}");
            Console.WriteLine($"MiscFlags: {desc.MiscFlags}");
            Console.WriteLine($"Usage: {desc.Usage}");
            Console.WriteLine("=== END OF DESC ===");
            
            using var staging = _d3d11Device.CreateTexture2D(desc);
            _d3d11Device.ImmediateContext.CopyResource(staging, frameTexture);

            var dataBox = _d3d11Device.ImmediateContext.Map(staging, 0);

            try
            {
                var memoryOwner = new UnmanagedMemoryOwner<byte>(size.Height * size.Width * 8);

                unsafe
                {
                    var srcSpan = new Span<byte>((byte*)dataBox.DataPointer, size.Height * size.Width * 8);
                    srcSpan.CopyTo(memoryOwner.Memory.Span);

                    return new LibraryIndependentImage<DirectXHalfVector4>(memoryOwner, size.Width, size.Height);
                }
            }
            finally
            {
                _d3d11Device.ImmediateContext.Unmap(staging, 0);
            }
        }
    }

    public void Dispose()
    {
        _d3d11Device.Dispose();
        _device.Dispose();
    }
}