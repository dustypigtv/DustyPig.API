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

        [JsonRequired]
        [JsonProperty("in_watchlist")]
        public bool InWatchlist { get; set; }

        [JsonProperty("can_play")]
        public bool CanPlay { get; set; }

        [JsonProperty("can_manage")]
        public bool CanManage { get; set; }

        [JsonProperty("access_request_status")]
        public OverrideRequestStatus AccessRequestedStatus { get; set; }
    }
}
