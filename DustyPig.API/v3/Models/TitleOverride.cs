using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class TitleOverride : IValidate
    {
        [JsonProperty("media_entry_id")]
        public int MediaEntryId { get; set; }

        [JsonProperty("overrides")]
        public List<ProfileTitleOverrideInfo> Overrides { get; set; } = new List<ProfileTitleOverrideInfo>();

        public void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(MediaEntryId), MediaEntryId, lst);

            if (Overrides == null || Overrides.Count == 0)
                lst.Add($"{nameof(Overrides)} may not be empty");
            else
                foreach (var item in Overrides)
                    try { item.Validate(); }
                    catch (ModelValidationException ex) { lst.AddRange(ex.Errors); }


            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

    }
}
