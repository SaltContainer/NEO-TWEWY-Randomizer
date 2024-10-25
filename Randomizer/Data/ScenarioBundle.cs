using AssetsTools.NET.Extra;
using AssetsTools.NET;
using System.Collections.Generic;
using System.Linq;

namespace NEO_TWEWY_Randomizer
{
    public class ScenarioBundle : Bundle
    {
        public ScenarioBundle(AssetsManager manager, BundleFileInstance bundle, string bundleKey, bool encrypted) :
            base(manager, bundle, bundleKey, encrypted)
        { }

        public ScenarioObjectItemGroup GetScenarioFile(string assetName)
        {
            return ScenarioObjectItemGroup.CreateFromMono(GetBaseFieldOfAsset(assetName));
        }

        public void SetScenarioFiles(Dictionary<string, ScenarioObjectItemGroup> scenarios)
        {
            foreach (var scenario in scenarios)
            {
                var assetInfo = GetAssetInfoOfAsset(scenario.Key);
                var baseField = GetBaseFieldOfAsset(scenario.Key);

                scenario.Value.ExportToMono(baseField);
                assetInfo.SetNewData(baseField);
            }

            SetAssetsFileInBundle();
        }

        private AssetFileInfo GetAssetInfoOfAsset(string assetName)
        {
            var assetInfos = assetsFile.file.GetAssetsOfType(AssetClassID.MonoBehaviour);
            return assetInfos.Where(f => manager.GetBaseField(assetsFile, f)["m_Name"].AsString == assetName).FirstOrDefault();
        }

        private AssetTypeValueField GetBaseFieldOfAsset(string assetName)
        {
            var baseFields = assetsFile.file.GetAssetsOfType(AssetClassID.MonoBehaviour).Select(f => manager.GetBaseField(assetsFile, f));
            var names = baseFields.Select(f => f["m_Name"].AsString);
            return baseFields.Where(f => f["m_Name"].AsString == assetName).FirstOrDefault();
        }
    }
}
