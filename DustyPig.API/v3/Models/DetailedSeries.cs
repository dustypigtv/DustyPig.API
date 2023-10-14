using DustyPig.API.v3.BaseClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DetailedSeries : BaseSeriesInfo, IEquatable<DetailedSeries>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("episodes")]
        public List<DetailedEpisode> Episodes { get; set; } = new List<DetailedEpisode>();

        [JsonRequired]
        [JsonProperty("in_watchlist")]
        public bool InWatchlist { get; set; }

        [JsonProperty("can_play")]
        public bool CanPlay { get; set; }

        [JsonProperty("can_manage")]
        public bool CanManage { get; set; }

        [JsonProperty("title_request_permission")]
        public TitleRequestPermissions TitleRequestPermission { get; set; }


        [JsonProperty("access_request_status")]
        public OverrideRequestStatus AccessRequestedStatus { get; set; }


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as DetailedSeries);
        }

        public bool Equals(DetailedSeries other)
        {
            return !(other is null) &&
                   base.Equals(other) &&
                   Id == other.Id &&
                   Owner == other.Owner &&
                   EqualityComparer<List<DetailedEpisode>>.Default.Equals(Episodes, other.Episodes) &&
                   InWatchlist == other.InWatchlist &&
                   CanPlay == other.CanPlay &&
                   CanManage == other.CanManage &&
                   AccessRequestedStatus == other.AccessRequestedStatus;
        }

        public override int GetHashCode()
        {
            int hashCode = 9335446;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Owner);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<DetailedEpisode>>.Default.GetHashCode(Episodes);
            hashCode = hashCode * -1521134295 + InWatchlist.GetHashCode();
            hashCode = hashCode * -1521134295 + CanPlay.GetHashCode();
            hashCode = hashCode * -1521134295 + CanManage.GetHashCode();
            hashCode = hashCode * -1521134295 + AccessRequestedStatus.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(DetailedSeries left, DetailedSeries right)
        {
            return EqualityComparer<DetailedSeries>.Default.Equals(left, right);
        }

        public static bool operator !=(DetailedSeries left, DetailedSeries right)
        {
            return !(left == right);
        }

        #endregion


        public override string ToString() => base.ToString();
    }
}
