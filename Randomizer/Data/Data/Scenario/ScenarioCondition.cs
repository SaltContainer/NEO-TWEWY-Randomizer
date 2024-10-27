using AssetsTools.NET;

namespace NEO_TWEWY_Randomizer
{
    public class ScenarioCondition
    {
        public EnumItem Kind { get; set; }
        public EnumItem Index { get; set; }
        public ScenarioKindExtension ScenarioKindExtension { get; set; }
        public bool Inverse { get; set; }

        public static ScenarioCondition CreateFromMono(AssetTypeValueField baseField)
        {
            return new ScenarioCondition()
            {
                Kind = EnumItem.CreateFromMono(baseField["m_Kind"]),
                Index = EnumItem.CreateFromMono(baseField["m_Index"]),
                ScenarioKindExtension = ScenarioKindExtension.CreateFromMono(baseField["m_ScenarioKindExtension"]),
                Inverse = baseField["m_Inverse"].AsBool,
            };
        }

        public void ExportToMono(AssetTypeValueField baseField)
        {
            Kind.ExportToMono(baseField["m_Kind"]);
            Index.ExportToMono(baseField["m_Index"]);
            ScenarioKindExtension.ExportToMono(baseField["m_ScenarioKindExtension"]);
            baseField["m_Inverse"].AsBool = Inverse;
        }
    }
}
