using HarmonyLib;

namespace UnrestrictedPortals.Patches
{
    [HarmonyPatch(typeof(ObjectDB), "Awake")]
    public static class ObjectDBAwake
    {
        private static void Postfix()
        {
            foreach (var gameObject in ObjectDB.instance.m_items)
            {
                Plugin.TeleportationManager.OriginalItems.Add(gameObject.GetComponentInChildren<ItemDrop>().m_itemData);
            }
        }
    }
}