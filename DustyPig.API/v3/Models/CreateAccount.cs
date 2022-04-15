using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateAccount : IValidate
    {
        [JsonRequired]
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonRequired]
        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

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

            chk = Validators.Validate(nameof(DisplayName), DisplayName, false, Constants.MAX_NAME_LENGTH);
            if (chk.Valid)
                DisplayName = chk.Fixed;
            else
                lst.Add(chk.Error);

            chk = Validators.Validate(nameof(AvatarUrl), AvatarUrl, false, Constants.MAX_URL_LENGTH);
            if (chk.Valid)
                AvatarUrl = chk.Fixed;
            else
                lst.Add(chk.Error);

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
