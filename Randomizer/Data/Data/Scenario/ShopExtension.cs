using AssetsTools.NET;

namespace NEO_TWEWY_Randomizer
{
    public class ShopExtension
    {
        public EnumItem ShopStatus { get; set; }

        public static ShopExtension CreateFromMono(AssetTypeValueField baseField)
        {
            return new ShopExtension()
            {
                ShopStatus = EnumItem.CreateFromMono(baseField["m_ShopStatus"]),
            };
        }

        public void ExportToMono(AssetTypeValueField baseField)
        {
            ShopStatus.ExportToMono(baseField["m_ShopStatus"]);
        }
    }
}
