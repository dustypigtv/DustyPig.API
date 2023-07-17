using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public enum LoginType
    {
        Account = 0,
        MainProfile = 1,
        SubProfile = 2
    }


    public class LoginResponse : IEquatable<LoginResponse>
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("login_type")]
        public LoginType LoginType { get; set; }

        /// <summary>
        /// If <see cref="LoginType"/> != <see cref="LoginType.Account"/>, this will hold the id of the logged in profile
        /// </summary>
        [JsonProperty("profile_id")]
        public int? ProfileId { get; set; }


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as LoginResponse);
        }

        public bool Equals(LoginResponse other)
        {
            return !(other is null) &&
                   Token == other.Token &&
                   LoginType == other.LoginType &&
                   ProfileId == other.ProfileId;
        }

        public override int GetHashCode()
        {
            int hashCode = -2053575977;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Token);
            hashCode = hashCode * -1521134295 + LoginType.GetHashCode();
            hashCode = hashCode * -1521134295 + ProfileId.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(LoginResponse left, LoginResponse right)
        {
            return EqualityComparer<LoginResponse>.Default.Equals(left, right);
        }

        public static bool operator !=(LoginResponse left, LoginResponse right)
        {
            return !(left == right);
        }

        #endregion
    }
}
