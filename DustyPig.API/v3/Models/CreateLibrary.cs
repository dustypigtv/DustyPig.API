using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateLibrary : IValidate, IEquatable<CreateLibrary>
    {
        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonRequired]
        [JsonProperty("is_tv")]
        public bool IsTV { get; set; }


        #region IValidate

        public void Validate()
        {
            var lst = new List<string>();

            var (Valid, Fixed, Error) = Validators.Validate(nameof(Name), Name, true, Constants.MAX_NAME_LENGTH);
            if (Valid)
                Name = Fixed;
            else
                lst.Add(Error);

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

        #endregion


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as CreateLibrary);
        }

        public bool Equals(CreateLibrary other)
        {
            return !(other is null) &&
                   Name == other.Name &&
                   IsTV == other.IsTV;
        }

        public override int GetHashCode()
        {
            int hashCode = 1625735029;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + IsTV.GetHashCode();
            return hashCode;
        }

         public static bool operator ==(CreateLibrary left, CreateLibrary right)
        {
            return EqualityComparer<CreateLibrary>.Default.Equals(left, right);
        }

        public static bool operator !=(CreateLibrary left, CreateLibrary right)
        {
            return !(left == right);
        }

        #endregion


        public override string ToString() => Name;
    }
}
