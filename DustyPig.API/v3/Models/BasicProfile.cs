using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class BasicProfile : IComparable, IEquatable<BasicProfile>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("is_main")]
        public bool IsMain { get; set; }

        [JsonProperty("has_pin")]
        public bool HasPin { get; set; }


        #region IComparable

        public int CompareTo(object obj)
        {
            var comp = obj as BasicProfile;
            int ret = -IsMain.CompareTo(comp.IsMain);
            if (ret == 0) ret = Name.CompareTo(comp.Name);
            return ret;
        }

        #endregion

        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as BasicProfile);
        }

        public bool Equals(BasicProfile other)
        {
            return !(other is null) &&
                   Id == other.Id &&
                   Name == other.Name &&
                   AvatarUrl == other.AvatarUrl &&
                   IsMain == other.IsMain &&
                   HasPin == other.HasPin;
        }

        public override int GetHashCode()
        {
            int hashCode = -1242372443;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AvatarUrl);
            hashCode = hashCode * -1521134295 + IsMain.GetHashCode();
            hashCode = hashCode * -1521134295 + HasPin.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(BasicProfile left, BasicProfile right)
        {
            return EqualityComparer<BasicProfile>.Default.Equals(left, right);
        }

        public static bool operator !=(BasicProfile left, BasicProfile right)
        {
            return !(left == right);
        }

        #endregion


        public override string ToString() => Name;

    }
}
