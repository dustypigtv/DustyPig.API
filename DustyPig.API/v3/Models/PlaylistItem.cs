using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class PlaylistItem
    {
        [JsonProperty("id")]
        [JsonRequired]
        public int Id { get; set; }

        [JsonProperty("index")]
        [JsonRequired]
        public int Index { get; set; }

        [JsonProperty("media_id")]
        [JsonRequired]
        public int MediaId { get; set; }


        [JsonProperty("series_id")]
        [JsonRequired]
        public int? SeriesId { get; set; }

        [JsonRequired]
        [JsonProperty("media_type")]
        public MediaTypes MediaType { get; set; }

        [JsonRequired]
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonRequired]
        [JsonProperty("artwork_url")]
        public string ArtworkUrl { get; set; }

        [JsonProperty("played")]
        public double? Played { get; set; }


        [JsonProperty("bif_asset")]
        public StreamingAsset BifAsset { get; set; }

        [JsonProperty("video_asset")]
        public StreamingAsset VideoAsset { get; set; }

        [JsonProperty("srt_subtitles")]
        public List<ExternalSubtitle> ExternalSubtitles { get; set; }

    }
}
