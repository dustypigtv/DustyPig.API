using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SearchRequest : IValidate, IEquatable<SearchRequest>
    {
        [JsonRequired]
        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("search_tmdb")]
        public bool SearchTMDB { get; set; }


        #region IValidate

        public void Validate()
        {
            var lst = new List<string>();

            var chk = Validators.Validate(nameof(Query), Query, true, Constants.MAX_NAME_LENGTH);
            if (chk.Valid)
                Query = chk.Fixed.ToLower();
            else
                lst.Add(chk.Error);

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

        #endregion


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as SearchRequest);
        }

        public bool Equals(SearchRequest other)
        {
            return !(other is null) &&
                   Query == other.Query &&
                   SearchTMDB == other.SearchTMDB;
        }

        public override int GetHashCode()
        {
            int hashCode = 652018495;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Query);
            hashCode = hashCode * -1521134295 + SearchTMDB.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(SearchRequest left, SearchRequest right)
        {
            return EqualityComparer<SearchRequest>.Default.Equals(left, right);
        }

        public static bool operator !=(SearchRequest left, SearchRequest right)
        {
            return !(left == right);
        }

        #endregion
    }
}
