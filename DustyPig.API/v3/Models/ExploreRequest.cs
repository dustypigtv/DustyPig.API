using DustyPig.API.v3.MPAA;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ExploreRequest
    {
        /// <summary>
        /// If specified, only media in these genres will be returned.
        /// </summary>
        [JsonProperty("genres")]
        public Genres? FilterOnGenres { get; set; }

        /// <summary>
        /// If specified, only media with these ratings will be returned.
        /// </summary>
        [JsonProperty("ratings")]
        public Ratings? FilterOnRatings { get; set; }

        /// <summary>
        /// If specified, only media in these libraries will be returned.
        /// </summary>
        [JsonProperty("library_ids")]
        public List<int> LibraryIds { get; set; }

        /// <summary>
        /// If true, results will include movies. Default is true
        /// </summary>
        [JsonProperty("return_movies")]
        public bool ReturnMovies { get; set; } = true;

        /// <summary>
        /// If true, results will include series. Default is true
        /// </summary>
        [JsonProperty("return_series")]
        public bool ReturnSeries { get; set; } = true;

        /// <summary>
        /// How results are sorted. Default is <see cref="SortOrder.Popularity_Descending"/>
        /// </summary>
        [JsonProperty("sort_by")]
        public SortOrder SortBy { get; set; } = SortOrder.Popularity_Descending;

        /// <summary>
        /// Return next batch of results starting at this index
        /// </summary>
        public int Start { get; set; }
    }
}
