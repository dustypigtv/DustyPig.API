using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class BasicMedia
    {
        [JsonRequired]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonRequired]
        [JsonProperty("media_type")]
        public MediaTypes MediaType { get; set; }

        [JsonRequired]
        [JsonProperty("artwork_url")]
        public string ArtworkUrl { get; set; }

        [JsonRequired]
        [JsonProperty("title")]
        public string Title { get; set; }

        public override string ToString() => Title;
    }
}
