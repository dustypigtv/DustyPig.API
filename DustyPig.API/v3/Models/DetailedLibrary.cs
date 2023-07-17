using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DetailedLibrary : BasicLibrary, IEquatable<DetailedLibrary>
    {
        [JsonProperty("profiles")]
        public List<BasicProfile> Profiles { get; set; } = new List<BasicProfile>();

        [JsonProperty("shared_with")]
        public List<BasicFriend> SharedWith { get; set; } = new List<BasicFriend>();

        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as DetailedLibrary);
        }

        public bool Equals(DetailedLibrary other)
        {
            return !(other is null) &&
                   base.Equals(other) &&
                   EqualityComparer<List<BasicProfile>>.Default.Equals(Profiles, other.Profiles) &&
                   EqualityComparer<List<BasicFriend>>.Default.Equals(SharedWith, other.SharedWith);
        }

        public override int GetHashCode()
        {
            int hashCode = -1728390543;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<BasicProfile>>.Default.GetHashCode(Profiles);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<BasicFriend>>.Default.GetHashCode(SharedWith);
            return hashCode;
        }

        public static bool operator ==(DetailedLibrary left, DetailedLibrary right)
        {
            return EqualityComparer<DetailedLibrary>.Default.Equals(left, right);
        }

        public static bool operator !=(DetailedLibrary left, DetailedLibrary right)
        {
            return !(left == right);
        }

        #endregion


        public override string ToString() => base.ToString();
    }
}
