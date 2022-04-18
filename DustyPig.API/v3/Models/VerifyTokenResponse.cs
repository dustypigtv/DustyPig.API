using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    public class VerifyTokenResponse
    {
        [JsonProperty("login_type")]
        public LoginResponseType LoginType { get; set; }
    }
}
