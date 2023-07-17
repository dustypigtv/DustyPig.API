using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class ProfileTitleOverrideInfo : IValidate, IEquatable<ProfileTitleOverrideInfo>
    {
        [JsonProperty("profile_id")]
        public int ProfileId { get; set; }

        /// <summary>
        /// This is filled in for <see cref="Clients.MediaClient.GetTitlePermissionsAsync(int, System.Threading.CancellationToken)"/>, and is ignored for <see cref="Clients.MediaClient.SetTitlePermissionsAsync(TitlePermissionInfo, System.Threading.CancellationToken)"/>
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }


        /// <summary>
        /// This is filled in for <see cref="Clients.MediaClient.GetTitlePermissionsAsync(int, System.Threading.CancellationToken)"/>, and is ignored for <see cref="Clients.MediaClient.SetTitlePermissionsAsync(TitlePermissionInfo, System.Threading.CancellationToken)"/>
        /// </summary>
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }


        [JsonProperty("state")]
        public OverrideState State { get; set; }


        #region IValidate

        public void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(ProfileId), ProfileId, lst);

            if (!(State == OverrideState.Allow || State == OverrideState.Block))
                lst.Add($"Invalid {nameof(State)}");

            //Don't validate Name and AvatarUrl. They are set by the server for GetTitlePermissions, and ignored for SetTitlePermissions

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

        #endregion


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
                   State == other.State;
        }

        public override int GetHashCode()
        {
            int hashCode = -360266660;
            hashCode = hashCode * -1521134295 + ProfileId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AvatarUrl);
            hashCode = hashCode * -1521134295 + State.GetHashCode();
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
