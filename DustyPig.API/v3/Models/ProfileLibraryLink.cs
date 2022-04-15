using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class ProfileLibraryLink : IValidate
    {
        [JsonProperty("profile_id")]
        public int ProfileId { get; set; }

        [JsonProperty("library_id")]
        public int LibraryId { get; set; }

        public void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(ProfileId), ProfileId, lst);
            Validators.ValidateId(nameof(LibraryId), LibraryId, lst);

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
