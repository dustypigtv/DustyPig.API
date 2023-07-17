using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class MovePlaylistItem : IValidate, IEquatable<MovePlaylistItem>
    {
        /// <summary>
        /// Playlist Item Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// New Index
        /// </summary>
        [JsonRequired]
        [JsonProperty("new_index")]
        public int NewIndex { get; set; }


        #region IValidate

        public void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(Id), Id, lst);

            if (NewIndex < 0)
                lst.Add($"Invalid {nameof(NewIndex)}");

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

        #endregion


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as MovePlaylistItem);
        }

        public bool Equals(MovePlaylistItem other)
        {
            return !(other is null) &&
                   Id == other.Id &&
                   NewIndex == other.NewIndex;
        }

        public override int GetHashCode()
        {
            int hashCode = 2051833351;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + NewIndex.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(MovePlaylistItem left, MovePlaylistItem right)
        {
            return EqualityComparer<MovePlaylistItem>.Default.Equals(left, right);
        }

        public static bool operator !=(MovePlaylistItem left, MovePlaylistItem right)
        {
            return !(left == right);
        }

        #endregion
    }
}
