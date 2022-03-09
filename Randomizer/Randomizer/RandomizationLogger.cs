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

        #region Noise Drops
        public void LogDropTypeChanges(List<EnemyData> original, List<EnemyData> randomized)
        {
            log += "Noise Drops\n========================================\n\n";

            List<NameAssociation> pins = FileConstants.ItemNames.Pins.ToList();
            pins.AddRange(FileConstants.ItemNames.YenPins.ToList());
            pins.AddRange(FileConstants.ItemNames.GemPins.ToList());
            pins.AddRange(FileConstants.ItemNames.LimitedPins.ToList());

            for (int i=0; i<original.Count; i++)
            {
                string enemyName = FileConstants.ItemNames.Enemies.Where(e => e.Id == original[i].Id).First().Name;
                List<string> dropsOriginal = original[i].Drop.Select(d => pins.Where(p => p.Id == d).First()).Select(d => d.Name).ToList();
                List<string> dropsRandomized = randomized[i].Drop.Select(d => pins.Where(p => p.Id == d).First()).Select(d => d.Name).ToList();
                log += string.Format("{0}\n{1,-8}: {2,-25} -> {3}\n{4,-8}: {5,-25} -> {6}\n{7,-8}: {8,-25} -> {9}\n{10,-8}: {11,-25} -> {12}\n\n", enemyName, "Easy", dropsOriginal[0], dropsRandomized[0], "Normal", dropsOriginal[1], dropsRandomized[1], "Hard", dropsOriginal[2], dropsRandomized[2], "Ultimate", dropsOriginal[3], dropsRandomized[3]);
            }
        }

        public void LogDropRateChanges(List<EnemyData> original, List<EnemyData> randomized)
        {
            log += "Noise Drop Rates\n========================================\n\n";

            for (int i = 0; i < original.Count; i++)
            {
                string enemyName = FileConstants.ItemNames.Enemies.Where(e => e.Id == original[i].Id).First().Name;
                List<float> dropsOriginal = original[i].DropRate.Select(r => r * 100).ToList();
                List<float> dropsRandomized = randomized[i].DropRate.Select(r => r * 100).ToList();
                log += string.Format("{0}\n{1,-8}: {2,-6:F2}% -> {3:F2}%\n{4,-8}: {5,-6:F2}% -> {6:F2}%\n{7,-8}: {8,-6:F2}% -> {9:F2}%\n{10,-8}: {11,-6:F2}% -> {12:F2}%\n\n", enemyName, "Easy", dropsOriginal[0], dropsRandomized[0], "Normal", dropsOriginal[1], dropsRandomized[1], "Hard", dropsOriginal[2], dropsRandomized[2], "Ultimate", dropsOriginal[3], dropsRandomized[3]);
            }
        }

        public void LogPigDropChanges(List<PigData> original, List<PigData> randomized)
        {
            log += "Pig Noise Drops\n========================================\n\n";

            List<int> normalPinIds = FileConstants.ItemNames.Pins.Select(p => p.Id).ToList();
            List<int> limitedPinIds = FileConstants.ItemNames.LimitedPins.Select(p => p.Id).ToList();

            for (int i = 0; i < original.Count; i++)
            {
                string pigName = FileConstants.ItemNames.Pigs.Where(e => e.Id == original[i].Id).First().Name;
                string dropOriginal = limitedPinIds.Contains(original[i].Drop) ? FileConstants.ItemNames.LimitedPins.Where(p => p.Id == original[i].Drop).First().Name : FileConstants.ItemNames.Pins.Where(p => p.Id == original[i].Drop).First().Name;
                string dropRandomized = limitedPinIds.Contains(randomized[i].Drop) ? FileConstants.ItemNames.LimitedPins.Where(p => p.Id == randomized[i].Drop).First().Name : FileConstants.ItemNames.Pins.Where(p => p.Id == randomized[i].Drop).First().Name;
                log += string.Format("{0,-20}: {1,-25} -> {2}\n", pigName, dropOriginal, dropRandomized);
            }

            log += "\n";
        }
        #endregion

        #region Pin Stats
        public void LogPinStatsChanges(List<Badge> original, List<Badge> randomized)
        {
            log += "Pin Stats\n========================================\n\n";

            for (int i = 0; i < original.Count; i++)
            {
                Badge pinOriginal = original[i];
                Badge pinRandomized = randomized[i];
                log += string.Format("{0}\n", FileConstants.ItemNames.Pins.Where(p => p.Id == original[i].Id).First().Name);
                log += string.Format("{0,-14}: {1,-4} (+{2,-3})               -> {3,-4} (+{4,-3})\n", "Power", pinOriginal.Power, pinOriginal.PowerScaling, pinRandomized.Power, pinRandomized.PowerScaling);
                log += string.Format("{0,-14}: {1,-4:F1} uses/secs (+{2,-3:F1})     -> {3,-4:F2} uses/secs (+{4,-3:F1})\n", "Limit", pinOriginal.Limit, pinOriginal.LimitScaling, pinRandomized.Limit, pinRandomized.LimitScaling);
                log += string.Format("{0,-14}: {1,-4:F1} secs (-{2,-3:F1})          -> {3,-4:F1} secs (-{4,-3:F1})\n", "Reboot", pinOriginal.Reboot, pinOriginal.RebootScaling, pinRandomized.Reboot, pinRandomized.RebootScaling);
                log += string.Format("{0,-14}: {1,-3:F1} secs (-{2,-3:F1})           -> {3,-3:F1} secs (-{4,-3:F1})\n", "Boot", pinOriginal.Boot, pinOriginal.BootScaling, pinRandomized.Boot, pinRandomized.BootScaling);
                log += string.Format("{0,-14}: {1,-4:F1} secs (-{2,-3:F1})          -> {3,-4:F1} secs (-{4,-3:F1})\n", "Recover", pinOriginal.Recover, pinOriginal.RecoverScaling, pinRandomized.Recover, pinRandomized.RecoverScaling);
                log += string.Format("{0,-14}: {1,-3:F1} secs                  -> {2,-3:F1} secs\n", "Charge", pinOriginal.Charge, pinRandomized.Charge);
                log += string.Format("{0,-14}: {1,-5} ¥ (+{2,-4})           -> {3,-5} ¥ (+{4,-4})\n", "Sell Price", pinOriginal.SellPrice, pinOriginal.SellPriceScaling, pinRandomized.SellPrice, pinRandomized.SellPriceScaling);
                log += string.Format("{0,-14}: {1,-8}                  -> {2,-8}\n", "Affinity", FileConstants.ItemNames.Affinities.Where(a => a.Id == pinOriginal.MashUpAffinity).First().Name, FileConstants.ItemNames.Affinities.Where(a => a.Id == pinRandomized.MashUpAffinity).First().Name);
                log += string.Format("{0,-14}: {1,-2}                        -> {2,-2}\n", "Max Level", pinOriginal.MaxLevel, pinRandomized.MaxLevel);
                log += string.Format("{0,-14}: {1,-24}  -> {2,-24}\n", "Brand", FileConstants.ItemNames.Brands.Where(b => b.Id == pinOriginal.Brand).First().Name, FileConstants.ItemNames.Brands.Where(b => b.Id == pinRandomized.Brand).First().Name);
                log += string.Format("{0,-14}: {1,-3}                       -> {2,-3}\n", "Uber", pinOriginal.Uber == 1 ? "Yes" : "No", pinRandomized.Uber == 1 ? "Yes" : "No");
                log += string.Format("{0,-14}: {1,-18}        -> {2,-18}\n", "Ability", pinOriginal.Abilities.Count > 0 ? FileConstants.ItemNames.PinAbilities.Where(a => a.Id == pinOriginal.Abilities[0]).First().Name : "None", pinRandomized.Abilities.Count > 0 ? FileConstants.ItemNames.PinAbilities.Where(a => a.Id == pinRandomized.Abilities[0]).First().Name : "None");
                log += string.Format("{0,-14}: {1,-13}             -> {2,-13}\n", "Growth", FileConstants.ItemNames.GrowthRates.Where(g => g.Id == pinOriginal.Growth).First().Name, FileConstants.ItemNames.GrowthRates.Where(g => g.Id == pinRandomized.Growth).First().Name);
                log += string.Format("{0,-14}: {1,-25} -> {2,-25}\n", "Global Evo", pinOriginal.EvolutionSingle != -1 ? FileConstants.ItemNames.Pins.Where(p => p.Id == pinOriginal.EvolutionSingle).First().Name : "None", pinRandomized.EvolutionSingle != -1 ? FileConstants.ItemNames.Pins.Where(p => p.Id == pinRandomized.EvolutionSingle).First().Name : "None");

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
                        log += string.Format("{0,-14}: {1,-25} -> {2,-25}\n", character + " Evo", pinNameOriginal, pinNameRandomized);
                    }
                }

                log += "\n";
            }
        }
        #endregion

        public bool SaveLogToFile(string fileName)
        {
            try
            {
                File.WriteAllText(fileName, log);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error writing the log. Full Exception: " + ex.Message, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
