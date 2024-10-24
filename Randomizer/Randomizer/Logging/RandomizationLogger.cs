using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace NEO_TWEWY_Randomizer
{
    public class RandomizationLogger
    {
        private StringBuilder log;

        private NoiseDropsLogger noiseDropsLogger;
        private PinStatsLogger pinStatsLogger;
        private StoryRewardsLogger storyRewardsLogger;

        public RandomizationLogger()
        {
            log = new StringBuilder();

            noiseDropsLogger = new NoiseDropsLogger();
            pinStatsLogger = new PinStatsLogger();
            storyRewardsLogger = new StoryRewardsLogger();
        }

        public void AddToLog(string logString)
        {
            log.Append(logString);
        }

        public void LogSettings(RandomizationSettings settings)
        {
            AddToLog("========================================\nNEO: THE WORLD ENDS WITH YOU RANDOMIZATION SETTINGS\n\n");
            AddToLog(string.Format("Settings String:\n{0}\n\n", settings.GenerateSettingsString()));

            AddToLog(noiseDropsLogger.LogSettings(settings));
            AddToLog(pinStatsLogger.LogSettings(settings));
            AddToLog(storyRewardsLogger.LogSettings(settings));
        }

        public void LogDropTypeChanges(List<EnemyData> original, List<EnemyData> randomized)
        {
            AddToLog(noiseDropsLogger.LogDropTypeChanges(original, randomized));
        }

        public void LogDropRateChanges(List<EnemyData> original, List<EnemyData> randomized)
        {
            AddToLog(noiseDropsLogger.LogDropRateChanges(original, randomized));
        }

        public void LogPigDropChanges(List<PigData> original, List<PigData> randomized)
        {
            AddToLog(noiseDropsLogger.LogPigDropChanges(original, randomized));
        }

        public void LogPinStatsChanges(List<Badge> original, List<Badge> randomized)
        {
            AddToLog(pinStatsLogger.LogPinStatsChanges(original, randomized));
        }

        public void LogStoryRewardChanges(List<ScenarioRewards> original, List<ScenarioRewards> randomized)
        {
            AddToLog(storyRewardsLogger.LogStoryRewardChanges(original, randomized));
        }

        public bool SaveLogToFile(string fileName)
        {
            try
            {
                File.WriteAllText(fileName, log.ToString());
                log.Clear();
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
