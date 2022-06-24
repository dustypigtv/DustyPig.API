using DustyPig.API.v3.MPAA;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DetailedTMDB : BasicTMDB
    {
        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("backdrop_url")]
        public string BackdropUrl { get; set; }

        [JsonProperty("rated")]
        public string Rated { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("genres")]
        public Genres? Genres { get; set; }

        [JsonProperty("cast")]
        public List<string> Cast { get; set; }

        [JsonProperty("directors")]
        public List<string> Directors { get; set; }

        [JsonProperty("producers")]
        public List<string> Producers { get; set; }

        [JsonProperty("writers")]
        public List<string> Writers { get; set; }

        [JsonProperty("available")]
        public List<BasicMedia> Available { get; set; } = new List<BasicMedia>();

        [JsonProperty("request_permission")]
        public TitleRequestPermissions RequestPermission { get; set; }

        public override string ToString() => Title;
    }
}
