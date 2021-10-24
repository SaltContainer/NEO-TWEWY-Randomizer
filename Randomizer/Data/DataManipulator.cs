using AssetsTools.NET;
using AssetsTools.NET.Extra;
using NEO_TWEWY_Randomizer.Randomizer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEO_TWEWY_Randomizer
{
    class DataManipulator
    {
        private AssetsManager assetsManager;
        private BundleDecompressor bundleDecrypter;
        private Dictionary<string, BundleFileInstance> dataFiles;

        public DataManipulator()
        {
            assetsManager = new AssetsManager();
            bundleDecrypter = new BundleDecompressor();
            dataFiles = new Dictionary<string, BundleFileInstance>();
        }

        public void LoadBundles(Dictionary<string, string> fileNames)
        {
            try
            {
                foreach (var entry in fileNames)
                {
                    dataFiles.Add(entry.Key, bundleDecrypter.LoadAndDecompressFile(assetsManager, entry.Value));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error reading or decrypting one of the data files. Exception: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string LoadScriptFileFromBundle(string bundle, string className, string attributeName)
        {
            AssetsFileInstance assetsFile = assetsManager.LoadAssetsFileFromBundle(dataFiles[bundle], FileConstants.FILES_CAB_DIRECTORIES[bundle]);
            if (!assetsFile.file.typeTree.hasTypeTree)
                assetsManager.LoadClassDatabaseFromPackage(assetsFile.file.typeTree.unityVersion);

            AssetFileInfoEx fileInfo = assetsFile.table.GetAssetInfo(className);
            AssetTypeValueField baseField = assetsManager.GetTypeInstance(assetsFile, fileInfo).GetBaseField();

            return baseField.Get(attributeName).GetValue().AsString();
        }
    }
}
