using NEO_TWEWY_Randomizer.Randomizer.Data;
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

        public void RandomizeAndSave(RandomizationSettings settings, string fileName)
        {
            rand = new Random();
            Randomize(settings);
            Save(fileName);
        }

        public void RandomizeAndSave(RandomizationSettings settings, string fileName, int seed)
        {
            rand = new Random(seed);
            Randomize(settings);
            Save(fileName);
        }

        private void Randomize(RandomizationSettings settings)
        {
            RandomizeDrops(settings);
        }

        private void Save(string fileName)
        {

        }

        private void RandomizeDrops(RandomizationSettings settings)
        {
            string enemyDataScript = dataManipulator.LoadScriptFileFromBundle(FileConstants.TEXT_DATA_KEY, FileConstants.TEXT_DATA_ENEMY_DATA_CLASS_NAME, FileConstants.TEXT_DATA_ENEMY_DATA_SCRIPT);
        }
    }
}
