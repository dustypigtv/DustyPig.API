using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TitlePermissionInfo : IValidate
    {
        [JsonProperty("title_id")]
        public int TitleId { get; set; }

        /// <summary>
        /// Profiles not listed will not have overrides changed
        /// </summary>
        [JsonProperty("profiles")]
        public List<ProfileTitleOverrideInfo> Profiles { get; set; } = new List<ProfileTitleOverrideInfo>();

        public void Validate()
        {
            var lst = new List<string>();
            Validators.ValidateId(nameof(TitleId), TitleId, lst);

            Profiles ??= new List<ProfileTitleOverrideInfo>();
            foreach (var profile in Profiles)
                try { profile.Validate(); }
                catch (ModelValidationException ex) { lst.AddRange(ex.Errors); }

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
