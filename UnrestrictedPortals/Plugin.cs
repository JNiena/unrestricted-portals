using System.Collections.Generic;
using System.Reflection;
using BepInEx;
using HarmonyLib;

namespace UnrestrictedPortals
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGUID = "com.github.jniena";
        public const string PluginName = "UnrestrictedPortals";
        public const string PluginVersion = "1.4.2";

        public static Configuration.Configuration Configuration;
        public static TeleportationManager TeleportationManager;

        private Harmony Harmony;

        public Plugin()
        {
            Harmony = new Harmony("com.github.jniena.unrestrictedportals");
        }

        private void Awake()
        {
            if (!LoadConfiguration() || !LoadPatches())
            {
                return;
            }
            TeleportationManager = new TeleportationManager();
        }

        private bool LoadConfiguration()
        {
            Logger.LogMessage("Loading configuration...");
            Configuration = new Configuration.Configuration("UnrestrictedPortals.yml", new Configuration.Settings
            {
                AllTeleportable = true,
                NoneTeleportable = false,
                Items = new Dictionary<string, bool>
                {
                    {"TinOre", true},
                    {"CopperOre", true}
                }
            });
            if (Configuration.Load())
            {
                Logger.LogMessage("Successfully loaded configuration.");
                return true;
            }
            Logger.LogFatal("Failed to load configuration.");
            return false;
        }

        private bool LoadPatches()
        {
            Logger.LogMessage("Loading patches...");
            try
            {
                Harmony.PatchAll(Assembly.GetExecutingAssembly());
                Logger.LogMessage("Successfully loaded patches.");
                return true;
            }
            catch
            {
                Logger.LogInfo("Failed to load patches.");
                return false;
            }
        }
    }
}