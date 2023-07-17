using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class HomeScreenList : IEquatable<HomeScreenList>
    {
        [JsonRequired]
        [JsonProperty("list_id")]
        public long ListId { get; set; }

        [JsonRequired]
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonRequired]
        [JsonProperty("items")]
        public List<BasicMedia> Items { get; set; }


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as HomeScreenList);
        }

        public bool Equals(HomeScreenList other)
        {
            return !(other is null) &&
                   ListId == other.ListId &&
                   Title == other.Title &&
                   EqualityComparer<List<BasicMedia>>.Default.Equals(Items, other.Items);
        }

        public override int GetHashCode()
        {
            int hashCode = -1343809708;
            hashCode = hashCode * -1521134295 + ListId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<BasicMedia>>.Default.GetHashCode(Items);
            return hashCode;
        }

        public static bool operator ==(HomeScreenList left, HomeScreenList right)
        {
            return EqualityComparer<HomeScreenList>.Default.Equals(left, right);
        }

        public static bool operator !=(HomeScreenList left, HomeScreenList right)
        {
            return !(left == right);
        }

        #endregion


        public override string ToString() => Title;
    }
}
