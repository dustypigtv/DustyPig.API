using DustyPig.API.v3.BaseClasses;
using DustyPig.API.v3.Interfaces;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.Models
{
    public class TitleRequest : IValidate
    {
        [JsonPropertyName("tmdbId")]
        public int TMDB_Id { get; set; }

        /// <summary>
        /// This will also be ignored if If <see cref="BaseProfile.TitleRequestPermissions"/> == <see cref="TitleRequestPermissions.RequiresAuthorization"/>, as the request will be sent to the main profile on the account. 
        /// Set to null to request the title from the main profile on the account
        /// </summary>
        public int? FriendId { get; set; }

        public TMDB_MediaTypes MediaType { get; set; }


        #region IValidate

        public void Validate()
        {
            var lst = new List<string>();
            Validators.ValidateId("tmdbId", TMDB_Id, lst);

            //Don't validate the FriendId, that will happen based on profile permissions on the server

            if (MediaType != TMDB_MediaTypes.Movie)
                if (MediaType != TMDB_MediaTypes.Series)
                    lst.Add($"Invalid {nameof(MediaType)}");

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

        #endregion
    }
}
