using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class BrandQuota : Quota
    {
        [JsonProperty("BrandID")]
        public int BrandID { get; set; }
        [JsonProperty("EquipSlots")]
        public IList<int> EquipSlots { get; set; }
        [JsonProperty("EvenOne")]
        public int EvenOne { get; set; }
    }
}
