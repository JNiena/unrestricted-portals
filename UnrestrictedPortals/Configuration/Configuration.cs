using System.IO;
using BepInEx;

namespace UnrestrictedPortals.Configuration
{
    public class Configuration
    {
        public Settings Settings;
        private Settings DefaultDefaultSettings;
        private string Path;

        public Configuration(string path, Settings defaultSettings)
        {
            Path = System.IO.Path.Combine(Paths.ConfigPath, path);
            DefaultDefaultSettings = defaultSettings;
        }

        public bool Load()
        {
            try
            {
                if (!File.Exists(Path) || File.ReadAllText(Path) == string.Empty)
                {
                    File.WriteAllText(Path, Yaml.Serialize(DefaultDefaultSettings));
                }
                Settings = Yaml.Deserialize<Settings>(File.ReadAllText(Path));
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}