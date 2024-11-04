using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEO_TWEWY_Randomizer
{
    public class NoiseDropsLogger
    {
        private StringBuilder log;

        public NoiseDropsLogger()
        {
            log = new StringBuilder();
        }

        public void AddToLog(string logString)
        {
            log.Append(logString);
        }

        public string LogDropTypeChanges(List<EnemyData> original, List<EnemyData> randomized)
        {
            log.Clear();
            AddToLog("Noise Drops\n========================================\n\n");

            List<NameAssociation> pins = FileConstants.IDNames.Pins
                .Union(FileConstants.IDNames.LimitedPins)
                .Union(FileConstants.IDNames.YenPins)
                .Union(FileConstants.IDNames.GemPins).ToList();

            for (int i=0; i<original.Count; i++)
            {
                string enemyName = FileConstants.IDNames.Enemies.Where(e => (EnemyData.Name)e.Id == original[i].Id).First().Name;
                List<string> dropsOriginal = original[i].Drop.Select(d => pins.Where(p => (Badge.Label)p.Id == d).First()).Select(d => d.Name).ToList();
                List<string> dropsRandomized = randomized[i].Drop.Select(d => pins.Where(p => (Badge.Label)p.Id == d).First()).Select(d => d.Name).ToList();
                AddToLog(string.Format("{0}\n{1,-8}: {2,-25} -> {3}\n{4,-8}: {5,-25} -> {6}\n{7,-8}: {8,-25} -> {9}\n{10,-8}: {11,-25} -> {12}\n\n", enemyName, "Easy", dropsOriginal[0], dropsRandomized[0], "Normal", dropsOriginal[1], dropsRandomized[1], "Hard", dropsOriginal[2], dropsRandomized[2], "Ultimate", dropsOriginal[3], dropsRandomized[3]));
            }

            return log.ToString();
        }

        public string LogDropRateChanges(List<EnemyData> original, List<EnemyData> randomized)
        {
            log.Clear();
            AddToLog("Noise Drop Rates\n========================================\n\n");

            for (int i=0; i<original.Count; i++)
            {
                string enemyName = FileConstants.IDNames.Enemies.Where(e => (EnemyData.Name)e.Id == original[i].Id).First().Name;
                List<float> dropsOriginal = original[i].DropRate.Select(r => r * 100).ToList();
                List<float> dropsRandomized = randomized[i].DropRate.Select(r => r * 100).ToList();
                AddToLog(string.Format("{0}\n{1,-8}: {2,-6:F2}% -> {3:F2}%\n{4,-8}: {5,-6:F2}% -> {6:F2}%\n{7,-8}: {8,-6:F2}% -> {9:F2}%\n{10,-8}: {11,-6:F2}% -> {12:F2}%\n\n", enemyName, "Easy", dropsOriginal[0], dropsRandomized[0], "Normal", dropsOriginal[1], dropsRandomized[1], "Hard", dropsOriginal[2], dropsRandomized[2], "Ultimate", dropsOriginal[3], dropsRandomized[3]));
            }

            return log.ToString();
        }

        public string LogPigDropChanges(List<PigData> original, List<PigData> randomized)
        {
            log.Clear();
            AddToLog("Pig Noise Drops\n========================================\n\n");

            List<NameAssociation> pins = FileConstants.IDNames.Pins
                .Union(FileConstants.IDNames.LimitedPins)
                .Union(FileConstants.IDNames.YenPins)
                .Union(FileConstants.IDNames.GemPins).ToList();

            for (int i=0; i<original.Count; i++)
            {
                string pigName = FileConstants.IDNames.Pigs.Where(e => (PigData.Label)e.Id == original[i].Id).First().Name;
                string dropOriginal = pins.Where(p => (Badge.Label)p.Id == original[i].Drop).First().Name;
                string dropRandomized = pins.Where(p => (Badge.Label)p.Id == randomized[i].Drop).First().Name;
                AddToLog(string.Format("{0,-20}: {1,-25} -> {2}\n", pigName, dropOriginal, dropRandomized));
            }

            AddToLog("\n");

            return log.ToString();
        }

        public string LogSettings(RandomizationSettings settings)
        {
            log.Clear();

            LogDroppedPinsSettings(settings);
            LogDropRateSettings(settings);

            return log.ToString();
        }

        private void LogDroppedPinsSettings(RandomizationSettings settings)
        {
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
        }

        private void LogDropRateSettings(RandomizationSettings settings)
        {
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
        }
    }
}
