using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace UnrestrictedPortals.Configuration
{
    public static class Yaml
    {
        private static IDeserializer Deserializer = new DeserializerBuilder().WithNamingConvention(PascalCaseNamingConvention.Instance).Build();
        private static ISerializer Serializer = new Serializer();

        public static string Serialize(object data)
        {
            return Serializer.Serialize(data);
        }

        public static T Deserialize<T>(string data)
        {
            return Deserializer.Deserialize<T>(data);
        }
    }
}