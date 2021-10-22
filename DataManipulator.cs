using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class DataManipulator
    {
        private Dictionary<string, Data> dataFiles;

        public DataManipulator()
        {
            dataFiles = new Dictionary<string, Data>();
        }

        public void LoadFiles(Dictionary<string, string> fileNames)
        {
            foreach(var entry in fileNames)
            {
                dataFiles.Add(entry.Key, new Data(entry.Value));
            }
        }
    }
}
