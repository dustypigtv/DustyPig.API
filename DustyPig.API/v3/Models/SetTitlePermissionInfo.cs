using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DustyPig.API.v3.Models
{
    public class SetTitlePermissionInfo : IValidate, IEquatable<SetTitlePermissionInfo>
    {
        [JsonProperty("media_id")]
        public int MediaId { get; set; }

        [JsonProperty("profile_id")]
        public int ProfileId { get; set; }

        [JsonProperty("override_state")]
        public OverrideState OverrideState { get; set; }

        #region IValidate

        public void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(MediaId), MediaId, lst);
            Validators.ValidateId(nameof(ProfileId), ProfileId, lst);
            if (new OverrideState[] { OverrideState.Allow, OverrideState.Block, OverrideState.Default }.Contains(OverrideState) == false)
                lst.Add($"Invalid {nameof(OverrideState)}");

            Validators.ValidateId(nameof(MediaId), MediaId, lst);

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }


        #endregion


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as SetTitlePermissionInfo);
        }

        public bool Equals(SetTitlePermissionInfo other)
        {
            return !(other is null) &&
                   MediaId == other.MediaId &&
                   ProfileId == other.ProfileId &&
                   OverrideState == other.OverrideState;
        }

        public override int GetHashCode()
        {
            int hashCode = 399468919;
            hashCode = hashCode * -1521134295 + MediaId.GetHashCode();
            hashCode = hashCode * -1521134295 + ProfileId.GetHashCode();
            hashCode = hashCode * -1521134295 + OverrideState.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(SetTitlePermissionInfo left, SetTitlePermissionInfo right)
        {
            return EqualityComparer<SetTitlePermissionInfo>.Default.Equals(left, right);
        }

        public static bool operator !=(SetTitlePermissionInfo left, SetTitlePermissionInfo right)
        {
            return !(left == right);
        }

        #endregion
    }
}
