using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class HomeScreenList
    {
        [JsonRequired]
        [JsonProperty("list_id")]
        public long ListId { get; set; }

        [JsonRequired]
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonRequired]
        [JsonProperty("items")]
        public List<BasicMedia> Items { get; set; }
    }
}
