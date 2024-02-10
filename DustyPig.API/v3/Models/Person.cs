using System.Text.Json.Serialization;

namespace DustyPig.API.v3.Models
{
    public class Person
    {
        [JsonPropertyName("tmdbId")]
        public int TMDB_Id { get; set; }

        public string Name { get; set; }

        public string AvatarUrl { get; set; }
    }
}
