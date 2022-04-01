using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DeviceCodeStatus
    {
        [JsonProperty("activated")]
        public bool Activated { get; set; }

        [JsonProperty("account_token")]
        public string AccountToken { get; set; }
    }
}
