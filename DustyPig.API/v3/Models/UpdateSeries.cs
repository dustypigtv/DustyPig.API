using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class UpdateSeries : CreateSeries
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        public new void Validate()
        {
            var lst = new List<string>();

            if (Id <= 0)
                lst.Add($"Invalid {nameof(Id)}");

            try { base.Validate(); }
            catch (ModelValidationException ex) { lst.AddRange(ex.Errors); }

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
