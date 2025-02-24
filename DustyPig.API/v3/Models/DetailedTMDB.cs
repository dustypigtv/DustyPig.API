using DustyPig.API.v3.Interfaces;
using DustyPig.API.v3.JsonConverters;
using DustyPig.API.v3.MPAA;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.Models;

public class DetailedTMDB : BasicTMDB, ICredits
{
    public int Year { get; set; }

    public string Rated { get; set; }

    public string Description { get; set; }

    [JsonConverter(typeof(GenresConverter))]
    public Genres Genres { get; set; }

    public List<BasicMedia> Available { get; set; } = [];

    [JsonConverter(typeof(TitleRequestPermissionsConverter))]
    public TitleRequestPermissions RequestPermission { get; set; }

    [JsonConverter(typeof(RequestStatusConverter))]
    public RequestStatus RequestStatus { get; set; }

    public bool RequestedOfThisProfile { get; set; }

    public List<string> Requestors { get; set; } = [];

    #region ICredits

    public List<BasicPerson> Credits { get; set; } = [];

    #endregion

    public override string ToString() => base.ToString();
}
