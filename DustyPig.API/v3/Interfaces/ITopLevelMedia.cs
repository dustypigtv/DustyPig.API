using DustyPig.API.v3.JsonConverters;
using DustyPig.API.v3.MPAA;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.Interfaces;

public interface ITopLevelMedia
{
    public int LibraryId { get; set; }

    public string BackdropUrl { get; set; }

    [JsonConverter(typeof(GenresConverter))]
    public Genres Genres { get; set; }

    public List<string> ExtraSearchTerms { get; set; }
}
