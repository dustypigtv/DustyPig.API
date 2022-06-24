using Newtonsoft.Json;
using System;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class BasicFriend : IComparable
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonRequired]
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonRequired]
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        public int CompareTo(object obj)
        {
            var comp = obj as BasicFriend;
            return DisplayName.CompareTo(comp.DisplayName);
        }
    }
}
