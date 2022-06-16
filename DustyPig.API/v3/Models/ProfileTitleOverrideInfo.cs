using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class ProfileTitleOverrideInfo : IValidate
    {
        [JsonProperty("profile_id")]
        public int ProfileId { get; set; }

        [JsonProperty("new_state")]
        public OverrideState NewState { get; set; }

        public void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(ProfileId), ProfileId, lst);

            if (!(NewState == OverrideState.Allow || NewState == OverrideState.Block || NewState == OverrideState.Default))
                lst.Add($"Invalid {nameof(NewState)}");

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
