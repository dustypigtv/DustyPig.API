using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TitlePermissionInfo : IEquatable<TitlePermissionInfo>
    {
        [JsonProperty("media_id")]
        public int MediaId { get; set; }

        [JsonProperty("sub_profiles")]
        public List<ProfileTitleOverrideInfo> SubProfiles { get; set; } = new List<ProfileTitleOverrideInfo>();

        [JsonProperty("friend_profiles")]
        public List<ProfileTitleOverrideInfo> FriendProfiles { get; set; } = new List<ProfileTitleOverrideInfo>();




        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as TitlePermissionInfo);
        }

        public bool Equals(TitlePermissionInfo other)
        {
            return !(other is null) &&
                   MediaId == other.MediaId &&
                   EqualityComparer<List<ProfileTitleOverrideInfo>>.Default.Equals(SubProfiles, other.SubProfiles);
        }

        public override int GetHashCode()
        {
            int hashCode = -1342469197;
            hashCode = hashCode * -1521134295 + MediaId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<ProfileTitleOverrideInfo>>.Default.GetHashCode(SubProfiles);
            return hashCode;
        }

        public static bool operator ==(TitlePermissionInfo left, TitlePermissionInfo right)
        {
            return EqualityComparer<TitlePermissionInfo>.Default.Equals(left, right);
        }

        public static bool operator !=(TitlePermissionInfo left, TitlePermissionInfo right)
        {
            return !(left == right);
        }

        #endregion
    }
}
