using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class DetailedPlaylist : BasicPlaylist, IEquatable<DetailedPlaylist>
    {
        [JsonRequired]
        [JsonProperty("current_item_id")]
        public int CurrentItemId { get; set; }

        [JsonProperty("current_progress")]
        public double CurrentProgress { get; set; }

        [JsonRequired]
        [JsonProperty("items")]
        public List<PlaylistItem> Items { get; set; } = new List<PlaylistItem>();


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as DetailedPlaylist);
        }

        public bool Equals(DetailedPlaylist other)
        {
            return !(other is null) &&
                   base.Equals(other) &&
                   CurrentItemId == other.CurrentItemId &&
                   CurrentProgress == other.CurrentProgress &&
                   EqualityComparer<List<PlaylistItem>>.Default.Equals(Items, other.Items);
        }

        public override int GetHashCode()
        {
            int hashCode = 519810995;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + CurrentItemId.GetHashCode();
            hashCode = hashCode * -1521134295 + CurrentProgress.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<PlaylistItem>>.Default.GetHashCode(Items);
            return hashCode;
        }

        public static bool operator ==(DetailedPlaylist left, DetailedPlaylist right)
        {
            return EqualityComparer<DetailedPlaylist>.Default.Equals(left, right);
        }

        public static bool operator !=(DetailedPlaylist left, DetailedPlaylist right)
        {
            return !(left == right);
        }

        #endregion


        public override string ToString() => base.ToString();
    }
}
