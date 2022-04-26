# NEO-TWEWY-Randomizer
This is a Randomizer for NEO: The World Ends With You.

![Picture showing the application](https://i.imgur.com/e5sp2lp.png "The Randomizer")<br>

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
  - There are various different ways to do this randomization.
- Random Pin Stats
  - A good amount of the stats have pre-determined ranges, this might change in the future.

### Planned
- Shuffled Social Network Rewards
- Random Thread Stats
- Random Shops
- Random Noise Encounters
- Random Food Stats
- Random Music
- Random Restaurants
- Random Story Progression Pins
- Available at start dialogue and cutscene skipping
- Maybe more...

## Bugs
If you find any bugs please let me know! You can use the issues tab of the repository. **Make sure to include your seed and the settings you used (if applicable). This will help tremendously in figuring out what is wrong.**

## Dependencies
This project uses the [AssetsTools.NET](https://github.com/nesrak1/AssetsTools.NET/) library to easily manipulate Unity Asset Bundles.<br>
This project uses the [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) library to easily manipulate the JSON files containing the game data.
