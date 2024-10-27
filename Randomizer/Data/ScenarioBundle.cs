using AssetsTools.NET.Extra;
using AssetsTools.NET;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class ScenarioBundle : Bundle
    {
        private Dictionary<string, ScenarioObjectItemGroup> scenarios;

        public ScenarioBundle(AssetsManager manager, BundleFileInstance bundle, string bundleKey, bool encrypted) :
            base(manager, bundle, bundleKey, encrypted)
        {
            scenarios = new Dictionary<string, ScenarioObjectItemGroup>();
        }

        public ScenarioObjectItemGroup GetScenarioFile(string assetName)
        {
            if (scenarios.TryGetValue(assetName, out ScenarioObjectItemGroup scenario))
                return scenario;

            var newScenario = ScenarioObjectItemGroup.CreateFromMono(GetBaseFieldOfAsset(assetName));
            scenarios.Add(assetName, newScenario);
            return newScenario;
        }

        public void SaveScenarioFiles()
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
            return assetsFile.file.GetAssetsOfType(AssetClassID.MonoBehaviour)
                .Find(f => manager.GetBaseField(assetsFile, f)["m_Name"].AsString == assetName);
        }

        private AssetTypeValueField GetBaseFieldOfAsset(string assetName)
        {
            return manager.GetBaseField(assetsFile, GetAssetInfoOfAsset(assetName));
        }
    }
}
