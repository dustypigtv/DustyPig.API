using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class BasicFriend
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
    }
}
