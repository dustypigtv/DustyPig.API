using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SearchRequest : IValidate
    {
        [JsonRequired]
        [JsonProperty("query")] 
        public string Query { get; set; }

        [JsonProperty("search_tmdb")] 
        public bool SearchTMDB { get; set; }

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
    }
}
