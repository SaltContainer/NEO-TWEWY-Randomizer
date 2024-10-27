using AssetsTools.NET;

namespace NEO_TWEWY_Randomizer
{
    public class StruggleTeamMemberExtension
    {
        public EnumItem TeamMember { get; set; }
        public EnumItem TargetArea { get; set; }

        public static StruggleTeamMemberExtension CreateFromMono(AssetTypeValueField baseField)
        {
            return new StruggleTeamMemberExtension()
            {
                TeamMember = EnumItem.CreateFromMono(baseField["m_TeamMember"]),
                TargetArea = EnumItem.CreateFromMono(baseField["m_TargetArea"]),
            };
        }

        public void ExportToMono(AssetTypeValueField baseField)
        {
            TeamMember.ExportToMono(baseField["m_TeamMember"]);
            TargetArea.ExportToMono(baseField["m_TargetArea"]);
        }
    }
}
