using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    public enum OAuthCredentialProviders
    {
        Apple,
        Facebook,
        Google,
        Microsoft,
        Twitter
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class OAuthCredentials
    {

        [JsonRequired]
        [JsonProperty("provider")]
        public OAuthCredentialProviders Provider { get; set; }

        [JsonRequired]
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
