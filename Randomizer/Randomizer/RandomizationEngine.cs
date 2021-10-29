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

        private void AdjustEnemyDataDropRate(EnemyDataList enemyData)
        {
            foreach (EnemyDuplicate dupe in FileConstants.EnemyDataDuplicates.Duplicates)
            {
                EnemyData original = enemyData.Target.Where(enemy => enemy.Id == dupe.Id).First();
                enemyData.Target.Where(enemy => dupe.Duplicates.Contains(enemy.Id)).ToList().ForEach(enemy => enemy.Drop = new List<int>(original.Drop));
            }

            foreach (EnemyDuplicate dupe in FileConstants.EnemyDataDuplicates.ForcedNormalDrops)
            {
                EnemyData original = enemyData.Target.Where(enemy => enemy.Id == dupe.Id).First();
                enemyData.Target.Where(enemy => dupe.Duplicates.Contains(enemy.Id)).ToList().ForEach(enemy => enemy.Drop = new List<int>(original.Drop));
            }

            foreach (EnemyDuplicate dupe in FileConstants.EnemyDataDuplicates.NoDrops)
            {
                EnemyData original = enemyData.Target.Where(enemy => enemy.Id == dupe.Id).First();
                enemyData.Target.Where(enemy => dupe.Duplicates.Contains(enemy.Id)).ToList().ForEach(enemy => enemy.Drop = new List<int>(original.Drop));
            }
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

            bool dropEasy = settings.NoiseDropTypeDifficulties.Contains(Difficulties.Easy);
            bool dropNormal = settings.NoiseDropTypeDifficulties.Contains(Difficulties.Normal);
            bool dropHard = settings.NoiseDropTypeDifficulties.Contains(Difficulties.Hard);
            bool dropUltimate = settings.NoiseDropTypeDifficulties.Contains(Difficulties.Ultimate);

            switch (settings.DropType)
            {
                case NoiseDropType.ShuffleCompletely:
                    List<int> scPins = new List<int>();
                    if (dropEasy) scPins.AddRange(listToEditOriginal.Select(data => data.Drop[0]));
                    if (dropNormal) scPins.AddRange(listToEditOriginal.Select(data => data.Drop[1]));
                    if (dropHard) scPins.AddRange(listToEditOriginal.Select(data => data.Drop[2]));
                    if (dropUltimate) scPins.AddRange(listToEditOriginal.Select(data => data.Drop[3]));

                    scPins = scPins.OrderBy(pin => rand.Next()).ToList();

                    int pinId = 0;
                    foreach (EnemyData data in listToEdit)
                    {
                        if (dropEasy) data.Drop[0] = scPins[pinId++];
                        if (dropNormal) data.Drop[1] = scPins[pinId++];
                        if (dropHard) data.Drop[2] = scPins[pinId++];
                        if (dropUltimate) data.Drop[3] = scPins[pinId++];
                    }
                    AdjustEnemyDataDropRate(enemyData);
                    break;

                case NoiseDropType.ShuffleSets:
                    List<IList<int>> ssPins = listToEditOriginal.Select(data => data.Drop).ToList();
                    ssPins = ssPins.OrderBy(pin => rand.Next()).ToList();

                    for (int i=0; i<listToEdit.Count; i++)
                    {
                        listToEdit[i].Drop = ssPins[i];
                    }
                    AdjustEnemyDataDropRate(enemyData);
                    break;
            }

            logger.LogDropTypeChanges(enemyDataOriginal, enemyData);

            string randomizedScript = JsonConvert.SerializeObject(enemyData, Formatting.Indented);
            return randomizedScript;
        }
    }
}
