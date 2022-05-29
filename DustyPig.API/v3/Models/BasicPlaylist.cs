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
        public string ArtworkUrl1 { get; set; }

        [JsonProperty("artwork_url_2")]
        public string ArtworkUrl2 { get; set; }

        [JsonProperty("artwork_url_3")]
        public string ArtworkUrl3 { get; set; }

        [JsonProperty("artwork_url_4")]
        public string ArtworkUrl4 { get; set; }
    }
}
