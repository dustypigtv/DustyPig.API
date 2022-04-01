using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DetailedFriend : BasicFriend
    {
        [JsonProperty("accepted")]
        public bool Accepted { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("shared_with_friend")]
        public List<BasicLibrary> SharedWithFriend { get; set; } = new List<BasicLibrary>();

        [JsonProperty("shared_with_me")]
        public List<BasicLibrary> SharedWithMe { get; set; } = new List<BasicLibrary>();

    }
}
