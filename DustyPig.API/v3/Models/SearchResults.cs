using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SearchResults : IEquatable<SearchResults>
    {
        [JsonRequired]
        [JsonProperty("available")]
        public List<BasicMedia> Available { get; set; } = new List<BasicMedia>();

        [JsonRequired]
        [JsonProperty("other_titles_allowed")]
        public bool OtherTitlesAllowed { get; set; }

        [JsonRequired]
        [JsonProperty("other_titles")]
        public List<BasicTMDB> OtherTitles { get; set; } = new List<BasicTMDB>();

        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as SearchResults);
        }

        public bool Equals(SearchResults other)
        {
            return !(other is null) &&
                   EqualityComparer<List<BasicMedia>>.Default.Equals(Available, other.Available) &&
                   OtherTitlesAllowed == other.OtherTitlesAllowed &&
                   EqualityComparer<List<BasicTMDB>>.Default.Equals(OtherTitles, other.OtherTitles);
        }

        public override int GetHashCode()
        {
            int hashCode = 1649303048;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<BasicMedia>>.Default.GetHashCode(Available);
            hashCode = hashCode * -1521134295 + OtherTitlesAllowed.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<BasicTMDB>>.Default.GetHashCode(OtherTitles);
            return hashCode;
        }

        public static bool operator ==(SearchResults left, SearchResults right)
        {
            return EqualityComparer<SearchResults>.Default.Equals(left, right);
        }

        public static bool operator !=(SearchResults left, SearchResults right)
        {
            return !(left == right);
        }

        #endregion
    }
}
