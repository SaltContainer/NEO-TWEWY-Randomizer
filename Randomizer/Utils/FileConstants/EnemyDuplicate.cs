using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class EnemyDuplicate
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("duplicates")]
        public IList<int> Duplicates { get; set; }
    }
}
