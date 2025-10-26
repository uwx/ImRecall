using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using Windows.Graphics.Display;
using Windows.Win32;
using Windows.Win32.Foundation;
using ImRecall;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Extensions;
using SixLabors.ImageSharp.PixelFormats;
using GraphicsCaptureItem = Windows.Graphics.Capture.GraphicsCaptureItem;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureApi((context, services, options) =>
    {
        // The type of token here depends on the api security specifications
        // Available token types are ApiKeyToken, BasicToken, BearerToken, HttpSigningToken, and OAuthToken.
        // BearerToken token = new("<your token>");
        // options.AddTokens(token);
        
        services.AddSingleton<ImmichAuth>(static services => services.GetRequiredService<IImmichConfigProvider>().GetAuth());

        services.AddSingleton<TokenContainer<ApiKeyToken>>(static services => new TokenContainer<ApiKeyToken>([
            new ApiKeyToken(services.GetRequiredService<ImmichAuth>().Key, ClientUtils.ApiKeyHeader.X_api_key)
        ]));
        services.AddSingleton<TokenContainer<BearerToken>>(static services => new TokenContainer<BearerToken>([
            new BearerToken(services.GetRequiredService<ImmichAuth>().Key)
        ]));

        // optionally choose the method the tokens will be provided with, default is RateLimitProvider
        options.UseProvider<RateLimitProvider<BearerToken>, BearerToken>();

        options.ConfigureJsonOptions(static jsonOptions =>
        {
            // your custom converters if any
        });

        options.AddApiHttpClients(
            static (services, client) =>
            {
                // client configuration
                client.BaseAddress = new Uri(services.GetRequiredService<ImmichAuth>().Url);
            },
            static builder =>
            {
                builder
                    .AddRetryPolicy(0)
                    .AddTimeoutPolicy(TimeSpan.FromSeconds(5))
                    .AddCircuitBreakerPolicy(10, TimeSpan.FromSeconds(30));
                // add whatever middleware you prefer
            }
        );
    })
    .ConfigureServices(services =>
    {
        services.AddHostedService<ScreenshotProgram>();
        services.AddTransient<IImmichConfigProvider, ImmichConfigProvider>();
        services.AddTransient<IScreenshotService, ScreenshotService>();
        services.AddTransient<IImmichUploadService, ImmichUploadService>();
    });

using var host = builder.Build();
host.Run();

namespace ImRecall
{
    public partial class ScreenshotProgram(IScreenshotService screenshotService, IImmichUploadService immichUploadService) : IHostedService, IDisposable
    {
        [GeneratedRegex(
            """
            [\0-\u001F"*/:<>?\\\|]
            """,
            RegexOptions.Compiled | RegexOptions.CultureInvariant
        )]
        private static partial Regex InvalidFileNameCharsRegex { get; }

        // TODO remove disconnected displays from here
        private Dictionary<string, Bitmap> lastBitmapByDisplayName = new();
        
        private static string SanitizeFileName(string fileName)
        {
            return InvalidFileNameCharsRegex.Replace(fileName, "_");
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                foreach (var (index, displayId) in DisplayServices.FindAll().Index())
                {
                    var captureItem = GraphicsCaptureItem.TryCreateFromDisplayId(displayId);
                    if (captureItem == null)
                    {
                        Console.WriteLine($"[{index}] WindowsCapture was provided with a invalid item (null) for Windows.Graphics.Capture to capture window... :(");
                        continue;
                    }

                    var bitmap = await screenshotService.CaptureScreenshotAsync(captureItem);
                    if (bitmap == null)
                    {
                        Console.WriteLine($"[{index}] Failed to capture screenshot.");
                        continue;
                    }

                    try
                    {
                        if (!lastBitmapByDisplayName.TryGetValue(captureItem.DisplayName, out var lastBitmap) ||
                            !AreBitmapsSimilar(bitmap, lastBitmap))
                        {
                            lastBitmap?.Dispose();
                            lastBitmapByDisplayName[captureItem.DisplayName] = bitmap;

                            // Save the tonemapped SDR image
                            // var stopwatch = Stopwatch.StartNew();
                            // bitmap.Save($"{SanitizeFileName(captureItem.DisplayName)}-{SanitizeFileName(GetForegroundWindowName())}-{DateTimeOffset.Now:yyyy-MM-dd_HH-mm-ss}.png", ImageFormat.Png);
                            // stopwatch.Stop();
                            // Console.WriteLine($"[{index}] Image saved in {stopwatch.ElapsedMilliseconds} ms.");
                            
                            // Upload to Immich
                            var stopwatch = Stopwatch.StartNew();
                            await immichUploadService.UploadAsync(
                                $"{SanitizeFileName(captureItem.DisplayName)}-{SanitizeFileName(GetForegroundWindowName())}-{DateTimeOffset.Now:yyyy-MM-dd_HH-mm-ss}.png",
                                bitmap,
                                cancellationToken
                            );
                            stopwatch.Stop();
                            Console.WriteLine($"[{index}] Image uploaded in {stopwatch.ElapsedMilliseconds} ms.");
                        }
                        else
                        {
                            bitmap.Dispose();
                        }
                    }
                    catch
                    {
                        bitmap.Dispose();
                        throw;
                    }

                    continue;

                    static bool AreBitmapsSimilar(Bitmap currentBitmap, Bitmap lastBitmap)
                    {
                        using var currentImg = LibraryIndependentImage<Bgr24>.FromBitmap(currentBitmap);
                        using var lastImg = LibraryIndependentImage<Bgr24>.FromBitmap(lastBitmap);
                        return SsimUtils.IsSimilar(currentImg, lastImg);
                    }
                }

                await Task.Delay(TimeSpan.FromSeconds(3), cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private static string GetForegroundWindowName()
        {
            var hwnd = PInvoke.GetForegroundWindow();
            if (hwnd != HWND.Null)
            {
                Span<char> title = stackalloc char[256];
                var length = PInvoke.GetWindowText(hwnd, title);
                if (length > 0)
                {
                    return new string(title[..length]);
                }
            }
            return "Desktop";
        }

        public void Dispose()
        {
            foreach (var bitmap in lastBitmapByDisplayName.Values)
            {
                bitmap.Dispose();
            }
        }
    }
}