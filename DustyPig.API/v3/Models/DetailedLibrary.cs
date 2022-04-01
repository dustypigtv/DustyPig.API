using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DetailedLibrary : BasicLibrary
    {
        [JsonProperty("profiles")]
        public List<BasicProfile> Profiles { get; set; } = new List<BasicProfile>();

        [JsonProperty("shared_with")]
        public List<BasicFriend> SharedWith { get; set; } = new List<BasicFriend>();
    }
}
