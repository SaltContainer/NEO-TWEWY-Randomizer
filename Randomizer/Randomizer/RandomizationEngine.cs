using AssetsTools.NET;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class RandomizationEngine
    {
        private Random rand;
        private DataManipulator dataManipulator;
        private RandomizationLogger logger;

        public RandomizationEngine()
        {
            dataManipulator = new DataManipulator();
            logger = new RandomizationLogger();
        }

        public bool LoadFiles(Dictionary<string, string> fileNames)
        {
            return dataManipulator.LoadBundles(fileNames);
        }

        public bool AreFilesLoaded()
        {
            return dataManipulator.AreFilesLoaded();
        }

        public void Randomize(RandomizationSettings settings)
        {
            if (rand == null) rand = new Random();

            string enemyDataJson = RandomizeEnemyData(settings);

            Dictionary<string, string> scripts = new Dictionary<string, string>
                { { FileConstants.EnemyDataClassName, enemyDataJson } };
            dataManipulator.SetScriptFilesToBundle(FileConstants.TextDataBundleKey, scripts);
        }

        public void Randomize(RandomizationSettings settings, int seed)
        {
            rand = new Random(seed);
            Randomize(settings);
        }

        public bool Save(string filePath, int seed)
        {
            bool result = dataManipulator.SaveBundles(filePath);
            result = result && logger.SaveLogToFile(string.Format("{0}\\Randomization-Log-{1}.log", filePath, seed.ToString()));
            return result;
        }

        private string RandomizeEnemyData(RandomizationSettings settings)
        {
            string enemyDataScript = dataManipulator.GetScriptFileFromBundle(FileConstants.TextDataBundleKey, FileConstants.EnemyDataClassName);
            string enemyReportScript = dataManipulator.GetScriptFileFromBundle(FileConstants.TextDataBundleKey, FileConstants.EnemyReportClassName);

            EnemyDataList enemyDataOriginal = JsonConvert.DeserializeObject<EnemyDataList>(enemyDataScript);
            EnemyDataList enemyData = JsonConvert.DeserializeObject<EnemyDataList>(enemyDataScript);
            EnemyReportList enemyReport = JsonConvert.DeserializeObject<EnemyReportList>(enemyReportScript);

            List<EnemyData> listToEditOriginal = enemyDataOriginal.Target.Where(data => enemyReport.Target.Any(report => report.EnemyDataId == data.Id)).ToList();
            List<EnemyData> listToEdit = enemyData.Target.Where(data => enemyReport.Target.Any(report => report.EnemyDataId == data.Id)).ToList();

            switch (settings.DropType)
            {
                case NoiseDropType.ShuffleCompletely:
                    List<int> pins = listToEditOriginal.SelectMany(data => data.Drop).OrderBy(pin => rand.Next()).ToList();
                    break;
            }

            logger.LogDropTypeChanges(enemyDataOriginal, enemyData);

            string randomizedScript = JsonConvert.SerializeObject(enemyData, Formatting.Indented);
            return randomizedScript;
        }
    }
}
