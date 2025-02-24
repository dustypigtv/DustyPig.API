using DustyPig.API.v3.JsonConverters;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.Models;

public class BasicTMDB
{
    [JsonPropertyName("tmdbId")]
    public int TMDB_ID { get; set; }

    [JsonConverter(typeof(TMDB_MediaTypesConverter))]
    public TMDB_MediaTypes MediaType { get; set; }

    public string ArtworkUrl { get; set; }

    public string BackdropUrl { get; set; }

    public string Title { get; set; }

    [JsonConverter(typeof(CreditRolesConverter))]
    public CreditRoles? Role { get; set; }

    public override string ToString() => Title;
}
