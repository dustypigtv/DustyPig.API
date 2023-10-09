using DustyPig.API.v3.BaseClasses;
using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateProfile : BaseProfile, IValidate, IEquatable<CreateProfile>
    {
        [JsonProperty("avatar_image")]
        public byte[] AvatarImage { get; set; }

        #region IValidate

        public new void Validate()
        {
            var lst = new List<string>();

            try { base.Validate(); }
            catch (ModelValidationException ex) { lst.AddRange(ex.Errors); }


            //Limit avatar to 5mb
            if (AvatarImage != null && AvatarImage.Length > 0)
            {
                if (AvatarImage.Length > 1024 * 1024 * 5)
                    lst.Add($"{nameof(AvatarImage)} must be less than 5 MB");

                else if (AvatarImage.Length < 3)
                    lst.Add($"{nameof(AvatarImage)} is not a valid image");

                else if (AvatarImage[0] != 0xFF && AvatarImage[1] != 0xD8)
                    lst.Add($"{nameof(AvatarImage)} does not seem to be a jpg image");
            }


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
                   base.Equals(other) &&
                   EqualityComparer<byte[]>.Default.Equals(AvatarImage, other.AvatarImage);
        }

        public override int GetHashCode()
        {
            int hashCode = -1822940787;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<byte[]>.Default.GetHashCode(AvatarImage);
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
