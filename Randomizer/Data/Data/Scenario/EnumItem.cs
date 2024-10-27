using AssetsTools.NET;

namespace NEO_TWEWY_Randomizer
{
    public class EnumItem
    {
        public string Name { get; set; }
        public int SerializedValue { get; set; }

        public static EnumItem CreateFromMono(AssetTypeValueField baseField)
        {
            return new EnumItem()
            {
                Name = baseField["Name"].AsString,
                SerializedValue = baseField["m_SerializedValue"].AsInt,
            };
        }

        public void ExportToMono(AssetTypeValueField baseField)
        {
            baseField["Name"].AsString = Name;
            baseField["m_SerializedValue"].AsInt = SerializedValue;
        }
    }
}
