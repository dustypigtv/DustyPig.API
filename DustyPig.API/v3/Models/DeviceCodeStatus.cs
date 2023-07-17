using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DeviceCodeStatus : LoginResponse, IEquatable<DeviceCodeStatus>
    {
        [JsonProperty("activated")]
        public bool Activated { get; set; }


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as DeviceCodeStatus);
        }

        public bool Equals(DeviceCodeStatus other)
        {
            return !(other is null) &&
                   base.Equals(other) &&
                   Activated == other.Activated;
        }

        public override int GetHashCode()
        {
            int hashCode = -615389774;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Activated.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(DeviceCodeStatus left, DeviceCodeStatus right)
        {
            return EqualityComparer<DeviceCodeStatus>.Default.Equals(left, right);
        }

        public static bool operator !=(DeviceCodeStatus left, DeviceCodeStatus right)
        {
            return !(left == right);
        }

        #endregion
    }
}
