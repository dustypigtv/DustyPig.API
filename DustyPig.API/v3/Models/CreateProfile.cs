using DustyPig.API.v3.BaseClasses;
using DustyPig.API.v3.Interfaces;
using DustyPig.API.v3.MPAA;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateProfile : BaseProfile, IValidate, IEquatable<CreateProfile>
    {
        [JsonProperty("pin")]
        public short? Pin { get; set; }

        #region IValidate

        public new void Validate()
        {
            var lst = new List<string>();

            try { base.Validate(); }
            catch (ModelValidationException ex) { lst.AddRange(ex.Errors); }

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
                   base.Equals(other) &&
                   Pin == other.Pin;
        }

        public override int GetHashCode()
        {
            int hashCode = 538616385;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Pin.GetHashCode();
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