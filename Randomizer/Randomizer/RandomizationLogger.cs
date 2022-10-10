using NEO_TWEWY_Randomizer
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

            AddToLog("NOISE DROPPED PINS\n");
            string droppedPinsChoice = "";
            switch (settings.NoiseDrops.NoiseDropTypeChoice)
            {
                case NoiseDropType.Unchanged: droppedPinsChoice = "Unchanged"; break;
                case NoiseDropType.ShuffleCompletely: droppedPinsChoice = "Shuffle (Completely)"; break;
                case NoiseDropType.ShuffleSets: droppedPinsChoice = "Shuffle (Sets)"; break;
                case NoiseDropType.RandomCompletely: droppedPinsChoice = "Random (Completely)"; break;
                case NoiseDropType.RandomAllPins: droppedPinsChoice = "Random (All Pins)"; break;
            }
            AddToLog(string.Format("Dropped Pins: {0}\n", droppedPinsChoice));
            if (settings.NoiseDrops.NoiseDropTypeChoice != NoiseDropType.Unchanged)
            {
                AddToLog(string.Format("Limited Pins: {0}\n", settings.NoiseDrops.NoiseIncludeLimitedPins ? "Yes" : "No"));
                List<string> dropTypeDifficulties = new List<string>();
                if (settings.NoiseDrops.NoiseDropTypeDifficulties.Contains(Difficulties.Easy)) dropTypeDifficulties.Add("Easy");
                if (settings.NoiseDrops.NoiseDropTypeDifficulties.Contains(Difficulties.Normal)) dropTypeDifficulties.Add("Normal");
                if (settings.NoiseDrops.NoiseDropTypeDifficulties.Contains(Difficulties.Hard)) dropTypeDifficulties.Add("Hard");
                if (settings.NoiseDrops.NoiseDropTypeDifficulties.Contains(Difficulties.Ultimate)) dropTypeDifficulties.Add("Ultimate");
                AddToLog(string.Format("Difficulties: {0}", string.Join(", ", dropTypeDifficulties)));
                AddToLog("\n");
            }
            AddToLog("\n");

            AddToLog("NOISE DROP RATE\n");
            string dropRateChoice = "";
            switch (settings.NoiseDrops.NoiseDropRateChoice)
            {
                case NoiseDropRate.Unchanged: dropRateChoice = "Unchanged"; break;
                case NoiseDropRate.RandomCompletely: dropRateChoice = "Random (Completely)"; break;
                case NoiseDropRate.RandomWeighted: dropRateChoice = "Random (Weighted)"; break;
            }
            AddToLog(string.Format("Drop Rate: {0}\n", dropRateChoice + (settings.NoiseDrops.NoiseDropRateChoice != NoiseDropRate.Unchanged ? string.Format(" ({0:F2}% - {1:F2}%)", settings.NoiseDrops.NoiseMinimumDropRate, settings.NoiseDrops.NoiseMaximumDropRate) : "")));
            if (settings.NoiseDrops.NoiseDropRateChoice != NoiseDropRate.Unchanged)
            {
                List<string> dropRateDifficulties = new List<string>();
                if (settings.NoiseDrops.NoiseDropRateDifficulties.Contains(Difficulties.Easy)) dropRateDifficulties.Add(settings.NoiseDrops.NoiseDropRateChoice == NoiseDropRate.RandomWeighted ? string.Format("Easy (Weight {0})", settings.NoiseDrops.NoiseDropRateWeights[0]) : "Easy");
                if (settings.NoiseDrops.NoiseDropRateDifficulties.Contains(Difficulties.Normal)) dropRateDifficulties.Add(settings.NoiseDrops.NoiseDropRateChoice == NoiseDropRate.RandomWeighted ? string.Format("Normal (Weight {0})", settings.NoiseDrops.NoiseDropRateWeights[1]) : "Normal");
                if (settings.NoiseDrops.NoiseDropRateDifficulties.Contains(Difficulties.Hard)) dropRateDifficulties.Add(settings.NoiseDrops.NoiseDropRateChoice == NoiseDropRate.RandomWeighted ? string.Format("Hard (Weight {0})", settings.NoiseDrops.NoiseDropRateWeights[2]) : "Hard");
                if (settings.NoiseDrops.NoiseDropRateDifficulties.Contains(Difficulties.Ultimate)) dropRateDifficulties.Add(settings.NoiseDrops.NoiseDropRateChoice == NoiseDropRate.RandomWeighted ? string.Format("Ultimate (Weight {0})", settings.NoiseDrops.NoiseDropRateWeights[3]) : "Ultimate");
                AddToLog(string.Format("Difficulties: {0}", string.Join(", ", dropRateDifficulties)));
                AddToLog("\n");
            }
            AddToLog("\n");

            AddToLog("PIN STATS\n");
            AddToLog("Randomized General Stats: ");
            List<string> generalPinStats = new List<string>();
            if (settings.PinStats.PinPower) generalPinStats.Add("Power");
            if (settings.PinStats.PinPowerScaling) generalPinStats.Add("Power Scaling");
            if (settings.PinStats.PinLimit) generalPinStats.Add("Limit");
            if (settings.PinStats.PinLimitScaling) generalPinStats.Add("Limit Scaling");
            if (settings.PinStats.PinReboot) generalPinStats.Add("Reboot");
            if (settings.PinStats.PinRebootScaling) generalPinStats.Add("Reboot Scaling");
            if (settings.PinStats.PinBoot) generalPinStats.Add("Boot");
            if (settings.PinStats.PinBootScaling) generalPinStats.Add("Boot Scaling");
            if (settings.PinStats.PinRecover) generalPinStats.Add("Recover");
            if (settings.PinStats.PinRecoverScaling) generalPinStats.Add("Recover Scaling");
            if (settings.PinStats.PinCharge) generalPinStats.Add("Charge");
            if (settings.PinStats.PinSell) generalPinStats.Add("Sell Price");
            if (settings.PinStats.PinSellScaling) generalPinStats.Add("Sell Price Scaling");
            if (settings.PinStats.PinAffinity) generalPinStats.Add("Affinity");
            if (settings.PinStats.PinMaxLevel) generalPinStats.Add("Max Level");
            AddToLog(generalPinStats.Count > 0 ? string.Join(", ", generalPinStats) : "None");
            AddToLog("\n");
            string brandChoice = "";
            switch (settings.PinStats.PinBrandChoice)
            {
                case PinBrand.Unchanged: brandChoice = "Unchanged"; break;
                case PinBrand.Shuffle: brandChoice = "Shuffle"; break;
                case PinBrand.RandomCompletely: brandChoice = "Random (Completely)"; break;
                case PinBrand.RandomUniform: brandChoice = "Random (Uniform)"; break;
            }
            AddToLog(string.Format("Brand: {0}\n", brandChoice));
            AddToLog(string.Format("Uber Pins: {0}\n", settings.PinStats.PinUber ? string.Format("Random ({0}%)", settings.PinStats.PinUberPercentage) : "Unchanged"));
            string abilityChoice = "";
            switch (settings.PinStats.PinAbilityChoice)
            {
                case PinAbility.Unchanged: abilityChoice = "Unchanged"; break;
                case PinAbility.Shuffle: abilityChoice = "Shuffle"; break;
                case PinAbility.RandomCompletely: abilityChoice = "Random (Completely)"; break;
            }
            AddToLog(string.Format("Pin Abilities: {0}\n", abilityChoice + (settings.PinStats.PinAbilityChoice == PinAbility.RandomCompletely ? string.Format(" ({0}%)", settings.PinStats.PinUberPercentage) : "")));
            string growthChoice = "";
            switch (settings.PinStats.PinGrowthChoice)
            {
                case PinGrowthRandomization.Unchanged: growthChoice = "Unchanged"; break;
                case PinGrowthRandomization.RandomCompletely: growthChoice = "Random (Completely)"; break;
                case PinGrowthRandomization.RandomUniform: growthChoice = "Random (Uniform)"; break;
                case PinGrowthRandomization.Specific: growthChoice = "Specific Growth Speed"; break;
            }
            AddToLog(string.Format("Growth Speed: {0}\n", growthChoice + (settings.PinStats.PinGrowthChoice == PinGrowthRandomization.Specific ? string.Format(" ({0})", FileConstants.ItemNames.GrowthRates.Where(g => g.Id == (int) settings.PinStats.PinGrowthSpecific).First().Name) : "")));
            string evoChoice = "";
            switch (settings.PinStats.PinEvolutionChoice)
            {
                case PinEvolution.Unchanged: evoChoice = "Unchanged"; break;
                case PinEvolution.RandomExisting: evoChoice = "Random (Existing)"; break;
                case PinEvolution.RandomCompletely: evoChoice = "Random (Completely)"; break;
            }
            AddToLog(string.Format("Evolution: {0}\n", evoChoice + (settings.PinStats.PinEvolutionChoice == PinEvolution.RandomCompletely ? string.Format(" ({0}%)", settings.PinStats.PinEvoPercentage) : "")));
            if (settings.PinStats.PinEvolutionChoice != PinEvolution.Unchanged) AddToLog(string.Format("Force Same-Brand Evolutions: {0}\n", settings.PinStats.PinEvoForceBrand ? "Yes" : "No"));
            AddToLog(string.Format("Remove Character-Specific Evolutions: {0}\n", settings.PinStats.PinRemoveCharaEvos ? "Yes" : "No"));

            AddToLog("\n");
        }
        #endregion

        #region Noise Drops
        public void LogDropTypeChanges(List<EnemyData> original, List<EnemyData> randomized)
        {
            AddToLog("Noise Drops\n========================================\n\n");

            List<NameAssociation> pins = FileConstants.ItemNames.Pins.ToList();
            pins.AddRange(FileConstants.ItemNames.YenPins.ToList());
            pins.AddRange(FileConstants.ItemNames.GemPins.ToList());
            pins.AddRange(FileConstants.ItemNames.LimitedPins.ToList());

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

            List<int> normalPinIds = FileConstants.ItemNames.Pins.Select(p => p.Id).ToList();
            List<int> limitedPinIds = FileConstants.ItemNames.LimitedPins.Select(p => p.Id).ToList();

            for (int i = 0; i < original.Count; i++)
            {
                string pigName = FileConstants.ItemNames.Pigs.Where(e => e.Id == original[i].Id).First().Name;
                string dropOriginal = limitedPinIds.Contains(original[i].Drop) ? FileConstants.ItemNames.LimitedPins.Where(p => p.Id == original[i].Drop).First().Name : FileConstants.ItemNames.Pins.Where(p => p.Id == original[i].Drop).First().Name;
                string dropRandomized = limitedPinIds.Contains(randomized[i].Drop) ? FileConstants.ItemNames.LimitedPins.Where(p => p.Id == randomized[i].Drop).First().Name : FileConstants.ItemNames.Pins.Where(p => p.Id == randomized[i].Drop).First().Name;
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
