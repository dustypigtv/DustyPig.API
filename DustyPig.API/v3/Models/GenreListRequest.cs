using DustyPig.API.v3.Interfaces;
using DustyPig.API.v3.MPAA;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DustyPig.API.v3.Models
{
    public class GenreListRequest : ListRequest, IValidate
    {
        [JsonProperty("genre")]
        public Genres Genre { get; set; }

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
    }
}
