using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class PlaybackProgress
    {
        [JsonRequired]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Set to 0 to reset
        /// </summary>
        [JsonRequired]
        [JsonProperty("Seconds")]
        public double Seconds { get; set; }
    }
}
