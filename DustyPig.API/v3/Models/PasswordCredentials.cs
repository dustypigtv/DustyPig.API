using DustyPig.API.v3.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.Models
{
    public class PasswordCredentials : IValidate
    {
        public string Email { get; set; }

        public string Password { get; set; }

        [JsonPropertyName("fcmToken")]
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
    }
}
