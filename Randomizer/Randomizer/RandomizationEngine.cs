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

        public RandomizationEngine()
        {
            dataManipulator = new DataManipulator();
        }

        public bool AreFilesLoaded()
        {
            return dataManipulator.AreFilesLoaded();
        }

        public bool LoadFiles(Dictionary<string, string> fileNames)
        {
            return dataManipulator.LoadBundles(fileNames);
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

        public bool Save(string filePath)
        {
            return dataManipulator.SaveBundles(filePath);
        }

        private string RandomizeEnemyData(RandomizationSettings settings)
        {
            string enemyDataScript = dataManipulator.GetScriptFileFromBundle(FileConstants.TextDataBundleKey, FileConstants.EnemyDataClassName);

            EnemyData enemyData = JsonConvert.DeserializeObject<EnemyData>(enemyDataScript);
            enemyData.Target[0].Drop = new List<int> { 5001, 5001, 5001, 5001 };
            enemyData.Target[0].DropRate = new List<float> { 0.70f, 0.70f, 0.70f, 0.70f };
            enemyData.Target[0].Scale = 3.0f;
            return JsonConvert.SerializeObject(enemyData, Formatting.Indented);
        }
    }
}
