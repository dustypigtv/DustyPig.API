﻿using DustyPig.API.v3.Interfaces;
using DustyPig.API.v3.JsonConverters;
using DustyPig.API.v3.MPAA;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.BaseClasses;

public abstract class BaseMovieInfo : IMedia, ITopLevelMedia
{
    #region IMedia

    public string Title { get; set; }

    [JsonPropertyName("tmdbId")]
    public int? TMDB_Id { get; set; }

    public string Description { get; set; }

    public string ArtworkUrl { get; set; }

    #endregion


    #region ITopLevelMedia

    public int LibraryId { get; set; }

    public string BackdropUrl { get; set; }

    [JsonConverter(typeof(GenresConverter))]
    public Genres Genres { get; set; }

    public List<string> ExtraSearchTerms { get; set; } = [];

    #endregion

#if !NET7_0_OR_GREATER
    [JsonConverter(typeof(JsonConverters.DateOnlyConverter))]
#endif
    public DateOnly Date { get; set; }

    public double Length { get; set; }

    public double? IntroStartTime { get; set; }

    public double? IntroEndTime { get; set; }

    public double? CreditsStartTime { get; set; }

    [JsonConverter(typeof(MovieRatingsConverter))]
    public MovieRatings Rated { get; set; }

    public override string ToString() => $"{Title} ({Date.Year})";
}
