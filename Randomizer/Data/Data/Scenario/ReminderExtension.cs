using AssetsTools.NET;

namespace NEO_TWEWY_Randomizer
{
    public class ReminderExtension
    {
        public EnumItem ReminderStatus { get; set; }

        public static ReminderExtension CreateFromMono(AssetTypeValueField baseField)
        {
            return new ReminderExtension()
            {
                ReminderStatus = EnumItem.CreateFromMono(baseField["m_ReminderStatus"]),
            };
        }

        public void ExportToMono(AssetTypeValueField baseField)
        {
            ReminderStatus.ExportToMono(baseField["m_ReminderStatus"]);
        }
    }
}
