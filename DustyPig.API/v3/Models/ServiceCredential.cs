using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ServiceCredential
    {
        [JsonRequired]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonRequired]
        [JsonProperty("credential_type")]
        public ServiceCredentialTypes CredentialType { get; set; }
    }
}
