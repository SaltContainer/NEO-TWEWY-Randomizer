using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class ReductionQuota : Quota
    {
        [JsonProperty("MapID")]
        public IList<int> MapID { get; set; }
        [JsonProperty("Count")]
        public int Count { get; set; }
    }
}
