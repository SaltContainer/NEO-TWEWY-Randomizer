using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class ItemQuota : Quota
    {
        [JsonProperty("BadgeID")]
        public IList<int> BadgeID { get; set; }
        [JsonProperty("m_CostumeList")]
        public IList<QuotaCostume> CostumeList { get; set; }
    }
}
