using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class EnemyDuplicate
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("duplicates")]
        public IList<int> Duplicates { get; set; }
    }
}
