using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class LibraryListRequest : ListRequest, IValidate, IEquatable<LibraryListRequest>
    {
        [JsonProperty("library_id")]
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


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as LibraryListRequest);
        }

        public bool Equals(LibraryListRequest other)
        {
            return !(other is null) &&
                   base.Equals(other) &&
                   LibraryId == other.LibraryId;
        }

        public override int GetHashCode()
        {
            int hashCode = -1408483677;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + LibraryId.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(LibraryListRequest left, LibraryListRequest right)
        {
            return EqualityComparer<LibraryListRequest>.Default.Equals(left, right);
        }

        public static bool operator !=(LibraryListRequest left, LibraryListRequest right)
        {
            return !(left == right);
        }

        #endregion
    }
}
