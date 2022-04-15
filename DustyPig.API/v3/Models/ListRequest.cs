using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DustyPig.API.v3.Models
{
    public class ListRequest : IValidate
    {
        [JsonProperty("start")]
        public int Start { get; set; }

        [JsonProperty("sort")]
        public SortOrder Sort { get; set; }

        public void Validate()
        {
            var lst = new List<string>();

            if (Start < 0)
                lst.Add($"Invalid {nameof(Start)}");

            if (!Enum.GetNames(typeof(SortOrder)).Contains(Sort.ToString()))
                lst.Add($"Invalid {nameof(Sort)}");

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
