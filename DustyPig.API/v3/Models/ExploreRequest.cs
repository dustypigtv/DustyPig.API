using DustyPig.API.v3.Interfaces;
using DustyPig.API.v3.MPAA;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ExploreRequest : ListRequest, IValidate
    {
        /// <summary>
        /// If specified, only media in these genres will be returned.
        /// </summary>
        [JsonProperty("genres")]
        public Genres? FilterOnGenres { get; set; }

        /// <summary>
        /// If <see cref="FilterOnGenres"/> is specified, then this flag determines whether to include media where <see cref="Genres"/> == <see cref="Genres.Unknown"/> or null
        /// </summary>
        [JsonProperty("include_unknown_genres", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool IncludeUnknownGenres { get; set; }


        /// <summary>
        /// If specified, only media with these ratings will be returned.
        /// </summary>
        [JsonProperty("ratings")]
        public Ratings? FilterOnRatings { get; set; }

        /// <summary>
        /// If <see cref="FilterOnRatings"/> is specified, then this flag determines whether to include media where <see cref="Ratings"/> == <see cref="Ratings.None"/> or null
        /// </summary>
        [JsonProperty("include_none_ratings", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool IncludeNoneRatings { get; set; }

        /// <summary>
        /// If specified, only media in these libraries will be returned.
        /// </summary>
        [JsonProperty("library_ids")]
        public List<int> LibraryIds { get; set; }

        /// <summary>
        /// If true, results will include movies. Default is true
        /// </summary>
        [JsonProperty("return_movies", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool ReturnMovies { get; set; } = true;

        /// <summary>
        /// If true, results will include series. Default is true
        /// </summary>
        [JsonProperty("return_series", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool ReturnSeries { get; set; } = true;

        

        public new void Validate()
        {
            var lst = new List<string>();

            if (!(ReturnMovies || ReturnSeries))
                lst.Add($"You must set either {nameof(ReturnMovies)} or {nameof(ReturnSeries)} (or both) to true");

            if (Start < 0)
                Start = 0;

            if (LibraryIds != null && LibraryIds.Count == 0)
                LibraryIds = null;

            try { base.Validate(); }
            catch (ModelValidationException ex) { lst.AddRange(ex.Errors); }

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
