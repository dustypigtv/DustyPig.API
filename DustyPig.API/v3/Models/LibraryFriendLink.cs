using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class LibraryFriendLink : IValidate
    {
        [JsonProperty("library_id")]
        public int LibraryId { get; set; }

        [JsonProperty("friend_id")]
        public int FriendId { get; set; }

        public void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(LibraryId), LibraryId, lst);
            Validators.ValidateId(nameof(FriendId), FriendId, lst);

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
