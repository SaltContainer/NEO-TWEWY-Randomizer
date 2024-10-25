using AssetsTools.NET;

namespace NEO_TWEWY_Randomizer
{
    public class ScenarioMapExtension
    {
        public string PositionTag { get; set; }

        public static ScenarioMapExtension CreateFromMono(AssetTypeValueField baseField)
        {
            return new ScenarioMapExtension()
            {
                PositionTag = baseField["m_PositionTag"].AsString,
            };
        }

        public void ExportToMono(AssetTypeValueField baseField)
        {
            baseField["m_PositionTag"].AsString = PositionTag;
        }
    }
}
