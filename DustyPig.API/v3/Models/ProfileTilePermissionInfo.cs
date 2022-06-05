using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ProfileTilePermissionInfo : BasicProfile
    {
        [JsonProperty("has_library_access")]
        public bool HasLibraryAccess { get; set; }

        [JsonProperty("can_watch_by_default")]
        public bool CanWatchByDefault { get; set; }

        [JsonProperty("override")]
        public OverrideState Override { get; set; }
    }
}
