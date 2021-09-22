using HarmonyLib;

namespace UnrestrictedPortals.Patches
{
    [HarmonyPatch(typeof(Inventory), "IsTeleportable")]
    public static class InventoryIsTeleportable
    {
        private static void Prefix()
        {
            Plugin.TeleportationManager.Update(Player.m_localPlayer.GetInventory().GetAllItems());
        }
    }
}