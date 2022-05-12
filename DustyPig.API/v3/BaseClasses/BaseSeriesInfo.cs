using DustyPig.API.v3.Interfaces;
using DustyPig.API.v3.MPAA;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.BaseClasses
{
    public abstract class BaseSeriesInfo : IMedia, ITopLevelMedia
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


        #endregion

        #region ITopLevelMedia

        [JsonRequired]
        [JsonProperty("library_id")]
        public int LibraryId { get; set; }

        [JsonProperty("backdrop_url")]
        public string BackdropUrl { get; set; }


        [JsonProperty("rated")]
        public Ratings Rated { get; set; }

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
    }
}
