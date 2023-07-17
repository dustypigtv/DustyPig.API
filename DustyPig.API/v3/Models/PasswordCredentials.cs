using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class PasswordCredentials : IValidate, IEquatable<PasswordCredentials>
    {
        [JsonRequired]
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonRequired]
        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("fcm_token")]
        public string FCMToken { get; set; }


        #region IValidate

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

            chk = Validators.Validate(nameof(FCMToken), FCMToken, false, Constants.MAX_MOBILE_DEVICE_ID_LENGTH);
            if (chk.Valid)
                FCMToken = chk.Fixed;
            else
                lst.Add(chk.Error);

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

        #endregion


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as PasswordCredentials);
        }

        public bool Equals(PasswordCredentials other)
        {
            return !(other is null) &&
                   Email == other.Email &&
                   Password == other.Password &&
                   FCMToken == other.FCMToken;
        }

        public override int GetHashCode()
        {
            int hashCode = -271805987;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FCMToken);
            return hashCode;
        }

        
        public static bool operator ==(PasswordCredentials left, PasswordCredentials right)
        {
            return EqualityComparer<PasswordCredentials>.Default.Equals(left, right);
        }

        public static bool operator !=(PasswordCredentials left, PasswordCredentials right)
        {
            return !(left == right);
        }

        #endregion
    }
}
