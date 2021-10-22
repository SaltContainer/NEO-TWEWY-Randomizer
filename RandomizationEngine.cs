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
            dataManipulator.LoadFiles(fileNames);
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

        }

        private void Save(string fileName)
        {

        }
    }
}
