using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ProfileCredentials : IValidate, IEquatable<ProfileCredentials>
    {
        [JsonRequired]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("pin")]
        public short? Pin { get; set; }

        [JsonProperty("fcm_token")]
        public string FCMToken { get; set; }


        #region IValidate

        public void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(Id), Id, lst);

            if (Pin.HasValue && Pin.Value < 1000)
                lst.Add($"Invalid {nameof(Pin)}");

            var chk = Validators.Validate(nameof(FCMToken), FCMToken, false, Constants.MAX_MOBILE_DEVICE_ID_LENGTH);
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
            return Equals(obj as ProfileCredentials);
        }

        public bool Equals(ProfileCredentials other)
        {
            return !(other is null) &&
                   Id == other.Id &&
                   Pin == other.Pin &&
                   FCMToken == other.FCMToken;
        }

        public override int GetHashCode()
        {
            int hashCode = -39207710;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + Pin.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FCMToken);
            return hashCode;
        }

        public static bool operator ==(ProfileCredentials left, ProfileCredentials right)
        {
            return EqualityComparer<ProfileCredentials>.Default.Equals(left, right);
        }

        public static bool operator !=(ProfileCredentials left, ProfileCredentials right)
        {
            return !(left == right);
        }

        #endregion
    }
}
