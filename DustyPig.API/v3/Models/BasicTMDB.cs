using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class BasicTMDB
    {
        [JsonRequired]
        [JsonProperty("tmdb_id")]
        public int TMDB_ID { get; set; }

        [JsonRequired]
        [JsonProperty("media_type")]
        public TMDB_MediaTypes MediaType { get; set; }

        [JsonRequired]
        [JsonProperty("artwork_url")]
        public string ArtworkUrl { get; set; }

        [JsonRequired]
        [JsonProperty("title")]
        public string Title { get; set; }

        public override string ToString() => Title;
    }
}
