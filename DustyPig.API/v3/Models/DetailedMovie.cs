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


        [JsonProperty("bif_asset")]
        public StreamingAsset BifAsset { get; set; }

        [JsonProperty("video_asset")]
        public StreamingAsset VideoAsset { get; set; }

        [JsonProperty("srt_subtitles")]
        public List<ExternalSubtitle> ExternalSubtitles { get; set; }

        /// <summary>
        /// Only returned when calling AdminDetails
        /// </summary>
        [JsonProperty("extra_search_terms")]
        public List<string> ExtraSearchTerms { get; set; }
    }
}
