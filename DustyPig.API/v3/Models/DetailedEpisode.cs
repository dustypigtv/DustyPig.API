using DustyPig.API.v3.BaseClasses;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DetailedEpisode : BaseEpisodeInfo
    {
        [JsonRequired]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("bif_asset")]
        public StreamingAsset BifAsset { get; set; }

        [JsonRequired]
        [JsonProperty("video_asset")]
        public StreamingAsset VideoAsset { get; set; }

        [JsonProperty("srt_subtitles")]
        public List<ExternalSubtitle> ExternalSubtitles { get; set; } = new List<ExternalSubtitle>();

        [JsonProperty("played")]
        public double? Played { get; set; }

        [JsonProperty("up_next")]
        public bool UpNext { get; set; }
    }
}
