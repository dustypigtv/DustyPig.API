using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class BasicMedia : IEquatable<BasicMedia>
    {
        [JsonRequired]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonRequired]
        [JsonProperty("media_type")]
        public MediaTypes MediaType { get; set; }

        [JsonRequired]
        [JsonProperty("artwork_url")]
        public string ArtworkUrl { get; set; }

        [JsonProperty("backdrop_url")]
        public string BackdropUrl { get; set; }


        [JsonRequired]
        [JsonProperty("title")]
        public string Title { get; set; }

        
        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as BasicMedia);
        }

        public bool Equals(BasicMedia other)
        {
            return !(other is null) &&
                   Id == other.Id &&
                   MediaType == other.MediaType &&
                   ArtworkUrl == other.ArtworkUrl &&
                   Title == other.Title;
        }

        public override int GetHashCode()
        {
            int hashCode = -736120932;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + MediaType.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ArtworkUrl);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            return hashCode;
        }

        public static bool operator ==(BasicMedia left, BasicMedia right)
        {
            return EqualityComparer<BasicMedia>.Default.Equals(left, right);
        }

        public static bool operator !=(BasicMedia left, BasicMedia right)
        {
            return !(left == right);
        }

        #endregion


        public override string ToString() => Title;

    }
}
