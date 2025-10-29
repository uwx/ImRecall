using ImRecall;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Environment.SetEnvironmentVariable("MICROSOFT_WINDOWSAPPRUNTIME_BASE_DIRECTORY", AppContext.BaseDirectory);
    
var builder = Host.CreateApplicationBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

services.AddHostedService<ScreenshotProgram>();
services.AddTransient<IImmichConfigProvider, ImmichConfigProvider>();
services.AddTransient<IScreenshotService, ScreenshotService>();
services.AddTransient<IImmichUploadService, ImmichUploadService>();

services.AddSingleton<ImmichAuth>(static services => services.GetRequiredService<IImmichConfigProvider>().GetAuth());

var imRecallOptions = new ImRecallOptions();
configuration.Bind(ImRecallOptions.ImRecall, imRecallOptions);
services.AddSingleton(imRecallOptions);

using var host = builder.Build();
await host.RunAsync();