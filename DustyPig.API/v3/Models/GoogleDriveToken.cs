using Newtonsoft.Json;
using System;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class GoogleDriveToken
    {
        [JsonRequired]
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonRequired]
        [JsonProperty("expires_utc")]
        public DateTime ExpiresUTC { get; set; }
    }
}
