using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    public class ResponseWrapper
    {
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
