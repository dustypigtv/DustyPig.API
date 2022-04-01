using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    public class Playlist
    {
        [JsonProperty("id")]
        [JsonRequired]
        public int Id { get; set; }

        [JsonProperty("name")]
        [JsonRequired]
        public string Name { get; set; }

        [JsonProperty("artwork_url")]
        [JsonRequired]
        public string ArtworkUrl { get; set; }
    }
}
