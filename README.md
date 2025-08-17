# Never Ending Game Mod for CloverPit

![.NET Version](https://img.shields.io/badge/.NET%20Framework-4.7.2-blue)
![BepInEx Version](https://img.shields.io/badge/BepInEx-5.4.23.3-blue)
![Mod Version](https://img.shields.io/badge/version-1.0.0-green)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

This mod extends gameplay in CloverPit Demo by providing configurable deadlines and an infinite mode option.

## Features
- Customizable maximum deadlines (0-999999)
- Infinite mode toggle
- Live configuration via config file
- Harmony-based patching for seamless integration

## Prerequisites
- Steam installation of [CloverPit Demo](https://store.steampowered.com/app/2692780/CloverPit/)
- .NET Framework 4.7.2

## Installation Guide

### Step 1: Install BepInEx
1. Download **[BepInEx v5.4.23.3](https://github.com/BepInEx/BepInEx/releases/tag/v5.4.23.3)**
2. Extract the archive contents to your game directory:
```
...\Program Files (x86)\Steam\steamapps\common\CloverPit Demo
```
- Copy **all files EXCEPT** `changelog.txt`
- Your directory should now contain a `BepInEx` folder

### Step 2: Initialize BepInEx
1. Launch the game through Steam
2. Wait until main menu appears
3. Exit the game

### Step 3: Install Mod
1. Download `NeverEndingGame.dll` from [Releases](../../releases)
2. Place the DLL in plugins folder:
```
...\Program Files (x86)\Steam\steamapps\common\CloverPit Demo\BepInEx\plugins\NeverEndingGame.dll
```

### Step 4: Configure Mod
1. Launch then exit the game again
2. Edit the generated config file:
```
...\Program Files (x86)\Steam\steamapps\common\CloverPit Demo\BepInEx\config\com.mikhaelo.cloverpitneverendinggame.cfg
```

3. Adjust values using any text editor:
```ini
## Settings file was created by plugin CloverPit Never Ending Game v1.0.0
## Plugin GUID: com.mikhaelo.cloverpitneverendinggame

[General]

## Maximum number of deadlines
# Setting type: Int32
# Acceptable values: 0 to 999999
MaxDeadlines = 5

## Endless game mode
# Setting type: Boolean
InfiniteMode = false
```

## Configuration Options
| Parameter       | Type    | Default | Description                     |
|-----------------|---------|---------|---------------------------------|
| MaxDeadlines    | Integer | 5       | Maximum deadlines (0-100)       |
| InfiniteMode    | Boolean | false   | Enable infinite gameplay mode   |

## Building from Source
1. Clone repository:
```bash
git clone https://github.com/mikhael-coder/NeverEndingGame-CloverPit-Mode.git
```
2. Open `NeverEndingGame.sln` in Visual Studio 2022
3. Set build configuration to **Release**
4. Add reference paths to:
   - Game assemblies: `CloverPit_Data/Managed`
   - BepInEx core: `BepInEx/core`
5. Build solution (Output: `bin/Release/NeverEndingGame.dll`)

## Technical Details
- **Patch Method:** `GameplayData.GetRewardBoxDebtIndex`
- **Hook Type:** Harmony Prefix
- **Dependencies:**
  - BepInEx 5.4.23
  - HarmonyLib
  - UnityEngine.CoreModule

## Troubleshooting
1. **Mod not loading:**
   - Verify BepInEx installation
   - Check `LogOutput.log` for errors
2. **Configuration not applying:**
   - Ensure game was launched after mod installation
   - Verify config file permissions
3. **Game crashes:**
   - Remove other mods to test compatibility
   - Reinstall clean BepInEx version

## License
Distributed under the MIT License. See `LICENSE` for more information.

---
> **Note:** This mod is not affiliated with CloverPit developers. Use at your own risk.
