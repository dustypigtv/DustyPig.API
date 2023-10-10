using DustyPig.API.v3.Interfaces;
using DustyPig.API.v3.Models;
using DustyPig.API.v3.MPAA;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.BaseClasses
{
    public abstract class BaseProfile : IValidate, IEquatable<BaseProfile>
    {
        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonRequired]
        [JsonProperty("allowed_ratings")]
        public Ratings AllowedRatings { get; set; }

        [JsonRequired]
        [JsonProperty("title_request_permissions")]
        public TitleRequestPermissions TitleRequestPermissions { get; set; }

        [JsonRequired]
        [JsonProperty("locked")]
        public bool Locked { get; set; }


        #region IValidate

        public void Validate()
        {
            var lst = new List<string>();

            var chk = Validators.Validate(nameof(Name), Name, true, Constants.MAX_NAME_LENGTH);
            if (chk.Valid)
                Name = chk.Fixed;
            else
                lst.Add(chk.Error);

            chk = Validators.Validate(nameof(AvatarUrl), AvatarUrl, false, Constants.MAX_URL_LENGTH);
            if (chk.Valid)
                AvatarUrl = chk.Fixed;
            else
                lst.Add(chk.Error);

           
            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

        #endregion


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as BaseProfile);
        }

        public bool Equals(BaseProfile other)
        {
            return !(other is null) &&
                   Name == other.Name &&
                   AvatarUrl == other.AvatarUrl &&
                   AllowedRatings == other.AllowedRatings &&
                   TitleRequestPermissions == other.TitleRequestPermissions &&
                   Locked == other.Locked;
        }

        public override int GetHashCode()
        {
            int hashCode = 1237016275;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AvatarUrl);
            hashCode = hashCode * -1521134295 + AllowedRatings.GetHashCode();
            hashCode = hashCode * -1521134295 + TitleRequestPermissions.GetHashCode();
            hashCode = hashCode * -1521134295 + Locked.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(BaseProfile left, BaseProfile right)
        {
            return EqualityComparer<BaseProfile>.Default.Equals(left, right);
        }

        public static bool operator !=(BaseProfile left, BaseProfile right)
        {
            return !(left == right);
        }

        #endregion


        public override string ToString() => Name;

    }
}
