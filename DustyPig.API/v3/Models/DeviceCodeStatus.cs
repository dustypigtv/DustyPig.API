using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DeviceCodeStatus : LoginResponse
    {
        [JsonProperty("activated")]
        public bool Activated { get; set; }
    }
}
