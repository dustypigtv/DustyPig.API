using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    public class CreateAccountResponse
    {
        [JsonProperty("email_verification_required")]
        public bool EmailVerificationRequired { get; set; }
    }
}
