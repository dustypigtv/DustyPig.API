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
        [JsonProperty("account_id")]
        public int? AccountId { get; set; }

        public void Validate()
        {
            var lst = new List<string>();
            Validators.ValidateId(nameof(TMDB_Id), TMDB_Id, lst);

            //Don't validate the AccountId, that will happen based on profile permissions on the server

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
