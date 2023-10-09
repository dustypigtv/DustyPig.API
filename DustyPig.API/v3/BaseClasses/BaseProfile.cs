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
        
        [JsonRequired]
        [JsonProperty("allowed_ratings")]
        public Ratings AllowedRatings { get; set; }

        [JsonProperty("pin")]
        public short? Pin { get; set; }

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

            if (Pin != null && (Pin < 1000 || Pin > 9999))
                lst.Add($"{nameof(Pin)} must be between 1000 and 9999, or null");


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
                   AllowedRatings == other.AllowedRatings &&
                   Pin == other.Pin &&
                   TitleRequestPermissions == other.TitleRequestPermissions &&
                   Locked == other.Locked;
        }

        public override int GetHashCode()
        {
            int hashCode = -561002618;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + AllowedRatings.GetHashCode();
            hashCode = hashCode * -1521134295 + Pin.GetHashCode();
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
    }
}
