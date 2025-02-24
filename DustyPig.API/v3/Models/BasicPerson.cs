using DustyPig.API.v3.JsonConverters;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.Models;

public class BasicPerson
{
    [JsonPropertyName("tmdbId")]
    public int TMDB_Id { get; set; }

    public string Name { get; set; }

    public string Initials { get; set; }

    public string AvatarUrl { get; set; }

    public int Order { get; set; }

    [JsonConverter(typeof(CreditRolesConverter))]
    public CreditRoles Role { get; set; }

}
