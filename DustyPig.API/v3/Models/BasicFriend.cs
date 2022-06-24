using Newtonsoft.Json;
using System;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class BasicFriend : IComparable
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        public int CompareTo(object obj)
        {
            var comp = obj as BasicFriend;
            return DisplayName.CompareTo(comp.DisplayName);
        }
    }
}
