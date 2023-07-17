using DustyPig.API.v3.BaseClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DetailedMovie : BaseMovieInfo, IEquatable<DetailedMovie>
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
        public List<ExternalSubtitle> ExternalSubtitles { get; set; } = new List<ExternalSubtitle>();

        [JsonProperty("in_watchlist")]
        public bool InWatchlist { get; set; }

        [JsonProperty("can_play")]
        public bool CanPlay { get; set; }

        [JsonProperty("can_manage")]
        public bool CanManage { get; set; }

        [JsonProperty("access_request_status")]
        public OverrideRequestStatus AccessRequestedStatus { get; set; }


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as DetailedMovie);
        }

        public bool Equals(DetailedMovie other)
        {
            return !(other is null) &&
                   base.Equals(other) &&
                   Id == other.Id &&
                   Owner == other.Owner &&
                   Played == other.Played &&
                   BifUrl == other.BifUrl &&
                   VideoUrl == other.VideoUrl &&
                   EqualityComparer<List<ExternalSubtitle>>.Default.Equals(ExternalSubtitles, other.ExternalSubtitles) &&
                   InWatchlist == other.InWatchlist &&
                   CanPlay == other.CanPlay &&
                   CanManage == other.CanManage &&
                   AccessRequestedStatus == other.AccessRequestedStatus;
        }

        public override int GetHashCode()
        {
            int hashCode = -1848868944;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Owner);
            hashCode = hashCode * -1521134295 + Played.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(BifUrl);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(VideoUrl);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<ExternalSubtitle>>.Default.GetHashCode(ExternalSubtitles);
            hashCode = hashCode * -1521134295 + InWatchlist.GetHashCode();
            hashCode = hashCode * -1521134295 + CanPlay.GetHashCode();
            hashCode = hashCode * -1521134295 + CanManage.GetHashCode();
            hashCode = hashCode * -1521134295 + AccessRequestedStatus.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(DetailedMovie left, DetailedMovie right)
        {
            return EqualityComparer<DetailedMovie>.Default.Equals(left, right);
        }

        public static bool operator !=(DetailedMovie left, DetailedMovie right)
        {
            return !(left == right);
        }

        #endregion


        public override string ToString() => base.ToString();
    }
}
