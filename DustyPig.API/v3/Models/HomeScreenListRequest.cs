using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class HomeScreenListRequest : IValidate, IEquatable<HomeScreenListRequest>
    {
        [JsonProperty("list_id")]
        public long ListId { get; set; }

        [JsonProperty("start")]
        public int Start { get; set; }


        #region IValidate

        public void Validate()
        {
            var lst = new List<string>();

            if (Start < 0)
                lst.Add($"Invalid {nameof(Start)}");

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

        #endregion


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as HomeScreenListRequest);
        }

        public bool Equals(HomeScreenListRequest other)
        {
            return !(other is null) &&
                   ListId == other.ListId &&
                   Start == other.Start;
        }

        public override int GetHashCode()
        {
            int hashCode = -119949965;
            hashCode = hashCode * -1521134295 + ListId.GetHashCode();
            hashCode = hashCode * -1521134295 + Start.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(HomeScreenListRequest left, HomeScreenListRequest right)
        {
            return EqualityComparer<HomeScreenListRequest>.Default.Equals(left, right);
        }

        public static bool operator !=(HomeScreenListRequest left, HomeScreenListRequest right)
        {
            return !(left == right);
        }

        #endregion
    }
}
