using AssetsTools.NET;

namespace NEO_TWEWY_Randomizer
{
    public class ScenarioResetExtension
    {
        public UnityFile ResetItemGroup { get; set; }

        public static ScenarioResetExtension CreateFromMono(AssetTypeValueField baseField)
        {
            return new ScenarioResetExtension()
            {
                ResetItemGroup = UnityFile.CreateFromMono(baseField["m_ResetItemGroup"]),
            };
        }

        public void ExportToMono(AssetTypeValueField baseField)
        {
            ResetItemGroup.ExportToMono(baseField["m_ResetItemGroup"]);
        }
    }
}
