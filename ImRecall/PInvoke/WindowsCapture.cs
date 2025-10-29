using System.Runtime.InteropServices;
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
public class WindowsCapture
{
    private bool IsSupportedFeatureLevel(IDXGIAdapter1 adapter, FeatureLevel featureLevel,
        DeviceCreationFlags creationFlags)
    {
        var result = D3D11.D3D11CreateDevice(
            adapter,
            DriverType.Hardware,
            creationFlags,
            [featureLevel],
            out var device,
            out var supportedFeatureLevel,
            out _);

        if (result.Success && supportedFeatureLevel == featureLevel)
        {
            device?.Dispose();
            return true;
        }

        device?.Dispose();
        return false;
    }

    public async IAsyncEnumerable<Image> CaptureFullscreen()
    {
        var factory = DXGI.CreateDXGIFactory1<IDXGIFactory1>()!;

        var adapters = EnumerateAdapters(factory);

        if (adapters.Count == 0)
        {
            yield break;
        }

        var outputs = EnumerateOutputs(adapters);

        if (outputs.Count == 0)
        {
            yield break;
        }

        var totalWidth = 0;
        var totalHeight = 0;

        foreach (var (output, x, y, width, height, _) in outputs)
        {
            totalWidth = Math.Max(totalWidth, x + width);
            totalHeight = Math.Max(totalHeight, y + height);
        }

        var captureTasks = new List<Task<Image?>>();

        foreach (var (output, x, y, width, height, adapter) in outputs)
        {
            var bounds = new Rectangle(x, y, width, height);
            var captureTask = CaptureOutputImage(output, adapter, bounds);
            captureTasks.Add(captureTask);
        }

        var capturedImages = await Task.WhenAll(captureTasks);

        foreach (var (_, x, y, _, _, _) in outputs)
        {
            var monitorImage = capturedImages.FirstOrDefault(image => image != null);
            if (monitorImage != null)
            {
                yield return monitorImage;
            }
        }

        foreach (var output in outputs)
        {
            output.Output.Dispose();
        }

        foreach (var adapter in adapters)
        {
            adapter.Dispose();
        }
    }


    public async Task<Image?> CaptureScreen(Point? pos)
    {
        var factory = DXGI.CreateDXGIFactory1<IDXGIFactory1>()!;

        var adapters = EnumerateAdapters(factory);

        if (adapters.Count == 0)
        {
            Console.WriteLine($"{nameof(WindowsCapture)}: No adapters found");
            return null;
        }

        var outputs = EnumerateOutputs(adapters);

        if (outputs.Count == 0)
        {
            Console.WriteLine($"{nameof(WindowsCapture)}: No output found");
            return null;
        }

        if (pos.HasValue)
        {
            var targetOutput = outputs.FirstOrDefault(output =>
                pos.Value.X >= output.X && pos.Value.X < output.X + output.Width &&
                pos.Value.Y >= output.Y && pos.Value.Y < output.Y + output.Height);

            if (targetOutput.Equals(default))
            {
                return null;
            }

            var output = targetOutput.Output;
            var adapter = targetOutput.Adapter;
            var bounds = new Rectangle(targetOutput.X, targetOutput.Y, targetOutput.Width, targetOutput.Height);

            return await CaptureOutputImage(output, adapter, bounds);
        }

        var defaultOutput = outputs.FirstOrDefault();
        if (defaultOutput.Equals(default))
        {
            return null;
        }

        var defaultBounds = new Rectangle(defaultOutput.X, defaultOutput.Y, defaultOutput.Width, defaultOutput.Height);
        return await CaptureOutputImage(defaultOutput.Output, defaultOutput.Adapter, defaultBounds);
    }

    [DllImport(
        "d3d11.dll",
        EntryPoint = "CreateDirect3D11DeviceFromDXGIDevice",
        SetLastError = true,
        CharSet = CharSet.Unicode,
        ExactSpelling = true,
        CallingConvention = CallingConvention.StdCall
    )]
    private static extern uint CreateDirect3D11DeviceFromDXGIDevice(IntPtr dxgiDevice, out IntPtr graphicsDevice);
    private static IDirect3DDevice? CreateDirect3DDeviceFromVorticeDevice(ID3D11Device d3dDevice)
    {
        IDirect3DDevice? device = null;

        // Acquire the DXGI interface for the Direct3D device.
        using var dxgiDevice = d3dDevice.QueryInterface<ID3D11Device3>();
        // Wrap the native device using a WinRT interop object.
        var hr = CreateDirect3D11DeviceFromDXGIDevice(dxgiDevice.NativePointer, out var pUnknown);

        if (hr != 0) return device!;
        ComWrappers cw = new DefaultComWrappers();

        device = (cw.GetOrCreateObjectForComInstance(pUnknown, CreateObjectFlags.UniqueInstance) as IDirect3DDevice)!;
        Marshal.Release(pUnknown);

        return device;
    }
    private static ID3D11Texture2D Texture2DFromSurface(IDirect3DSurface surface, ID3D11Device device)
    {
        Console.WriteLine("=== IDirect3DSurface ===");
        Console.WriteLine($"Format: {surface.Description.Format}");
        Console.WriteLine($"MultisampleDescription: {surface.Description.MultisampleDescription}");
        Console.WriteLine($"Width: {surface.Description.Width}");
        Console.WriteLine($"Height: {surface.Description.Height}");
        // Workaround to get around:
        // hez2010 — 8:32 PM
        // CsWinRT currently relies on some source generators that only applies to source code you authored,
        // so it won't work well if you referenced an external library and used the interfaces it provides,
        // because no code (mainly, vtbl) was generated for them.
        // I think you will have to wait for CsWinRT 3.0, which replaces the source generators with assembly weavers.

        var ptr = ((IWinRTObject)surface).NativeObject.GetRef();
        Console.WriteLine($"Surface PTR: {ptr:X}");
        var access = SharpGen.Runtime.ComObject.As<IDirect3DDxgiInterfaceAccess>(ptr);
        Marshal.Release(ptr);

        access.GetInterface<ID3D11Texture2D>(out var texture);

        return texture;
    }
    public async Task<Image?> CaptureWindow(Point pos)
    {
        if (!GraphicsCaptureSession.IsSupported())
        {
            throw new ExternalException("WindowsCapture: GraphicsCaptureSession is not supported on this device. Perhaps update your Windows?");
        }
        var hwnd = PInvoke.WindowFromPoint(new System.Drawing.Point(pos.X, pos.Y));
        if (hwnd == IntPtr.Zero)
        {
            Console.WriteLine("WindowsCapture was provided a invalid window handle");
            return null;
        }

        var capacity = PInvoke.GetWindowTextLength(hwnd);
        var buffer = new char[capacity + 1];
        var length = PInvoke.GetWindowText(hwnd, buffer);

        var windowTitle = new string(buffer, 0, length);
        var windowInfo = new WINDOWINFO();
        var successRect = PInvoke.GetWindowRect(hwnd, out var RECT);
        var IRect = new Rectangle(RECT.X, RECT.Y, RECT.Width, RECT.Height);
        var successWindowInfo = PInvoke.GetWindowInfo(hwnd, ref windowInfo);
        Console.WriteLine("==== Window Info ====");
        Console.WriteLine($"Title: {windowTitle}");
        Console.WriteLine($"Rect: {IRect}");
        Console.WriteLine($"dwStyle: {windowInfo.dwStyle}");
        Console.WriteLine($"dwExStyle: {windowInfo.dwExStyle}");
        Console.WriteLine($"dwWindowStatus: {windowInfo.dwWindowStatus}");
        Console.WriteLine($"cxWindowBorders: {windowInfo.cxWindowBorders}");
        Console.WriteLine($"cyWindowBorders: {windowInfo.cyWindowBorders}");
        Console.WriteLine($"atomWindowType: {windowInfo.atomWindowType}");
        Console.WriteLine($"wCreatorVersion: {windowInfo.wCreatorVersion}");
        Console.WriteLine($"Active: {windowInfo.dwWindowStatus == 0x0001}");
        Console.WriteLine("=====================");


        var captureItem = CaptureItemHelper.CreateItemForWindow(hwnd);
        if (captureItem == null)
        {
            Console.WriteLine("WindowsCapture was provided with a invalid item (null) for Windows.Graphics.Capture to capture window... :(");
            return null;
        }

        using var d3d11Device = D3D11.D3D11CreateDevice(DriverType.Hardware, DeviceCreationFlags.BgraSupport);
        using var device = CreateDirect3DDeviceFromVorticeDevice(d3d11Device);
        if (device == null)
        {
            Console.WriteLine("WindowsCapture was provided with a invalid  IDirect3DDevice (null) for Windows.Graphics.Capture to capture window... :( ");
            return null;
        }

        var size = captureItem.Size;
        Console.WriteLine($"Capture Item Size... Width: {size.Width}, Height: {size.Height}");
        using var framePool = Direct3D11CaptureFramePool.CreateFreeThreaded(device, DirectXPixelFormat.R16G16B16A16UIntNormalized,
            1,
            size);
        var asyncFrame = new TaskCompletionSource<Direct3D11CaptureFrame>();
        framePool.FrameArrived += (Sender, Args) =>
        {
            Console.WriteLine("Frame arrived");
            asyncFrame.TrySetResult(Sender.TryGetNextFrame());
        };
        using var session = framePool.CreateCaptureSession(captureItem);
        if (session == null)
        {
            Console.WriteLine($"Capture Session could not be created from {captureItem}");
            return null;
        }
        session.IsBorderRequired = false;
        // session.IncludeSecondaryWindows = true;
        session.IsCursorCaptureEnabled = true;
        session.StartCapture();
        Console.WriteLine("Waiting for frame...");
        using var result = await asyncFrame.Task.WaitAsync(TimeSpan.FromSeconds(10));
        if (result == null)
        {
            Console.WriteLine($"The frame from framePool ({framePool}) was null for {captureItem} :(");
            return null;
        }
        Console.WriteLine("Moving to Texture2DFromSurface");
        var width = size.Width;
        var height = size.Height;
        using var frameTexture = Texture2DFromSurface(result.Surface, d3d11Device);
        Console.WriteLine($"{frameTexture.Dimension} {width} {height}");
        var desc = frameTexture.Description;
        desc.BindFlags = BindFlags.None;
        desc.Usage = ResourceUsage.Staging;
        desc.CPUAccessFlags = CpuAccessFlags.Read;
        desc.MiscFlags = ResourceOptionFlags.None;
        Console.WriteLine("=== Desc Info ===");
        Console.WriteLine($"Width: {width}, Height: {height}");
        Console.WriteLine($"CPUAccessFlags: {desc.CPUAccessFlags}");
        Console.WriteLine($"MiscFlags: {desc.MiscFlags}");
        Console.WriteLine($"Usage: {desc.Usage}");
        Console.WriteLine("=== END OF DESC ===");
        using var staging = d3d11Device.CreateTexture2D(desc);
        d3d11Device.ImmediateContext.CopyResource(staging, frameTexture);

        var dataBox = d3d11Device.ImmediateContext.Map(staging, 0);

        var screenshotBytes = GetDataAsByteArray(dataBox.DataPointer, (int)dataBox.RowPitch, width,
            height);
        d3d11Device.ImmediateContext.Unmap(staging, 0);
        return Image.LoadPixelData<Rgba64>(screenshotBytes, width, height);
    }
    
    public async ValueTask<LibraryIndependentImage<DirectXHalfVector4>?> CaptureFullscreen2(GraphicsCaptureItem captureItem)
    {
        if (!GraphicsCaptureSession.IsSupported())
        {
            throw new ExternalException("WindowsCapture: GraphicsCaptureSession is not supported on this device. Perhaps update your Windows?");
        }

        using var d3d11Device = D3D11.D3D11CreateDevice(DriverType.Hardware, DeviceCreationFlags.BgraSupport);
        using var device = CreateDirect3DDeviceFromVorticeDevice(d3d11Device);
        if (device == null)
        {
            Console.WriteLine("WindowsCapture was provided with a invalid  IDirect3DDevice (null) for Windows.Graphics.Capture to capture window... :( ");
            return null;
        }

        var size = captureItem.Size;
        Console.WriteLine($"Capture Item Size... Width: {size.Width}, Height: {size.Height}");
        using var framePool = Direct3D11CaptureFramePool.CreateFreeThreaded(device, DirectXPixelFormat.R16G16B16A16Float,
            1,
            size);
        var asyncFrame = new TaskCompletionSource<Direct3D11CaptureFrame>();
        framePool.FrameArrived += (Sender, Args) =>
        {
            Console.WriteLine("Frame arrived");
            asyncFrame.TrySetResult(Sender.TryGetNextFrame());
        };
        using var session = framePool.CreateCaptureSession(captureItem);
        if (session == null)
        {
            Console.WriteLine($"Capture Session could not be created from {captureItem}");
            return null;
        }
        session.IsBorderRequired = false;
        // session.IncludeSecondaryWindows = true;
        session.IsCursorCaptureEnabled = true;
        session.StartCapture();
        Console.WriteLine("Waiting for frame...");
        using var result = await asyncFrame.Task.WaitAsync(TimeSpan.FromSeconds(10));
        if (result == null)
        {
            Console.WriteLine($"The frame from framePool ({framePool}) was null for {captureItem} :(");
            return null;
        }
        Console.WriteLine("Moving to Texture2DFromSurface");
        var width = size.Width;
        var height = size.Height;
        using var frameTexture = Texture2DFromSurface(result.Surface, d3d11Device);
        Console.WriteLine($"{frameTexture.Dimension} {width} {height}");
        var desc = frameTexture.Description;
        desc.BindFlags = BindFlags.None;
        desc.Usage = ResourceUsage.Staging;
        desc.CPUAccessFlags = CpuAccessFlags.Read;
        desc.MiscFlags = ResourceOptionFlags.None;
        Console.WriteLine("=== Desc Info ===");
        Console.WriteLine($"Width: {width}, Height: {height}");
        Console.WriteLine($"CPUAccessFlags: {desc.CPUAccessFlags}");
        Console.WriteLine($"MiscFlags: {desc.MiscFlags}");
        Console.WriteLine($"Usage: {desc.Usage}");
        Console.WriteLine("=== END OF DESC ===");
        using var staging = d3d11Device.CreateTexture2D(desc);
        d3d11Device.ImmediateContext.CopyResource(staging, frameTexture);

        var dataBox = d3d11Device.ImmediateContext.Map(staging, 0);

        // var screenshotBytes = GetDataAsByteArray(dataBox.DataPointer, (int)dataBox.RowPitch, width,
        //     height);

        var memoryOwner = new UnmanagedMemoryOwner<byte>(height * width * 8);
        
        unsafe
        {
            var srcSpan = new Span<byte>((byte*)dataBox.DataPointer, height * width * 8);
            srcSpan.CopyTo(memoryOwner.Memory.Span);
            
            d3d11Device.ImmediateContext.Unmap(staging, 0);
            
            return new LibraryIndependentImage<DirectXHalfVector4>(memoryOwner, width, height);
        }
        // return Image.LoadPixelData<DirectXHalfVector4>(screenshotBytes, width, height);
    }

    private List<IDXGIAdapter1> EnumerateAdapters(IDXGIFactory1 factory)
    {
        var adapters = new List<IDXGIAdapter1>();

        for (uint adapterIndex = 0; factory.EnumAdapters1(adapterIndex, out var adapter).Success; adapterIndex++)
        {
            var desc = adapter.Description1;

            if ((desc.Flags & AdapterFlags.Software) != AdapterFlags.None)
            {
                adapter.Dispose();
                continue;
            }

            if (IsSupportedFeatureLevel(adapter, FeatureLevel.Level_11_1, DeviceCreationFlags.BgraSupport))
            {
                Console.WriteLine(
                    $"Feature level {FeatureLevel.Level_11_1} not supported. Skipping Adapter {adapter.Description}");
                adapter.Dispose();
                continue;
            }

            adapters.Add(adapter);
        }

        return adapters;
    }

    private List<(IDXGIOutput1 Output, int X, int Y, int Width, int Height, IDXGIAdapter Adapter)> EnumerateOutputs(
        List<IDXGIAdapter1> adapters)
    {
        var outputs = new List<(IDXGIOutput1 Output, int X, int Y, int Width, int Height, IDXGIAdapter Adapter)>();

        foreach (var adapter in adapters)
        {
            for (uint outputIndex = 0; adapter.EnumOutputs(outputIndex, out var output).Success; outputIndex++)
            {
                var firstOutput = output.QueryInterface<IDXGIOutput1>();
                var bounds = firstOutput.Description.DesktopCoordinates;

                var width = bounds.Right - bounds.Left;
                var height = bounds.Bottom - bounds.Top;
                var x = bounds.Left;
                var y = bounds.Top;

                outputs.Add((firstOutput, x, y, width, height, adapter));
            }
        }

        return outputs;
    }

    private static async Task<Image?> CaptureOutputImage(IDXGIOutput1 output, IDXGIAdapter adapter, Rectangle bounds)
    {
        if (output == null) throw new ArgumentNullException(nameof(output));
        if (adapter == null) throw new ArgumentNullException(nameof(adapter));
        if (bounds.Width <= 0 || bounds.Height <= 0) throw new ArgumentException("Invalid bounds", nameof(bounds));
        var hr = D3D11.D3D11CreateDevice(adapter, DriverType.Unknown, DeviceCreationFlags.BgraSupport,
            [FeatureLevel.Level_11_1], out var d3dDevice);
        using var device = d3dDevice;
        if (hr.Failure) throw new InvalidOperationException(
            $"D3D11CreateDevice failed: {hr} ({hr.Description}) " +
            $"Module: {hr.Module}, API: {hr.ApiCode}, Native: {hr.NativeApiCode}"
        );
        if (device == null) throw new InvalidOperationException("D3D11CreateDevice failed, out device is NULL");
        output.GetParent<IDXGIAdapter>(out var outAdapter);
        using var outputAdapter = outAdapter;
        if (outputAdapter == null) throw new ArgumentNullException(nameof(outputAdapter));
        if (!outputAdapter?.NativePointer.Equals(adapter.NativePointer) ?? false)
        {
            throw new InvalidOperationException("The IDXGIAdapter used does not match the one used to create this IDXGIOutput1.");
        }
        IDXGIOutput baseOutput = output;
        var outputDesc = baseOutput.Description;
        Console.WriteLine("=== Output Description ===");
        Console.WriteLine($"Device Name           : {outputDesc.DeviceName}");
        Console.WriteLine($"Attached To Desktop   : {outputDesc.AttachedToDesktop}");
        Console.WriteLine($"Monitor Coordinates   : L:{outputDesc.DesktopCoordinates.Left}, T:{outputDesc.DesktopCoordinates.Top}, R:{outputDesc.DesktopCoordinates.Right}, B:{outputDesc.DesktopCoordinates.Bottom}");
        Console.WriteLine($"Monitor Handle (HMONITOR): 0x{outputDesc.Monitor.ToInt64():X}");
        Console.WriteLine($"Rotation              : {outputDesc.Rotation}");
        Console.WriteLine("==========================");

        var desc = adapter.Description;

        Console.WriteLine("=== Adapter Info ===");
        Console.WriteLine($"Description           : {desc.Description}");
        Console.WriteLine($"VendorId              : 0x{desc.VendorId:X} ({desc.VendorId})");
        Console.WriteLine($"DeviceId              : 0x{desc.DeviceId:X} ({desc.DeviceId})");
        Console.WriteLine($"SubsystemId           : 0x{desc.SubsystemId:X} ({desc.SubsystemId})");
        Console.WriteLine($"Revision              : {desc.Revision}");
        Console.WriteLine($"DedicatedVideoMemory  : {desc.DedicatedVideoMemory / 1024 / 1024} MB");
        Console.WriteLine($"DedicatedSystemMemory : {desc.DedicatedSystemMemory / 1024 / 1024} MB");
        Console.WriteLine($"SharedSystemMemory    : {desc.SharedSystemMemory / 1024 / 1024} MB");
        Console.WriteLine("=== Device Info ===");
        Console.WriteLine($"DebugName           : {device.DebugName ?? "N/A"}");
        Console.WriteLine(
            $"DeviceRemovedReason       : {(device.DeviceRemovedReason.Success ? $"{device.DeviceRemovedReason.Description} ({device.DeviceRemovedReason.ApiCode}, {device.DeviceRemovedReason.Module}) " : "")}"
        );
        Console.WriteLine($"CreationFlags       : {device.CreationFlags}");

        Console.WriteLine("======================");

        using var duplication = output.DuplicateOutput(device);

        var textureDesc = new Texture2DDescription
        {
            CPUAccessFlags = CpuAccessFlags.Read,
            BindFlags = BindFlags.None,
            Format = Format.R16G16B16A16_UNorm,
            Width = (uint)bounds.Width,
            Height = (uint)bounds.Height,
            MiscFlags = ResourceOptionFlags.None,
            MipLevels = 1,
            ArraySize = 1,
            SampleDescription = { Count = 1, Quality = 0 },
            Usage = ResourceUsage.Staging
        };
        using var currentFrame = device.CreateTexture2D(textureDesc);

        await Task.Delay(150);

        duplication.AcquireNextFrame(500, out var frameInfo, out var dskTopResource).CheckError();
        using var desktopResource = dskTopResource;
        using var tempTexture = desktopResource.QueryInterface<ID3D11Texture2D>();

        device.ImmediateContext.CopyResource(currentFrame, tempTexture);
        var dataBox = device.ImmediateContext.Map(currentFrame, 0);
        var screenshotBytes = GetDataAsByteArray(dataBox.DataPointer, (int)dataBox.RowPitch, bounds.Width, bounds.Height);
        duplication.ReleaseFrame().CheckError();
        device.ImmediateContext.Unmap(currentFrame, 0);
        return Image.LoadPixelData<Rgba64>(screenshotBytes, bounds.Width, bounds.Height);
    }

    private static byte[] GetDataAsByteArray(IntPtr dataPointer, int rowPitch, int width, int height)
    {
        // Create a byte[] array to hold the pixel data
        var pixelData = new byte[height * rowPitch];

        // Copy the data from unmanaged memory to the byte array
        for (var y = 0; y < height; y++)
        {
            // Pointer arithmetic to calculate the address of each row
            var rowPointer = IntPtr.Add(dataPointer, y * rowPitch);

            // Copy the row from unmanaged memory to the byte array
            Marshal.Copy(rowPointer, pixelData, y * width * 8, width * 8); // Assuming 4 bytes per pixel (RGBA)
        }

        // for (var i = 0; i < pixelData.Length; i += 4)
        // {
        //     // Deconstruct the RGBA values and swap the red and blue channels
        //     (pixelData[i + 2], pixelData[i]) =
        //         (pixelData[i], pixelData[i + 2]); // Swap Blue (index 0) and Red (index 2)
        // }

        return pixelData;
    }
}