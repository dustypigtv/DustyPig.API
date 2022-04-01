using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateGoogleDriveCredential
    {
        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonRequired]
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonRequired]
        [JsonProperty("service_credentials_json")]
        public string ServiceCredentialsJson { get; set; }



        public void Validate()
        {
            var lst = new List<string>();

            var chk = Validators.Validate(nameof(Name), Name, true, Constants.MAX_NAME_LENGTH);
            if (chk.Valid)
                Name = chk.Fixed;
            else
                lst.Add(chk.Error);

            chk = Validators.Validate(nameof(Email), Email, true, int.MaxValue);
            if (chk.Valid)
                Email = chk.Fixed;
            else
                lst.Add(chk.Error);

            //Don't change the text of the credential
            chk = Validators.Validate(nameof(ServiceCredentialsJson), ServiceCredentialsJson, true, int.MaxValue);
            if (!chk.Valid)
                lst.Add(chk.Error);

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
