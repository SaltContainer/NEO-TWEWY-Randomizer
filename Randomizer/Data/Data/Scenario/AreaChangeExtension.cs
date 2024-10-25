using AssetsTools.NET;

namespace NEO_TWEWY_Randomizer
{
    public class AreaChangeExtension
    {
        public EnumItem AreaChangeStatus { get; set; }

        public static AreaChangeExtension CreateFromMono(AssetTypeValueField baseField)
        {
            return new AreaChangeExtension()
            {
                AreaChangeStatus = EnumItem.CreateFromMono(baseField["m_AreaChangeStatus"]),
            };
        }

        public void ExportToMono(AssetTypeValueField baseField)
        {
            AreaChangeStatus.ExportToMono(baseField["m_AreaChangeStatus"]);
        }
    }
}
