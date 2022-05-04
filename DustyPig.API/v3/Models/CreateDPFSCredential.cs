using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateDPFSCredential : IValidate
    {
        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonRequired]
        [JsonProperty("key")]
        public string Key { get; set; }

        public void Validate()
        {
            var lst = new List<string>();

            var chk = Validators.Validate(nameof(Name), Name, true, Constants.MAX_NAME_LENGTH);
            if (chk.Valid)
                Name = chk.Fixed;
            else
                lst.Add(chk.Error);


            //Don't change cred strings
            chk = Validators.Validate(nameof(Key), Key, true, int.MaxValue);
            if (!chk.Valid)
                lst.Add(chk.Error);


            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
