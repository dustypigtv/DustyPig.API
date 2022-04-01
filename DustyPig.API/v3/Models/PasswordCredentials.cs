using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class PasswordCredentials
    {
        [JsonRequired]
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonRequired]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
