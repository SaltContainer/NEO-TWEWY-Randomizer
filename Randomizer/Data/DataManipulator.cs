﻿using AssetsTools.NET;
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
                    Data data = new Data(assetsManager, bundleCompressor.LoadAndDecompressFile(entry.Value), entry.Key);
                    dataFiles.Add(entry.Key, data);
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
            Data data = dataFiles[bundleKey];
            BundleFileInstance bundleInstance = data.GetBundle();
            string cabDirName = FileConstants.Bundles[bundleKey].CabDirectory;

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
