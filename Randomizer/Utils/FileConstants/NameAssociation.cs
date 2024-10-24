using Newtonsoft.Json;

namespace NEO_TWEWY_Randomizer
{
    public class NameAssociation
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
