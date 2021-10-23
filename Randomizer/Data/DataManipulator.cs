using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class DataManipulator
    {
        private BundleDecrypter bundleDecrypter;
        private Dictionary<string, Data> dataFiles;

        public DataManipulator()
        {
            bundleDecrypter = new BundleDecrypter();
            dataFiles = new Dictionary<string, Data>();
        }

        public void LoadFiles(Dictionary<string, string> fileNames)
        {
            foreach(var entry in fileNames)
            {
                dataFiles.Add(entry.Key, bundleDecrypter.DecryptData(new Data(entry.Value)));
            }
        }
    }
}
