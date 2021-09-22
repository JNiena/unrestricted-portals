using HarmonyLib;

namespace UnrestrictedPortals.Patches
{
    [HarmonyPatch(typeof(Container), "Interact")]
    public static class ContainerInteract
    {
        private static void Prefix(ref Container __instance)
        {
            if (__instance.GetInventory() != null)
            {
                Plugin.TeleportationManager.Update(__instance.GetInventory().GetAllItems());
            }
        }
    }
}