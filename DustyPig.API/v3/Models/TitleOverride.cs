using DustyPig.API.v3.Interfaces;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class TitleOverride : IValidate
    {
        public int MediaEntryId { get; set; }

        public int ProfileId { get; set; }

        public int? RequestId { get; set; }

        public OverrideState State { get; set; }

        public void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(MediaEntryId), MediaEntryId, lst);
            Validators.ValidateId(nameof(ProfileId), ProfileId, lst);
            if(RequestId.HasValue)
                Validators.ValidateId(nameof(RequestId), RequestId.Value, lst);

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

    }
}
