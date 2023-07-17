using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class CreateAccountResponse : IEquatable<CreateAccountResponse>
    {
        [JsonProperty("email_verification_required")]
        public bool EmailVerificationRequired { get; set; }

        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as CreateAccountResponse);
        }

        public bool Equals(CreateAccountResponse other)
        {
            return !(other is null) &&
                   EmailVerificationRequired == other.EmailVerificationRequired;
        }

        public override int GetHashCode()
        {
            return -1482514975 + EmailVerificationRequired.GetHashCode();
        }

        public static bool operator ==(CreateAccountResponse left, CreateAccountResponse right)
        {
            return EqualityComparer<CreateAccountResponse>.Default.Equals(left, right);
        }

        public static bool operator !=(CreateAccountResponse left, CreateAccountResponse right)
        {
            return !(left == right);
        }

        #endregion
    }
}
