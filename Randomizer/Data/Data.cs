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
        private BundleFileInstance bundle;
        private AssetsFileInstance assetsFile;
        private byte[] newData;

        public Data(AssetsManager assetsManager, BundleFileInstance bundle, string bundleKey)
        {
            this.assetsManager = assetsManager;
            this.bundle = bundle;

            assetsFile = assetsManager.LoadAssetsFileFromBundle(bundle, FileConstants.FILES_CAB_DIRECTORIES[bundleKey]);
            if (!assetsFile.file.typeTree.hasTypeTree)
                assetsManager.LoadClassDatabaseFromPackage(assetsFile.file.typeTree.unityVersion);
        }

        public string GetScriptFile(string className)
        {
            AssetFileInfoEx fileInfo = assetsFile.table.GetAssetInfo(className);
            AssetTypeValueField baseField = assetsManager.GetTypeInstance(assetsFile, fileInfo).GetBaseField();

            return baseField.Get(FileConstants.TEXT_DATA_ATTRIBUTES[className]).GetValue().AsString();
        }

        public void SetScriptFiles(Dictionary<string, string> scripts)
        {
            List<AssetsReplacer> replacers = new List<AssetsReplacer>();
            foreach(var script in scripts)
            {
                AssetFileInfoEx fileInfo = assetsFile.table.GetAssetInfo(script.Key);
                AssetTypeValueField baseField = assetsManager.GetTypeInstance(assetsFile, fileInfo).GetBaseField();
                baseField.Get(FileConstants.TEXT_DATA_ATTRIBUTES[script.Key]).GetValue().Set(script.Value);
                replacers.Add(new AssetsReplacerFromMemory(0, fileInfo.index, (int)fileInfo.curFileType, 0xffff, baseField.WriteToByteArray()));
            }

            using (var stream = new MemoryStream())
            using (var writer = new AssetsFileWriter(stream))
            {
                assetsFile.file.Write(writer, 0, replacers, 0);
                newData = stream.ToArray();
            }
        }

        public AssetTypeValueField GetBaseField(string className)
        {
            AssetFileInfoEx fileInfo = assetsFile.table.GetAssetInfo(className);
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
    }
}
