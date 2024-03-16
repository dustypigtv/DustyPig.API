using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.Models;

public class TMDB_Person
{
    [JsonPropertyName("tmdbId")]
    public int TMDB_ID { get; set; }

    public string Name { get; set; }

    public string AvatarUrl { get; set; }

#if !NET7_0_OR_GREATER
    [JsonConverter(typeof(JsonConverters.DateOnlyConverter))]
#endif
    public DateOnly? Birthday { get; set; }

#if !NET7_0_OR_GREATER
    [JsonConverter(typeof(JsonConverters.DateOnlyConverter))]
#endif
    public DateOnly? Deathday { get; set; }

    public string PlaceOfBirth { get; set; }

    public string Biography { get; set; }

    public string KnownFor { get; set; }

    public List<BasicMedia> Available { get; set; } = [];

    public List<BasicTMDB> OtherTitles { get; set; } = [];
}