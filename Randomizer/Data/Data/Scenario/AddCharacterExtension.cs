using AssetsTools.NET;

namespace NEO_TWEWY_Randomizer
{
    public class AddCharacterExtension
    {
        public EnumItem CalcOperator { get; set; }

        public static AddCharacterExtension CreateFromMono(AssetTypeValueField baseField)
        {
            return new AddCharacterExtension()
            {
                CalcOperator = EnumItem.CreateFromMono(baseField["m_CalcOperator"]),
            };
        }

        public void ExportToMono(AssetTypeValueField baseField)
        {
            CalcOperator.ExportToMono(baseField["m_CalcOperator"]);
        }
    }
}
