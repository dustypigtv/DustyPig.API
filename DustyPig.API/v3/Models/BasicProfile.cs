using Newtonsoft.Json;
using System;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class BasicProfile : IComparable
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("is_main")]
        public bool IsMain { get; set; }

        [JsonProperty("has_pin")]
        public bool HasPin { get; set; }

        public int CompareTo(object obj)
        {
            var comp = obj as BasicProfile;
            int ret = -IsMain.CompareTo(comp.IsMain);
            if (ret == 0) ret = Name.CompareTo(comp.Name);
            return ret;
        }

        public override string ToString() => Name;
    }
}
