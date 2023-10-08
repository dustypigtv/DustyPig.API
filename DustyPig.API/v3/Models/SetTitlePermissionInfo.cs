using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class SetTitlePermissionInfo : IEquatable<SetTitlePermissionInfo>
    {
        [JsonProperty("media_id")]
        public int MediaId { get; set; }

        [JsonProperty("profile_id")]
        public int ProfileId { get; set; }

        [JsonProperty("override_state")]
        public OverrideState OverrideState { get; set; }

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
    }
}
