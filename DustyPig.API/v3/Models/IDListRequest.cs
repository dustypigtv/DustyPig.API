using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    public class IDListRequest
    {
        [JsonProperty("list_id")]
        public long ListId { get; set; }

        [JsonProperty("start")]
        public int Start { get; set; }
    }
}
