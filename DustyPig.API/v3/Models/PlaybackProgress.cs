using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class PlaybackProgress : IEquatable<PlaybackProgress>
    {
        /// <summary>
        /// For playlists, this is the <see cref="PlaylistItem.Id"/>. Otherwise, this is the movie or episode id
        /// </summary>
        [JsonRequired]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Set to 0 to reset
        /// </summary>
        [JsonRequired]
        [JsonProperty("seconds")]
        public double Seconds { get; set; }


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as PlaybackProgress);
        }

        public bool Equals(PlaybackProgress other)
        {
            return !(other is null) &&
                   Id == other.Id &&
                   Seconds == other.Seconds;
        }

        public override int GetHashCode()
        {
            int hashCode = -70937206;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + Seconds.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(PlaybackProgress left, PlaybackProgress right)
        {
            return EqualityComparer<PlaybackProgress>.Default.Equals(left, right);
        }

        public static bool operator !=(PlaybackProgress left, PlaybackProgress right)
        {
            return !(left == right);
        }

        #endregion
    }
}
