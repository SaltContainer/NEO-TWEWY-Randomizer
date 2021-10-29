using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class PigDataList
    {
        [JsonProperty("mTarget")]
        public IList<PigData> Items { get; set; }
    }
}
