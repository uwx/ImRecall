using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ImRecall
{
    public interface IImmichConfigProvider
    {
        public ImmichAuth GetAuth();
    }
    
    public class ImmichConfigProvider : IImmichConfigProvider
    {
        private readonly IDeserializer _deserializer = new StaticDeserializerBuilder(new YamlStaticContext())
            .WithNamingConvention(UnderscoredNamingConvention.Instance)
            .Build();
        
        public ImmichAuth GetAuth()
        {
            using var reader = File.OpenText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".config", "immich", "auth.yml"));
            return _deserializer.Deserialize<ImmichAuth>(reader);
        }
    }
}