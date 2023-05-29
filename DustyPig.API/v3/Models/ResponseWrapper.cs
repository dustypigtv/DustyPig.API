using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    public class ResponseWrapper
    {
        /// <summary>
        /// Initialize with <see cref="Success"/> == true
        /// </summary>
        public ResponseWrapper() => Success = true;

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
    }

    public class ResponseWrapper<T>
    {
        public ResponseWrapper() { }

        /// <summary>
        /// Initialize with <see cref="Success"/> == true and <see cref="Data"/> == <paramref name="data"/>
        /// </summary>
        public ResponseWrapper(T data)
        {
            Success = true;
            Data = data;
        }

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
        /// If <see cref="Success"/> == true, then this is the json response
        /// </summary>
        [JsonProperty("data")]
        public T Data { get; set; }

        /// <summary>
        /// If <see cref="Success"/> == false, then this is the error message
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
