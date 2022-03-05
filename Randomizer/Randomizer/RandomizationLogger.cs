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
                log += string.Format("{0}\n{1,-8}: {2,-6}% -> {3}%\n{4,-8}: {5,-6}% -> {6}%\n{7,-8}: {8,-6}% -> {9}%\n{10,-8}: {11,-6}% -> {12}%\n\n", enemyName, "Easy", dropsOriginal[0], dropsRandomized[0], "Normal", dropsOriginal[1], dropsRandomized[1], "Hard", dropsOriginal[2], dropsRandomized[2], "Ultimate", dropsOriginal[3], dropsRandomized[3]);
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

        public void LogPinStatsChanges(List<Badge> original, List<Badge> randomized)
        {
            log += "Pin Stats\n========================================\n\n";

            for (int i = 0; i < original.Count; i++)
            {
                string pinName = FileConstants.ItemNames.Pins.Where(p => p.Id == original[i].Id).First().Name;
                Badge pinOriginal = original[i];
                Badge pinRandomized = randomized[i];
                log += string.Format("{0}\n{1,-11}: {2,-4} (+{3,-3})           -> {4,-4} (+{5,-3})\n", pinName, "Power", pinOriginal.Power, pinOriginal.PowerScaling, pinRandomized.Power, pinRandomized.PowerScaling);
                log += string.Format("{0,-11}: {1,-4} uses/secs (+{2,-3}) -> {3,-4} uses/secs (+{4,-3})\n\n", "Limit", pinOriginal.Limit, pinOriginal.LimitScaling, pinRandomized.Limit, pinRandomized.LimitScaling);
            }
        }

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
