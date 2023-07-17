using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class SetPlaylistProgress : IValidate, IEquatable<SetPlaylistProgress>
    {
        [JsonRequired]
        [JsonProperty("playlist_id")]
        public int PlaylistId { get; set; }

        [JsonRequired]
        [JsonProperty("new_index")]
        public int NewIndex { get; set; }

        [JsonRequired]
        [JsonProperty("new_progress")]
        public double NewProgress { get; set; }


        #region IValidate

        public void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(PlaylistId), PlaylistId, lst);

            if (NewIndex < 0)
                lst.Add($"Invalid {nameof(NewIndex)}");

            if (NewProgress < 0)
                lst.Add($"Invalid {nameof(NewProgress)}");

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

        #endregion


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as SetPlaylistProgress);
        }

        public bool Equals(SetPlaylistProgress other)
        {
            return !(other is null) &&
                   PlaylistId == other.PlaylistId &&
                   NewIndex == other.NewIndex &&
                   NewProgress == other.NewProgress;
        }

        public override int GetHashCode()
        {
            int hashCode = 1016641471;
            hashCode = hashCode * -1521134295 + PlaylistId.GetHashCode();
            hashCode = hashCode * -1521134295 + NewIndex.GetHashCode();
            hashCode = hashCode * -1521134295 + NewProgress.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(SetPlaylistProgress left, SetPlaylistProgress right)
        {
            return EqualityComparer<SetPlaylistProgress>.Default.Equals(left, right);
        }

        public static bool operator !=(SetPlaylistProgress left, SetPlaylistProgress right)
        {
            return !(left == right);
        }

        #endregion
    }
}
