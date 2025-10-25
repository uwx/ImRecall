using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BetterWin32Errors;
using SharpGen.Runtime;
using Veldrid;
using Vortice.Direct3D;
using Vortice.Direct3D11;
using Vortice.DXGI;
using Vortice.DXGI.Debug;
using Vortice.Mathematics;

namespace ShareXBitmapUtils;

public class ScreenshotHelpers
{
    public HdrSettings HdrSettings { get; set; } = new HdrSettings();
    
    private static ModernCapture _captureInstance;
    private static Lock _captureInstanceLock = new Lock();

    public Bitmap CaptureAllMonitors(bool captureCursor = false)
    {
        SharpGen.Runtime.Configuration.EnableObjectTracking = true;
        SharpGen.Runtime.Configuration.EnableReleaseOnFinalizer = true;
        
        var captureMonRegions = new List<ModernCaptureMonitorDescription>();
        Bitmap bmp;

        // 1. Get regions and the HDR metadata information

        var globalRect = new Rectangle();
        var mons = MonitorEnumerationHelper.GetMonitors();
        foreach (var monitor in mons)
        {
            Console.WriteLine($"Monitor: {monitor.MonitorArea}, IsPrimary: {monitor.IsPrimary}, DN: {monitor.DeviceName}");
            globalRect = Rectangle.Union(globalRect, monitor.MonitorArea);
        }
        
        foreach (var monitor in mons)
        {
            captureMonRegions.Add(new ModernCaptureMonitorDescription
            {
                DestGdiRect = monitor.MonitorArea,
                MonitorInfo = monitor,
                CaptureCursor = captureCursor,
            });
        }

        // 2. Compose a list of rects for capture
        var catpureItem = new ModernCaptureItemDescription(globalRect, captureMonRegions);

        // 3. Request capture and wait for bitmap
        // 3.1 Determine rects and transform them to DirectX coordinate system
        // 3.2 Capture and wait for content
        // 3.3 Shader and draw passes
        // 3.4 Datastream pass, copy
        lock (_captureInstanceLock)
        {
            if (_captureInstance == null) _captureInstance = new ModernCapture(HdrSettings);
            bmp = _captureInstance.CaptureAndProcess(HdrSettings, catpureItem);
        }

        return bmp;
    }
    
    public Bitmap CaptureRectangleDirect3D11(Rectangle rect, bool captureCursor = false)
    {
        SharpGen.Runtime.Configuration.EnableObjectTracking = true;
        SharpGen.Runtime.Configuration.EnableReleaseOnFinalizer = true;
        
        var captureMonRegions = new List<ModernCaptureMonitorDescription>();
        Bitmap bmp;

        if (rect.Width == 0 || rect.Height == 0)
        {
            return null;
        }

        // 1. Get regions and the HDR metadata information
        foreach (var monitor in MonitorEnumerationHelper.GetMonitors())
        {
            if (monitor.MonitorArea.IntersectsWith(rect))
            {
                var screenBoundCopy = monitor.MonitorArea.Copy();
                screenBoundCopy.Intersect(rect);
                captureMonRegions.Add(new ModernCaptureMonitorDescription
                {
                    DestGdiRect = screenBoundCopy,
                    MonitorInfo = monitor,
                    CaptureCursor = captureCursor,
                });
            }
        }

        // 2. Compose a list of rects for capture
        var catpureItem = new ModernCaptureItemDescription(rect, captureMonRegions);

        // 3. Request capture and wait for bitmap
        // 3.1 Determine rects and transform them to DirectX coordinate system
        // 3.2 Capture and wait for content
        // 3.3 Shader and draw passes
        // 3.4 Datastream pass, copy
        lock (_captureInstanceLock)
        {
            if (_captureInstance == null) _captureInstance = new ModernCapture(HdrSettings);
            bmp = _captureInstance.CaptureAndProcess(HdrSettings, catpureItem);
        }

        return bmp;
    }
}

public class BitmapUtils
{
    public static Bitmap BuildBitmapFromMappedPointer(
        IntPtr dataPtr,
        int rowPitch,
        int width,
        int height)
    {
        var bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

        // Lock the entire bitmap's bits
        var rect = new Rectangle(0, 0, width, height);
        var bmpData = bmp.LockBits(rect, ImageLockMode.WriteOnly, bmp.PixelFormat);

        unsafe
        {
            byte* srcRow = (byte*)dataPtr;
            byte* dstRow = (byte*)bmpData.Scan0.ToPointer();

            for (int y = 0; y < height; y++)
            {
                // Copy exactly width * 4 bytes from srcRow to dstRow
                Buffer.MemoryCopy(
                    srcRow + y * rowPitch,
                    dstRow + y * bmpData.Stride,
                    bmpData.Stride,
                    width * 4
                );
            }
        }

        bmp.UnlockBits(bmpData);
        return bmp;
    }

    public static Bitmap BuildBitmapFromByteArray(
        byte[] pixelBytes, // length = (width*4) * height
        int width,
        int height)
    {
        var bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
        var rect = new Rectangle(0, 0, width, height);
        var bmpData = bmp.LockBits(rect, ImageLockMode.WriteOnly, bmp.PixelFormat);

        int rowPitchDst = bmpData.Stride; // usually >= width*4
        int rowPitchSrc = width * 4; // exactly width * 4

        unsafe
        {
            byte* dstBase = (byte*)bmpData.Scan0.ToPointer();
            fixed (byte* srcBase = pixelBytes)
            {
                for (int y = 0; y < height; y++)
                {
                    // IntPtr srcRowPtr = new IntPtr(srcBase + y * rowPitchSrc);
                    // IntPtr dstRowPtr = new IntPtr(dstBase + y * rowPitchDst);

                    // Marshal.Copy(
                    //     srcRowPtr,
                    //     new byte[rowPitchSrc],
                    //     0,
                    //     rowPitchSrc
                    // );
                    // Or use a single Buffer.MemoryCopy if you want to stay in unsafe:
                    Buffer.MemoryCopy(
                        srcBase + y * rowPitchSrc,
                        dstBase + y * rowPitchDst,
                        rowPitchDst,
                        rowPitchSrc
                    );
                    //
                    // But Marshal.Copy is simpler here (no pin/unpin issues).
                }
            }
        }

        bmp.UnlockBits(bmpData);
        return bmp;
    }
}



public class ColorspaceUtils
{
    static readonly Matrix4x4 Rec709toICtCpConvMat = new Matrix4x4
    (
        0.5000f, 1.6137f, 4.3780f, 0.0f,
        0.5000f, -3.3234f, -4.2455f, 0.0f,
        0.0000f, 1.7097f, -0.1325f, 0.0f,
        0.0f, 0.0f, 0.0f, 1.0f
    );




    private static readonly Matrix4x4 ICtCpToRec709ConvMat = new(
        1.0f, 1.0f, 1.0f, 0.0f,
        0.0086051457f, -0.0086051457f, 0.5600488596f, 0.0f,
        0.1110356045f, -0.1110356045f, -0.3206374702f, 0.0f,
        0.0f, 0.0f, 0.0f, 1.0f);




    public static readonly Matrix4x4 from709ToXYZ = new
    (
        0.4123907983303070068359375f, 0.2126390039920806884765625f, 0.0193308182060718536376953125f, 0.0f,
        0.3575843274593353271484375f, 0.715168654918670654296875f, 0.119194783270359039306640625f, 0.0f,
        0.18048079311847686767578125f, 0.072192318737506866455078125f, 0.950532138347625732421875f, 0.0f,
        0.0f, 0.0f, 0.0f, 1.0f
    );


    static readonly Matrix4x4 fromXYZtoLMS = new
    (
        0.3592f, -0.1922f, 0.0070f, 0.0f,
        0.6976f, 1.1004f, 0.0749f, 0.0f,
        -0.0358f, 0.0755f, 0.8434f, 0.0f,
        0.0f, 0.0f, 0.0f, 1.0f
    );


    static readonly Matrix4x4 fromLMStoXYZ = new
    (
        2.070180056695613509600f, 0.364988250032657479740f, -0.049595542238932107896f, 0.0f,
        -1.326456876103021025500f, 0.680467362852235141020f, -0.049421161186757487412f, 0.0f,
        0.206616006847855170810f, -0.045421753075853231409f, 1.187995941732803439400f, 0.0f,
        0.0f, 0.0f, 0.0f, 1.0f
    );


    static readonly Matrix4x4 fromXYZto709 = new
    (3.2409698963165283203125f, -0.96924364566802978515625f, 0.055630080401897430419921875f, 0.0f,
        -1.53738319873809814453125f, 1.875967502593994140625f, -0.2039769589900970458984375f, 0.0f,
        -0.4986107647418975830078125f, 0.0415550582110881805419921875f, 1.05697154998779296875f, 0.0f,
        0.0f, 0.0f, 0.0f, 1.0f
    );


    static readonly Vector4 PQ_N = new(2610.0f / 4096.0f / 4.0f);
    static readonly Vector4 PQ_M = new(2523.0f / 4096.0f * 128.0f);
    static readonly Vector4 PQ_C1 = new(3424.0f / 4096.0f);
    static readonly Vector4 PQ_C2 = new(2413.0f / 4096.0f * 32.0f);
    static readonly Vector4 PQ_C3 = new(2392.0f / 4096.0f * 32.0f);
    static readonly Vector4 PQ_MaxPQ = new(125.0f);
    static readonly Vector4 RcpM = new(2610.0f / 4096.0f / 4.0f);
    static readonly Vector4 RcpN = new(2523.0f / 4096.0f * 128.0f);




    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector4 Rec709toICtCp(Vector4 N)
    {
        Vector4 ret = N;


        ret = Vector4.Transform(ret.AsVector3(), from709ToXYZ);
        ret = Vector4.Transform(ret.AsVector3(), fromXYZtoLMS);


        ret = LinearToPQ(Vector4.Max(ret, Vector4.Zero), PQ_MaxPQ);




        return Vector4.Transform(ret, Rec709toICtCpConvMat);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector4 PQToLinear(Vector4 pq, Vector4 maxPQ)
    {
        // ret = (max(pq, 0))^(1/m)


        var ret = VectorPow(Vector4.Max(pq, Vector4.Zero), RcpM);


        // nd  = max(ret - C1, 0) / (C2 - C3·ret)
        var numerator = Vector4.Max(ret - PQ_C1, Vector4.Zero);
        var denominator = PQ_C2 - PQ_C3 * ret;
        var nd = numerator / denominator;


        // ret = nd^(1/n) · maxPQ
        ret = VectorPow(nd, RcpN) * maxPQ;
        return ret;
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector4 ICtCpToRec709(Vector4 ictcp)
    {
        var v = Vector4.Transform(ictcp.AsVector3(), ICtCpToRec709ConvMat);


        v = PQToLinear(v, PQ_MaxPQ);


        v = Vector4.Transform(v.AsVector3(), fromLMStoXYZ);
        return Vector4.Transform(v.AsVector3(), fromXYZto709);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static Vector4 LinearToPQ(Vector4 N, Vector4 maxPQValue)
    {
        Vector4 ret = VectorPow(Vector4.Max(N, Vector4.Zero) / maxPQValue, PQ_N);
        Vector4 nd = (PQ_C1 + (PQ_C2 * ret)) / (Vector4.One + (PQ_C3 * ret));


        return VectorPow(nd, PQ_M);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float LinearToPQY(float N) // 1.5
    {
        float fScaledN = Math.Abs(N * 0.008f); // 0.008 = 1/125.0


        float ret = MathF.Pow(fScaledN, 0.1593017578125f);


        float nd = Math.Abs((0.8359375f + (18.8515625f * ret)) /
                            (1.0f + (18.6875f * ret)));


        return MathF.Pow(nd, 78.84375f);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float HdrTonemap(float maxYInPQ, float Y_out, float Y_in)
    {
        float a = (Y_out / MathF.Pow(maxYInPQ, 2.0f));
        float b = (1.0f / Y_out);
        Y_out = (Y_in * (1 + a * Y_in)) / (1 + b * Y_in);
        return Y_out;
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector4 VectorPow(Vector4 v, Vector4 p)
    {
        return new Vector4(
            (float)MathF.Pow(v.X, p.X),
            (float)MathF.Pow(v.Y, p.Y),
            (float)MathF.Pow(v.Z, p.Z),
            (float)MathF.Pow(v.W, p.W)
        );
    }
}


// TODO: temp solution until i can get correct cross GPU capture, but need a setup to test it
public class CursorFilter
{
    [DllImport("user32.dll")]
    static extern bool GetCursorPos(out POINT lpPoint);

    [DllImport("user32.dll")]
    static extern IntPtr MonitorFromPoint(POINT pt, uint dwFlags);

    const uint MONITOR_DEFAULTTONEAREST = 0x00000002;

    [StructLayout(LayoutKind.Sequential)]
    struct POINT
    {
        public int X;
        public int Y;
    }

    internal static List<ModernCaptureMonitorDescription> FilterByCursorGpu(
        DeviceCache cache,
        IDXGIFactory1 factory,
        IEnumerable<ModernCaptureMonitorDescription> monitors)
    {
        IntPtr cursorHmon = IntPtr.Zero;
        if (GetCursorPos(out POINT pt))
        {
            cursorHmon = MonitorFromPoint(pt, MONITOR_DEFAULTTONEAREST);
        }
        if (cursorHmon == IntPtr.Zero)
        {
            // lets just assume its the first one...
            cursorHmon = monitors.First().MonitorInfo.Hmon;
        }


        var cursorAccess = cache.GetOutputForScreen(factory, cursorHmon, false);
        var cursorDeviceId = cursorAccess.Adapter.Description.DeviceId;

        var filtered = new List<ModernCaptureMonitorDescription>();
        foreach (var desc in monitors)
        {
            var access = cache.GetOutputForScreen(factory, desc.MonitorInfo.Hmon, false);
            if (access.Adapter.Description.DeviceId == cursorDeviceId)
                filtered.Add(desc);
        }
        return filtered;
    }
}


class DeviceCache : IDisposable, DisposableCache
{
    private Action<DeviceAccess> deviceInit;
    private Dictionary<long, CachedOutput> adapters = new();
    private Dictionary<uint, DeviceAccess> devices = new();

    public DeviceCache(Action<DeviceAccess> deviceInit)
    {
        this.deviceInit = deviceInit;
    }

    // TODO: validate how to handle multi gpu setups with screens connected to more than 1 gpu
    public DeviceAccess GetMainDevice(IDXGIFactory1 factory)
    {
        if (devices.Values.Count == 0)
        {
            Init(factory);
            if (devices.Values.Count == 0) throw new InvalidOperationException("No devices available for screen capture?");
        }

        return devices.Values.FirstOrDefault();
    }


    // private ID3D11Device tempForcedDeviceCache;

    public ScreenDeviceAccess GetOutputForScreen(IDXGIFactory1 factory, IntPtr hMon, bool initDevice  = true) // TODO: separate function for dontInit/
    {
        var output = GetOrCreateOutput(factory, hMon);
        devices.TryGetValue(output.Adapter.Description.DeviceId, out DeviceAccess deviceAccess);
        if (initDevice && (deviceAccess == null || deviceAccess.Device.DeviceRemovedReason.Failure))
        {
            if (deviceAccess?.Device != null)
            {
                deviceAccess.Dispose();
                devices.Remove(output.Adapter.Description.DeviceId);
                return GetOutputForScreen(factory, hMon);
            }

            // if (tempForcedDeviceCache == null)
            // {
                D3D11.D3D11CreateDevice(
                    output.Adapter,
                    DriverType.Unknown,
                    DeviceCreationFlags.BgraSupport | DeviceCreationFlags.Debug | DeviceCreationFlags.Debuggable,
                    null,
                    out var newDevice).CheckError();
                if (newDevice == null) throw new ApplicationException("Could not create device for screen capture.");
                deviceAccess = new DeviceAccess(newDevice);
            // }
            // else
            // {
            //     deviceAccess = new DeviceAccess(tempForcedDeviceCache);
            // }

            deviceInit(deviceAccess);
            devices[output.Adapter.Description.DeviceId] = deviceAccess;
        }

        if (initDevice && (deviceAccess == null || deviceAccess.Device == null)) throw new ApplicationException("Could not create device for screen capture.");

        return new ScreenDeviceAccess
        {
            Adapter = output.Adapter,
            Device = deviceAccess?.Device,
            Context = deviceAccess,
            Output = output.Output,
        };
    }

    public void Init(IDXGIFactory1 factory)
    {
        foreach (var monitorInfo in MonitorEnumerationHelper.GetMonitors())
        {
            GetOutputForScreen(factory, monitorInfo.Hmon);
        }
    }

    private CachedOutput GetOrCreateOutput(IDXGIFactory1 factory, IntPtr hMon)
    {
        adapters.TryGetValue(hMon.ToInt64(), out CachedOutput cachedOutput);
        if (cachedOutput is not null)
        {
            return cachedOutput;
        }

        for (uint ai = 0; factory.EnumAdapters1(ai, out IDXGIAdapter1 adapter).Success; ++ai)
        {
            for (uint oi = 0; adapter.EnumOutputs(oi, out IDXGIOutput output).Success; ++oi)
            {
                var desc = output.Description;
                if (desc.Monitor == hMon)
                {
                    cachedOutput = new CachedOutput(adapter, output.QueryInterface<IDXGIOutput1>());
                    break;
                }

                output.Dispose();
            }

            if (cachedOutput is not null) break;
            adapter.Dispose();
        }

        if (cachedOutput is null)
            throw new InvalidOperationException("Monitor not found");

        adapters[hMon.ToInt64()] = cachedOutput;
        return cachedOutput;
    }

    private class CachedOutput(IDXGIAdapter1 adapter, IDXGIOutput1 output) : IDisposable
    {
        internal IDXGIAdapter1 Adapter { get; } = adapter;
        internal IDXGIOutput1 Output { get; } = output;

        public void Dispose()
        {
            Adapter?.Dispose();
            Output?.Dispose();
        }
    }

    public void Dispose()
    {
        foreach (var deviceAccess in devices.Values)
        {
            deviceAccess.Dispose();
        }

        devices.Clear();
        foreach (var adaptersValue in adapters.Values)
        {
            adaptersValue.Dispose();
        }

        adapters.Clear();
    }

    public void ReleaseCachedValues(HdrSettings settings)
    {
        if (!settings.SaveDevices)
        {
            Dispose();
        }
    }
}

public struct ScreenDeviceAccess
{
    public IDXGIAdapter1 Adapter;
    public IDXGIOutput1 Output;
    public ID3D11Device Device;
    public DeviceAccess Context;
}

public class DeviceAccess : IDisposable
{
    public ID3D11PixelShader pxShader;
    public ID3D11VertexShader vxShader;
    public ID3D11InputLayout inputLayout;
    public ID3D11SamplerState samplerState;

    public DeviceAccess(ID3D11Device device)
    {
        Device = device;
    }

    public ID3D11Device Device { get; }


    public void Dispose()
    {
        samplerState?.Dispose();
        inputLayout?.Dispose();
        pxShader?.Dispose();
        vxShader?.Dispose();
        Device?.Dispose();
    }
}



public static class Direct3DUtils
{
    public static ID3D11Texture2D CreateCanvasTexture(uint width, uint height, ID3D11Device device)
    {
        var desc = new Texture2DDescription
        {
            Width = width,
            Height = height,
            MipLevels = 1,
            ArraySize = 1,
            Format = Format.B8G8R8A8_UNorm,
            SampleDescription = new SampleDescription(1, 0),
            Usage = ResourceUsage.Default,
            BindFlags = BindFlags.RenderTarget,
            CPUAccessFlags = CpuAccessFlags.None,
            MiscFlags = ResourceOptionFlags.None
        };


        return device.CreateTexture2D(desc);
    }




    /// After you finish copying all regions into this “canvas,” you can do:
    ///    var staging = CreateStagingFor(canvasTex);
    ///    ctx.CopyResource(staging, canvasTex);
    ///    Map+Encode…
    public static ID3D11Texture2D CreateStagingFor(ID3D11Texture2D gpuTex)
    {
        var desc = gpuTex.Description;
        var stagingDesc = new Texture2DDescription
        {
            Width = desc.Width,
            Height = desc.Height,
            MipLevels = 1,
            ArraySize = 1,
            Format = desc.Format,
            SampleDescription = new SampleDescription(1, 0),
            Usage = ResourceUsage.Staging,
            BindFlags = BindFlags.None,
            CPUAccessFlags = CpuAccessFlags.Read,
            MiscFlags = ResourceOptionFlags.None
        };
        return gpuTex.Device.CreateTexture2D(stagingDesc);
    }


    public static Vector4[] GetPixelSpan(this ID3D11Texture2D frame)
    {
        var device = frame.Device;


        // If the texture is not already CPU-readable, create a staging copy.
        var desc = frame.Description;


        bool isF32 = desc.Format == Format.R32G32B32A32_Float;
        bool isF16 = desc.Format == Format.R16G16B16A16_Float;


        if (!isF32 && !isF16)
            throw new InvalidOperationException(
                $"Format {desc.Format} not handled. Only R32G32B32A32_FLOAT & R16G16B16A16_FLOAT are supported.");


        ID3D11Texture2D stagingTex = frame;
        if ((desc.CPUAccessFlags & CpuAccessFlags.Read) == 0 ||
            desc.Usage != ResourceUsage.Staging)
        {
            var stagingDesc = desc;
            stagingDesc.Usage = ResourceUsage.Staging;
            stagingDesc.BindFlags = BindFlags.None;
            stagingDesc.CPUAccessFlags = CpuAccessFlags.Read;
            stagingDesc.MiscFlags = ResourceOptionFlags.None;


            stagingTex = device.CreateTexture2D(stagingDesc);
            device.ImmediateContext.CopyResource(stagingTex, frame);
        }


        // Map, copy row-by-row into managed storage, then unmap.
        var ctx = device.ImmediateContext;
        var mapped = ctx.Map(stagingTex, 0);


        int width = (int)desc.Width;
        int height = (int)desc.Height;
        int totalPixels = width * height;


        var backingStore = new Vector4[totalPixels]; // managed backing array


        unsafe
        {
            byte* srcRow = (byte*)mapped.DataPointer;


            fixed (Vector4* dstBase = backingStore)
            {
                Vector4* dstRow = dstBase;


                if (isF32)
                {
                    int bytesPerRow = width * sizeof(float) * 4; // 16 bytes per pixel
                    for (int y = 0; y < height; y++)
                    {
                        Buffer.MemoryCopy(srcRow, dstRow, bytesPerRow, bytesPerRow);
                        srcRow += mapped.RowPitch;
                        dstRow += width;
                    }
                }
                else // isF16
                {
                    for (int y = 0; y < height; y++)
                    {
                        ushort* halfPtr = (ushort*)srcRow;


                        for (int x = 0; x < width; x++)
                        {
                            int i = y * width + x;
                            backingStore[i] = new Vector4(
                                HalfToSingle(halfPtr[0]),
                                HalfToSingle(halfPtr[1]),
                                HalfToSingle(halfPtr[2]),
                                HalfToSingle(halfPtr[3]));


                            halfPtr += 4;
                        }


                        srcRow += mapped.RowPitch;
                    }
                }
            }
        }


        ctx.Unmap(stagingTex, 0);


        if (!ReferenceEquals(stagingTex, frame))
            stagingTex.Dispose(); // Only dispose the temp copy


        return backingStore;
    }


    public static PixelReader GetPixelReader(this ID3D11Texture2D frame, HdrSettings settings)
    {
        PixelReader reader = new PixelReader { frame = frame, };
        reader.Start(settings);
        return reader;
    }


    public unsafe class PixelReader : IDisposable
    {
        public ID3D11Texture2D frame;
        public ID3D11Texture2D stagingTex;
        private float* floats;
        private ushort* halfs;
        private bool isF32;


        private uint size;
        // private uint cacheIndex = uint.MaxValue;
        // private Vector4[] cachedLine;
        // private uint lastRead = 0;


        private Vector4[] pixels;
        private bool isInMemory;


        public void Start(HdrSettings settings)
        {
            var device = frame.Device;
            var width = frame.Description.Width;
            var height = frame.Description.Height;
            size = width * height;


            // If the texture is not already CPU-readable, create a staging copy.
            var desc = frame.Description;


            isF32 = desc.Format == Format.R32G32B32A32_Float;
            bool isF16 = desc.Format == Format.R16G16B16A16_Float;


            if (!isF32 && !isF16)
                throw new InvalidOperationException(
                    $"Format {desc.Format} not handled. Only R32G32B32A32_FLOAT & R16G16B16A16_FLOAT are supported.");


            stagingTex = frame;
            if ((desc.CPUAccessFlags & CpuAccessFlags.Read) == 0 ||
                desc.Usage != ResourceUsage.Staging)
            {
                throw new Exception("Expected readable texture here.");
            }


            var ctx = device.ImmediateContext;
            var mapped = ctx.Map(stagingTex, 0);
            var basePtr = (byte*)mapped.DataPointer;
            if (isF32) floats = (float*)basePtr;
            else halfs = (ushort*)basePtr;
            // cachedLine = new Vector4[frame.Description.Width];
            // InitCache();


            if (!settings.AvoidBuffering)
            {
                var backingStore = new Vector4[size];


                byte* srcRow = (byte*)mapped.DataPointer;
                fixed (Vector4* dstBase = backingStore)
                {
                    Vector4* dstRow = dstBase;


                    if (isF32)
                    {
                        uint bytesPerRow = width * sizeof(float) * 4; // 16 bytes per pixel
                        for (uint y = 0; y < height; y++)
                        {
                            Buffer.MemoryCopy(srcRow, dstRow, bytesPerRow, bytesPerRow);
                            srcRow += mapped.RowPitch;
                            dstRow += width;
                        }
                    }
                    else // isF16
                    {
                        for (uint y = 0; y < height; y++)
                        {
                            ushort* halfPtr = (ushort*)srcRow;


                            for (uint x = 0; x < width; x++)
                            {
                                uint i = y * width + x;
                                backingStore[i] = new Vector4(
                                    HalfToSingle(halfPtr[0]),
                                    HalfToSingle(halfPtr[1]),
                                    HalfToSingle(halfPtr[2]),
                                    HalfToSingle(halfPtr[3]));


                                halfPtr += 4;
                            }


                            srcRow += mapped.RowPitch;
                        }
                    }
                }


                pixels = backingStore;
                isInMemory = true;
            }
        }


        public uint Pixels => size;


        // [MethodImpl(MethodImplOptions.NoInlining)]
        // private void InitCache()
        // {
        //     cacheIndex = 0;
        //     if (isF32)
        //     {
        //         for (uint i = 0; i < cachedLine.Length; i++)
        //         {
        //             cachedLine[i] = GetPixelF32Raw(lastRead + i);
        //         }
        //     }
        //     else
        //     {
        //         for (uint i = 0; i < cachedLine.Length; i++)
        //         {
        //             cachedLine[i] = GetPixelF16Raw(lastRead + i);
        //         }
        //     }
        // }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4 GetPixel(uint index)
        {
            if (isInMemory) return pixels[index];
            if (isF32) return GetPixelF32Raw(index);
            return GetPixelF16Raw(index);
            // lastRead = index;
            // var vector4 = cachedLine[cacheIndex++];
            // if (cacheIndex >= cachedLine.Length)
            // {
            //     InitCache();
            // }
            //
            // return vector4;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Vector4 GetPixelF32Raw(uint index)
        {
            var f = floats;
            var baseIndex = index * 4;
            return new Vector4(f[baseIndex], f[baseIndex + 1], f[baseIndex + 2], f[baseIndex + 3]);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Vector4 GetPixelF16Raw(uint index)
        {
            var halfs1 = halfs;
            var baseIndex = index * 4;
            return new Vector4(
                HalfToSingle(halfs1[baseIndex]),
                HalfToSingle(halfs1[baseIndex + 1]),
                HalfToSingle(halfs1[baseIndex + 2]),
                HalfToSingle(halfs1[baseIndex + 3]));
        }


        public void Dispose()
        {
            if (stagingTex != null)
            {
                var ctx = stagingTex.Device.ImmediateContext;
                ctx.Unmap(stagingTex, 0);
            }


            if (!ReferenceEquals(stagingTex, frame))
            {
                stagingTex?.Dispose();
            }
        }
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static float HalfToSingle(ushort bits)
        => (float)BitConverter.UInt16BitsToHalf(bits);
}


public interface DisposableCache
{
    public void ReleaseCachedValues(HdrSettings settings);
}



public static class ShaderConstantHelper // naming is hard
{
    public static void GetShaderConstants(MonitorInfo monitorInfo, HdrSettings settings, ImageInfo imageInfo, out VertexShaderConstants vertexShader,
        out PixelShaderConstants pixelShader)
    {
        // white level, isHDR, is10bpc, is16bpc
        vertexShader = new VertexShaderConstants
        {
            LuminanceScale = new Vector4(1.0f, 0.0f, 0.0f, 0.0f)
        };


        bool isHdr = false;
        uint bitsPerColor = 8;
        uint sdrWhiteLevel = 80;
        float maxFullFrameLuminance = 600;
        float maxLuminance = 600;
        float minLuminance = 0.0f;
        float maxContentLuminance = settings.Use99ThPercentileMaxCll ? imageInfo.P99Nits : imageInfo.MaxNits;


        pixelShader = new PixelShaderConstants()
        {
            DisplayMaxLuminance = maxLuminance / 80,
            HdrMaxLuminance = maxContentLuminance / 80,
            UserBrightnessScale = settings.BrightnessScale / 100,
            TonemapType = (uint)HdrToneMapType.MapCllToDisplay,
            // MaxYInPQ = imageInfo.MaxYInPQ,
        };


        monitorInfo.QueryMonitorData((colorInfoNullable, sdrInfoNullable, output6) =>
        {
            if (colorInfoNullable.HasValue)
            {
                var colorInfo = colorInfoNullable.Value;
                isHdr = (colorInfo.AdvancedColorStatus & AdvancedColorStatus.AdvancedColorEnabled) == AdvancedColorStatus.AdvancedColorEnabled;
                bitsPerColor = colorInfo.BitsPerColorChannel;
            }


            if (sdrInfoNullable.HasValue)
            {
                var sdrInfo = sdrInfoNullable.Value;
                sdrWhiteLevel = sdrInfo.SDRWhiteLevel;
            }


            if (output6 != null)
            {
                bitsPerColor = output6.Description1.BitsPerColor;
                maxFullFrameLuminance = output6.Description1.MaxFullFrameLuminance;
                maxLuminance = output6.Description1.MaxLuminance;
                minLuminance = output6.Description1.MinLuminance;
            }
        });


        if (isHdr)
        {
            vertexShader.LuminanceScale.Y = 1.0f; // is hdr


            // scRGB HDR 16 bpc
            if (settings.HdrMode == HdrMode.Hdr16Bpc)
            {
                vertexShader.LuminanceScale.X = settings.HdrBrightnessNits / 80.0f;
                vertexShader.LuminanceScale.W = 1.0f;
            }


            // HDR10
            else
            {
                vertexShader.LuminanceScale.X = -settings.HdrBrightnessNits;
                vertexShader.LuminanceScale.Z = 1.0f;
            }
        }


        // TODO
        // scRGB 16 bpc special handling
        else // if (SKIF_ImplDX11_ViewPort_GetDXGIFormat (vp) == DXGI_FORMAT_R16G16B16A16_FLOAT)
        {
            // SDR 16 bpc on HDR display
            if (sdrWhiteLevel > 80.0f)
                vertexShader.LuminanceScale.X = (sdrWhiteLevel / 80.0f);


            // SDR 16 bpc on SDR display
            vertexShader.LuminanceScale.W = 1.0f;
        }
        // TODO: maybe support later?
        // else if (SKIF_ImplDX11_ViewPort_GetDXGIFormat (vp) == DXGI_FORMAT_R10G10B10A2_UNORM)
        // {
        //     // SDR 10 bpc on SDR display
        //     vertexShader.LuminanceScale.Z = 1.0f;
        // }


        pixelShader.DisplayMaxLuminance = maxLuminance / 80;
        // TODO: edit when actually supporting hdr flow, for now we always want to get sdr result
        // if (pixelShader.UserBrightnessScale * maxContentLuminance > maxLuminance)
        pixelShader.TonemapType = (uint)settings.HdrToneMapType;
        // else
        //     pixelShader.TonemapType = (uint)HdrToneMapType.None;
        pixelShader.SdrWhiteLevel = (float)(sdrWhiteLevel / 1000.0 * 80.0 * (settings.SdrWhiteScale / 100.0));


        vertexShader.LuminanceScale = new Vector4(1, 0, 0, 0);
    }
}

class HLSLShaderIncludeHandler : Include
{
    public IDisposable Shadow { get; set; }

    public void Close(Stream stream)
    {
        stream.Close();
        stream.Dispose();
    }

    public void Dispose()
    {
        Shadow?.Dispose();
    }

    public Stream Open(IncludeType type, string fileName, Stream parentStream)
    {
        var assembly = Assembly.GetExecutingAssembly();
        return assembly.GetManifestResourceStream($"{ShaderConstants.ResourcePrefix}.{fileName}");
    }
}

static class ShaderConstants
{
    public static string ResourcePrefix => "ShareXBitmapUtils.D3D11Shaders";
}

[StructLayout(LayoutKind.Sequential, Size = 32)]
public struct PixelShaderConstants
{
    public float HdrMaxLuminance;
    public float DisplayMaxLuminance;
    public float UserBrightnessScale;
    public float SdrWhiteLevel;
    public uint TonemapType;
}

[StructLayout(LayoutKind.Sequential)]
public struct VertexShaderConstants
{
    // scRGB allows values > 1.0, sRGB (SDR) simply clamps them
    // x = Luminance/Brightness -- For HDR displays, 1.0 = 80 Nits, For SDR displays, >= 1.0 = 80 Nits
    // y = isHDR
    // z = is10bpc
    // w = is16bpc
    public Vector4 LuminanceScale;
}

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public unsafe struct Vertex(Vector2 position, Vector2 textureCoord)
{
    public Vector2 Position = position;
    public Vector2 TextureCoord = textureCoord;

    public static uint SizeInBytes => (uint)sizeof(Vertex);
}

public class Tonemapping
{
// TODO: as this code is from SKIV project it probably can be simplifed a lot more, as we dont need many of the features
    public static ID3D11Texture2D TonemapOnCpu(HdrSettings hdrSettings, ModernCaptureMonitorDescription region, DeviceAccess deviceAccess,
        ID3D11Texture2D inputHdrTex)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    static readonly Vertex[] defaultVerts =
    [
        new(position: new Vector2(-1f, +1f), textureCoord: new Vector2(0f, 0f)),
        new(position: new Vector2(+1f, +1f), textureCoord: new Vector2(1f, 0f)),
        new(position: new Vector2(-1f, -1f), textureCoord: new Vector2(0f, 1f)),
        new(position: new Vector2(+1f, +1f), textureCoord: new Vector2(1f, 0f)),
        new(position: new Vector2(+1f, -1f), textureCoord: new Vector2(1f, 1f)),
        new(position: new Vector2(-1f, -1f), textureCoord: new Vector2(0f, 1f))
    ];

    public static ID3D11Texture2D TonemapOnGpu(HdrSettings hdrSettings, ModernCaptureMonitorDescription region, DeviceAccess deviceAccess,
        ID3D11Texture2D cpuStaging, ID3D11Texture2D gpuRawTexture, ID3D11Texture2D canvasGpu,     Box                                  destBox,
        Box                                  srcBox)
    {
        ID3D11Device device = deviceAccess.Device;
        ID3D11DeviceContext ctx = device.ImmediateContext;
        ImageInfo imageInfo = CalculateImageInfo(hdrSettings, cpuStaging);
        ShaderConstantHelper.GetShaderConstants(region.MonitorInfo, hdrSettings, imageInfo, out var vertexShaderConstants, out var pixelShaderConstants);
        // var quadVerts = defaultVerts; // Direct3DUtils.ConstructForScreen(region);

        var rawDesc = gpuRawTexture.Description;
        float u0 = srcBox.Left   / (float)rawDesc.Width;
        float v0 = srcBox.Top    / (float)rawDesc.Height;
        float u1 = u0 + (srcBox.Width / (float)rawDesc.Width);
        float v1 = v0 + (srcBox.Height / (float)rawDesc.Height);

        float left = -1.0f;
        float right = 1.0f;
        float bottom = -1.0f;
        float top = 1.0f;
        var quadVerts = new[]
        {
            new Vertex(new Vector2(left, top),  new Vector2(u0, v0)),
            new Vertex(new Vector2(right, top),  new Vector2(u1, v0)),
            new Vertex(new Vector2(left, bottom),  new Vector2(u0, v1)),
            new Vertex(new Vector2(left, bottom),  new Vector2(u0, v1)),
            new Vertex(new Vector2(right, top),  new Vector2(u1, v0)),
            new Vertex(new Vector2(right, bottom),  new Vector2(u1, v1)),
        };


        var vertexBuffer = device.CreateBuffer(quadVerts, BindFlags.VertexBuffer);

        PixelShaderConstants[] pixelShaderConstantsArray = [pixelShaderConstants];
        var psConstantBuffer = device.CreateBuffer(pixelShaderConstantsArray, BindFlags.ConstantBuffer);

        VertexShaderConstants[] vertexShaderConstantsArray = [vertexShaderConstants];
        var vsConstantBuffer = device.CreateBuffer(vertexShaderConstantsArray, BindFlags.ConstantBuffer);

        var inDesc = gpuRawTexture.Description;
        var ldrRtv = device.CreateRenderTargetView(canvasGpu);

        var hdrSrvDesc = new ShaderResourceViewDescription
        {
            Format = inDesc.Format,
            ViewDimension = ShaderResourceViewDimension.Texture2D,
            Texture2D = new Texture2DShaderResourceView
            {
                MostDetailedMip = 0,
                MipLevels = 1
            }
        };
        var hdrSrv = device.CreateShaderResourceView(gpuRawTexture, hdrSrvDesc);

        ctx.OMSetRenderTargets(ldrRtv);

        var vp = new Viewport {
            X = destBox.Left,
            Y = destBox.Top,
            Width    = destBox.Width,
            Height   = destBox.Height,
            MinDepth = 0,
            MaxDepth = 1
        };
        ctx.RSSetViewport(vp);

        ctx.IASetPrimitiveTopology(PrimitiveTopology.TriangleList);
        ctx.IASetInputLayout(deviceAccess.inputLayout);
        ctx.IASetVertexBuffer(0, vertexBuffer, Vertex.SizeInBytes);

        var sampler = device.CreateSamplerState(new SamplerDescription()
        {
            Filter = Filter.MinMagMipLinear,
            AddressU = TextureAddressMode.Clamp,
            AddressV = TextureAddressMode.Clamp,
            AddressW = TextureAddressMode.Clamp,
            MipLODBias = 0,
            ComparisonFunc = ComparisonFunction.Never,
            MinLOD = 0,
            MaxLOD = 0
        });
        ctx.PSSetSampler(0, sampler);

        ctx.VSSetShader(deviceAccess.vxShader);
        ctx.VSSetConstantBuffer(0, vsConstantBuffer);
        ctx.PSSetShader(deviceAccess.pxShader);
        ctx.PSSetConstantBuffer(0, psConstantBuffer);
        ctx.PSSetShaderResource(0, hdrSrv);


        ctx.Draw(vertexCount: 6, startVertexLocation: 0);

        hdrSrv.Dispose();
        psConstantBuffer.Dispose();
        vertexBuffer.Dispose();
        ldrRtv.Dispose();
        sampler.Dispose();


        return canvasGpu;
    }

    // heavily inspired by https://github.com/SpecialKO/SKIV/blob/ed2a4a9de93ebba9661f9e8ed31c5d67ab490d2d/src/utility/image.cpp#L1300C1-L1300C25
    // MIT License Copyright (c) 2024 Aemony

    private static readonly string defaultSDRFileExt = ".png";

    // TODO: consider threads?
    public static ImageInfo CalculateImageInfo(Direct3DUtils.PixelReader pixelReader)
    {
        ImageInfo result = new ImageInfo();
        var log = Console.Out;

        Vector4 maxCLLVector = Vector4.Zero;
        float maxLum = 0;
        float minLum = float.MaxValue;
        double totalLum = 0;

        log.WriteLine("CalculateLightInfo(): EvaluateImageBegin");

        var stopwatchCore = Stopwatch.StartNew();
        uint[] luminance_freq = new uint[65536];
        float fLumRange = maxLum - minLum;

        var pixels = pixelReader.Pixels;
        for (uint i = 0; i < pixels; i++)
        {
            Vector4 v = pixelReader.GetPixel(i);
            maxCLLVector = Vector4.Max(v, maxCLLVector);
            Vector4 vXyz = Vector4.Transform(v, ColorspaceUtils.from709ToXYZ);

            maxLum = MathF.Max(vXyz.Y, maxLum);
            minLum = MathF.Min(vXyz.Y, minLum);

            totalLum += MathF.Max(0, maxLum);
        }

        float maxCll = MathF.Max(maxCLLVector.X, maxCLLVector.Y);
        maxCll = MathF.Max(maxCll, maxCLLVector.Z);
        float avgLum = (float)(totalLum / pixels);
        minLum = MathF.Max(0, minLum);
        result.MaxNits = MathF.Max(0, maxLum * 80);
        result.MinNits = MathF.Max(0, minLum * 80);
        result.AvgNits = avgLum * 80;
        result.MaxCLL = maxCll;

        if (maxCll == maxCLLVector.X) result.MaxCLLChannel = 'R';
        else if (maxCll == maxCLLVector.Y) result.MaxCLLChannel = 'G';
        else if (maxCll == maxCLLVector.Z) result.MaxCLLChannel = 'B';
        else result.MaxCLLChannel = 'X';

        log.WriteLine("CalculateLightInfo(): EvaluateImage, min/max calculated (max: " + maxLum + "): " + stopwatchCore.ElapsedMilliseconds + "ms");

        for (uint i = 0; i < pixels; i++)
        {
            Vector4 v = pixelReader.GetPixel(i);
            v = Vector4.Max(Vector4.Zero, Vector4.Transform(v, ColorspaceUtils.from709ToXYZ));
            luminance_freq[Math.Clamp((int)Math.Round((v.Y - minLum) / (fLumRange / 65536.0f)), 0, 65535)]++;

            int idx = Math.Clamp(
                (int)Math.Round((v.Y - minLum) / (fLumRange / 65536.0f)),
                0,
                65535
            );
            luminance_freq[idx]++;
        }

        log.WriteLine("CalculateImageInfo(): EvaluateImage, luminance_freq calculated: " + stopwatchCore.ElapsedMilliseconds + "ms");

        double percent = 100.0;
        double img_size = pixels;

        float p99Lum = maxLum;
        for (int i = 65535; i >= 0; --i)
        {
            percent -= 100.0 * ((double)luminance_freq[i] / img_size);
            if (percent <= 99.94)
            {
                float percentileLum = minLum + (fLumRange * ((float)i / 65536.0f));
                p99Lum = percentileLum;
                break;
            }
        }

        if (p99Lum <= 0.01f)
            p99Lum = maxLum;

        result.P99Nits = MathF.Max(0, p99Lum * 80);

        log.WriteLine("CalculateImageInfo(): EvaluateImage, percentileLum calculated: " + stopwatchCore.ElapsedMilliseconds + "ms");

        const float scale = 1;
        const float _maxNitsToTonemap = 125.0f * scale;
        float SDR_YInPQ = ColorspaceUtils.LinearToPQY(1.5f);
        float maxYInPQ = MathF.Max(
            SDR_YInPQ,
            ColorspaceUtils.LinearToPQY(MathF.Min(_maxNitsToTonemap, maxLum * scale))
        );
        result.MaxYInPQ = maxYInPQ; // TODO: is this correct?
        return result;
    }

    public static ImageInfo CalculateImageInfo(HdrSettings setting, ID3D11Texture2D image)
    {
        Direct3DUtils.PixelReader reader = null;
        try
        {
            reader = image.GetPixelReader(setting);
            return CalculateImageInfo(reader);
        }
        finally
        {
            reader?.Dispose();
        }
    }

    // public static ScratchImage ConvertToSDRPixels(ID3D11Texture2D image, out Vector4[] scrgb, out ImageInfo imageInfo)
    // {
    //     var log = Console.Out;
    //
    //     var stopwatchTotal = Stopwatch.StartNew();
    //     int width = (int)image.Description.Width;
    //     int height = (int)image.Description.Height;
    //     scrgb = image.GetPixelSpan();
    //
    //     log.WriteLine("ConvertToSDRPixels(): EvaluateImageBegin");
    //
    //     var stopwatchCore = Stopwatch.StartNew();
    //     imageInfo = CalculateImageInfo(scrgb, );
    //     log.WriteLine("ConvertToSDRPixels(): EvaluateImage, percentileLum calculated: " + stopwatchCore.ElapsedMilliseconds + "ms");
    //
    //     PerformTonemapping(scrgb, imageInfo, scrgb);
    //
    //     log.WriteLine("ConvertToSDRPixels(): EvaluateImage, tonemapped: " + stopwatchCore.ElapsedMilliseconds + "ms");
    //
    //     stopwatchCore.Stop();
    //     log.WriteLine("ConvertToSDRPixels(): ConvertToSDR: " + stopwatchCore.ElapsedMilliseconds + "ms (total: " + stopwatchTotal.ElapsedMilliseconds +
    //                   "ms)");
    //     var texHelper = TexHelper.Instance;
    //     var hdrScratch = texHelper.Initialize2D(DXGI_FORMAT.R32G32B32A32_FLOAT,
    //         width,
    //         height,
    //         1,
    //         1, CP_FLAGS.NONE);
    //
    //     unsafe
    //     {
    //         var img = hdrScratch.GetImage(0);
    //         fixed (Vector4* pSrc = scrgb) //
    //         {
    //             // copy the whole image in one go
    //             Buffer.MemoryCopy(pSrc,
    //                 (void*)img.Pixels,
    //                 img.SlicePitch, // dest capacity
    //                 img.SlicePitch); // bytes to copy
    //         }
    //     }
    //
    //     return hdrScratch;
    // }

    // public static void SaveImageToDiskSDR(ID3D11Texture2D image, string wszFileName, bool force_sRGB)
    // {
    //     var stopwatchTotal = Stopwatch.StartNew();
    //
    //     var log = Console.Out;
    //
    //     // 2. Get the file extension from the provided filename
    //     string wszExtension = GetExtension(wszFileName);
    //
    //     // 3. Prepare an “implicit” filename in case the user did not supply an extension
    //     string wszImplicitFileName = wszFileName;
    //     if (string.IsNullOrEmpty(wszExtension))
    //     {
    //         wszImplicitFileName += defaultSDRFileExt;
    //         wszExtension = GetExtension(wszImplicitFileName);
    //     }
    //
    //     // 8. Flags for preferring higher‐bit‐depth WIC pixel formats
    //     bool bPrefer10bpcAs48bpp = false;
    //     bool bPrefer10bpcAs32bpp = false;
    //
    //     // 9. Prepare WIC codec GUID and WIC flags
    //     WICCodecs wic_codec;
    //     WIC_FLAGS wic_flags = WIC_FLAGS.DITHER_DIFFUSION |
    //                           (force_sRGB ? WIC_FLAGS.FORCE_SRGB : WIC_FLAGS.NONE);
    //
    //     // 10. Branch based on extension: “jpg” / “jpeg”
    //     if ((HasExtension(wszExtension, "jpg") != null) ||
    //         (HasExtension(wszExtension, "jpeg") != null))
    //     {
    //         wic_codec = WICCodecs.JPEG;
    //     }
    //     // 11. Extension: “png”
    //     else if (HasExtension(wszExtension, "png") != null)
    //     {
    //         wic_codec = WICCodecs.PNG;
    //         // Force sRGB for PNG
    //         wic_flags |= WIC_FLAGS.FORCE_SRGB;
    //         wic_flags |= WIC_FLAGS.DEFAULT_SRGB;
    //     }
    //     // 12. Extension: “bmp”
    //     else if (HasExtension(wszExtension, "bmp") != null)
    //     {
    //         wic_codec = WICCodecs.BMP;
    //     }
    //     // 13. Extension: “tiff”
    //     else if (HasExtension(wszExtension, "tiff") != null)
    //     {
    //         wic_codec = WICCodecs.TIFF;
    //         // bPrefer10bpcAs32bpp = false;
    //     }
    //     // 14. Extension: “hdp” or “jxr” (WMP)
    //     else if ((HasExtension(wszExtension, "hdp") != null) ||
    //              (HasExtension(wszExtension, "jxr") != null))
    //     {
    //         wic_codec = WICCodecs.WMP;
    //         bPrefer10bpcAs32bpp = true;
    //     }
    //     else throw new Exception("Unsupported file extension");
    //
    //     if (bPrefer10bpcAs32bpp)
    //     {
    //         wic_flags |= WIC_FLAGS.FORCE_SRGB;
    //     }
    //
    //     var stopwatchCore = Stopwatch.StartNew();
    //     using var tonemappedScratchImage = ConvertToSDRPixels(image, out var scrgb, out _);
    //
    //     DXGI_FORMAT outFormat = bPrefer10bpcAs32bpp ? DXGI_FORMAT.R10G10B10A2_UNORM : DXGI_FORMAT.B8G8R8X8_UNORM_SRGB;
    //
    //     stopwatchCore.Stop();
    //     log.WriteLine("SaveImageToDiskSDR(): ConvertToSDR: " + stopwatchCore.ElapsedMilliseconds + "ms (total: " + stopwatchTotal.ElapsedMilliseconds +
    //                   "ms)");
    //
    //
    //     using var sdrScratch = tonemappedScratchImage.Convert(0, outFormat, TEX_FILTER_FLAGS.DEFAULT, 1.0f);
    //
    //     log.WriteLine("SaveImageToDiskSDR(): EncodeToMemory: " + stopwatchTotal.ElapsedMilliseconds);
    //     if (wic_codec == WICCodecs.JPEG)
    //     {
    //         sdrScratch.SaveToJPGFile(0, 1.0f, wszImplicitFileName);
    //     }
    //     else
    //     {
    //         Guid guid = TexHelper.Instance.GetWICCodec(wic_codec);
    //         sdrScratch.SaveToWICFile(0, wic_flags, guid, wszImplicitFileName);
    //     }
    //
    //     log.WriteLine("SaveImageToDiskSDR(): EncodeToDisk: " + stopwatchTotal.ElapsedMilliseconds);
    // }

    // private static void PerformTonemapping(Vector4[] scrgb, ImageInfo imageInfo, Vector4[] outPixels)
    // {
    //     var maxYInPQ = imageInfo.MaxYInPQ;
    //     for (int j = 0; j < scrgb.Length; ++j)
    //     {
    //         MaxTonemappedRgb(scrgb, maxYInPQ, outPixels, j);
    //     }
    // }
    //
    // private static void MaxTonemappedRgb(Vector4[] scrgb, float maxYInPQ, Vector4[] outPixels, int j)
    // {
    //     Vector4 value = scrgb[j];
    //     Vector4 ICtCp = ColorspaceUtils.Rec709toICtCp(value);
    //     float Y_in = MathF.Max(ICtCp.X, 0.0f);
    //     float Y_out = 1.0f;
    //
    //     Y_out = ColorspaceUtils.HdrTonemap(maxYInPQ, Y_out, Y_in);
    //
    //     if (Y_out + Y_in > 0.0f)
    //     {
    //         ICtCp.X = MathF.Pow(Y_in, 1.18f);
    //         float I0 = ICtCp.X;
    //         ICtCp.X *= MathF.Max(Y_out / Y_in, 0.0f);
    //         float I1 = ICtCp.X;
    //
    //         float I_scale = 0.0f;
    //         if (I0 != 0.0f && I1 != 0.0f)
    //         {
    //             I_scale = MathF.Min(I0 / I1, I1 / I0);
    //         }
    //
    //         ICtCp.Y *= I_scale;
    //         ICtCp.Z *= I_scale;
    //     }
    //
    //     value = ColorspaceUtils.ICtCpToRec709(ICtCp);
    //     outPixels[j] = value;
    // }
    // public static void ConvertToSDRPixelsInPlace(
    //     ID3D11DeviceContext context,
    //     ID3D11Texture2D image,
    //     out Vector4[] scrgb,
    //     out ImageInfo imageInfo)
    // {
    //     int width = (int)image.Description.Width;
    //     int height = (int)image.Description.Height;
    //     var fmt = image.Description.Format;
    //     scrgb = image.GetPixelSpan();
    //     imageInfo = CalculateImageInfo(scrgb);
    //     PerformTonemapping(scrgb, imageInfo, scrgb);
    //
    //     unsafe
    //     {
    //         if (fmt == Format.R32G32B32A32_Float)
    //         {
    //             // TODO: does this work?
    //             fixed (Vector4* pSrc = scrgb)
    //             {
    //                 int strideInBytes = width * sizeof(Vector4);
    //                 var sysMem = new DataBox((IntPtr)pSrc, strideInBytes, 0);
    //                 context.UpdateSubresource(sysMem, image);
    //             }
    //         }
    //         else if (fmt == Format.R16G16B16A16_Float)
    //         {
    //             // TODO: avoid that copy?
    //             int pixelCount = width * height;
    //             ulong[] packed = new ulong[pixelCount];
    //
    //             for (int i = 0; i < pixelCount; i++)
    //             {
    //                 Half4 h = scrgb[i];
    //                 packed[i] = h.PackedValue;
    //             }
    //
    //             var handle = GCHandle.Alloc(packed, GCHandleType.Pinned);
    //             try
    //             {
    //                 IntPtr ptr = handle.AddrOfPinnedObject();
    //                 int rowPitch = width * sizeof(ulong); // 8 bytes × width
    //                 var box = new DataBox(ptr, rowPitch, 0);
    //                 context.UpdateSubresource(box, image);
    //             }
    //             finally
    //             {
    //                 handle.Free();
    //             }
    //         }
    //         else
    //         {
    //             throw new InvalidOperationException(
    //                 $"ConvertToSDRPixelsInPlace: Format {fmt} is not supported. " +
    //                 "Only R32G32B32A32_Float and R16G16B16A16_Float are implemented.");
    //         }
    //     }
    // }

    private static string GetExtension(string wszFileName)
    {
        return Path.GetExtension(wszFileName)?.ToLower() ?? "";
    }

    private static object HasExtension(string wszExtension, string extension)
    {
        return wszExtension.EndsWith(extension);
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct POINT
{
    public int x;
    public int y;
}

[StructLayout(LayoutKind.Sequential)]
public struct RECT
{
    public int left;
    public int top;
    public int right;
    public int bottom;
}

    [Flags]
    public enum QDC_CONSTANT : uint
    {
        QDC_ALL_PATHS = 0x1,
        QDC_ONLY_ACTIVE_PATHS = 0x2,
        QDC_DATABASE_CURRENT = 0x4,
        QDC_VIRTUAL_MODE_AWARE = 0x10,
        QDC_INCLUDE_HMD = 0x20,
    }

    public enum DISPLAYCONFIG_DEVICE_INFO_TYPE : uint
    {
        DISPLAYCONFIG_DEVICE_INFO_GET_SOURCE_NAME = 1,
        DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_NAME = 2,
        DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_PREFERRED_MODE = 3,
        DISPLAYCONFIG_DEVICE_INFO_GET_ADAPTER_NAME = 4,
        DISPLAYCONFIG_DEVICE_INFO_SET_TARGET_PERSISTENCE = 5,
        DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_BASE_TYPE = 6,
        DISPLAYCONFIG_DEVICE_INFO_GET_SUPPORT_VIRTUAL_RESOLUTION = 7,
        DISPLAYCONFIG_DEVICE_INFO_SET_SUPPORT_VIRTUAL_RESOLUTION = 8,
        DISPLAYCONFIG_DEVICE_INFO_GET_ADVANCED_COLOR_INFO = 9,
        DISPLAYCONFIG_DEVICE_INFO_SET_ADVANCED_COLOR_STATE = 10,
        DISPLAYCONFIG_DEVICE_INFO_GET_SDR_WHITE_LEVEL = 11,
        DISPLAYCONFIG_DEVICE_INFO_FORCE_UINT32 = 0xFFFFFFFF,
    }

    public enum DISPLAYCONFIG_COLOR_ENCODING : uint
    {
        DISPLAYCONFIG_COLOR_ENCODING_RGB = 0,
        DISPLAYCONFIG_COLOR_ENCODING_YCBCR444 = 1,
        DISPLAYCONFIG_COLOR_ENCODING_YCBCR422 = 2,
        DISPLAYCONFIG_COLOR_ENCODING_YCBCR420 = 3,
        DISPLAYCONFIG_COLOR_ENCODING_INTENSITY = 4,
        DISPLAYCONFIG_COLOR_ENCODING_FORCE_UINT32 = 0xFFFFFFFF,
    }

    [Flags]
    public enum DISPLAYCONFIG_PATH_SOURCE_INFO_FLAGS
    {
        None = 0,
        DISPLAYCONFIG_SOURCE_IN_USE = 1,
    }

    public enum DISPLAYCONFIG_MODE_INFO_TYPE
    {
        DISPLAYCONFIG_MODE_INFO_TYPE_FORCE_UINT32 = -1,
        DISPLAYCONFIG_MODE_INFO_TYPE_SOURCE = 1,
        DISPLAYCONFIG_MODE_INFO_TYPE_TARGET = 2,
        DISPLAYCONFIG_MODE_INFO_TYPE_DESKTOP_IMAGE = 3,
    }

    [Flags]
    public enum DISPLAYCONFIG_PATH_TARGET_INFO_FLAGS
    {
        None = 0,
        DISPLAYCONFIG_TARGET_IN_USE = 1,
        DISPLAYCONFIG_TARGET_FORCIBLE = 2,
        DISPLAYCONFIG_TARGET_FORCED_AVAILABILITY_BOOT = 4,
        DISPLAYCONFIG_TARGET_FORCED_AVAILABILITY_PATH = 8,
        DISPLAYCONFIG_TARGET_FORCED_AVAILABILITY_SYSTEM = 16,
    }

    public enum DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY
    {
        DISPLAYCONFIG_OUTPUT_TECHNOLOGY_INTERNAL = int.MinValue,
        DISPLAYCONFIG_OUTPUT_TECHNOLOGY_OTHER = -1,
        DISPLAYCONFIG_OUTPUT_TECHNOLOGY_FORCE_UINT32 = -1,
        DISPLAYCONFIG_OUTPUT_TECHNOLOGY_HD15 = 0,
        DISPLAYCONFIG_OUTPUT_TECHNOLOGY_SVIDEO = 1,
        DISPLAYCONFIG_OUTPUT_TECHNOLOGY_COMPOSITE_VIDEO = 2,
        DISPLAYCONFIG_OUTPUT_TECHNOLOGY_COMPONENT_VIDEO = 3,
        DISPLAYCONFIG_OUTPUT_TECHNOLOGY_DVI = 4,
        DISPLAYCONFIG_OUTPUT_TECHNOLOGY_HDMI = 5,
        DISPLAYCONFIG_OUTPUT_TECHNOLOGY_LVDS = 6,
        DISPLAYCONFIG_OUTPUT_TECHNOLOGY_D_JPN = 8,
        DISPLAYCONFIG_OUTPUT_TECHNOLOGY_SDI = 9,
        DISPLAYCONFIG_OUTPUT_TECHNOLOGY_DISPLAYPORT_EXTERNAL = 10,
        DISPLAYCONFIG_OUTPUT_TECHNOLOGY_DISPLAYPORT_EMBEDDED = 11,
        DISPLAYCONFIG_OUTPUT_TECHNOLOGY_UDI_EXTERNAL = 12,
        DISPLAYCONFIG_OUTPUT_TECHNOLOGY_UDI_EMBEDDED = 13,
        DISPLAYCONFIG_OUTPUT_TECHNOLOGY_SDTVDONGLE = 14,
        DISPLAYCONFIG_OUTPUT_TECHNOLOGY_MIRACAST = 15,
    }
    public enum DISPLAYCONFIG_ROTATION
    {
        DISPLAYCONFIG_ROTATION_FORCE_UINT32 = -1,
        DISPLAYCONFIG_ROTATION_IDENTITY = 1,
        DISPLAYCONFIG_ROTATION_ROTATE90 = 2,
        DISPLAYCONFIG_ROTATION_ROTATE180 = 3,
        DISPLAYCONFIG_ROTATION_ROTATE270 = 4,
    }

    public enum DISPLAYCONFIG_SCANLINE_ORDERING
    {
        DISPLAYCONFIG_SCANLINE_ORDERING_FORCE_UINT32 = -1,
        DISPLAYCONFIG_SCANLINE_ORDERING_UNSPECIFIED = 0,
        DISPLAYCONFIG_SCANLINE_ORDERING_PROGRESSIVE = 1,
        DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED = 2,
        DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED_UPPERFIELDFIRST = 2,
        DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED_LOWERFIELDFIRST = 3,
    }

    public enum DISPLAYCONFIG_SCALING
    {
        DISPLAYCONFIG_SCALING_FORCE_UINT32 = -1,
        DISPLAYCONFIG_SCALING_IDENTITY = 1,
        DISPLAYCONFIG_SCALING_CENTERED = 2,
        DISPLAYCONFIG_SCALING_STRETCHED = 3,
        DISPLAYCONFIG_SCALING_ASPECTRATIOCENTEREDMAX = 4,
        DISPLAYCONFIG_SCALING_CUSTOM = 5,
        DISPLAYCONFIG_SCALING_PREFERRED = 128,
    }

    [Flags]
    public enum AdvancedColorStatus : uint
    {
        AdvancedColorNone = 0,
        AdvancedColorSupported = 1 << 0,
        AdvancedColorEnabled = 1 << 1,
        WideColorEnforced = 1 << 2,
        AdvancedColorForceDisabled = 1 << 3,
    }

    public enum DISPLAYCONFIG_PIXELFORMAT
    {
        DISPLAYCONFIG_PIXELFORMAT_FORCE_UINT32 = -1,
        DISPLAYCONFIG_PIXELFORMAT_8BPP = 1,
        DISPLAYCONFIG_PIXELFORMAT_16BPP = 2,
        DISPLAYCONFIG_PIXELFORMAT_24BPP = 3,
        DISPLAYCONFIG_PIXELFORMAT_32BPP = 4,
        DISPLAYCONFIG_PIXELFORMAT_NONGDI = 5,
    }

    public enum DISPLAYCONFIG_PATH
    {
        DISPLAYCONFIG_PATH_ACTIVE = 0x00000001,
        DISPLAYCONFIG_PATH_PREFERRED_UNSCALED = 0x00000004,
        DISPLAYCONFIG_PATH_SUPPORT_VIRTUAL_MODE = 0x00000008,
    }

    public interface IDisplayConfigInfo
    {
        // Nothing here
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DISPLAYCONFIG_DEVICE_INFO_HEADER : IDisplayConfigInfo
    {
        public DISPLAYCONFIG_DEVICE_INFO_TYPE type;
        public uint size;
        public LUID adapterId;
        public uint id;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DISPLAYCONFIG_GET_ADVANCED_COLOR_INFO : IDisplayConfigInfo
    {
        public DISPLAYCONFIG_DEVICE_INFO_HEADER header;
        public AdvancedColorStatus AdvancedColorStatus;
        public DISPLAYCONFIG_COLOR_ENCODING ColorEncoding;
        public uint BitsPerColorChannel;

        public static DISPLAYCONFIG_GET_ADVANCED_COLOR_INFO CreateGet()
        {
            DISPLAYCONFIG_GET_ADVANCED_COLOR_INFO s = new DISPLAYCONFIG_GET_ADVANCED_COLOR_INFO();
            s.header.type = DISPLAYCONFIG_DEVICE_INFO_TYPE.DISPLAYCONFIG_DEVICE_INFO_GET_ADVANCED_COLOR_INFO;
            s.header.size = (uint)Marshal.SizeOf(s);
            return s;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DISPLAYCONFIG_SDR_WHITE_LEVEL : IDisplayConfigInfo
    {
        public DISPLAYCONFIG_DEVICE_INFO_HEADER header;
        public uint SDRWhiteLevel;

        public float SDRWhiteLevelInNits => (SDRWhiteLevel / 1000) * 80;

        public static DISPLAYCONFIG_SDR_WHITE_LEVEL CreateGet()
        {
            DISPLAYCONFIG_SDR_WHITE_LEVEL s = new DISPLAYCONFIG_SDR_WHITE_LEVEL();
            s.header.type = DISPLAYCONFIG_DEVICE_INFO_TYPE.DISPLAYCONFIG_DEVICE_INFO_GET_SDR_WHITE_LEVEL;
            s.header.size = (uint)Marshal.SizeOf(s);
            return s;
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DISPLAYCONFIG_SOURCE_DEVICE_NAME : IDisplayConfigInfo
    {
        public DISPLAYCONFIG_DEVICE_INFO_HEADER header;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = GdiInteropConstants.CCHDEVICENAME)]
        public string DeviceName;

        public static DISPLAYCONFIG_SOURCE_DEVICE_NAME CreateGet()
        {
            DISPLAYCONFIG_SOURCE_DEVICE_NAME s = new DISPLAYCONFIG_SOURCE_DEVICE_NAME();
            s.header.type = DISPLAYCONFIG_DEVICE_INFO_TYPE.DISPLAYCONFIG_DEVICE_INFO_GET_SOURCE_NAME;
            s.header.size = (uint)Marshal.SizeOf(s);
            return s;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DISPLAYCONFIG_PATH_SOURCE_INFO
    {
        public LUID adapterId;
        public uint id;
        public uint modeInfoIdx;
        public DISPLAYCONFIG_PATH_SOURCE_INFO_FLAGS statusFlags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DISPLAYCONFIG_RATIONAL
    {
        public uint Numerator;
        public uint Denominator;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DISPLAYCONFIG_PATH_TARGET_INFO
    {
        public LUID adapterId;
        public uint id;
        public uint modeInfoIdx;
        public DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY outputTechnology;
        public DISPLAYCONFIG_ROTATION rotation;
        public DISPLAYCONFIG_SCALING scaling;
        public DISPLAYCONFIG_RATIONAL refreshRate;
        public DISPLAYCONFIG_SCANLINE_ORDERING scanLineOrdering;
        public bool targetAvailable;
        public DISPLAYCONFIG_PATH_TARGET_INFO_FLAGS statusFlags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DISPLAYCONFIG_PATH_INFO
    {
        public DISPLAYCONFIG_PATH_SOURCE_INFO sourceInfo;
        public DISPLAYCONFIG_PATH_TARGET_INFO targetInfo;
        public DISPLAYCONFIG_PATH flags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DISPLAYCONFIG_2DREGION
    {
        public uint cx;
        public uint cy;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DISPLAYCONFIG_ADDITIONAL_SIGNAL_INFO
    {
        public ushort videoStandard;

        public int vSyncFreqDivider { get; set; }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DISPLAYCONFIG_VIDEO_SIGNAL_INFO
    {
        public ulong pixelRate;
        public DISPLAYCONFIG_RATIONAL hSyncFreq;
        public DISPLAYCONFIG_RATIONAL vSyncFreq;
        public DISPLAYCONFIG_2DREGION activeSize;
        public DISPLAYCONFIG_2DREGION totalSize;
        public DISPLAYCONFIG_ADDITIONAL_SIGNAL_INFO AdditionalSignalInfo;
        public uint videoStandard;
        public DISPLAYCONFIG_SCANLINE_ORDERING scanLineOrdering;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DISPLAYCONFIG_TARGET_MODE
    {
        public DISPLAYCONFIG_VIDEO_SIGNAL_INFO targetVideoSignalInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DISPLAYCONFIG_SOURCE_MODE
    {
        public uint width;
        public uint height;
        public DISPLAYCONFIG_PIXELFORMAT pixelFormat;
        public POINT position;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DISPLAYCONFIG_DESKTOP_IMAGE_INFO
    {
        public POINT PathSourceSize;
        public RECT DesktopImageRegion;
        public RECT DesktopImageClip;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DISPLAYCONFIG_MODE_INFO
    {
        public DISPLAYCONFIG_MODE_INFO_TYPE infoType;
        public uint id;
        public LUID adapterId;
        public DISPLAYCONFIG_TARGET_MODE targetMode;
        public DISPLAYCONFIG_SOURCE_MODE sourceMode;
        public DISPLAYCONFIG_DESKTOP_IMAGE_INFO desktopImageInfo;
    }
    
    public static class GdiInterop
    {
        [DllImport("User32.dll")]
        private static extern Win32Error DisplayConfigSetDeviceInfo(IntPtr requestPacket);
        public static Win32Error DisplayConfigSetDeviceInfo<T>(ref T displayConfig)
            where T : IDisplayConfigInfo
        {
            return WrapStructureAndCall(ref displayConfig, DisplayConfigSetDeviceInfo);
        }

        [DllImport("User32.dll")]
        private static extern Win32Error DisplayConfigGetDeviceInfo(IntPtr targetDeviceName);
        public static Win32Error DisplayConfigGetDeviceInfo<T>(ref T displayConfig)
            where T : IDisplayConfigInfo
        {
            return WrapStructureAndCall(ref displayConfig, DisplayConfigGetDeviceInfo);
        }

        [DllImport("User32.dll")]
        public static extern Win32Error GetDisplayConfigBufferSizes(QDC_CONSTANT flags,
            ref uint numPathArrayElements, ref uint numModeInfoArrayElements);

        [DllImport("User32.dll")]
        public static extern unsafe Win32Error QueryDisplayConfig(
            QDC_CONSTANT Flags,
            ref uint pNumPathArrayElements,
            [Out] DISPLAYCONFIG_PATH_INFO[] pPathInfoArray,
            ref uint pNumModeInfoArrayElements,
            [Out] DISPLAYCONFIG_MODE_INFO[] pModeInfoArray,
            IntPtr pCurrentTopologyId);

        public static Win32Error WrapStructureAndCall<T>(ref T displayConfig,
            Func<IntPtr, Win32Error> func)
            where T : IDisplayConfigInfo
        {
            var ptr = Marshal.AllocHGlobal(Marshal.SizeOf(displayConfig));
            Marshal.StructureToPtr(displayConfig, ptr, false);

            var retval = func(ptr);

            displayConfig = (T)Marshal.PtrToStructure(ptr, displayConfig.GetType());

            Marshal.FreeHGlobal(ptr);
            return retval;
        }
    }
    
    static class GdiInteropConstants
    {
        public const int CCHDEVICENAME = 32;
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct LUID
    {
        public uint LowPart;
        public int HighPart;
    }
    
        static class MonitorEnumerationHelper
    {
        delegate bool EnumMonitorsDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        private const int CCHDEVICENAME = 32;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct MonitorInfoEx
        {
            public int Size;
            public RECT Monitor;
            public RECT WorkArea;
            public uint Flags;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
            public string DeviceName;
        }

        [DllImport("user32.dll")]
        static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, EnumMonitorsDelegate lpfnEnum, IntPtr dwData);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetMonitorInfo(IntPtr hMonitor, ref MonitorInfoEx lpmi);

        public static List<MonitorInfo> GetMonitors()
        {
            var result = new List<MonitorInfo>();

            EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero,
                delegate(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData)
                {
                    MonitorInfoEx mi = new MonitorInfoEx();
                    mi.Size = Marshal.SizeOf(mi);
                    bool success = GetMonitorInfo(hMonitor, ref mi);
                    if (success)
                    {

                        var info = new MonitorInfo
                        {
                            MonitorArea =
                                new Rectangle(mi.Monitor.left, mi.Monitor.top, mi.Monitor.right - mi.Monitor.left, mi.Monitor.bottom - mi.Monitor.top),
                            WorkArea = new Rectangle(mi.WorkArea.left, mi.WorkArea.top, mi.WorkArea.right - mi.WorkArea.left,
                                mi.WorkArea.bottom - mi.WorkArea.top),
                            IsPrimary = mi.Flags > 0,
                            Hmon = hMonitor,
                            DeviceName = mi.DeviceName
                        };
                        result.Add(info);
                    }

                    return true;
                }, IntPtr.Zero);
            return result;
        }

        public static int GetMonitorsCount()
        {
            int i = 0;
            EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero,
                delegate
                {
                    i++;
                    return true;
                }, IntPtr.Zero);
            return i;
        }
    }
    
        public class MonitorInfo
    {
        public bool IsPrimary { get; set; }
        public Rectangle MonitorArea { get; set; }
        public Rectangle WorkArea { get; set; }
        public string DeviceName { get; set; }
        public IntPtr Hmon { get; set; }

        public void QueryMonitorData(Action<DISPLAYCONFIG_GET_ADVANCED_COLOR_INFO?, DISPLAYCONFIG_SDR_WHITE_LEVEL?, IDXGIOutput6> func)
        {
            var err = BetterWin32Errors.Win32Error.ERROR_SUCCESS;
            bool monAdvColorInfoFound = false;
            var monAdvColorInfo = DISPLAYCONFIG_GET_ADVANCED_COLOR_INFO.CreateGet();
            bool monSdrWhiteLevelFound = false;
            var monSdrWhiteLevel = DISPLAYCONFIG_SDR_WHITE_LEVEL.CreateGet();
            uint numPathArrayElements = 0;
            uint numModeInfoArrayElements = 0;

            err = GdiInterop.GetDisplayConfigBufferSizes(QDC_CONSTANT.QDC_ONLY_ACTIVE_PATHS,
                ref numPathArrayElements, ref numModeInfoArrayElements);
            if (err != BetterWin32Errors.Win32Error.ERROR_SUCCESS)
            {
                throw new System.ComponentModel.Win32Exception((int)err);
            }

            var displayPathInfoArray = new DISPLAYCONFIG_PATH_INFO[numPathArrayElements];
            var displayModeInfoArray = new DISPLAYCONFIG_MODE_INFO[numModeInfoArrayElements];

            err = GdiInterop.QueryDisplayConfig(QDC_CONSTANT.QDC_ONLY_ACTIVE_PATHS,
                ref numPathArrayElements, displayPathInfoArray,
                ref numModeInfoArrayElements, displayModeInfoArray, IntPtr.Zero);
            if (err != BetterWin32Errors.Win32Error.ERROR_SUCCESS)
            {
                throw new System.ComponentModel.Win32Exception((int)err);
            }

            for (uint pathIdx = 0; pathIdx < numPathArrayElements; pathIdx++)
            {
                DISPLAYCONFIG_SOURCE_DEVICE_NAME srcName = DISPLAYCONFIG_SOURCE_DEVICE_NAME.CreateGet();
                srcName.header.adapterId.HighPart = displayPathInfoArray[pathIdx].sourceInfo.adapterId.HighPart;
                srcName.header.adapterId.LowPart = displayPathInfoArray[pathIdx].sourceInfo.adapterId.LowPart;
                srcName.header.id = displayPathInfoArray[pathIdx].sourceInfo.id;

                err = GdiInterop.DisplayConfigGetDeviceInfo(ref srcName);
                if (err != BetterWin32Errors.Win32Error.ERROR_SUCCESS)
                {
                    throw new System.ComponentModel.Win32Exception((int)err);
                }

                if (srcName.DeviceName == DeviceName)
                {
                    // If matches, proceed to query color information
                    monAdvColorInfo.header.adapterId.HighPart = displayPathInfoArray[pathIdx].targetInfo.adapterId.HighPart;
                    monAdvColorInfo.header.adapterId.LowPart = displayPathInfoArray[pathIdx].targetInfo.adapterId.LowPart;
                    monAdvColorInfo.header.id = displayPathInfoArray[pathIdx].targetInfo.id;

                    monSdrWhiteLevel.header.adapterId.HighPart = displayPathInfoArray[pathIdx].targetInfo.adapterId.HighPart;
                    monSdrWhiteLevel.header.adapterId.LowPart = displayPathInfoArray[pathIdx].targetInfo.adapterId.LowPart;
                    monSdrWhiteLevel.header.id = displayPathInfoArray[pathIdx].targetInfo.id;

                    err = GdiInterop.DisplayConfigGetDeviceInfo(ref monAdvColorInfo);
                    if (err != BetterWin32Errors.Win32Error.ERROR_SUCCESS)
                    {
                        throw new System.ComponentModel.Win32Exception((int)err);
                    }

                    monAdvColorInfoFound = true;

                    err = GdiInterop.DisplayConfigGetDeviceInfo(ref monSdrWhiteLevel);
                    monSdrWhiteLevelFound = err == BetterWin32Errors.Win32Error.ERROR_SUCCESS;
                    // Should just throw?
                }
            }


            var factory = DXGI.CreateDXGIFactory1<IDXGIFactory1>();

            bool done = false;
            for (uint ai = 0; factory.EnumAdapters1(ai, out IDXGIAdapter1 adapter).Success; ++ai)
            {
                for (uint oi = 0; adapter.EnumOutputs(oi, out IDXGIOutput output).Success; ++oi)
                {
                    if (output.Description.DeviceName != DeviceName)
                    {
                        continue;
                    }

                    done = true;
                    using (var output6 = output.QueryInterface<IDXGIOutput6>())
                    {
                        func(monAdvColorInfoFound ? monAdvColorInfo : null, monSdrWhiteLevelFound ? monSdrWhiteLevel : null, output6);
                    }
                }

                adapter.Dispose();
                if (done) return;
            }

            func(monAdvColorInfoFound ? monAdvColorInfo : null, monSdrWhiteLevelFound ? monSdrWhiteLevel : null, null);
        }
    }
    
    
        public enum HdrMode
        {
            NoHDR,
            Hdr10Bpc,
            Hdr16Bpc
        }

        public enum HdrToneMapType
        {
            None = 0x0, // Let the display figure it out
            Clip = 0x1, // Truncate the image before display
            InfiniteRolloff = 0x2, // Reduce to finite range (i.e. x/(1+x))
            NormalizeToCll = 0x4, // Content range mapped to [0,1]
            MapCllToDisplay = 0x8 // Content range mapped to display range
        }
        
        
// TODO: all of this should be exposed in GUI
        public class HdrSettings
        {
            private float hdrBrightnessNits = 203;

            public float HdrBrightnessNits
            {
                get => Math.Clamp(hdrBrightnessNits, 80, 400);
                set => hdrBrightnessNits = value;
            }

            private float brightnessScale = 100;

            public float BrightnessScale
            {
                get => Math.Clamp(brightnessScale, 1, 2000);
                set => brightnessScale = value;
            }

            private float sdrWhiteScale = 100;

            public float SdrWhiteScale
            {
                get => Math.Clamp(sdrWhiteScale,
                    0, 2000);
                set => sdrWhiteScale = value;
            }

            public bool Use99ThPercentileMaxCll { get; set; } = true;
            public HdrMode HdrMode { get; set; } = HdrMode.Hdr16Bpc;
            public HdrToneMapType HdrToneMapType { get; set; } = HdrToneMapType.NormalizeToCll;

            public PerformanceMode PerformanceMode { get; set; } = PerformanceMode.Balanced;

            public bool ReuseBuffers => PerformanceMode is PerformanceMode.Max;

            // TODO: fiix these... still leaks memory
            public bool AvoidBuffering => PerformanceMode is PerformanceMode.SaveMemory or PerformanceMode.LowMemory;
            public bool SaveDevices => PerformanceMode != PerformanceMode.LowMemory;
        }

        public enum PerformanceMode
        {
            Max,
            Balanced,
            SaveMemory,
            LowMemory
        }
        
        
        public class ImageInfo
        {
            public float MaxCLL;
            public char MaxCLLChannel;
            public float MaxNits;
            public float MinNits;
            public float AvgNits;
            public float P99Nits;
            public bool Hdr;
            public float MaxYInPQ;
        }
        
        public class ModernCaptureMonitorDescription
        {
            // For GDI use
            public Rectangle DestGdiRect { get; set; }
            public MonitorInfo MonitorInfo { get; set; }

            // For WinRT use
            public bool CaptureCursor { get; set; }

            public ModernCaptureMonitorDescription()
            {
            }
        }

        public class ModernCaptureItemDescription
        {
            public List<ModernCaptureMonitorDescription> Regions { get; set; }
            public Rectangle CanvasRect { get; private set; }

            public ModernCaptureItemDescription(Rectangle canvas, List<ModernCaptureMonitorDescription> monRegions)
            {
                CanvasRect = canvas;
                Regions = monRegions;
            }
        }
        
public class ModernCapture : IDisposable, DisposableCache
{
#if DEBUG
    private IDXGIDebug1 debug;
#endif
    private DeviceCache deviceCache;
    private IDXGIFactory1 idxgiFactory1;
    private HdrSettings Settings;

    private InputElementDescription[] shaderInputElements =
    [
        new("POSITION", 0, Format.R32G32_Float, 0),
        new("TEXCOORD", 0, Format.R32G32_Float, 0)
    ];

    private byte[] vxShader;
    private byte[] psShader;
    private Blob inputSignatureBlob;

    public ModernCapture(HdrSettings settings)
    {
#if DEBUG
        DXGI.DXGIGetDebugInterface1(out debug).CheckError();
#endif

        Settings = settings;
        deviceCache = new DeviceCache(InitializeDevice);
        idxgiFactory1 = DXGI.CreateDXGIFactory1<IDXGIFactory1>();
        InitializeShaders();
        if (settings.SaveDevices)
        {
            deviceCache.Init(idxgiFactory1);
        }
    }

    private void ReInit()
    {
        Dispose();
#if DEBUG
        DXGI.DXGIGetDebugInterface1(out debug).CheckError();
#endif
        deviceCache = new DeviceCache(InitializeDevice);
        idxgiFactory1 = DXGI.CreateDXGIFactory1<IDXGIFactory1>();
        if (Settings.SaveDevices)
        {
            deviceCache.Init(idxgiFactory1);
        }
    }

    private void PrintDebug()
    {
#if DEBUG
        debug.ReportLiveObjects(DXGI.DebugAll,ReportLiveObjectFlags.Summary);
        // TODO: how to do this correctly?
        var idxgiInfoQueue = debug.QueryInterface<IDXGIInfoQueue>();
        var infoQueueMessage = idxgiInfoQueue.GetMessage(DXGI.DebugAll, 0);
        Console.WriteLine(infoQueueMessage.Description);
#endif
    }

    private readonly Dictionary<IntPtr /*hmon*/, DuplicationState> _duplications = new();
    private readonly Lock _lock = new(); // makes first-time creation threadsafe

    private sealed class DuplicationState(IDXGIOutputDuplication dup, ID3D11Texture2D staging, bool isHdr, ID3D11Device device) : IDisposable, DisposableCache
    {
        public IDXGIOutputDuplication Dup { get; } = dup;
        public ID3D11Texture2D Staging { get; set; } = staging;
        public bool IsHdr { get; } = isHdr;

        public ID3D11Device Device = device;

        public void ReleaseFrame(bool includeBuffer)
        {
            Dup?.ReleaseFrame();
            if (includeBuffer)
            {
                Staging?.Dispose();
                Staging = null;
            }
        }

        public void Dispose()
        {
            Dup?.Dispose();
            Staging?.Dispose();
        }

        public void ReleaseCachedValues(HdrSettings settings)
        {
            ReleaseFrame(!settings.ReuseBuffers);
        }
    }

    private DeviceCache GetCache()
    {
        // deviceCache.Dispose();
        // deviceCache = new DeviceCache(InitializeDevice);
        // deviceCache.Init(idxgiFactory1);
        return deviceCache;
    }

    private DuplicationState GetOrCreateDup(IntPtr hmon, bool forceRecreate = false)
    {
        lock (_lock)
        {
            if (_duplications.Count > MonitorEnumerationHelper.GetMonitorsCount())
            {
                foreach (var duplicationsValue in _duplications.Values)
                {
                    duplicationsValue.Dispose();
                }

                _duplications.Clear();
            }

            if (_duplications.TryGetValue(hmon, out var state))
            {
                if (!forceRecreate)
                {
                    if (Settings.ReuseBuffers && state.Staging != null) return state;
                    state.Staging?.Dispose();
                    state.Staging = CreateStagingBuffer(state.Device, state.Dup.Description);
                    return state;
                }

                state.Dup.Dispose();
                state.Staging.Dispose();
            }

            // your helper:
            var screen = GetCache().GetOutputForScreen(idxgiFactory1, hmon);

            // Ask for native format first, SDR fallback second
            var fmts = new[] { Format.R16G16B16A16_Float, Format.B8G8R8A8_UNorm };

            using IDXGIOutput5 output5 = screen.Output.QueryInterface<IDXGIOutput5>();
            var dup = output5.DuplicateOutput1(screen.Device, fmts);

            var desc = dup.Description;
            bool isHdr = desc.ModeDescription.Format == Format.R16G16B16A16_Float;

            state = new DuplicationState(dup, CreateStagingBuffer(screen.Device, desc), isHdr, screen.Device);
            _duplications[hmon] = state;
            return state;
        }
    }

    private ID3D11Texture2D CreateStagingBuffer(ID3D11Device device, OutduplDescription desc)
    {
        var texDesc = new Texture2DDescription
        {
            Width = desc.ModeDescription.Width,
            Height = desc.ModeDescription.Height,
            MipLevels = 1,
            ArraySize = 1,
            Format = desc.ModeDescription.Format,
            SampleDescription = new SampleDescription(1, 0),
            Usage = ResourceUsage.Staging,
            BindFlags = BindFlags.None,
            CPUAccessFlags = CpuAccessFlags.Read | CpuAccessFlags.Write
        };
        return device.CreateTexture2D(texDesc);
    }


    /// Temporary struct to carry each region’s state
    private class RegionTempState
    {
        public ModernCaptureMonitorDescription Region;
        public DeviceAccess DeviceAccess;
        public ID3D11Device Device;
        public ID3D11DeviceContext Context;
        public Rectangle SrcRect;
    }

    public Bitmap CaptureAndProcess(HdrSettings hdrSettings, ModernCaptureItemDescription item)
    {
        // TODO: support multi-gpu setups
        item.Regions = CursorFilter.FilterByCursorGpu(deviceCache, idxgiFactory1, item.Regions);
        Settings = hdrSettings;
        List<DisposableCache> disposableCaches = [];
        try
        {
            bool forceCpuTonemap = false;

            // (A) First pass: discover if all Regions live on the *same* ID3D11Device, and gather per-region state:
            ID3D11Device commonDevice = null;
            ID3D11DeviceContext commonCtx = null;
            bool hasCommonDevice = true;
            var perRegionState = new List<RegionTempState>();
            ID3D11Device firstDevice = null;

            foreach (var r in item.Regions)
            {
                // 2) Grab the D3D11Device + Context for this monitor from your cache:
                var screenAccess = GetCache().GetOutputForScreen(idxgiFactory1, r.MonitorInfo.Hmon);
                ID3D11Device device = screenAccess.Device;
                ID3D11DeviceContext ctx = screenAccess.Context.Device.ImmediateContext;

                // 3) If this is the first region, capture its device as "common"; else check equality:
                if (commonDevice == null)
                {
                    commonDevice = device;
                    commonCtx = ctx;
                }
                else if (!ReferenceEquals(commonDevice, device))
                {
                    hasCommonDevice = false;
                    break;
                }

                // 4) Compute this region’s SrcRect (pixel‐coords inside the monitor texture):
                var srcRect = new Rectangle(
                    r.DestGdiRect.X - r.MonitorInfo.MonitorArea.X,
                    r.DestGdiRect.Y - r.MonitorInfo.MonitorArea.Y,
                    r.DestGdiRect.Width,
                    r.DestGdiRect.Height
                );

                perRegionState.Add(new RegionTempState
                {
                    Region = r,
                    Device = device,
                    DeviceAccess = screenAccess.Context,
                    Context = ctx,
                    SrcRect = srcRect,
                });
            }

            if (!hasCommonDevice)
            {
                throw new Exception("💀 We currently don't support screenshots across multiple GPUs");
            }
#if DEBUG
            var loaded = RenderDoc.Load(out var lib);
            if (loaded && lib != null) lib.StartFrameCapture();
#endif

            // (B) If GPU composition is allowed, create one big GPU canvas now:
            ID3D11Texture2D canvasGpu = null;
            ID3D11DeviceContext canvasContext = null;
            int W = item.CanvasRect.Width;
            int H = item.CanvasRect.Height;

            canvasGpu = Direct3DUtils.CreateCanvasTexture((uint)W, (uint)H, commonDevice);
            canvasContext = commonCtx;

            // (D) Now actually do one pass per region:
            foreach (var state in perRegionState)
            {
                var r = state.Region;
                var device = state.Device;
                var ctx = state.Context;
                var srcRect = state.SrcRect;

                // 1) AcquireNextFrame:
                var dupState = GetOrCreateDup(state.Region.MonitorInfo.Hmon);
                IDXGIResource resourcee;
                Result acquireNextFrame;
                OutduplFrameInfo outduplFrameInfo;
                do
                {
                    dupState.Dup.ReleaseFrame();
                    // sometimes this closes the device??? ?? ?? ? ? ???? wheen screen is in the nagtive space??? TODO
                    acquireNextFrame = dupState.Dup.AcquireNextFrame(10, out outduplFrameInfo, out resourcee);
                    if (acquireNextFrame.Failure) // TODO: only recreate on some errors?
                    {
                        if (acquireNextFrame.ApiCode != "WaitTimeout")
                        {
                            dupState.Dup.ReleaseFrame();
                            dupState = GetOrCreateDup(state.Region.MonitorInfo.Hmon, true);
                        }
                    }
                } while (!acquireNextFrame.Success || outduplFrameInfo.LastPresentTime == 0);

                using var resource = resourcee;
                using var frameTex = resource.QueryInterface<ID3D11Texture2D>();

                // 2) Copy GPU→staging (float or unorm, depending on format):
                ctx.CopyResource(dupState.Staging, frameTex);

                ID3D11Texture2D ldrSource = dupState.Staging;


                //   destBox is where to place it in the big canvas
                var destBox = new Box
                {
                    Left = r.DestGdiRect.X - item.CanvasRect.Left,
                    Top = r.DestGdiRect.Y - item.CanvasRect.Top,
                    Front = 0,
                    Back = 1,
                    Right = (r.DestGdiRect.X - item.CanvasRect.Left) + r.DestGdiRect.Width,
                    Bottom = ( r.DestGdiRect.Y - item.CanvasRect.Top) + r.DestGdiRect.Height
                };

                //   srcBox is the sub‐rectangle inside ldrSource
                var srcBox = new Box
                {
                    Left = srcRect.X,
                    Top = srcRect.Y,
                    Front = 0,
                    Back = 1,
                    Right = srcRect.Right,
                    Bottom = srcRect.Bottom
                };

                if (dupState.IsHdr)
                {
                    if (!forceCpuTonemap)
                    {
                        // GPU path: convert HDR staging → B8G8R8A8_UNorm GPU texture
                        ldrSource = Tonemapping.TonemapOnGpu(Settings, state.Region, state.DeviceAccess, dupState.Staging, frameTex, canvasGpu, destBox, srcBox);
                    }
                    else
                    {
                        // CPU path: convert HDR staging → B8G8R8A8_UNorm STAGING
                        ldrSource = Tonemapping.TonemapOnCpu(Settings, state.Region, state.DeviceAccess, frameTex);
                    }
                }
                else
                {
                    canvasContext.CopySubresourceRegion(
                        canvasGpu, // destination (big canvas)
                        0, // dest mip
                        (uint)destBox.Left, // dest X offset in canvas
                        (uint)destBox.Top, // dest Y offset in canvas
                        0, // dest Z
                        ldrSource, // source texture (either GPU‐tonemapped or staging if it was already unorm)
                        0, // source mip
                        srcBox
                    );
                }
                dupState.ReleaseFrame(!Settings.ReuseBuffers);
            } // end per‐region loop

            // 1) Copy GPU canvas → staging
            using var stagingCanvas = Direct3DUtils.CreateStagingFor(canvasGpu);
            canvasContext.CopyResource(stagingCanvas, canvasGpu);

            // 2) Map once, then build a Bitmap from that pointer
            var descSt = stagingCanvas.Description;
            var mapped = canvasContext.Map(stagingCanvas, 0, MapMode.Read, Vortice.Direct3D11.MapFlags.None);

            Bitmap finalBitmap = BitmapUtils.BuildBitmapFromMappedPointer(
                mapped.DataPointer,
                (int)mapped.RowPitch,
                (int)descSt.Width,
                (int)descSt.Height
            );
            canvasContext.Unmap(stagingCanvas, 0);

            canvasGpu.Dispose();
            stagingCanvas.Dispose();
#if DEBUG
            if (loaded && lib != null) lib.EndFrameCapture();
#endif
            return finalBitmap;
        }
        catch (Exception e)
        {
            // somethingn went wrong, so lets scram
            foreach (var disposableCache in disposableCaches)
            {
                disposableCache.ReleaseCachedValues(Settings);
            }

            ReInit();

            throw new ApplicationException("HDR screenshot failed", e);
        }
        finally
        {
            foreach (var disposableCache in disposableCaches)
            {
                disposableCache.ReleaseCachedValues(Settings);
            }
            this.ReleaseCachedValues(Settings);
        }
    }

    private void InitializeDevice(DeviceAccess deviceAccess)
    {
        var device = deviceAccess.Device;
        deviceAccess.pxShader = device.CreatePixelShader(psShader);
        deviceAccess.vxShader = device.CreateVertexShader(vxShader);

        deviceAccess.inputLayout = device.CreateInputLayout(shaderInputElements, inputSignatureBlob);

        var samplerDesc = new SamplerDescription
        {
            AddressU = TextureAddressMode.Wrap,
            AddressV = TextureAddressMode.Wrap,
            AddressW = TextureAddressMode.Wrap,
            MaxLOD = float.MaxValue,
            BorderColor = new Color4(0, 0, 0, 0),
            Filter = Filter.MinMagMipLinear
        };

        deviceAccess.samplerState = device.CreateSamplerState(samplerDesc);
    }

    private void InitializeShaders()
    {
        var assembly = typeof(ModernCapture).Assembly;
        using (var vxShaderStream = assembly.GetManifestResourceStream($"{ShaderConstants.ResourcePrefix}.PostProcessingQuad.cso"))
        {
            vxShader = new byte[vxShaderStream.Length];
            vxShaderStream.ReadExactly(vxShader);
            inputSignatureBlob = Vortice.D3DCompiler.Compiler.GetInputSignatureBlob(vxShader);
        }

        using (var psShaderStream = assembly.GetManifestResourceStream($"{ShaderConstants.ResourcePrefix}.PostProcessingColor.cso"))
        {
            psShader = new byte[psShaderStream.Length];
            psShaderStream.ReadExactly(psShader);
        }
    }

    public void Dispose()
    {
        foreach (var duplicationsValue in _duplications.Values)
        {
            duplicationsValue.Dispose();
        }
        _duplications.Clear();
        deviceCache?.Dispose();
        deviceCache = null;
#if DEBUG
        debug?.Dispose();
#endif
    }

    public void ReleaseCachedValues(HdrSettings settings)
    {
        if (!settings.AvoidBuffering) return;
        foreach (var duplicationsValue in _duplications.Values)
        {
            duplicationsValue.Dispose();
        }
        _duplications.Clear();
        deviceCache?.ReleaseCachedValues(settings);
    }
}


public static class ObjectExtensions
{
    private static readonly MethodInfo CloneMethod = typeof(object).GetMethod("MemberwiseClone", BindingFlags.NonPublic | BindingFlags.Instance);

    public static bool IsPrimitive(this Type type)
    {
        if (type == typeof(string)) return true;
        return type.IsValueType && type.IsPrimitive;
    }

    public static object Copy(this object originalObject)
    {
        return InternalCopy(originalObject, new Dictionary<object, object>(new ReferenceEqualityComparer()));
    }

    private static object InternalCopy(object originalObject, IDictionary<object, object> visited)
    {
        if (originalObject == null) return null;
        Type typeToReflect = originalObject.GetType();
        if (IsPrimitive(typeToReflect)) return originalObject;
        if (visited.ContainsKey(originalObject)) return visited[originalObject];
        if (typeof(Delegate).IsAssignableFrom(typeToReflect)) return null;
        object cloneObject = CloneMethod.Invoke(originalObject, null);
        if (typeToReflect.IsArray)
        {
            Type arrayType = typeToReflect.GetElementType();
            if (IsPrimitive(arrayType) == false)
            {
                Array clonedArray = (Array)cloneObject;
                clonedArray.ForEach((array, indices) => array.SetValue(InternalCopy(clonedArray.GetValue(indices), visited), indices));
            }
        }
        visited.Add(originalObject, cloneObject);
        CopyFields(originalObject, visited, cloneObject, typeToReflect);
        RecursiveCopyBaseTypePrivateFields(originalObject, visited, cloneObject, typeToReflect);
        return cloneObject;
    }

    private static void RecursiveCopyBaseTypePrivateFields(object originalObject, IDictionary<object, object> visited, object cloneObject, Type typeToReflect)
    {
        if (typeToReflect.BaseType != null)
        {
            RecursiveCopyBaseTypePrivateFields(originalObject, visited, cloneObject, typeToReflect.BaseType);
            CopyFields(originalObject, visited, cloneObject, typeToReflect.BaseType, BindingFlags.Instance | BindingFlags.NonPublic, info => info.IsPrivate);
        }
    }

    private static void CopyFields(object originalObject, IDictionary<object, object> visited, object cloneObject, Type typeToReflect, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy, Func<FieldInfo, bool> filter = null)
    {
        foreach (FieldInfo fieldInfo in typeToReflect.GetFields(bindingFlags))
        {
            if (filter != null && filter(fieldInfo) == false) continue;
            if (IsPrimitive(fieldInfo.FieldType)) continue;
            object originalFieldValue = fieldInfo.GetValue(originalObject);
            object clonedFieldValue = InternalCopy(originalFieldValue, visited);
            fieldInfo.SetValue(cloneObject, clonedFieldValue);
        }
    }

    public static T Copy<T>(this T original)
    {
        return (T)Copy((object)original);
    }
}

public class ReferenceEqualityComparer : EqualityComparer<object>
{
    public override bool Equals(object x, object y)
    {
        return ReferenceEquals(x, y);
    }

    public override int GetHashCode(object obj)
    {
        if (obj == null) return 0;
        return obj.GetHashCode();
    }
}

public static class ArrayExtensions
{
    public static void ForEach(this Array array, Action<Array, int[]> action)
    {
        if (array.LongLength == 0) return;
        ArrayTraverse walker = new ArrayTraverse(array);
        do action(array, walker.Position);
        while (walker.Step());
    }
}

internal class ArrayTraverse
{
    public int[] Position;
    private int[] maxLengths;

    public ArrayTraverse(Array array)
    {
        maxLengths = new int[array.Rank];
        for (int i = 0; i < array.Rank; ++i)
        {
            maxLengths[i] = array.GetLength(i) - 1;
        }
        Position = new int[array.Rank];
    }

    public bool Step()
    {
        for (int i = 0; i < Position.Length; ++i)
        {
            if (Position[i] < maxLengths[i])
            {
                Position[i]++;
                for (int j = 0; j < i; j++)
                {
                    Position[j] = 0;
                }
                return true;
            }
        }
        return false;
    }
}