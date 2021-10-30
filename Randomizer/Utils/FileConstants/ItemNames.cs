﻿using Newtonsoft.Json;
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
        [JsonProperty("limited-pins")]
        public IList<NameAssociation> LimitedPins { get; set; }
        [JsonProperty("enemies")]
        public IList<NameAssociation> Enemies { get; set; }
        [JsonProperty("pigs")]
        public IList<NameAssociation> Pigs { get; set; }
    }
}