using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class UpdatePlaylistItemsData : IValidate, IEquatable<UpdatePlaylistItemsData>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// New list of media ids, in the order desired
        /// </summary>
        [JsonProperty("media_ids")]
        [JsonRequired]
        public List<int> MediaIds { get; set; } = new List<int>();


        #region IValidate

        public void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(Id), Id, lst);

            if (MediaIds == null || MediaIds.Count == 0)
                lst.Add($"{nameof(MediaIds)} cannot be empty");

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

        #endregion


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as UpdatePlaylistItemsData);
        }

        public bool Equals(UpdatePlaylistItemsData other)
        {
            return !(other is null) &&
                   Id == other.Id &&
                   EqualityComparer<List<int>>.Default.Equals(MediaIds, other.MediaIds);
        }

        public override int GetHashCode()
        {
            int hashCode = 1494704135;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<int>>.Default.GetHashCode(MediaIds);
            return hashCode;
        }

        public static bool operator ==(UpdatePlaylistItemsData left, UpdatePlaylistItemsData right)
        {
            return EqualityComparer<UpdatePlaylistItemsData>.Default.Equals(left, right);
        }

        public static bool operator !=(UpdatePlaylistItemsData left, UpdatePlaylistItemsData right)
        {
            return !(left == right);
        }

        #endregion
    }
}
