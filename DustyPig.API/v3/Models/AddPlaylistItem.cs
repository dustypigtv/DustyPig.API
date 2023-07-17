using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class AddPlaylistItem : IValidate, IEquatable<AddPlaylistItem>
    {
        [JsonProperty("playlist_id")]
        public int PlaylistId { get; set; }

        [JsonProperty("media_id")]
        public int MediaId { get; set; }

        #region IValidate

        public void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(PlaylistId), PlaylistId, lst);
            Validators.ValidateId(nameof(MediaId), MediaId, lst);

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

        #endregion


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as AddPlaylistItem);
        }

        public bool Equals(AddPlaylistItem other)
        {
            return !(other is null) &&
                   PlaylistId == other.PlaylistId &&
                   MediaId == other.MediaId;
        }

        public override int GetHashCode()
        {
            int hashCode = 143494756;
            hashCode = hashCode * -1521134295 + PlaylistId.GetHashCode();
            hashCode = hashCode * -1521134295 + MediaId.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(AddPlaylistItem left, AddPlaylistItem right)
        {
            return EqualityComparer<AddPlaylistItem>.Default.Equals(left, right);
        }

        public static bool operator !=(AddPlaylistItem left, AddPlaylistItem right)
        {
            return !(left == right);
        }

        #endregion

    }
}
