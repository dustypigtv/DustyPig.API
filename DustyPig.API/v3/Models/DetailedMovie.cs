using DustyPig.API.v3.BaseClasses;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DetailedMovie : BaseMovieInfo
    {
        [JsonRequired]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("played")]
        public double? Played { get; set; }


        [JsonProperty("bif_url")]
        public string BifUrl { get; set; }

        [JsonProperty("video_url")]
        public string VideoUrl { get; set; }

        [JsonProperty("srt_subtitles")]
        public List<ExternalSubtitle> ExternalSubtitles { get; set; }

        [JsonRequired]
        [JsonProperty("in_watchlist")]
        public bool InWatchlist { get; set; }
    }
}
