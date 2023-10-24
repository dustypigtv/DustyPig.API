using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class AddSeriesToPlaylistInfo : AddPlaylistItem, IEquatable<AddSeriesToPlaylistInfo>
    {
        /// <summary>
        /// Automatically add new episodes to this playlist when they become available in the series
        /// </summary>
        [JsonProperty("auto_add_new_episodes")]
        public bool AutoAddNewEpisodes { get; set; }

        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as AddSeriesToPlaylistInfo);
        }

        public bool Equals(AddSeriesToPlaylistInfo other)
        {
            return !(other is null) &&
                   base.Equals(other) &&
                   AutoAddNewEpisodes == other.AutoAddNewEpisodes;
        }

        public override int GetHashCode()
        {
            int hashCode = -816778523;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + AutoAddNewEpisodes.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(AddSeriesToPlaylistInfo left, AddSeriesToPlaylistInfo right)
        {
            return EqualityComparer<AddSeriesToPlaylistInfo>.Default.Equals(left, right);
        }

        public static bool operator !=(AddSeriesToPlaylistInfo left, AddSeriesToPlaylistInfo right)
        {
            return !(left == right);
        }

        #endregion

    }
}
