using DustyPig.API.v3.Interfaces;
using DustyPig.API.v3.MPAA;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateProfile : IValidate, IEquatable<CreateProfile>
    {
        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

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

            chk = Validators.Validate(nameof(AvatarUrl), AvatarUrl, false, Constants.MAX_NAME_LENGTH);
            if (chk.Valid)
                AvatarUrl = chk.Fixed;
            else
                lst.Add(chk.Error);

            if (Pin != null && (Pin < 1000 || Pin > 9999))
                lst.Add($"{nameof(Pin)} must be between 1000 and 9999");


            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

        #endregion

        
        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as CreateProfile);
        }

        public bool Equals(CreateProfile other)
        {
            return !(other is null) &&
                   Name == other.Name &&
                   AvatarUrl == other.AvatarUrl &&
                   AllowedRatings == other.AllowedRatings &&
                   Pin == other.Pin &&
                   TitleRequestPermissions == other.TitleRequestPermissions &&
                   Locked == other.Locked;
        }

        public override int GetHashCode()
        {
            int hashCode = 1237016275;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AvatarUrl);
            hashCode = hashCode * -1521134295 + AllowedRatings.GetHashCode();
            hashCode = hashCode * -1521134295 + Pin.GetHashCode();
            hashCode = hashCode * -1521134295 + TitleRequestPermissions.GetHashCode();
            hashCode = hashCode * -1521134295 + Locked.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(CreateProfile left, CreateProfile right)
        {
            return EqualityComparer<CreateProfile>.Default.Equals(left, right);
        }

        public static bool operator !=(CreateProfile left, CreateProfile right)
        {
            return !(left == right);
        }

        #endregion


        public override string ToString() => Name;
    
    }
}
