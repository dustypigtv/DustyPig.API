﻿using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class UpdateProfile : CreateProfile, IValidate, IEquatable<UpdateProfile>
    {
        [JsonRequired]
        [JsonProperty("id")]
        public int Id { get; set; }


        #region IValidate

        public new void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(Id), Id, lst);

            try { base.Validate(); }
            catch (ModelValidationException ex) { lst.AddRange(ex.Errors); }

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

        #endregion


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as UpdateProfile);
        }

        public bool Equals(UpdateProfile other)
        {
            return !(other is null) &&
                   base.Equals(other) &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            int hashCode = 402319765;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(UpdateProfile left, UpdateProfile right)
        {
            return EqualityComparer<UpdateProfile>.Default.Equals(left, right);
        }

        public static bool operator !=(UpdateProfile left, UpdateProfile right)
        {
            return !(left == right);
        }

        #endregion


        public override string ToString() => base.ToString();

        
    }
}
