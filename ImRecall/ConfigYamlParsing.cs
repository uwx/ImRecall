using YamlDotNet.Serialization;

namespace ImRecall;

[YamlStaticContext]
[YamlSerializable(typeof(ImmichAuth))] // Generate for WeatherForecast type
public partial class YamlStaticContext;

public class ImmichAuth
{
    public string Url { get; set; } = null!;
    public string Key { get; set; } = null!;
}