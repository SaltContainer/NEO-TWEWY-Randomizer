using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class EnemyReportList
    {
        [JsonProperty("mTarget")]
        public IList<EnemyReport> Items { get; set; }
    }
}
