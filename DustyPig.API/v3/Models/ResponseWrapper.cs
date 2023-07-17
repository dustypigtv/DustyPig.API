using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class ResponseWrapper : IEquatable<ResponseWrapper>
    {
        public ResponseWrapper() { }

        /// <summary>
        /// Initialize with <see cref="Success"/> == false and Error = <paramref name="error"/>
        /// </summary>
        public ResponseWrapper(string error) => Error = error;


        /// <summary>
        /// Whether the operation was successful
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// If <see cref="Success"/> == false, then this is the error message
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; }


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as ResponseWrapper);
        }

        public bool Equals(ResponseWrapper other)
        {
            return !(other is null) &&
                   Success == other.Success &&
                   Error == other.Error;
        }

        public override int GetHashCode()
        {
            int hashCode = -1489853407;
            hashCode = hashCode * -1521134295 + Success.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Error);
            return hashCode;
        }

        public static bool operator ==(ResponseWrapper left, ResponseWrapper right)
        {
            return EqualityComparer<ResponseWrapper>.Default.Equals(left, right);
        }

        public static bool operator !=(ResponseWrapper left, ResponseWrapper right)
        {
            return !(left == right);
        }

        #endregion
    }

    public class ResponseWrapper<T> : ResponseWrapper, IEquatable<ResponseWrapper<T>>
    {
        public ResponseWrapper() : base() { }

        /// <summary>
        /// Initialize with <see cref="ResponseWrapper.Success"/> == true and <see cref="Data"/> == <paramref name="data"/>
        /// </summary>
        public ResponseWrapper(T data) : base()
        {
            Success = true;
            Data = data;
        }

        /// <summary>
        /// Initialize with <see cref="ResponseWrapper.Success"/> == false and Error = <paramref name="error"/>
        /// </summary>
        public ResponseWrapper(string error) : base(error) { }

        /// <summary>
        /// If <see cref="ResponseWrapper.Success"/> == true, then this is the json response
        /// </summary>
        [JsonProperty("data")]
        public T Data { get; set; }


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as ResponseWrapper<T>);
        }

        public bool Equals(ResponseWrapper<T> other)
        {
            return !(other is null) &&
                   base.Equals(other) &&
                   EqualityComparer<T>.Default.Equals(Data, other.Data);
        }

        public override int GetHashCode()
        {
            int hashCode = 1686391899;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(Data);
            return hashCode;
        }

        public static bool operator ==(ResponseWrapper<T> left, ResponseWrapper<T> right)
        {
            return EqualityComparer<ResponseWrapper<T>>.Default.Equals(left, right);
        }

        public static bool operator !=(ResponseWrapper<T> left, ResponseWrapper<T> right)
        {
            return !(left == right);
        }

        #endregion
    }
}
