using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class CreatePlaylist : IValidate
    {
        [JsonProperty("name")]
        [JsonRequired]
        public string Name { get; set; }

        
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
