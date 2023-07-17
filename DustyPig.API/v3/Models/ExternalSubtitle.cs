using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ExternalSubtitle : IValidate, IEquatable<ExternalSubtitle>
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonRequired]
        [JsonProperty("url")]
        public string Url { get; set; }


        #region IValidate

        public void Validate()
        {
            var lst = new List<string>();

            var chk = Validators.Validate(nameof(Name), Name, true, Constants.MAX_NAME_LENGTH);
            if (chk.Valid)
                Name = chk.Fixed;
            else
                lst.Add(chk.Error);

            chk = Validators.Validate(nameof(Url), Url, true, Constants.MAX_URL_LENGTH);
            if (chk.Valid)
                Url = chk.Fixed;
            else
                lst.Add(chk.Error);

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };

        }

        #endregion


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as ExternalSubtitle);
        }

        public bool Equals(ExternalSubtitle other)
        {
            return !(other is null) &&
                   Name == other.Name &&
                   Url == other.Url;
        }

        public override int GetHashCode()
        {
            int hashCode = -1254404684;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Url);
            return hashCode;
        }

        public static bool operator ==(ExternalSubtitle left, ExternalSubtitle right)
        {
            return EqualityComparer<ExternalSubtitle>.Default.Equals(left, right);
        }

        public static bool operator !=(ExternalSubtitle left, ExternalSubtitle right)
        {
            return !(left == right);
        }

        #endregion


        public override string ToString() => Name;
    }
}
