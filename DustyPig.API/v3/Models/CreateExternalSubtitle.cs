using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateExternalSubtitle : CreateStreamingAsset
    {
        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }

        public new void Validate()
        {
            var lst = new List<string>();

            try { base.Validate(); }
            catch (ModelValidationException ex) { lst.AddRange(ex.Errors); }


            var (Valid, Fixed, Error) = Validators.Validate(nameof(Name), Name, true, Constants.MAX_NAME_LENGTH);
            if (Valid)
                Name = Fixed;
            else
                lst.Add(Error);


            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
