using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class StruggleTeamMember
    {
        [JsonProperty("m_TeamMember")]
        public SerializedString TeamMember { get; set; }
        [JsonProperty("m_TargetArea")]
        public SerializedString TargetArea { get; set; }
    }
}
