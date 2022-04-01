using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SimpleValue<T>
    {
        public SimpleValue() { }

        public SimpleValue(T value) => Value = value;

        [JsonRequired]
        [JsonProperty("value")]
        public T Value { get; set; }
    }
}
