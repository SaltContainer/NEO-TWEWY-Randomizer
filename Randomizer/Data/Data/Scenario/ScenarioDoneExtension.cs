using AssetsTools.NET;

namespace NEO_TWEWY_Randomizer
{
    public class ScenarioDoneExtension
    {
        public UnityFile DoneItemGroup { get; set; }

        public static ScenarioDoneExtension CreateFromMono(AssetTypeValueField baseField)
        {
            return new ScenarioDoneExtension()
            {
                DoneItemGroup = UnityFile.CreateFromMono(baseField["m_DoneItemGroup"]),
            };
        }

        public void ExportToMono(AssetTypeValueField baseField)
        {
            DoneItemGroup.ExportToMono(baseField["m_DoneItemGroup"]);
        }
    }
}
