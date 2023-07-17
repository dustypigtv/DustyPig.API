using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class ProfileLibraryLink : IValidate, IEquatable<ProfileLibraryLink>
    {
        [JsonProperty("profile_id")]
        public int ProfileId { get; set; }

        [JsonProperty("library_id")]
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


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as ProfileLibraryLink);
        }

        public bool Equals(ProfileLibraryLink other)
        {
            return !(other is null) &&
                   ProfileId == other.ProfileId &&
                   LibraryId == other.LibraryId;
        }

        public override int GetHashCode()
        {
            int hashCode = 587215352;
            hashCode = hashCode * -1521134295 + ProfileId.GetHashCode();
            hashCode = hashCode * -1521134295 + LibraryId.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(ProfileLibraryLink left, ProfileLibraryLink right)
        {
            return EqualityComparer<ProfileLibraryLink>.Default.Equals(left, right);
        }

        public static bool operator !=(ProfileLibraryLink left, ProfileLibraryLink right)
        {
            return !(left == right);
        }

        #endregion
    }
}
