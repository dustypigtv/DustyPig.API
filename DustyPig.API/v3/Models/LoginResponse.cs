using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    public enum LoginResponseType
    {
        Account = 0,
        Profile = 1
    }

    public class LoginResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("login_type")]
        public LoginResponseType LoginType { get; set; }
    }
}
