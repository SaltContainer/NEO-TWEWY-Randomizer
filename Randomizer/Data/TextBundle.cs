using AssetsTools.NET.Extra;
using AssetsTools.NET;
using System.Collections.Generic;
using System.Linq;

namespace NEO_TWEWY_Randomizer
{
    public class TextBundle : Bundle
    {
        public TextBundle(AssetsManager manager, BundleFileInstance bundle, string bundleKey, bool encrypted) :
            base (manager, bundle, bundleKey, encrypted) {}

        public string GetScriptFile(string scriptName)
        {
            return GetBaseFieldOfAsset(scriptName)?["m_Script"].AsString;
        }

        public void SetScriptFiles(Dictionary<string, string> scripts)
        {
            foreach (var script in scripts)
            {
                var assetInfo = GetAssetInfoOfAsset(script.Key);
                var baseField = GetBaseFieldOfAsset(script.Key);

                baseField["m_Script"].AsString = script.Value;
                assetInfo.SetNewData(baseField);
            }

            SetAssetsFileInBundle();
        }

        private AssetFileInfo GetAssetInfoOfAsset(string assetName)
        {
            var assetInfos = assetsFile.file.GetAssetsOfType(AssetClassID.TextAsset);
            return assetInfos.Where(f => manager.GetBaseField(assetsFile, f)["m_Name"].AsString == assetName).FirstOrDefault();
        }

        private AssetTypeValueField GetBaseFieldOfAsset(string assetName)
        {
            var baseFields = assetsFile.file.GetAssetsOfType(AssetClassID.TextAsset).Select(f => manager.GetBaseField(assetsFile, f));
            return baseFields.Where(f => f["m_Name"].AsString == assetName).FirstOrDefault();
        }
    }
}
