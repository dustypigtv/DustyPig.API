using DustyPig.API.v3.Interfaces;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.Models
{
    public class SearchRequest : IValidate
    {
        public string Query { get; set; }

        [JsonPropertyName("searchTMDB")]
        public bool SearchTMDB { get; set; }

        public bool SearchForPeople { get; set; }

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
    }
}
