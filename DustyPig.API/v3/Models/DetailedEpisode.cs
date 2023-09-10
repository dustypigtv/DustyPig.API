using DustyPig.API.v3.BaseClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DetailedEpisode : BaseEpisodeInfo, IEquatable<DetailedEpisode>
    {
        [JsonRequired]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("bif_url")]
        public string BifUrl { get; set; }

        [JsonProperty("video_url")]
        public string VideoUrl { get; set; }

        [JsonProperty("srt_subtitles")]
        public List<ExternalSubtitle> ExternalSubtitles { get; set; } = new List<ExternalSubtitle>();

        [JsonProperty("played")]
        public double? Played { get; set; }

        [JsonProperty("up_next")]
        public bool UpNext { get; set; }

        /// <summary>
        /// Helpful info for clients, has zero functionality on the server, and is not included in equality checks
        /// </summary>
        [JsonProperty("series_title")]
        public string SeriesTitle { get; set; }


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as DetailedEpisode);
        }

        public bool Equals(DetailedEpisode other)
        {
            return !(other is null) &&
                   base.Equals(other) &&
                   Id == other.Id &&
                   BifUrl == other.BifUrl &&
                   VideoUrl == other.VideoUrl &&
                   EqualityComparer<List<ExternalSubtitle>>.Default.Equals(ExternalSubtitles, other.ExternalSubtitles) &&
                   Played == other.Played &&
                   UpNext == other.UpNext;
        }

        public override int GetHashCode()
        {
            int hashCode = -1362334840;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(BifUrl);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(VideoUrl);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<ExternalSubtitle>>.Default.GetHashCode(ExternalSubtitles);
            hashCode = hashCode * -1521134295 + Played.GetHashCode();
            hashCode = hashCode * -1521134295 + UpNext.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(DetailedEpisode left, DetailedEpisode right)
        {
            return EqualityComparer<DetailedEpisode>.Default.Equals(left, right);
        }

        public static bool operator !=(DetailedEpisode left, DetailedEpisode right)
        {
            return !(left == right);
        }

        #endregion


        public override string ToString() => base.ToString();
    }
}
