using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class RelationshipQuota : Quota
    {
        [JsonProperty("SkillTreeID")]
        public int SkillTreeID { get; set; }
        [JsonProperty("Status")]
        public int Status { get; set; }
    }
}
