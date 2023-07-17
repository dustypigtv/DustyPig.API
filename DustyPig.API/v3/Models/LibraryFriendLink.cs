using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class LibraryFriendLink : IValidate, IEquatable<LibraryFriendLink>
    {
        [JsonProperty("library_id")]
        public int LibraryId { get; set; }

        [JsonProperty("friend_id")]
        public int FriendId { get; set; }


        #region IValidate

        public void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(LibraryId), LibraryId, lst);
            Validators.ValidateId(nameof(FriendId), FriendId, lst);

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

        #endregion


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as LibraryFriendLink);
        }

        public bool Equals(LibraryFriendLink other)
        {
            return !(other is null) &&
                   LibraryId == other.LibraryId &&
                   FriendId == other.FriendId;
        }

        public override int GetHashCode()
        {
            int hashCode = 1965113645;
            hashCode = hashCode * -1521134295 + LibraryId.GetHashCode();
            hashCode = hashCode * -1521134295 + FriendId.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(LibraryFriendLink left, LibraryFriendLink right)
        {
            return EqualityComparer<LibraryFriendLink>.Default.Equals(left, right);
        }

        public static bool operator !=(LibraryFriendLink left, LibraryFriendLink right)
        {
            return !(left == right);
        }

        #endregion
    }
}
