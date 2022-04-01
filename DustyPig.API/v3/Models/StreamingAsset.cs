using Newtonsoft.Json;
using System;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class StreamingAsset : CreateStreamingAsset
    {
        public StreamingAssetType AssetType { get; set; }


        /// <summary>
        /// Bearer token for protected resources
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }

        /// <summary>
        /// UTC Expiration of bearer token or signed url
        /// </summary>
        [JsonProperty("expires_utc")]
        public DateTime? ExpiresUTC { get; set; }
    }
}
