using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class BasicFriend : IComparable, IEquatable<BasicFriend>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonRequired]
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonRequired]
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        #region IComparable

        public int CompareTo(object obj)
        {
            var comp = obj as BasicFriend;
            return DisplayName.CompareTo(comp.DisplayName);
        }

        #endregion


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as BasicFriend);
        }

        public bool Equals(BasicFriend other)
        {
            return !(other is null) &&
                   Id == other.Id &&
                   DisplayName == other.DisplayName &&
                   AvatarUrl == other.AvatarUrl;
        }

        public override int GetHashCode()
        {
            int hashCode = -9873181;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DisplayName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AvatarUrl);
            return hashCode;
        }

        public static bool operator ==(BasicFriend left, BasicFriend right)
        {
            return EqualityComparer<BasicFriend>.Default.Equals(left, right);
        }

        public static bool operator !=(BasicFriend left, BasicFriend right)
        {
            return !(left == right);
        }

        #endregion


        public override string ToString() => DisplayName;

    }
}
