using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateS3Credential : IValidate
    {
        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonRequired]
        [JsonProperty("endpoint")]
        public string Endpoint { get; set; }

        [JsonRequired]
        [JsonProperty("access_key")]
        public string AccessKey { get; set; }

        [JsonRequired]
        [JsonProperty("access_secret")]
        public string AccessSecret { get; set; }


        public void Validate()
        {
            var lst = new List<string>();

            var chk = Validators.Validate(nameof(Name), Name, true, Constants.MAX_NAME_LENGTH);
            if (chk.Valid)
                Name = chk.Fixed;
            else
                lst.Add(chk.Error);


            //Don't change cred strings
            chk = Validators.Validate(nameof(Endpoint), Endpoint, true, int.MaxValue);
            if (!chk.Valid)
                lst.Add(chk.Error);


            chk = Validators.Validate(nameof(AccessKey), AccessKey, true, int.MaxValue);
            if (!chk.Valid)
                lst.Add(chk.Error);


            chk = Validators.Validate(nameof(AccessSecret), AccessSecret, true, int.MaxValue);
            if (!chk.Valid)
                lst.Add(chk.Error);

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
