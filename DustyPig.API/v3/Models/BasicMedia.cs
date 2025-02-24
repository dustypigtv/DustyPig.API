using DustyPig.API.v3.JsonConverters;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.Models;

public class BasicMedia
{
    public int Id { get; set; }

    [JsonConverter(typeof(MediaTypesConverter))]
    public MediaTypes MediaType { get; set; }

    public string ArtworkUrl { get; set; }

    public string BackdropUrl { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    [JsonConverter(typeof(CreditRolesConverter))]
    public CreditRoles? Role { get; set; }

    public override string ToString() => Title;

}
