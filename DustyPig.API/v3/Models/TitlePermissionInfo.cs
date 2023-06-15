using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TitlePermissionInfo
    {
        [JsonProperty("title_id")]
        public int TitleId { get; set; }

        [JsonProperty("profiles")]
        public List<ProfileTitleOverrideInfo> Profiles { get; set; } = new List<ProfileTitleOverrideInfo>();
    }
}
