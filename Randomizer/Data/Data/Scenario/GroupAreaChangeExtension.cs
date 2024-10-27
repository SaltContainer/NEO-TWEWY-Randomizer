using AssetsTools.NET;

namespace NEO_TWEWY_Randomizer
{
    public class GroupAreaChangeExtension
    {
        public EnumItem AreaChangeStatus { get; set; }

        public static GroupAreaChangeExtension CreateFromMono(AssetTypeValueField baseField)
        {
            return new GroupAreaChangeExtension()
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
