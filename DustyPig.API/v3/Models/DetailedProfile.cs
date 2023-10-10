using DustyPig.API.v3.BaseClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DetailedProfile : BaseProfile, IEquatable<DetailedProfile>
    {
        [JsonRequired]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("has_pin")]
        public bool HasPin { get; set; }

        [JsonProperty("available_libraries")]
        public List<BasicLibrary> AvailableLibraries { get; set; } = new List<BasicLibrary>();

        [JsonProperty("is_main")]
        public bool IsMain { get; set; }


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as DetailedProfile);
        }

        public bool Equals(DetailedProfile other)
        {
            return !(other is null) &&
                   base.Equals(other) &&
                   Id == other.Id &&
                   EqualityComparer<List<BasicLibrary>>.Default.Equals(AvailableLibraries, other.AvailableLibraries) &&
                   IsMain == other.IsMain;
        }

        public override int GetHashCode()
        {
            int hashCode = -950904311;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + HasPin.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<BasicLibrary>>.Default.GetHashCode(AvailableLibraries);
            hashCode = hashCode * -1521134295 + IsMain.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(DetailedProfile left, DetailedProfile right)
        {
            return EqualityComparer<DetailedProfile>.Default.Equals(left, right);
        }

        public static bool operator !=(DetailedProfile left, DetailedProfile right)
        {
            return !(left == right);
        }

        #endregion


        public override string ToString() => base.ToString();

    }
}