﻿using DustyPig.API.v3.Interfaces;
using DustyPig.API.v3.MPAA;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.BaseClasses;

public abstract class BaseSeriesInfo : IMedia, ITopLevelMedia
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

    public Genres Genres { get; set; }

    public List<string> ExtraSearchTerms { get; set; } = [];


    #endregion

    public TVRatings Rated { get; set; }

    public override string ToString() => Title;
}
