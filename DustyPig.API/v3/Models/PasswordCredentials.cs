using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class PasswordCredentials : IValidate
    {
        [JsonRequired]
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonRequired]
        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("device_token")]
        public string DeviceToken { get; set; }

        public void Validate()
        {
            var lst = new List<string>();

            var chk = Validators.Validate(nameof(Email), Email, true, int.MaxValue);
            if (chk.Valid)
            {
                Email = chk.Fixed.ToLower();
                if (!StringUtils.IsValidEmail(Email))
                    lst.Add($"Invalid {nameof(Email)}");
            }
            else
            {
                lst.Add(chk.Error);
            }

            
            chk = Validators.Validate(nameof(Password), Password, true, int.MaxValue);
            if (chk.Valid)
                Password = chk.Fixed;
            else
                lst.Add(chk.Error);

            if (Email == Clients.AuthClient.TEST_EMAIL)
                if (Password != Clients.AuthClient.TEST_PASSWORD)
                    lst.Add($"Invalid {nameof(Password)}");

            chk = Validators.Validate(nameof(DeviceToken), DeviceToken, false, Constants.MAX_MOBILE_DEVICE_ID_LENGTH);
            if (chk.Valid)
                DeviceToken = chk.Fixed;
            else
                lst.Add(chk.Error);

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
