using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class HomeScreen : IEquatable<HomeScreen>
    {
        [JsonRequired]
        [JsonProperty("sections")]
        public List<HomeScreenList> Sections { get; set; } = new List<HomeScreenList>();


        #region IEquatable 

        public override bool Equals(object obj)
        {
            return Equals(obj as HomeScreen);
        }

        public bool Equals(HomeScreen other)
        {
            return !(other is null) &&
                   EqualityComparer<List<HomeScreenList>>.Default.Equals(Sections, other.Sections);
        }

        public override int GetHashCode()
        {
            return -602821931 + EqualityComparer<List<HomeScreenList>>.Default.GetHashCode(Sections);
        }

        public static bool operator ==(HomeScreen left, HomeScreen right)
        {
            return EqualityComparer<HomeScreen>.Default.Equals(left, right);
        }

        public static bool operator !=(HomeScreen left, HomeScreen right)
        {
            return !(left == right);
        }

        #endregion
    }
}
