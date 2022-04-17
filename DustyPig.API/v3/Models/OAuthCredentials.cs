using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DustyPig.API.v3.Models
{
    public enum OAuthCredentialProviders
    {
        Apple,
        Facebook,
        Google
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class OAuthCredentials : IValidate
    {
        [JsonRequired]
        [JsonProperty("provider")]
        public OAuthCredentialProviders Provider { get; set; }

        [JsonRequired]
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("device_token")]
        public string DeviceToken { get; set; }

        public void Validate()
        {
            var lst = new List<string>();
            if (!Enum.GetNames(typeof(OAuthCredentialProviders)).Contains(Provider.ToString()))
                lst.Add($"Invalid {nameof(Provider)}");


            var chk = Validators.Validate(nameof(Token), Token, true, int.MaxValue);
            if (chk.Valid)
                Token = chk.Fixed;
            else
                lst.Add(chk.Error);

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
