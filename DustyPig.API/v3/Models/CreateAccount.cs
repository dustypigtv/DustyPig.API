using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateAccount : IValidate, IEquatable<CreateAccount>
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

            if (Email == Clients.AuthClient.TEST_EMAIL)
                lst.Add("Test email is not valid for this action");

            chk = Validators.Validate(nameof(Password), Password, true, int.MaxValue);
            if (chk.Valid)
                Password = chk.Fixed;
            else
                lst.Add(chk.Error);

            chk = Validators.Validate(nameof(DisplayName), DisplayName, true, Constants.MAX_NAME_LENGTH);
            if (chk.Valid)
                DisplayName = chk.Fixed;
            else
                lst.Add(chk.Error);

            chk = Validators.Validate(nameof(AvatarUrl), AvatarUrl, false, Constants.MAX_URL_LENGTH);
            if (chk.Valid)
                AvatarUrl = chk.Fixed;
            else
                lst.Add(chk.Error);

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
            return Equals(obj as CreateAccount);
        }

        public bool Equals(CreateAccount other)
        {
            return !(other is null) &&
                   Email == other.Email &&
                   Password == other.Password &&
                   DisplayName == other.DisplayName &&
                   AvatarUrl == other.AvatarUrl &&
                   FCMToken == other.FCMToken;
        }

        public override int GetHashCode()
        {
            int hashCode = -1250285400;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DisplayName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AvatarUrl);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FCMToken);
            return hashCode;
        }

        public static bool operator ==(CreateAccount left, CreateAccount right)
        {
            return EqualityComparer<CreateAccount>.Default.Equals(left, right);
        }

        public static bool operator !=(CreateAccount left, CreateAccount right)
        {
            return !(left == right);
        }

        #endregion


        public override string ToString() => StringUtils.Coalesce(DisplayName, Email);

    }
}
