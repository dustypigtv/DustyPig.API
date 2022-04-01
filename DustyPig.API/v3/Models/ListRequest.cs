using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    public class ListRequest
    {
        [JsonProperty("start")]
        public int Start { get; set; }

        [JsonProperty("sort")]
        public SortOrder Sort { get; set; }
    }
}
