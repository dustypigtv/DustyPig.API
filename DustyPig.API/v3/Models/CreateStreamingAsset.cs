using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateStreamingAsset : IStreamingAsset
    {
        [JsonRequired]
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// ID of the service credential to get updated tokens
        /// </summary>
        [JsonProperty("service_credential_Id")]
        public int? ServiceCredentialId { get; set; }

        public void Validate()
        {
            var lst = Validators.Validate(this);
            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
