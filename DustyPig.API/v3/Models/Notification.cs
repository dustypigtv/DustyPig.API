using Newtonsoft.Json;
using System;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Notification
    {
        [JsonRequired]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonRequired]
        [JsonProperty("profile_id")]
        public int ProfileId { get; set; }

        [JsonRequired]
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonRequired]
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("deep_link")]
        public string DeepLink { get; set; }

        [JsonRequired]
        [JsonProperty("seen")]
        public bool Seen { get; set; }

        [JsonRequired]
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
