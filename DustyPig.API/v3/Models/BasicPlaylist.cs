using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    public class BasicPlaylist : CreatePlaylist
    {
        [JsonProperty("id")]
        [JsonRequired]
        public int Id { get; set; }

        [JsonProperty("artwork_url_1")]
        [JsonRequired]
        public string ArtworkUrl { get; set; }
    }
}
