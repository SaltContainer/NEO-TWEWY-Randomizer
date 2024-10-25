using AssetsTools.NET;

namespace NEO_TWEWY_Randomizer
{
    public class StruggleBossExtension
    {
        public EnumItem TeamType { get; set; }

        public static StruggleBossExtension CreateFromMono(AssetTypeValueField baseField)
        {
            return new StruggleBossExtension()
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
