using DustyPig.API.v3.Interfaces;
using DustyPig.API.v3.MPAA;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DustyPig.API.v3.Models
{
    public class GenreListRequest : IValidate
    {
        [JsonProperty("genre")]
        public Genres Genre { get; set; }

        [JsonProperty("start")]
        public int Start { get; set; }

        public void Validate()
        {
            var lst = new List<string>();

            long g = (long)Genre;
            if (g == 0)
            {
                lst.Add($"Invalid {nameof(Genre)}");
            }
            else if (g > 0)
            {
                if(!Enum.GetNames(typeof(Genres)).Contains(Genre.ToString()))
                    lst.Add($"Invalid {nameof(Genre)}");
            }
            //g < 0 is speciallized request, like 'Up Next'

            if (Start < 0)
                lst.Add($"Invalid {nameof(Start)}");

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
