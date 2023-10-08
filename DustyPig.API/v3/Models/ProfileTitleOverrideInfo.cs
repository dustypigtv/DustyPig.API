using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class ProfileTitleOverrideInfo : IEquatable<ProfileTitleOverrideInfo>
    {
        [JsonProperty("profile_id")]
        public int ProfileId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }


        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }


        [JsonProperty("override_state")]
        public OverrideState OverrideState { get; set; }



        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as ProfileTitleOverrideInfo);
        }

        public bool Equals(ProfileTitleOverrideInfo other)
        {
            return !(other is null) &&
                   ProfileId == other.ProfileId &&
                   Name == other.Name &&
                   AvatarUrl == other.AvatarUrl &&
                   OverrideState == other.OverrideState;
        }

        public override int GetHashCode()
        {
            int hashCode = -360266660;
            hashCode = hashCode * -1521134295 + ProfileId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AvatarUrl);
            hashCode = hashCode * -1521134295 + OverrideState.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(ProfileTitleOverrideInfo left, ProfileTitleOverrideInfo right)
        {
            return EqualityComparer<ProfileTitleOverrideInfo>.Default.Equals(left, right);
        }

        public static bool operator !=(ProfileTitleOverrideInfo left, ProfileTitleOverrideInfo right)
        {
            return !(left == right);
        }

        #endregion
    }
}
