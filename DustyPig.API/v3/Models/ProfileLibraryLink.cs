using DustyPig.API.v3.Interfaces;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class ProfileLibraryLink : IValidate
    {
        public int ProfileId { get; set; }

        public int LibraryId { get; set; }


        #region IValidate

        public void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(ProfileId), ProfileId, lst);
            Validators.ValidateId(nameof(LibraryId), LibraryId, lst);

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

        #endregion
    }
}
