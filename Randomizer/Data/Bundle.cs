using AssetsTools.NET;
using AssetsTools.NET.Extra;
using System.Collections.Generic;
using System.Linq;

namespace NEO_TWEWY_Randomizer
{
    public class Bundle
    {
        private AssetsManager manager;
        private string bundleKey;
        private BundleFileInstance bundle;
        private AssetsFileInstance assetsFile;
        private bool encrypted;

        public AssetsManager Manager { get => manager; }
        public string BundleKey { get => bundleKey; }
        public BundleFileInstance BundleInstance { get => bundle; }
        public AssetsFileInstance AssetsFile { get => assetsFile; }
        public bool Encrypted { get => encrypted; }

        public string FileName { get => FileConstants.Bundles[bundleKey].FileName; }

        public Bundle(AssetsManager manager, BundleFileInstance bundle, string bundleKey, bool encrypted)
        {
            this.manager = manager;
            this.bundle = bundle;
            this.bundleKey = bundleKey;
            this.assetsFile = manager.LoadAssetsFileFromBundle(bundle, 0);
            this.encrypted = encrypted;
        }

        public string GetScriptFile(string scriptName)
        {
            return GetBaseFieldOfScript(scriptName)?[FileConstants.Bundles[bundleKey].Classes[scriptName].Attribute].AsString;
        }

        public void SetScriptFiles(Dictionary<string, string> scripts)
        {
            foreach(var script in scripts)
            {
                var assetInfo = GetAssetInfoOfScript(script.Key);
                var baseField = GetBaseFieldOfScript(script.Key);

                baseField[FileConstants.Bundles[bundleKey].Classes[script.Key].Attribute].AsString = script.Value;
                assetInfo.SetNewData(baseField);
            }

            SetAssetsFileInBundle();
        }

        private AssetFileInfo GetAssetInfoOfScript(string scriptName)
        {
            var assetInfos = assetsFile.file.GetAssetsOfType(AssetClassID.TextAsset);
            return assetInfos.Where(f => manager.GetBaseField(assetsFile, f)["m_Name"].AsString == scriptName).FirstOrDefault();
        }

        private AssetTypeValueField GetBaseFieldOfScript(string scriptName)
        {
            var baseFields = assetsFile.file.GetAssetsOfType(AssetClassID.TextAsset).Select(f => manager.GetBaseField(assetsFile, f));
            return baseFields.Where(f => f["m_Name"].AsString == scriptName).FirstOrDefault();
        }

        private void SetAssetsFileInBundle()
        {
            bundle.file.BlockAndDirInfo.DirectoryInfos[0].SetNewData(assetsFile.file);
        }
    }
}
