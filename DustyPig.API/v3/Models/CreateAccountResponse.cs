using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    public class CreateAccountResponse
    {
        [JsonProperty("email_verification_required")]
        public bool EmailVerificationRequired { get; set; }

        /// <summary>
        /// This will be null if <see cref="EmailVerificationRequired"/> == true
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
