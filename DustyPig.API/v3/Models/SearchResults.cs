using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SearchResults
    {
        [JsonRequired]
        [JsonProperty("available")]
        public List<BasicMedia> Available { get; set; } = new List<BasicMedia>();

        [JsonRequired]
        [JsonProperty("other_titles")]
        public List<BasicTMDB> OtherTitles { get; set; } = new List<BasicTMDB>();
    }
}
