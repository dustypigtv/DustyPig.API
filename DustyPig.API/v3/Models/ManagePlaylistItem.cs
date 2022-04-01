using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    public class ManagePlaylistItem
    {
        [JsonRequired]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonRequired]
        [JsonProperty("index")]
        public int Index { get; set; }
    }
}
