using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class UpdateFriend : IValidate, IEquatable<UpdateFriend>
    {
        [JsonRequired]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonRequired]
        [JsonProperty("accepted")]
        public bool Accepted { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }


        #region IValidate

        public void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(Id), Id, lst);

            var (Valid, Fixed, Error) = Validators.Validate(nameof(DisplayName), DisplayName, false, Constants.MAX_NAME_LENGTH);
            if (Valid)
                DisplayName = Fixed;
            else
                lst.Add(Error);

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

        #endregion


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as UpdateFriend);
        }

        public bool Equals(UpdateFriend other)
        {
            return !(other is null) &&
                   Id == other.Id &&
                   Accepted == other.Accepted &&
                   DisplayName == other.DisplayName;
        }

        public override int GetHashCode()
        {
            int hashCode = -829946090;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + Accepted.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DisplayName);
            return hashCode;
        }

        public static bool operator ==(UpdateFriend left, UpdateFriend right)
        {
            return EqualityComparer<UpdateFriend>.Default.Equals(left, right);
        }

        public static bool operator !=(UpdateFriend left, UpdateFriend right)
        {
            return !(left == right);
        }

        #endregion


        public override string ToString() => DisplayName;
    }
}
