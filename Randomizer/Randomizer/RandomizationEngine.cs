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

        public void LoadFiles(Dictionary<string, string> fileNames)
        {
            dataManipulator.LoadBundles(fileNames);
        }

        public void Randomize(RandomizationSettings settings)
        {
            if (rand == null) rand = new Random();

            string enemyDataJson = RandomizeEnemyData(settings);

            Dictionary<string, string> scripts = new Dictionary<string, string>
            { { FileConstants.TEXT_DATA_ENEMY_DATA_CLASS_NAME, enemyDataJson } };
            dataManipulator.SetScriptFilesToBundle(FileConstants.TEXT_DATA_KEY, scripts);
        }

        public void Randomize(RandomizationSettings settings, int seed)
        {
            rand = new Random(seed);
            Randomize(settings);
        }

        public void Save(string fileName)
        {
            dataManipulator.SaveBundles(new Dictionary<string, string> { { FileConstants.TEXT_DATA_KEY, fileName } });
        }

        private string RandomizeEnemyData(RandomizationSettings settings)
        {
            string enemyDataScript = dataManipulator.GetScriptFileFromBundle(FileConstants.TEXT_DATA_KEY, FileConstants.TEXT_DATA_ENEMY_DATA_CLASS_NAME);

            EnemyData enemyData = JsonConvert.DeserializeObject<EnemyData>(enemyDataScript);
            enemyData.Target[0].Drop = new List<int> { 5001, 5001, 5001, 5001 };
            enemyData.Target[0].DropRate = new List<float> { 0.70f, 0.70f, 0.70f, 0.70f };
            enemyData.Target[0].Scale = 3.0f;
            return JsonConvert.SerializeObject(enemyData, Formatting.Indented);
        }
    }
}
