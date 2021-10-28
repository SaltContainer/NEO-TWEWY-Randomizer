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

        public void LogDropTypeChanges(EnemyDataList original, EnemyDataList randomized)
        {
            //TODO: Implement
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
