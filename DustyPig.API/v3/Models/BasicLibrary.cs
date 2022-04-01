using Newtonsoft.Json;
using System;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class BasicLibrary : UpdateLibrary, IComparable
    {
        [JsonProperty("owner")]
        public string Owner { get; set; }

        public int CompareTo(object obj)
        {
            var comp = (BasicLibrary)obj;
            int ret = -string.IsNullOrWhiteSpace(Owner).CompareTo(string.IsNullOrWhiteSpace(comp.Owner));
            if (ret == 0) ret = Name.CompareTo(comp.Name);
            return ret;
        }

        public override string ToString() => Name;
    }
}
