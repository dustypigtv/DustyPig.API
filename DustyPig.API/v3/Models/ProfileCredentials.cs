using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ProfileCredentials
    {
        [JsonRequired]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("pin")]
        public short? Pin { get; set; }

        [JsonProperty("device_token")]
        public string DeviceToken { get; set; }
    }
}
