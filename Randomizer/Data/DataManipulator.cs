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
        private Dictionary<string, Bundle> dataFiles;

        public DataManipulator()
        {
            assetsManager = new AssetsManager();
            bundleCompressor = new BundleCompressor(assetsManager);
            dataFiles = new Dictionary<string, Bundle>();
        }

        public bool AreFilesLoaded()
        {
            return FileConstants.Bundles.All(kvp => dataFiles.ContainsKey(kvp.Key));
        }

        public bool LoadBundles(Dictionary<string, string> fileNames)
        {
            try
            {
                foreach (var entry in fileNames)
                {
                    if (FileConstants.Bundles[entry.Key].BundleType == FileConstants.TextBundleType)
                        dataFiles.Add(entry.Key, new TextBundle(assetsManager, bundleCompressor.LoadAndDecompressFile(entry.Value), entry.Key));
                    else if (FileConstants.Bundles[entry.Key].BundleType == FileConstants.ScenarioBundleType)
                        dataFiles.Add(entry.Key, new ScenarioBundle(assetsManager, bundleCompressor.LoadAndDecompressFile(entry.Value), entry.Key));
                    else if (FileConstants.Bundles[entry.Key].BundleType == FileConstants.QuotaBundleType)
                        dataFiles.Add(entry.Key, new QuotaBundle(assetsManager, bundleCompressor.LoadAndDecompressFile(entry.Value), entry.Key));
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error reading or decompressing one of the data files. Full Exception: " + ex.Message, "Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SaveBundles(string filePath)
        {
            try
            {
                foreach (var entry in dataFiles)
                {
                    SaveBundle(entry.Key, string.Format("{0}/{1}", filePath, FileConstants.Bundles[entry.Key].FileName));
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error writing one of the data files. Full Exception: " + ex.Message, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void SaveBundle(string bundleKey, string fileName)
        {
            Bundle data = dataFiles[bundleKey];
            BundleFileInstance bundleInstance = data.GetBundle();
            string cabDirName = FileConstants.Bundles[bundleKey].CabDirectory;

            if (data.GetNewData() != null)
            {
                BundleReplacerFromMemory bundleReplacer = new BundleReplacerFromMemory(cabDirName, cabDirName, true, data.GetNewData(), -1);
                AssetsFileWriter bundleWriter = new AssetsFileWriter(File.OpenWrite(fileName));
                bundleInstance.file.Write(bundleWriter, new List<BundleReplacer>() { bundleReplacer });

                bundleWriter.Close();
            }
        }

        public string GetScriptFileFromBundle(string bundleKey, string fileName)
        {
            return dataFiles[bundleKey].GetScriptFile(fileName);
        }

        public void SetScriptFilesToBundle(string bundleKey, Dictionary<string, string> scripts)
        {
            dataFiles[bundleKey].SetScriptFiles(scripts);
        }
    }
}
