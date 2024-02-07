using DustyPig.API.v3.Interfaces;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class LibraryListRequest : ListRequest, IValidate
    {
        public int LibraryId { get; set; }


        #region IValidate

        public new void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(LibraryId), LibraryId, lst);
            try { base.Validate(); }
            catch (ModelValidationException ex) { lst.AddRange(ex.Errors); }

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

        #endregion
    }
}
