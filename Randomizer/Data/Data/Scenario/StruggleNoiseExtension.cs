using AssetsTools.NET;

namespace NEO_TWEWY_Randomizer
{
    public class StruggleNoiseExtension
    {
        public EnumItem NoiseStatus { get; set; }
        public EnumItem TargetArea { get; set; }

        public static StruggleNoiseExtension CreateFromMono(AssetTypeValueField baseField)
        {
            return new StruggleNoiseExtension()
            {
                NoiseStatus = EnumItem.CreateFromMono(baseField["m_NoiseStatus"]),
                TargetArea = EnumItem.CreateFromMono(baseField["m_TargetArea"]),
            };
        }

        public void ExportToMono(AssetTypeValueField baseField)
        {
            NoiseStatus.ExportToMono(baseField["m_NoiseStatus"]);
            TargetArea.ExportToMono(baseField["m_TargetArea"]);
        }
    }
}
