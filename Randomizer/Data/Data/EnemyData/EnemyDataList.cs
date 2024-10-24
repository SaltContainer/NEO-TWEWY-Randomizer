using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class EnemyDataList
    {
        [JsonProperty("mTarget")]
        public IList<EnemyData> Items { get; set; }
    }
}
