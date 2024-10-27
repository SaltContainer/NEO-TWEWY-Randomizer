using AssetsTools.NET;

namespace NEO_TWEWY_Randomizer
{
    public class StruggleAreaControllExtension
    {
        public EnumItem TeamType { get; set; }

        public static StruggleAreaControllExtension CreateFromMono(AssetTypeValueField baseField)
        {
            return new StruggleAreaControllExtension()
            {
                TeamType = EnumItem.CreateFromMono(baseField["m_TeamType"]),
            };
        }

        public void ExportToMono(AssetTypeValueField baseField)
        {
            TeamType.ExportToMono(baseField["m_TeamType"]);
        }
    }
}
