using System.Collections.Generic;

namespace UnrestrictedPortals
{
    public class TeleportationManager
    {
        public List<ItemDrop.ItemData> OriginalItems = new List<ItemDrop.ItemData>();

        public void Update(List<ItemDrop.ItemData> items)
        {
            if (items == null || items.Count == 0 || Plugin.Configuration.Settings.Items == null || Plugin.Configuration.Settings.Items.Count == 0)
            {
                return;
            }
            if (Plugin.Configuration.Settings.AllTeleportable && !Plugin.Configuration.Settings.NoneTeleportable)
            {
                SetAllItemsTeleportable(items, true);
            }
            else if (!Plugin.Configuration.Settings.AllTeleportable && Plugin.Configuration.Settings.NoneTeleportable)
            {
                SetAllItemsTeleportable(items, false);
            }
            else
            {
                SetAllItemsDefaultTeleportable(items);
            }
            SetAllItemsTeleportableFrom(items, Plugin.Configuration.Settings.Items);
        }

        private void SetAllItemsTeleportable(List<ItemDrop.ItemData> inventoryItems, bool teleportable)
        {
            foreach (var inventoryItem in inventoryItems)
            {
                inventoryItem.m_shared.m_teleportable = teleportable;
            }
        }

        private void SetAllItemsDefaultTeleportable(List<ItemDrop.ItemData> inventoryItems)
        {
            foreach (var inventoryItem in inventoryItems)
            {
                foreach (var originalItem in OriginalItems)
                {
                    if (inventoryItem.m_shared.m_name == originalItem.m_shared.m_name)
                    {
                        inventoryItem.m_shared.m_teleportable = originalItem.m_shared.m_teleportable;
                    }
                }
            }
        }

        private void SetAllItemsTeleportableFrom(List<ItemDrop.ItemData> inventoryItems, Dictionary<string, bool> items)
        {
            foreach (var inventoryItem in inventoryItems)
            {
                foreach (var entryItem in items)
                {
                    if (EquivalentTo(inventoryItem, entryItem.Key))
                    {
                        inventoryItem.m_shared.m_teleportable = entryItem.Value;
                    }
                }
            }
        }

        private bool EquivalentTo(ItemDrop.ItemData itemData, string identifier)
        {
            return identifier.Replace("$", "") == itemData.m_shared.m_name.Replace("$", "") || identifier == itemData.m_dropPrefab.name;
        }
    }
}