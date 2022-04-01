using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    public class SetPlaylistIndex
    {
        [JsonRequired]
        [JsonProperty("playlist_id")]
        public int PlaylistId { get; set; }

        [JsonRequired]
        [JsonProperty("current_index")]
        public int CurrentIndex { get; set; }
    }
}
