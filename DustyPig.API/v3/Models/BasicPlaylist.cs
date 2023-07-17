using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class BasicPlaylist : CreatePlaylist, IEquatable<BasicPlaylist>
    {
        [JsonProperty("id")]
        [JsonRequired]
        public int Id { get; set; }

        [JsonProperty("artwork_url")]
        [JsonRequired]
        public string ArtworkUrl { get; set; }


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as BasicPlaylist);
        }

        public bool Equals(BasicPlaylist other)
        {
            return !(other is null) &&
                   base.Equals(other) &&
                   Id == other.Id &&
                   ArtworkUrl == other.ArtworkUrl;
        }

        public override int GetHashCode()
        {
            int hashCode = -1401875420;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ArtworkUrl);
            return hashCode;
        }

        public static bool operator ==(BasicPlaylist left, BasicPlaylist right)
        {
            return EqualityComparer<BasicPlaylist>.Default.Equals(left, right);
        }

        public static bool operator !=(BasicPlaylist left, BasicPlaylist right)
        {
            return !(left == right);
        }

        #endregion


        public override string ToString() => base.ToString();

    }
}
