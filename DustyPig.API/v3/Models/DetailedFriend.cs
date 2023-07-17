using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DetailedFriend : BasicFriend, IEquatable<DetailedFriend>
    {
        [JsonProperty("accepted")]
        public bool Accepted { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("shared_with_friend")]
        public List<BasicLibrary> SharedWithFriend { get; set; } = new List<BasicLibrary>();

        [JsonProperty("shared_with_me")]
        public List<BasicLibrary> SharedWithMe { get; set; } = new List<BasicLibrary>();


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as DetailedFriend);
        }

        public bool Equals(DetailedFriend other)
        {
            return !(other is null) &&
                   base.Equals(other) &&
                   Accepted == other.Accepted &&
                   Timestamp == other.Timestamp &&
                   EqualityComparer<List<BasicLibrary>>.Default.Equals(SharedWithFriend, other.SharedWithFriend) &&
                   EqualityComparer<List<BasicLibrary>>.Default.Equals(SharedWithMe, other.SharedWithMe);
        }

        public override int GetHashCode()
        {
            int hashCode = 848902802;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Accepted.GetHashCode();
            hashCode = hashCode * -1521134295 + Timestamp.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<BasicLibrary>>.Default.GetHashCode(SharedWithFriend);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<BasicLibrary>>.Default.GetHashCode(SharedWithMe);
            return hashCode;
        }

        public static bool operator ==(DetailedFriend left, DetailedFriend right)
        {
            return EqualityComparer<DetailedFriend>.Default.Equals(left, right);
        }

        public static bool operator !=(DetailedFriend left, DetailedFriend right)
        {
            return !(left == right);
        }

        #endregion


        public override string ToString() => base.ToString();
    }
}
