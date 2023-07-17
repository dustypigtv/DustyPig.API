using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SimpleValue<T> : IEquatable<SimpleValue<T>>
    {
        public SimpleValue() { }

        public SimpleValue(T value) => Value = value;

        [JsonRequired]
        [JsonProperty("value")]
        public T Value { get; set; }


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as SimpleValue<T>);
        }

        public bool Equals(SimpleValue<T> other)
        {
            return !(other is null) &&
                   EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        public override int GetHashCode()
        {
            return -1937169414 + EqualityComparer<T>.Default.GetHashCode(Value);
        }

        public static bool operator ==(SimpleValue<T> left, SimpleValue<T> right)
        {
            return EqualityComparer<SimpleValue<T>>.Default.Equals(left, right);
        }

        public static bool operator !=(SimpleValue<T> left, SimpleValue<T> right)
        {
            return !(left == right);
        }

        #endregion
    }
}
