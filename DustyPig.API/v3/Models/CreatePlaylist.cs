using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class CreatePlaylist : IValidate, IEquatable<CreatePlaylist>
    {
        [JsonProperty("name")]
        [JsonRequired]
        public string Name { get; set; }


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as CreatePlaylist);
        }

        public bool Equals(CreatePlaylist other)
        {
            return !(other is null) &&
                   Name == other.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }

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

        public static bool operator ==(CreatePlaylist left, CreatePlaylist right)
        {
            return EqualityComparer<CreatePlaylist>.Default.Equals(left, right);
        }

        public static bool operator !=(CreatePlaylist left, CreatePlaylist right)
        {
            return !(left == right);
        }

        #endregion


        public override string ToString() => Name;
    }
}
