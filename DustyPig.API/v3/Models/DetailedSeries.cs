using DustyPig.API.v3.BaseClasses;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DetailedSeries : BaseSeriesInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("episodes")]
        public List<DetailedEpisode> Episodes { get; set; } = new List<DetailedEpisode>();

        /// <summary>
        /// Only returned when calling AdminDetails
        /// </summary>
        [JsonProperty("extra_search_terms")]
        public List<string> ExtraSearchTerms { get; set; }
    }
}
