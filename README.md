# NEO-TWEWY-Randomizer
This is a Randomizer for NEO: The World Ends With You.

![Picture showing the application](https://i.imgur.com/IdOE9bS.png "The Randomizer")<br>

The most recent version can be downloaded from the releases page. Supported features are described further down.

## Requirements
As of the latest version, there is only one file needed for the randomization to work properly (4017d8fc.unity3d). To obtain this file, you can use Ryujinx or yuzu to extract the game data. You can also use any other tool that extracts the game files from your legally acquired ROM (hactool, etc.).

### Ryujinx
Simply right-click the ROM in your ROM list, then select Extract Data, then RomFS.<br>
![Picture showing where to extract on Ryujinx](https://i.imgur.com/dQgjGUb.png "Extracting on Ryujinx")<br>

### yuzu
Simply right-click the ROM in your ROM list, then select Dump RomFS, then Dump RomFS.<br>
![Picture showing where to extract on yuzu](https://i.imgur.com/EWi5YO5.png "Extracting on yuzu")<br>

In all cases, the file will be found at \<directory\>/Data/StreamingAssets/Assets/4017d8fc.unity3d. After it has been randomized, you can use the generated file and follow the many tutorials online for modding your Nintendo Switch games. Make sure not to forget to replicate the folder structure (Data/StreamingAssets/Assets/4017d8fc.unity3d).

## Platform Support
The Randomizer is currently being made for the Nintendo Switch release of the game. It may or may not also work out of the box for other versions (PS4 and PC). That all depends on how mods work on those other versions.

## Features

### Currently working
- Random Pin Drops, with Random Drop Chance
  - Pins dropped by Noise can be either shuffled or randomized.
    - "Limited" Pins (Axion, Dilaton, Dibaryon, and Sfermion) can also be included.
    - It is possible to only change drops for specific difficulties.
  - Drop Rates for these Pins can be randomized.
    - It is possible to only change rates for specific difficulties.
    - There is an option to "weigh" each difficulty so that pins are rarer or more common at different difficulties.
- Random Story Rewards
  - Pins, Yen Pins, and Gem Pins can all be either shuffled or randomized to new pins.
  - Secret Reports can be shuffled.
  - Friendship Point amounts can be either shuffled or randomized to have a set total (currently always 159).
  - The locations of each of these categories can also be shuffled so that, for example, a Yen Pin could be replaced by FP.
- Random Pin Stats
  - Power, Limit, Reboot, Boot, Recover, Charge, Sell Price, Affinity, Max Level, Brand, Uber Status, Ability, Growth Speed, and Evolution are all data that can be randomized.
    - Most stats have predetermined ranges that cannot be edited at this time.
  - Character-specific evolutions can be removed.

### Planned
- Shuffled Social Network Rewards
- Random Thread Stats
- Random Shops
- Random Noise Encounters
- Random Food Stats
- Random Music
- Random Restaurants
- Available at start dialogue and cutscene skipping
- Maybe more...

## Bugs
If you find any bugs please let me know! You can use the issues tab of the repository. **Make sure to include your seed and the settings you used (if applicable). This will help tremendously in figuring out what is wrong.**

## Dependencies
This project uses the [AssetsTools.NET](https://github.com/nesrak1/AssetsTools.NET/) library to easily manipulate Unity Asset Bundles.<br>
This project uses the [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) library to easily manipulate the JSON files containing the game data.
