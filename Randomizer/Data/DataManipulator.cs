using AssetsTools.NET;
using AssetsTools.NET.Extra;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEO_TWEWY_Randomizer
{
    class DataManipulator
    {
        private AssetsManager assetsManager;
        private BundleCompressor bundleCompressor;
        private Dictionary<string, Data> dataFiles;

        public DataManipulator()
        {
            assetsManager = new AssetsManager();
            bundleCompressor = new BundleCompressor(assetsManager);
            dataFiles = new Dictionary<string, Data>();
        }

        public void LoadBundles(Dictionary<string, string> fileNames)
        {
            try
            {
                foreach (var entry in fileNames)
                {
                    Data data = new Data(assetsManager, bundleCompressor.LoadAndDecompressFile(entry.Value), entry.Key);
                    dataFiles.Add(entry.Key, data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error reading or decompressing one of the data files. Exception: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SaveBundles(Dictionary<string, string> fileNames)
        {
            try
            {
                foreach (var entry in dataFiles)
                {
                    SaveBundle(entry.Key, fileNames[entry.Key]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error writing or compressing one of the data files. Exception: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveBundle(string bundleKey, string fileName)
        {
            Data data = dataFiles[bundleKey];
            BundleFileInstance bundleInstance = data.GetBundle();
            string cabDirName = FileConstants.FILES_CAB_DIRECTORIES[bundleKey];

            BundleReplacerFromMemory bundleReplacer = new BundleReplacerFromMemory(cabDirName, cabDirName, true, data.GetNewData(), -1);
            AssetsFileWriter bundleWriter = new AssetsFileWriter(File.OpenWrite(fileName));
            bundleInstance.file.Write(bundleWriter, new List<BundleReplacer>() { bundleReplacer });

            bundleWriter.Close();
        }

        public string GetScriptFileFromBundle(string bundleKey, string className)
        {
            return dataFiles[bundleKey].GetScriptFile(className);
        }

        public void SetScriptFilesToBundle(string bundleKey, Dictionary<string, string> scripts)
        {
            dataFiles[bundleKey].SetScriptFiles(scripts);
        }
    }
}
