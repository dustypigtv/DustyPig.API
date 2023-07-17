using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class BasicLibrary : UpdateLibrary, IComparable, IEquatable<BasicLibrary>
    {
        [JsonProperty("owner")]
        public string Owner { get; set; }


        #region IComparable

        public int CompareTo(object obj)
        {
            var comp = (BasicLibrary)obj;
            int ret = -string.IsNullOrWhiteSpace(Owner).CompareTo(string.IsNullOrWhiteSpace(comp.Owner));
            if (ret == 0) ret = Name.CompareTo(comp.Name);
            return ret;
        }

        #endregion


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as BasicLibrary);
        }

        public bool Equals(BasicLibrary other)
        {
            return !(other is null) &&
                   base.Equals(other) &&
                   Owner == other.Owner;
        }

        public override int GetHashCode()
        {
            int hashCode = -203318241;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Owner);
            return hashCode;
        }

        public static bool operator ==(BasicLibrary left, BasicLibrary right)
        {
            return EqualityComparer<BasicLibrary>.Default.Equals(left, right);
        }

        public static bool operator !=(BasicLibrary left, BasicLibrary right)
        {
            return !(left == right);
        }

        #endregion


        public override string ToString() => Name;
    }
}
