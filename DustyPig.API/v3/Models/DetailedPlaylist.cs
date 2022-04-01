using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class DetailedPlaylist : BasicPlaylist
    {
        [JsonRequired]
        [JsonProperty("current_index")]
        public int CurrentIndex { get; set; }

        [JsonRequired]
        [JsonProperty("items")]
        public List<PlaylistItem> Items { get; set; } = new List<PlaylistItem>();
    }
}
