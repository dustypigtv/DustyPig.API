using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TitleRequest : IValidate, IEquatable<TitleRequest>
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


        #region IValidate

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

        #endregion


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as TitleRequest);
        }

        public bool Equals(TitleRequest other)
        {
            return !(other is null) &&
                   TMDB_Id == other.TMDB_Id &&
                   FriendId == other.FriendId &&
                   MediaType == other.MediaType;
        }

        public override int GetHashCode()
        {
            int hashCode = -1402242925;
            hashCode = hashCode * -1521134295 + TMDB_Id.GetHashCode();
            hashCode = hashCode * -1521134295 + FriendId.GetHashCode();
            hashCode = hashCode * -1521134295 + MediaType.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(TitleRequest left, TitleRequest right)
        {
            return EqualityComparer<TitleRequest>.Default.Equals(left, right);
        }

        public static bool operator !=(TitleRequest left, TitleRequest right)
        {
            return !(left == right);
        }

        #endregion
    }
}
