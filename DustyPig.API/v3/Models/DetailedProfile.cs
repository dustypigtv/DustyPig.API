using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DetailedProfile : UpdateProfile
    {
        [JsonProperty("available_libraries")]
        public List<BasicLibrary> AvailableLibraries { get; set; } = new List<BasicLibrary>();

        [JsonProperty("is_main")]
        public bool IsMain { get; set; }

        public override string ToString() => Name;
    }
}
