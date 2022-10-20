using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class OwnBadgeQuota : Quota
    {
        [JsonProperty("m_BadgeList")]
        public IList<QuotaBadge> BadgeList { get; set; }
    }
}
