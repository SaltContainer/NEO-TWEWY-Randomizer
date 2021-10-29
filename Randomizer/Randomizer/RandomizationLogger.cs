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

            List<int> normalPinIds = FileConstants.ItemNames.Pins.Select(p => p.Id).ToList();
            List<int> limitedPinIds = FileConstants.ItemNames.LimitedPins.Select(p => p.Id).ToList();

            for (int i=0; i<original.Count; i++)
            {
                string enemyName = FileConstants.ItemNames.Enemies.Where(e => e.Id == original[i].Id).First().Name;
                List<string> dropsOriginal = original[i].Drop.Select(d => limitedPinIds.Contains(d) ? FileConstants.ItemNames.LimitedPins.Where(p => p.Id == d).First() : FileConstants.ItemNames.Pins.Where(p => p.Id == d).First()).Select(d => d.Name).ToList();
                List<string> dropsRandomized = randomized[i].Drop.Select(d => limitedPinIds.Contains(d) ? FileConstants.ItemNames.LimitedPins.Where(p => p.Id == d).First() : FileConstants.ItemNames.Pins.Where(p => p.Id == d).First()).Select(d => d.Name).ToList();
                log += string.Format("{0}\nEasy: {1}\t\t\t\t\t->\t{2}\nNormal: {3}\t\t\t\t\t->\t{4}\nHard: {5}\t\t\t\t\t->\t{6}\nUltimate: {7}\t\t\t\t\t->\t{8}\n\n", enemyName, dropsOriginal[0], dropsRandomized[0], dropsOriginal[1], dropsRandomized[1], dropsOriginal[2], dropsRandomized[2], dropsOriginal[3], dropsRandomized[3]);
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
                log += string.Format("{0}: {1}\t\t\t\t\t->\t{2}\n", pigName, dropOriginal, dropRandomized);
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
