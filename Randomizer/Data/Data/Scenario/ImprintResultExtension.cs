using AssetsTools.NET;

namespace NEO_TWEWY_Randomizer
{
    public class ImprintResultExtension
    {
        public EnumItem ImprintResultOperator { get; set; }
        public EnumItem ImprintResult { get; set; }

        public static ImprintResultExtension CreateFromMono(AssetTypeValueField baseField)
        {
            return new ImprintResultExtension()
            {
                ImprintResultOperator = EnumItem.CreateFromMono(baseField["m_ImprintResultOperator"]),
                ImprintResult = EnumItem.CreateFromMono(baseField["m_ImprintResult"]),
            };
        }

        public void ExportToMono(AssetTypeValueField baseField)
        {
            ImprintResultOperator.ExportToMono(baseField["m_ImprintResultOperator"]);
            ImprintResult.ExportToMono(baseField["m_ImprintResult"]);
        }
    }
}
