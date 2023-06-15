using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class ProfileTitleOverrideInfo : IValidate
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

        public void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(ProfileId), ProfileId, lst);

            if (!(State == OverrideState.Allow || State == OverrideState.Block))
                lst.Add($"Invalid {nameof(State)}");

            //Don't validate Name and AvatarUrl. They set by the server for GetTitlePermissions, and ignored for SetTitlePermissions

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
