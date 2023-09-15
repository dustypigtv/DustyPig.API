using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class BasicTMDB : IEquatable<BasicTMDB>
    {
        [JsonRequired]
        [JsonProperty("tmdb_id")]
        public int TMDB_ID { get; set; }

        [JsonRequired]
        [JsonProperty("media_type")]
        public TMDB_MediaTypes MediaType { get; set; }

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
            return Equals(obj as BasicTMDB);
        }

        public bool Equals(BasicTMDB other)
        {
            return !(other is null) &&
                   TMDB_ID == other.TMDB_ID &&
                   MediaType == other.MediaType &&
                   ArtworkUrl == other.ArtworkUrl &&
                   Title == other.Title;
        }

        public override int GetHashCode()
        {
            int hashCode = 1482519036;
            hashCode = hashCode * -1521134295 + TMDB_ID.GetHashCode();
            hashCode = hashCode * -1521134295 + MediaType.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ArtworkUrl);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            return hashCode;
        }

        public static bool operator ==(BasicTMDB left, BasicTMDB right)
        {
            return EqualityComparer<BasicTMDB>.Default.Equals(left, right);
        }

        public static bool operator !=(BasicTMDB left, BasicTMDB right)
        {
            return !(left == right);
        }

        #endregion


        public override string ToString() => Title;

    }
}
