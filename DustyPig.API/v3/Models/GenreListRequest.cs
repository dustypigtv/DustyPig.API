using DustyPig.API.v3.MPAA;
using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    public class GenreListRequest
    {
        [JsonProperty("genre")]
        public Genres Genre { get; set; }

        [JsonProperty("start")]
        public int Start { get; set; }
    }
}
