using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.BaseClasses
{
    public abstract class BaseEpisodeInfo : IMedia, IEquatable<BaseEpisodeInfo>
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

        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as BaseEpisodeInfo);
        }

        public bool Equals(BaseEpisodeInfo other)
        {
            return !(other is null) &&
                   Title == other.Title &&
                   TMDB_Id == other.TMDB_Id &&
                   Description == other.Description &&
                   ArtworkUrl == other.ArtworkUrl &&
                   Date == other.Date &&
                   Length == other.Length &&
                   IntroStartTime == other.IntroStartTime &&
                   IntroEndTime == other.IntroEndTime &&
                   CreditsStartTime == other.CreditsStartTime &&
                   SeriesId == other.SeriesId &&
                   SeasonNumber == other.SeasonNumber &&
                   EpisodeNumber == other.EpisodeNumber;
        }

        public override int GetHashCode()
        {
            int hashCode = 29759748;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + TMDB_Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ArtworkUrl);
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            hashCode = hashCode * -1521134295 + Length.GetHashCode();
            hashCode = hashCode * -1521134295 + IntroStartTime.GetHashCode();
            hashCode = hashCode * -1521134295 + IntroEndTime.GetHashCode();
            hashCode = hashCode * -1521134295 + CreditsStartTime.GetHashCode();
            hashCode = hashCode * -1521134295 + SeriesId.GetHashCode();
            hashCode = hashCode * -1521134295 + SeasonNumber.GetHashCode();
            hashCode = hashCode * -1521134295 + EpisodeNumber.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(BaseEpisodeInfo left, BaseEpisodeInfo right)
        {
            return EqualityComparer<BaseEpisodeInfo>.Default.Equals(left, right);
        }

        public static bool operator !=(BaseEpisodeInfo left, BaseEpisodeInfo right)
        {
            return !(left == right);
        }

        #endregion


        public override string ToString() => $"s{SeasonNumber:00}e{EpisodeNumber:00}";
    }
}
