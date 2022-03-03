using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class ItemNames
    {
        [JsonProperty("pins")]
        public IList<NameAssociation> Pins { get; set; }
        [JsonProperty("yen-pins")]
        public IList<NameAssociation> YenPins { get; set; }
        [JsonProperty("gem-pins")]
        public IList<NameAssociation> GemPins { get; set; }
        [JsonProperty("limited-pins")]
        public IList<NameAssociation> LimitedPins { get; set; }
        [JsonProperty("enemies")]
        public IList<NameAssociation> Enemies { get; set; }
        [JsonProperty("pigs")]
        public IList<NameAssociation> Pigs { get; set; }
        [JsonProperty("growth-classes")]
        public IList<NameAssociation> GrowthRates { get; set; }
        [JsonProperty("brands")]
        public IList<NameAssociation> Brands { get; set; }
    }
}
