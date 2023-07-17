using DustyPig.API.v3.Interfaces;
using DustyPig.API.v3.MPAA;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DustyPig.API.v3.Models
{
    public class GenreListRequest : ListRequest, IValidate, IEquatable<GenreListRequest>
    {
        [JsonProperty("genre")]
        public Genres Genre { get; set; }


        #region IValidate

        public new void Validate()
        {
            var lst = new List<string>();

            var allGenres = Enum.GetValues(typeof(Genres)).Cast<long>();
            var min = allGenres.Min();
            var max = allGenres.Max();

            long g = (long)Genre;

            if (g < min || g > max)
                lst.Add($"Invalid {nameof(Genre)}");

            try { base.Validate(); }
            catch (ModelValidationException ex) { lst.AddRange(ex.Errors); }

            if (Start < 0)
                lst.Add($"Invalid {nameof(Start)}");

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

        #endregion


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as GenreListRequest);
        }

        public bool Equals(GenreListRequest other)
        {
            return !(other is null) &&
                   base.Equals(other) &&
                   Genre == other.Genre;
        }

        public override int GetHashCode()
        {
            int hashCode = 1096400374;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Genre.GetHashCode();
            return hashCode;
        }

        

        public static bool operator ==(GenreListRequest left, GenreListRequest right)
        {
            return EqualityComparer<GenreListRequest>.Default.Equals(left, right);
        }

        public static bool operator !=(GenreListRequest left, GenreListRequest right)
        {
            return !(left == right);
        }

        #endregion


        public override string ToString() => Genre.AsString();
    }
}
