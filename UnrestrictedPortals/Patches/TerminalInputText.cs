using HarmonyLib;

namespace UnrestrictedPortals.Patches
{
    [HarmonyPatch(typeof(Terminal), "InputText")]
    public static class TerminalInputText
    {
        private static bool Prefix(ref Terminal __instance)
        {
            if (__instance.m_input.text == "reload")
            {
                Plugin.Configuration.Load();
                __instance.AddString("Configuration reloaded.");
                return false;
            }
            return true;
        }
    }
}