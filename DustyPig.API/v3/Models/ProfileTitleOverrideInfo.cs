using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class ProfileTitleOverrideInfo : IValidate
    {
        [JsonProperty("profile_id")]
        public int ProfileId { get; set; }

        [JsonProperty("state")]
        public OverrideState State { get; set; }

        public void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(ProfileId), ProfileId, lst);

            if (!(State == OverrideState.Allow || State == OverrideState.Block || State == OverrideState.Default))
                lst.Add($"Invalid {nameof(State)}");

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
