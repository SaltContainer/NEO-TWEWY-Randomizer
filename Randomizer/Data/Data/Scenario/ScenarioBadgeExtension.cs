using AssetsTools.NET;

namespace NEO_TWEWY_Randomizer
{
    public class ScenarioBadgeExtension
    {
        public EnumItem CalcOperator { get; set; }
        public int ComparisonValue { get; set; }

        public static ScenarioBadgeExtension CreateFromMono(AssetTypeValueField baseField)
        {
            return new ScenarioBadgeExtension()
            {
                CalcOperator = EnumItem.CreateFromMono(baseField["m_CalcOperator"]),
                ComparisonValue = baseField["m_ComparisonValue"].AsInt,
            };
        }

        public void ExportToMono(AssetTypeValueField baseField)
        {
            CalcOperator.ExportToMono(baseField["m_CalcOperator"]);
            baseField["m_ComparisonValue"].AsInt = ComparisonValue;
        }
    }
}
