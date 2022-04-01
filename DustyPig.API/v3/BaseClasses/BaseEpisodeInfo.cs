using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;

namespace DustyPig.API.v3.BaseClasses
{
    public abstract class BaseEpisodeInfo : IMedia
    {
        #region IMedia

        [JsonRequired]
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("tmdb_id")]
        public int? TMDB_Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonRequired]
        [JsonProperty("artwork_url")]
        public string ArtworkUrl { get; set; }

        #endregion


        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonRequired]
        [JsonProperty("length")]
        public double Length { get; set; }

        [JsonProperty("intro_start_time")]
        public double? IntroStartTime { get; set; }

        [JsonProperty("intro_end_time")]
        public double? IntroEndTime { get; set; }

        [JsonProperty("credits_start_time")]
        public double? CreditsStartTime { get; set; }

        [JsonRequired]
        [JsonProperty("series_id")]
        public int SeriesId { get; set; }

        [JsonRequired]
        [JsonProperty("season_number")]
        public ushort SeasonNumber { get; set; }

        [JsonRequired]
        [JsonProperty("episode_number")]
        public ushort EpisodeNumber { get; set; }


    }
}
