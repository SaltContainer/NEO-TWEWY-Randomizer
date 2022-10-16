using NEO_TWEWY_Randomizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEO_TWEWY_Randomizer
{
    class RandomizationLogger
    {
        private string log;

        public RandomizationLogger()
        {
            log = "";
        }

        public void AddToLog(string logString)
        {
            log += logString;
        }

        #region Settings
        public void LogSettings(RandomizationSettings settings)
        {
            AddToLog("========================================\nNEO: THE WORLD ENDS WITH YOU RANDOMIZATION SETTINGS\n\n");
            AddToLog(string.Format("Settings String:\n{0}\n\n", settings.GenerateSettingsString()));

            #region Noise Drops
            AddToLog("NOISE DROPPED PINS\n");
            string droppedPinsChoice = "";
            switch (settings.NoiseDrops.DropTypeChoice)
            {
                case NoiseDropType.Unchanged: droppedPinsChoice = "Unchanged"; break;
                case NoiseDropType.ShuffleCompletely: droppedPinsChoice = "Shuffle (Completely)"; break;
                case NoiseDropType.ShuffleSets: droppedPinsChoice = "Shuffle (Sets)"; break;
                case NoiseDropType.RandomCompletely: droppedPinsChoice = "Random (Completely)"; break;
                case NoiseDropType.RandomAllPins: droppedPinsChoice = "Random (All Pins)"; break;
            }
            AddToLog(string.Format("Dropped Pins: {0}\n", droppedPinsChoice));
            if (settings.NoiseDrops.DropTypeChoice != NoiseDropType.Unchanged)
            {
                AddToLog(string.Format("Limited Pins: {0}\n", settings.NoiseDrops.IncludeLimitedPins ? "Yes" : "No"));
                List<string> dropTypeDifficulties = new List<string>();
                if (settings.NoiseDrops.DropTypeDifficulties.Contains(Difficulties.Easy)) dropTypeDifficulties.Add("Easy");
                if (settings.NoiseDrops.DropTypeDifficulties.Contains(Difficulties.Normal)) dropTypeDifficulties.Add("Normal");
                if (settings.NoiseDrops.DropTypeDifficulties.Contains(Difficulties.Hard)) dropTypeDifficulties.Add("Hard");
                if (settings.NoiseDrops.DropTypeDifficulties.Contains(Difficulties.Ultimate)) dropTypeDifficulties.Add("Ultimate");
                AddToLog(string.Format("Difficulties: {0}", dropTypeDifficulties.Count() > 0 ? string.Join(", ", dropTypeDifficulties) : "None"));
                AddToLog("\n");
            }
            AddToLog("\n");

            AddToLog("NOISE DROP RATE\n");
            string dropRateChoice = "";
            switch (settings.NoiseDrops.DropRateChoice)
            {
                case NoiseDropRate.Unchanged: dropRateChoice = "Unchanged"; break;
                case NoiseDropRate.RandomCompletely: dropRateChoice = "Random (Completely)"; break;
                case NoiseDropRate.RandomWeighted: dropRateChoice = "Random (Weighted)"; break;
            }
            AddToLog(string.Format("Drop Rate: {0}\n", dropRateChoice + (settings.NoiseDrops.DropRateChoice != NoiseDropRate.Unchanged ? string.Format(" ({0:F2}% - {1:F2}%)", settings.NoiseDrops.MinimumDropRate, settings.NoiseDrops.MaximumDropRate) : "")));
            if (settings.NoiseDrops.DropRateChoice != NoiseDropRate.Unchanged)
            {
                List<string> dropRateDifficulties = new List<string>();
                if (settings.NoiseDrops.DropRateDifficulties.Contains(Difficulties.Easy)) dropRateDifficulties.Add(settings.NoiseDrops.DropRateChoice == NoiseDropRate.RandomWeighted ? string.Format("Easy (Weight {0})", settings.NoiseDrops.DropRateWeights[0]) : "Easy");
                if (settings.NoiseDrops.DropRateDifficulties.Contains(Difficulties.Normal)) dropRateDifficulties.Add(settings.NoiseDrops.DropRateChoice == NoiseDropRate.RandomWeighted ? string.Format("Normal (Weight {0})", settings.NoiseDrops.DropRateWeights[1]) : "Normal");
                if (settings.NoiseDrops.DropRateDifficulties.Contains(Difficulties.Hard)) dropRateDifficulties.Add(settings.NoiseDrops.DropRateChoice == NoiseDropRate.RandomWeighted ? string.Format("Hard (Weight {0})", settings.NoiseDrops.DropRateWeights[2]) : "Hard");
                if (settings.NoiseDrops.DropRateDifficulties.Contains(Difficulties.Ultimate)) dropRateDifficulties.Add(settings.NoiseDrops.DropRateChoice == NoiseDropRate.RandomWeighted ? string.Format("Ultimate (Weight {0})", settings.NoiseDrops.DropRateWeights[3]) : "Ultimate");
                AddToLog(string.Format("Difficulties: {0}", string.Join(", ", dropRateDifficulties)));
                AddToLog("\n");
            }
            AddToLog("\n");
            #endregion

            #region Pin Stats
            AddToLog("PIN STATS\n");
            AddToLog("Randomized General Stats: ");
            List<string> generalPinStats = new List<string>();
            if (settings.PinStats.Power) generalPinStats.Add("Power");
            if (settings.PinStats.PowerScaling) generalPinStats.Add("Power Scaling");
            if (settings.PinStats.Limit) generalPinStats.Add("Limit");
            if (settings.PinStats.LimitScaling) generalPinStats.Add("Limit Scaling");
            if (settings.PinStats.Reboot) generalPinStats.Add("Reboot");
            if (settings.PinStats.RebootScaling) generalPinStats.Add("Reboot Scaling");
            if (settings.PinStats.Boot) generalPinStats.Add("Boot");
            if (settings.PinStats.BootScaling) generalPinStats.Add("Boot Scaling");
            if (settings.PinStats.Recover) generalPinStats.Add("Recover");
            if (settings.PinStats.RecoverScaling) generalPinStats.Add("Recover Scaling");
            if (settings.PinStats.Charge) generalPinStats.Add("Charge");
            if (settings.PinStats.Sell) generalPinStats.Add("Sell Price");
            if (settings.PinStats.SellScaling) generalPinStats.Add("Sell Price Scaling");
            if (settings.PinStats.Affinity) generalPinStats.Add("Affinity");
            if (settings.PinStats.MaxLevel) generalPinStats.Add("Max Level");
            AddToLog(generalPinStats.Count > 0 ? string.Join(", ", generalPinStats) : "None");
            AddToLog("\n");
            string brandChoice = "";
            switch (settings.PinStats.BrandChoice)
            {
                case PinBrand.Unchanged: brandChoice = "Unchanged"; break;
                case PinBrand.Shuffle: brandChoice = "Shuffle"; break;
                case PinBrand.RandomCompletely: brandChoice = "Random (Completely)"; break;
                case PinBrand.RandomUniform: brandChoice = "Random (Uniform)"; break;
            }
            AddToLog(string.Format("Brand: {0}\n", brandChoice));
            AddToLog(string.Format("Uber Pins: {0}\n", settings.PinStats.Uber ? string.Format("Random ({0}%)", settings.PinStats.UberPercentage) : "Unchanged"));
            string abilityChoice = "";
            switch (settings.PinStats.AbilityChoice)
            {
                case PinAbility.Unchanged: abilityChoice = "Unchanged"; break;
                case PinAbility.Shuffle: abilityChoice = "Shuffle"; break;
                case PinAbility.RandomCompletely: abilityChoice = "Random (Completely)"; break;
            }
            AddToLog(string.Format("Pin Abilities: {0}\n", abilityChoice + (settings.PinStats.AbilityChoice == PinAbility.RandomCompletely ? string.Format(" ({0}%)", settings.PinStats.UberPercentage) : "")));
            string growthChoice = "";
            switch (settings.PinStats.GrowthChoice)
            {
                case PinGrowthRandomization.Unchanged: growthChoice = "Unchanged"; break;
                case PinGrowthRandomization.RandomCompletely: growthChoice = "Random (Completely)"; break;
                case PinGrowthRandomization.RandomUniform: growthChoice = "Random (Uniform)"; break;
                case PinGrowthRandomization.Specific: growthChoice = "Specific Growth Speed"; break;
            }
            AddToLog(string.Format("Growth Speed: {0}\n", growthChoice + (settings.PinStats.GrowthChoice == PinGrowthRandomization.Specific ? string.Format(" ({0})", FileConstants.ItemNames.GrowthRates.Where(g => g.Id == (int) settings.PinStats.GrowthSpecific).First().Name) : "")));
            string evoChoice = "";
            switch (settings.PinStats.EvolutionChoice)
            {
                case PinEvolution.Unchanged: evoChoice = "Unchanged"; break;
                case PinEvolution.RandomExisting: evoChoice = "Random (Existing)"; break;
                case PinEvolution.RandomCompletely: evoChoice = "Random (Completely)"; break;
            }
            AddToLog(string.Format("Evolution: {0}\n", evoChoice + (settings.PinStats.EvolutionChoice == PinEvolution.RandomCompletely ? string.Format(" ({0}%)", settings.PinStats.EvoPercentage) : "")));
            if (settings.PinStats.EvolutionChoice != PinEvolution.Unchanged) AddToLog(string.Format("Force Same-Brand Evolutions: {0}\n", settings.PinStats.EvoForceBrand ? "Yes" : "No"));
            AddToLog(string.Format("Remove Character-Specific Evolutions: {0}\n", settings.PinStats.RemoveCharaEvos ? "Yes" : "No"));
            AddToLog("\n");
            #endregion

            #region Story Rewards
            AddToLog("STORY REWARDS\n");
            string storyPinChoice = "";
            switch (settings.StoryRewards.PinChoice)
            {
                case StoryPin.Unchanged: storyPinChoice = "Unchanged"; break;
                case StoryPin.Shuffle: storyPinChoice = "Shuffle"; break;
                case StoryPin.Random: storyPinChoice = "Random"; break;
            }
            AddToLog(string.Format("Pin Rewards: {0}\n", storyPinChoice));
            if (settings.StoryRewards.PinChoice != StoryPin.Unchanged) AddToLog(string.Format("\tInclude Limited Pins: {0}\n", settings.StoryRewards.GlobalShuffleChoice == StoryGlobalShuffle.Shuffle ? "Yes" : "No"));
            string storyYenChoice = "";
            switch (settings.StoryRewards.YenChoice)
            {
                case StoryYen.Unchanged: storyYenChoice = "Unchanged"; break;
                case StoryYen.Shuffle: storyYenChoice = "Shuffle"; break;
                case StoryYen.Random: storyYenChoice = "Random"; break;
            }
            AddToLog(string.Format("Yen Pin Rewards: {0}\n", storyYenChoice));
            string storyGemChoice = "";
            switch (settings.StoryRewards.GemChoice)
            {
                case StoryGem.Unchanged: storyGemChoice = "Unchanged"; break;
                case StoryGem.Shuffle: storyGemChoice = "Shuffle"; break;
                case StoryGem.Random: storyGemChoice = "Random"; break;
            }
            AddToLog(string.Format("Gem Pin Rewards: {0}\n", storyGemChoice));
            string storyFPChoice = "";
            switch (settings.StoryRewards.FPChoice)
            {
                case StoryFP.Unchanged: storyFPChoice = "Unchanged"; break;
                case StoryFP.Shuffle: storyFPChoice = "Shuffle"; break;
                case StoryFP.RandomFixedTotal: storyFPChoice = "Random (Fixed Total)"; break;
            }
            AddToLog(string.Format("Friendship Point Rewards: {0}\n", storyFPChoice));
            string storyReportChoice = "";
            switch (settings.StoryRewards.ReportChoice)
            {
                case StoryReport.Unchanged: storyReportChoice = "Unchanged"; break;
                case StoryReport.Shuffle: storyReportChoice = "Shuffle"; break;
            }
            AddToLog(string.Format("Secret Report Rewards: {0}\n", storyReportChoice));
            AddToLog(string.Format("Shuffle Reward Locations: {0}\n", settings.StoryRewards.GlobalShuffleChoice == StoryGlobalShuffle.Shuffle ? "Yes" : "No"));
            if (settings.StoryRewards.GlobalShuffleChoice == StoryGlobalShuffle.Shuffle)
            {
                List<string> shuffledStoryRewards = new List<string>();
                if (settings.StoryRewards.ShuffledStoryRewards.Contains(StoryRewards.Pins)) shuffledStoryRewards.Add("Pins");
                if (settings.StoryRewards.ShuffledStoryRewards.Contains(StoryRewards.Yen)) shuffledStoryRewards.Add("Yen Pins");
                if (settings.StoryRewards.ShuffledStoryRewards.Contains(StoryRewards.Gems)) shuffledStoryRewards.Add("Gem Pins");
                if (settings.StoryRewards.ShuffledStoryRewards.Contains(StoryRewards.FP)) shuffledStoryRewards.Add("Friendship Points");
                if (settings.StoryRewards.ShuffledStoryRewards.Contains(StoryRewards.Reports)) shuffledStoryRewards.Add("Secret Reports");
                AddToLog(string.Format("\tShuffled Rewards: {0}", shuffledStoryRewards.Count() > 0 ? string.Join(", ", shuffledStoryRewards) : "None"));
                AddToLog("\n");
            }
            AddToLog("\n");
            #endregion
        }
        #endregion

        #region Noise Drops
        public void LogDropTypeChanges(List<EnemyData> original, List<EnemyData> randomized)
        {
            AddToLog("Noise Drops\n========================================\n\n");

            List<NameAssociation> pins = FileConstants.ItemNames.Pins
            .Union(FileConstants.ItemNames.LimitedPins)
            .Union(FileConstants.ItemNames.YenPins)
            .Union(FileConstants.ItemNames.GemPins).ToList();

            for (int i=0; i<original.Count; i++)
            {
                string enemyName = FileConstants.ItemNames.Enemies.Where(e => e.Id == original[i].Id).First().Name;
                List<string> dropsOriginal = original[i].Drop.Select(d => pins.Where(p => p.Id == d).First()).Select(d => d.Name).ToList();
                List<string> dropsRandomized = randomized[i].Drop.Select(d => pins.Where(p => p.Id == d).First()).Select(d => d.Name).ToList();
                AddToLog(string.Format("{0}\n{1,-8}: {2,-25} -> {3}\n{4,-8}: {5,-25} -> {6}\n{7,-8}: {8,-25} -> {9}\n{10,-8}: {11,-25} -> {12}\n\n", enemyName, "Easy", dropsOriginal[0], dropsRandomized[0], "Normal", dropsOriginal[1], dropsRandomized[1], "Hard", dropsOriginal[2], dropsRandomized[2], "Ultimate", dropsOriginal[3], dropsRandomized[3]));
            }
        }

        public void LogDropRateChanges(List<EnemyData> original, List<EnemyData> randomized)
        {
            AddToLog("Noise Drop Rates\n========================================\n\n");

            for (int i = 0; i < original.Count; i++)
            {
                string enemyName = FileConstants.ItemNames.Enemies.Where(e => e.Id == original[i].Id).First().Name;
                List<float> dropsOriginal = original[i].DropRate.Select(r => r * 100).ToList();
                List<float> dropsRandomized = randomized[i].DropRate.Select(r => r * 100).ToList();
                AddToLog(string.Format("{0}\n{1,-8}: {2,-6:F2}% -> {3:F2}%\n{4,-8}: {5,-6:F2}% -> {6:F2}%\n{7,-8}: {8,-6:F2}% -> {9:F2}%\n{10,-8}: {11,-6:F2}% -> {12:F2}%\n\n", enemyName, "Easy", dropsOriginal[0], dropsRandomized[0], "Normal", dropsOriginal[1], dropsRandomized[1], "Hard", dropsOriginal[2], dropsRandomized[2], "Ultimate", dropsOriginal[3], dropsRandomized[3]));
            }
        }

        public void LogPigDropChanges(List<PigData> original, List<PigData> randomized)
        {
            AddToLog("Pig Noise Drops\n========================================\n\n");

            List<NameAssociation> pins = FileConstants.ItemNames.Pins
            .Union(FileConstants.ItemNames.LimitedPins)
            .Union(FileConstants.ItemNames.YenPins)
            .Union(FileConstants.ItemNames.GemPins).ToList();

            for (int i = 0; i < original.Count; i++)
            {
                string pigName = FileConstants.ItemNames.Pigs.Where(e => e.Id == original[i].Id).First().Name;
                string dropOriginal = pins.Where(p => p.Id == original[i].Drop).First().Name;
                string dropRandomized = pins.Where(p => p.Id == randomized[i].Drop).First().Name;
                AddToLog(string.Format("{0,-20}: {1,-25} -> {2}\n", pigName, dropOriginal, dropRandomized));
            }

            AddToLog("\n");
        }
        #endregion

        #region Pin Stats
        public void LogPinStatsChanges(List<Badge> original, List<Badge> randomized)
        {
            AddToLog("Pin Stats\n========================================\n\n");

            for (int i = 0; i < original.Count; i++)
            {
                Badge pinOriginal = original[i];
                Badge pinRandomized = randomized[i];
                AddToLog(string.Format("{0}\n", FileConstants.ItemNames.Pins.Where(p => p.Id == original[i].Id).First().Name));
                AddToLog(string.Format("{0,-14}: {1,-4} (+{2,-3})               -> {3,-4} (+{4,-3})\n", "Power", pinOriginal.Power, pinOriginal.PowerScaling, pinRandomized.Power, pinRandomized.PowerScaling));
                AddToLog(string.Format("{0,-14}: {1,-4:F1} uses/secs (+{2,-3:F1})     -> {3,-4:F1} uses/secs (+{4,-3:F1})\n", "Limit", pinOriginal.Limit, pinOriginal.LimitScaling, pinRandomized.Limit, pinRandomized.LimitScaling));
                AddToLog(string.Format("{0,-14}: {1,-4:F1} secs (-{2,-3:F1})          -> {3,-4:F1} secs (-{4,-3:F1})\n", "Reboot", pinOriginal.Reboot, pinOriginal.RebootScaling, pinRandomized.Reboot, pinRandomized.RebootScaling));
                AddToLog(string.Format("{0,-14}: {1,-3:F1} secs (-{2,-3:F1})           -> {3,-3:F1} secs (-{4,-3:F1})\n", "Boot", pinOriginal.Boot, pinOriginal.BootScaling, pinRandomized.Boot, pinRandomized.BootScaling));
                AddToLog(string.Format("{0,-14}: {1,-4:F1} secs (-{2,-3:F1})          -> {3,-4:F1} secs (-{4,-3:F1})\n", "Recover", pinOriginal.Recover, pinOriginal.RecoverScaling, pinRandomized.Recover, pinRandomized.RecoverScaling));
                AddToLog(string.Format("{0,-14}: {1,-3:F1} secs                  -> {2,-3:F1} secs\n", "Charge", pinOriginal.Charge, pinRandomized.Charge));
                AddToLog(string.Format("{0,-14}: {1,-5} ¥ (+{2,-4})           -> {3,-5} ¥ (+{4,-4})\n", "Sell Price", pinOriginal.SellPrice, pinOriginal.SellPriceScaling, pinRandomized.SellPrice, pinRandomized.SellPriceScaling));
                AddToLog(string.Format("{0,-14}: {1,-8}                  -> {2,-8}\n", "Affinity", FileConstants.ItemNames.Affinities.Where(a => a.Id == pinOriginal.MashUpAffinity).First().Name, FileConstants.ItemNames.Affinities.Where(a => a.Id == pinRandomized.MashUpAffinity).First().Name));
                AddToLog(string.Format("{0,-14}: {1,-2}                        -> {2,-2}\n", "Max Level", pinOriginal.MaxLevel, pinRandomized.MaxLevel));
                AddToLog(string.Format("{0,-14}: {1,-24}  -> {2,-24}\n", "Brand", FileConstants.ItemNames.Brands.Where(b => b.Id == pinOriginal.Brand).First().Name, FileConstants.ItemNames.Brands.Where(b => b.Id == pinRandomized.Brand).First().Name));
                AddToLog(string.Format("{0,-14}: {1,-3}                       -> {2,-3}\n", "Uber", pinOriginal.Uber == 1 ? "Yes" : "No", pinRandomized.Uber == 1 ? "Yes" : "No"));
                AddToLog(string.Format("{0,-14}: {1,-18}        -> {2,-18}\n", "Ability", pinOriginal.Abilities.Count > 0 ? FileConstants.ItemNames.PinAbilities.Where(a => a.Id == pinOriginal.Abilities[0]).First().Name : "None", pinRandomized.Abilities.Count > 0 ? FileConstants.ItemNames.PinAbilities.Where(a => a.Id == pinRandomized.Abilities[0]).First().Name : "None"));
                AddToLog(string.Format("{0,-14}: {1,-13}             -> {2,-13}\n", "Growth", FileConstants.ItemNames.GrowthRates.Where(g => g.Id == pinOriginal.Growth).First().Name, FileConstants.ItemNames.GrowthRates.Where(g => g.Id == pinRandomized.Growth).First().Name));
                AddToLog(string.Format("{0,-14}: {1,-25} -> {2,-25}\n", "Global Evo", pinOriginal.EvolutionSingle != -1 ? FileConstants.ItemNames.Pins.Where(p => p.Id == pinOriginal.EvolutionSingle).First().Name : "None", pinRandomized.EvolutionSingle != -1 ? FileConstants.ItemNames.Pins.Where(p => p.Id == pinRandomized.EvolutionSingle).First().Name : "None"));

                List<int> charaEvoPinsOriginal = new List<int>(pinOriginal.EvolutionList);
                List<int> charaEvoPinsRandomized = new List<int>(pinRandomized.EvolutionList);
                if (charaEvoPinsOriginal.Count == 0) charaEvoPinsOriginal.AddRange(Enumerable.Repeat(-1, 7));
                if (charaEvoPinsRandomized.Count == 0) charaEvoPinsRandomized.AddRange(Enumerable.Repeat(-1, 7));

                for (int j=0; j<charaEvoPinsOriginal.Count; j++)
                {
                    if (charaEvoPinsOriginal[j] != -1 || charaEvoPinsRandomized[j] != -1)
                    {
                        string character = FileConstants.ItemNames.Characters.Where(c => c.Id == j + 1).First().Name;
                        string pinNameOriginal = charaEvoPinsOriginal[j] != -1 ? FileConstants.ItemNames.Pins.Where(p => p.Id == pinOriginal.EvolutionList[j]).First().Name : "None";
                        string pinNameRandomized = charaEvoPinsRandomized[j] != -1 ? FileConstants.ItemNames.Pins.Where(p => p.Id == pinRandomized.EvolutionList[j]).First().Name : "None";
                        AddToLog(string.Format("{0,-14}: {1,-25} -> {2,-25}\n", character + " Evo", pinNameOriginal, pinNameRandomized));
                    }
                }

                AddToLog("\n");
            }
        }
        #endregion

        #region Story Rewards
        public void LogStoryRewardChanges(List<ScenarioRewards> original, List<ScenarioRewards> randomized)
        {
            AddToLog("Story Rewards\n========================================\n\n");

            List<NameAssociation> itemNames = FileConstants.ItemNames.PinItems
                .Union(FileConstants.ItemNames.LimitedPins)
                .Union(FileConstants.ItemNames.YenPins)
                .Union(FileConstants.ItemNames.GemPins)
                .Union(FileConstants.ItemNames.FP)
                .Union(FileConstants.ItemNames.SecretReports)
                .ToList();
            List<NameAssociation> storyRewardNames = FileConstants.ItemNames.StoryPins
                .Union(FileConstants.ItemNames.StoryLimitedPins)
                .Union(FileConstants.ItemNames.StoryYen)
                .Union(FileConstants.ItemNames.StoryGems)
                .Union(FileConstants.ItemNames.StoryFP)
                .Union(FileConstants.ItemNames.StoryReports)
                .ToList();
            List<NameAssociation> storyRewardNames2nd = FileConstants.ItemNames.StoryYen2nd.ToList();

            for (int i = 0; i < original.Count; i++)
            {
                ScenarioRewards rewardsOriginal = original[i];
                ScenarioRewards rewardsRandomized = randomized[i];
                if (storyRewardNames.Where(n => n.Id == rewardsOriginal.Id).Any())
                {
                    string rewardName = storyRewardNames.Where(n => n.Id == rewardsOriginal.Id).First().Name;
                    AddToLog(string.Format("{0,-35}: {1,-25} x{2,-3} -> {3,-25} x{4,-3}\n", rewardName, itemNames.Where(n => n.Id == rewardsOriginal.FirstReward).First().Name, rewardsOriginal.FirstRewardCount, itemNames.Where(n => n.Id == rewardsRandomized.FirstReward).First().Name, rewardsRandomized.FirstRewardCount));
                    if (storyRewardNames2nd.Where(n => n.Id == rewardsOriginal.Id).Any())
                    {
                        string rewardName2nd = storyRewardNames2nd.Where(n => n.Id == rewardsOriginal.Id).First().Name;
                        AddToLog(string.Format("{0,-35}: {1,-25} x{2,-3} -> {3,-25} x{4,-3}\n", rewardName2nd, itemNames.Where(n => n.Id == rewardsOriginal.SecondReward).First().Name, rewardsOriginal.SecondRewardCount, itemNames.Where(n => n.Id == rewardsRandomized.SecondReward).First().Name, rewardsRandomized.SecondRewardCount));
                    }
                }
            }
            AddToLog("\n");
        }
        #endregion

        public bool SaveLogToFile(string fileName)
        {
            try
            {
                File.WriteAllText(fileName, log);
                log = "";
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error writing the log. The game files were still randomized and saved successfully. Full Exception: " + ex.Message, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
