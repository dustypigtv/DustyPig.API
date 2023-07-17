using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TitlePermissionInfo : IValidate, IEquatable<TitlePermissionInfo>
    {
        [JsonProperty("title_id")]
        public int TitleId { get; set; }

        /// <summary>
        /// Profiles not listed will not have overrides changed
        /// </summary>
        [JsonProperty("profiles")]
        public List<ProfileTitleOverrideInfo> Profiles { get; set; } = new List<ProfileTitleOverrideInfo>();


        #region IValidate

        public void Validate()
        {
            var lst = new List<string>();
            Validators.ValidateId(nameof(TitleId), TitleId, lst);

            Profiles ??= new List<ProfileTitleOverrideInfo>();
            foreach (var profile in Profiles)
                try { profile.Validate(); }
                catch (ModelValidationException ex) { lst.AddRange(ex.Errors); }

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

        #endregion


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as TitlePermissionInfo);
        }

        public bool Equals(TitlePermissionInfo other)
        {
            return !(other is null) &&
                   TitleId == other.TitleId &&
                   EqualityComparer<List<ProfileTitleOverrideInfo>>.Default.Equals(Profiles, other.Profiles);
        }

        public override int GetHashCode()
        {
            int hashCode = -1342469197;
            hashCode = hashCode * -1521134295 + TitleId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<ProfileTitleOverrideInfo>>.Default.GetHashCode(Profiles);
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
