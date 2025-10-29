using ImRecall;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<ScreenshotProgram>();
        services.AddTransient<IImmichConfigProvider, ImmichConfigProvider>();
        services.AddTransient<IScreenshotService, ScreenshotService>();
        services.AddTransient<IImmichUploadService, ImmichUploadService>();
        
        services.AddSingleton<ImmichAuth>(static services => services.GetRequiredService<IImmichConfigProvider>().GetAuth());
    });

using var host = builder.Build();
host.Run();