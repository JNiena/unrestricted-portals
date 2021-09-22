using HarmonyLib;

namespace UnrestrictedPortals.Patches
{
    [HarmonyPatch(typeof(InventoryGui), "Show")]
    public static class InventoryShow
    {
        private static void Postfix()
        {
            Plugin.TeleportationManager.Update(Player.m_localPlayer.GetInventory().GetAllItems());
        }
    }
}