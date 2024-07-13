# Summary

This mod is for those who think the process of traveling from one end of the world to another just to transport some ore in [Valheim](https://store.steampowered.com/app/892970/Valheim/) is a waste of time.

Unrestricted Portals is a client-side mod for players that enables the transfer of any item through portals. This mod offers extensive customization options, giving players the ability to add or remove item restrictions and even apply multipliers to specific items as desired.

If you find the idea of freely transporting all items through portals to be too overpowered, you can adjust the configuration file to manage the limitations for each item.

# Installation

1. Follow the installation guide at [BepInExPack Valheim](https://valheim.thunderstore.io/package/denikson/BepInExPack_Valheim/).
2. Download the mod at [Unrestricted Portals](https://www.nexusmods.com/valheim/mods/61?tab=files)
3. Unzip the downloaded file and move the folder into `﻿<Steam Location>\steamapps\common\Valheim\BepInEx\plugin`.

The next time you launch your game, the mod will be active. To turn it off, simply delete it from the mods folder or adjust the configuration settings.

# Usage

To refresh the configuration, use the command `﻿/reload`

By default, the mod allows you to transport all items that were previously restricted through portals. To change this, modify the configuration file in `﻿<Steam Location>\steamapps\common\Valheim\BepInEx\config\UnrestrictedPortals.yml`

### Enable Teleportation:

```
# This will enable teleportation for all items.
AllTeleportable: True
NoneTeleportable: False
```

### Disable Teleportation:

```
# This will disable teleportation for all items.
AllTeleportable: False
NoneTeleportable: True
```

### Use Vanilla Settings:

```
# This will use vanilla teleportation settings.
AllTeleportable: False
NoneTeleportable: False
```

### Toggle Teleportation (Single Items):

```
# This allow tin ore and copper ore to be teleported.
TinOre: True
CopperOre: True
```

**Item names need to use either token or prefab syntax. You can find a list those [here](https://valheim-modding.github.io/Jotunn/data/objects/item-list.html).**
