using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class HomeScreen
    {
        [JsonRequired]
        [JsonProperty("sections")]
        public List<HomeScreenList> Sections { get; set; } = new List<HomeScreenList>();
    }
}
