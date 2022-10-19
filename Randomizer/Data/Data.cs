using AssetsTools.NET;
using AssetsTools.NET.Extra;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class Data
    {
        private AssetsManager assetsManager;
        private string bundleKey;
        private BundleFileInstance bundle;
        private AssetsFileInstance assetsFile;
        private byte[] newData;

        public Data(AssetsManager assetsManager, BundleFileInstance bundle, string bundleKey)
        {
            this.assetsManager = assetsManager;
            this.bundle = bundle;
            this.bundleKey = bundleKey;

            assetsFile = assetsManager.LoadAssetsFileFromBundle(bundle, FileConstants.Bundles[bundleKey].CabDirectory);
            if (!assetsFile.file.typeTree.hasTypeTree)
                assetsManager.LoadClassDatabaseFromPackage(assetsFile.file.typeTree.unityVersion);
        }

        public string GetScriptFile(string fileName)
        {
            AssetFileInfoEx fileInfo = assetsFile.table.GetAssetInfo(fileName);
            AssetTypeValueField baseField = assetsManager.GetTypeInstance(assetsFile, fileInfo).GetBaseField();

            string assetType = FileConstants.Bundles[bundleKey].Files[fileName].AssetType;

            if (assetType == FileConstants.TextAssetType)
            {
                return GetTextAssetScriptFile(baseField);
            }
            else if (assetType == FileConstants.ScenarioAssetType)
            {
                return GetScenarioAssetScriptFile(baseField);
            }

            return "";
        }

        public void SetScriptFiles(Dictionary<string, string> scripts)
        {
            List<AssetsReplacer> replacers = new List<AssetsReplacer>();
            foreach(var script in scripts)
            {
                AssetFileInfoEx fileInfo = assetsFile.table.GetAssetInfo(script.Key);
                AssetTypeValueField baseField = assetsManager.GetTypeInstance(assetsFile, fileInfo).GetBaseField();

                string assetType = FileConstants.Bundles[bundleKey].Files[script.Key].AssetType;

                if (assetType == FileConstants.TextAssetType)
                {
                    SetTextAssetScriptFile(baseField, script.Value);
                }
                else if (assetType == FileConstants.ScenarioAssetType)
                {
                    SetScenarioAssetScriptFile(baseField, script.Value);
                }
                
                replacers.Add(new AssetsReplacerFromMemory(0, fileInfo.index, (int)fileInfo.curFileType, 0xffff, baseField.WriteToByteArray()));
            }

            using (var stream = new MemoryStream())
            using (var writer = new AssetsFileWriter(stream))
            {
                assetsFile.file.Write(writer, 0, replacers, 0);
                newData = stream.ToArray();
            }
        }

        public AssetTypeValueField GetBaseField(string fileName)
        {
            AssetFileInfoEx fileInfo = assetsFile.table.GetAssetInfo(fileName);
            return assetsManager.GetTypeInstance(assetsFile, fileInfo).GetBaseField();
        }

        public AssetsFileInstance GetAssetsFile()
        {
            return assetsFile;
        }

        public BundleFileInstance GetBundle()
        {
            return bundle;
        }

        public byte[] GetNewData()
        {
            return newData;
        }

        private string GetTextAssetScriptFile(AssetTypeValueField baseField)
        {
            return baseField.Get(FileConstants.TextAssetAttributeKey).GetValue().AsString();
        }

        private string GetScenarioAssetScriptFile(AssetTypeValueField baseField)
        {
            return ScenarioAssetConverter.ConvertFromBaseField(baseField);
        }

        private void SetTextAssetScriptFile(AssetTypeValueField baseField, string newValue)
        {
            baseField.Get(FileConstants.TextAssetAttributeKey).GetValue().Set(newValue);
        }

        private void SetScenarioAssetScriptFile(AssetTypeValueField baseField, string newValue)
        {
            ScenarioAssetConverter.InsertInBaseField(baseField, newValue);
        }
    }
}
