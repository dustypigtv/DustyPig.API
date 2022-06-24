using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TitleRequest : IValidate
    {
        [JsonProperty("tmdb_id")]
        public int TMDB_Id { get; set; }

        /// <summary>
        /// If DetailedProfile.TitleRequestPermissions == <see cref="TitleRequestPermissions.RequiresAuthorization"/>, this is ignored as the request will be sent to the main profile on the account
        /// </summary>
        [JsonProperty("friend_id")]
        public int? FriendId { get; set; }

        [JsonProperty("media_type")]
        public TMDB_MediaTypes MediaType { get; set; }

        public void Validate()
        {
            var lst = new List<string>();
            Validators.ValidateId(nameof(TMDB_Id), TMDB_Id, lst);

            //Don't validate the FriendId, that will happen based on profile permissions on the server

            if (MediaType != TMDB_MediaTypes.Movie)
                if (MediaType != TMDB_MediaTypes.Series)
                    lst.Add($"Invalid {nameof(MediaType)}");

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
