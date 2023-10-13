using DustyPig.API.v3.MPAA;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DetailedTMDB : BasicTMDB, IEquatable<DetailedTMDB>
    {
        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("rated")]
        public string Rated { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("genres")]
        public Genres Genres { get; set; }

        [JsonProperty("cast")]
        public List<string> Cast { get; set; } = new List<string>();

        [JsonProperty("directors")]
        public List<string> Directors { get; set; } = new List<string>();

        [JsonProperty("producers")]
        public List<string> Producers { get; set; } = new List<string>();

        [JsonProperty("writers")]
        public List<string> Writers { get; set; } = new List<string>();

        [JsonProperty("available")]
        public List<BasicMedia> Available { get; set; } = new List<BasicMedia>();

        [JsonProperty("request_permission")]
        public TitleRequestPermissions RequestPermission { get; set; }

        [JsonProperty("request_status")]
        public RequestStatus RequestStatus { get; set; }


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as DetailedTMDB);
        }

        public bool Equals(DetailedTMDB other)
        {
            return !(other is null) &&
                   base.Equals(other) &&
                   Year == other.Year &&
                   BackdropUrl == other.BackdropUrl &&
                   Rated == other.Rated &&
                   Description == other.Description &&
                   Genres == other.Genres &&
                   EqualityComparer<List<string>>.Default.Equals(Cast, other.Cast) &&
                   EqualityComparer<List<string>>.Default.Equals(Directors, other.Directors) &&
                   EqualityComparer<List<string>>.Default.Equals(Producers, other.Producers) &&
                   EqualityComparer<List<string>>.Default.Equals(Writers, other.Writers) &&
                   EqualityComparer<List<BasicMedia>>.Default.Equals(Available, other.Available) &&
                   RequestPermission == other.RequestPermission &&
                   RequestStatus == other.RequestStatus;
        }

        public override int GetHashCode()
        {
            int hashCode = 1952736145;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Year.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(BackdropUrl);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Rated);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + Genres.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(Cast);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(Directors);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(Producers);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(Writers);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<BasicMedia>>.Default.GetHashCode(Available);
            hashCode = hashCode * -1521134295 + RequestPermission.GetHashCode();
            hashCode = hashCode * -1521134295 + RequestStatus.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(DetailedTMDB left, DetailedTMDB right)
        {
            return EqualityComparer<DetailedTMDB>.Default.Equals(left, right);
        }

        public static bool operator !=(DetailedTMDB left, DetailedTMDB right)
        {
            return !(left == right);
        }

        #endregion


        public override string ToString() => base.ToString();
    }
}
