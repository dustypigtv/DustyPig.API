using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    public class LibraryListRequest : ListRequest
    {
        [JsonProperty("library_id")]
        public int LibraryId { get; set; }
    }
}
