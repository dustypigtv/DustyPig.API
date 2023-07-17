using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DustyPig.API.v3.Models
{
    public class ListRequest : IValidate, IEquatable<ListRequest>
    {
        [JsonProperty("start")]
        public int Start { get; set; }

        [JsonProperty("sort")]
        public SortOrder Sort { get; set; }

        #region IValidate

        public void Validate()
        {
            var lst = new List<string>();

            if (Start < 0)
                Start = 0;

            if (!Enum.GetNames(typeof(SortOrder)).Contains(Sort.ToString()))
                lst.Add($"Invalid {nameof(Sort)}");

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

        #endregion


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as ListRequest);
        }

        public bool Equals(ListRequest other)
        {
            return !(other is null) &&
                   Start == other.Start &&
                   Sort == other.Sort;
        }

        public override int GetHashCode()
        {
            int hashCode = 1356159048;
            hashCode = hashCode * -1521134295 + Start.GetHashCode();
            hashCode = hashCode * -1521134295 + Sort.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(ListRequest left, ListRequest right)
        {
            return EqualityComparer<ListRequest>.Default.Equals(left, right);
        }

        public static bool operator !=(ListRequest left, ListRequest right)
        {
            return !(left == right);
        }

        #endregion
    }
}
