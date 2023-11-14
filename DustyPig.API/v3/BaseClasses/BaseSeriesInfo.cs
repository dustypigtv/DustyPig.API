using DustyPig.API.v3.Interfaces;
using DustyPig.API.v3.MPAA;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.BaseClasses
{
    public abstract class BaseSeriesInfo : IMedia, ITopLevelMedia, IEquatable<BaseSeriesInfo>
    {
        #region IMedia

        [JsonRequired]
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("tmdb_id")]
        public int? TMDB_Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonRequired]
        [JsonProperty("artwork_url")]
        public string ArtworkUrl { get; set; }

        /// <summary>
        /// Size in Bytes
        /// </summary>
        [JsonProperty("artwork_size")]
        public ulong ArtworkSize { get; set; }


        #endregion

        #region ITopLevelMedia

        [JsonRequired]
        [JsonProperty("library_id")]
        public int LibraryId { get; set; }

        [JsonProperty("backdrop_url")]
        public string BackdropUrl { get; set; }

        /// <summary>
        /// Size in Bytes
        /// </summary>
        [JsonProperty("backdrop_size")]
        public ulong BackdropSize { get; set; }

        [JsonProperty("genres")]
        public Genres Genres { get; set; }

        [JsonProperty("cast")]
        public List<string> Cast { get; set; }

        [JsonProperty("directors")]
        public List<string> Directors { get; set; }

        [JsonProperty("producers")]
        public List<string> Producers { get; set; }

        [JsonProperty("writers")]
        public List<string> Writers { get; set; }

        [JsonProperty("extra_search_terms")]
        public List<string> ExtraSearchTerms { get; set; } = new List<string>();


        #endregion

        [JsonProperty("rated")]
        public TVRatings Rated { get; set; }


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as BaseSeriesInfo);
        }

        public bool Equals(BaseSeriesInfo other)
        {
            return !(other is null) &&
                   Title == other.Title &&
                   TMDB_Id == other.TMDB_Id &&
                   Description == other.Description &&
                   ArtworkUrl == other.ArtworkUrl &&
                   ArtworkSize == other.ArtworkSize &&
                   LibraryId == other.LibraryId &&
                   BackdropUrl == other.BackdropUrl &&
                   BackdropSize == other.BackdropSize &&
                   Rated == other.Rated &&
                   Genres == other.Genres &&
                   EqualityComparer<List<string>>.Default.Equals(Cast, other.Cast) &&
                   EqualityComparer<List<string>>.Default.Equals(Directors, other.Directors) &&
                   EqualityComparer<List<string>>.Default.Equals(Producers, other.Producers) &&
                   EqualityComparer<List<string>>.Default.Equals(Writers, other.Writers) &&
                   EqualityComparer<List<string>>.Default.Equals(ExtraSearchTerms, other.ExtraSearchTerms);
        }

        public override int GetHashCode()
        {
            int hashCode = 1096064864;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + TMDB_Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ArtworkUrl);
            hashCode = hashCode * -1521134295 + ArtworkSize.GetHashCode();
            hashCode = hashCode * -1521134295 + LibraryId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(BackdropUrl);
            hashCode = hashCode * -1521134295 + BackdropSize.GetHashCode();
            hashCode = hashCode * -1521134295 + Rated.GetHashCode();
            hashCode = hashCode * -1521134295 + Genres.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(Cast);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(Directors);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(Producers);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(Writers);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(ExtraSearchTerms);
            return hashCode;
        }

        public static bool operator ==(BaseSeriesInfo left, BaseSeriesInfo right)
        {
            return EqualityComparer<BaseSeriesInfo>.Default.Equals(left, right);
        }

        public static bool operator !=(BaseSeriesInfo left, BaseSeriesInfo right)
        {
            return !(left == right);
        }

        #endregion

        public override string ToString() => Title;
    }
}
