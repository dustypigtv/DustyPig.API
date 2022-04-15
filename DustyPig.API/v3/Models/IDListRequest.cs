using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class IDListRequest : IValidate
    {
        [JsonProperty("list_id")]
        public long ListId { get; set; }

        [JsonProperty("start")]
        public int Start { get; set; }

        public void Validate()
        {
            var lst = new List<string>();

            if (Start < 0)
                lst.Add($"Invalid {nameof(Start)}");

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

    }
}
