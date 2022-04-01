using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    public class ProfileLibraryLink
    {
        [JsonProperty("profile_id")]
        public int ProfileId { get; set; }

        [JsonProperty("library_id")]
        public int LibraryId { get; set; }
    }
}
