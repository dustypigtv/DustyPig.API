using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ExternalSubtitle : StreamingAsset
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
