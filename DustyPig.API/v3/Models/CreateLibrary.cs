using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateLibrary : IValidate
    {
        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonRequired]
        [JsonProperty("is_tv")]
        public bool IsTV { get; set; }


        public void Validate()
        {
            var lst = new List<string>();

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
