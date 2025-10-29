using System.Drawing.Imaging;
using ImRecall;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Extensions;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<ScreenshotProgram>();
        services.AddTransient<IImmichConfigProvider, ImmichConfigProvider>();
        services.AddTransient<IScreenshotService, ScreenshotService>();
        services.AddHttpClient<IImmichUploadService, ImmichUploadService>(); // (static (services, client) => client.BaseAddress = new Uri(services.GetRequiredService<ImmichAuth>().Url))
        services.AddTransient<IImmichUploadService, ImmichUploadService>();
        
        services.AddSingleton<ImmichAuth>(static services => services.GetRequiredService<IImmichConfigProvider>().GetAuth());
    });

using var host = builder.Build();
host.Run();

namespace ImRecall
{
}