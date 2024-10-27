using AssetsTools.NET;

namespace NEO_TWEWY_Randomizer
{
    public class StruggleTeamAreaExtension
    {
        public EnumItem CalcOperator { get; set; }
        public int ComparisonValue { get; set; }

        public static StruggleTeamAreaExtension CreateFromMono(AssetTypeValueField baseField)
        {
            return new StruggleTeamAreaExtension()
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
