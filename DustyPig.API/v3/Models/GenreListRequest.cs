﻿using DustyPig.API.v3.Interfaces;
using DustyPig.API.v3.JsonConverters;
using DustyPig.API.v3.MPAA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.Models;

public class GenreListRequest : ListRequest, IValidate
{
    [JsonConverter(typeof(GenresConverter))]
    public Genres Genre { get; set; }

    #region IValidate

    public new void Validate()
    {
        var lst = new List<string>();

        var allGenres = Enum.GetValues(typeof(Genres)).Cast<long>();
        var min = allGenres.Min();
        var max = allGenres.Max();

        long g = (long)Genre;

        if (g < min || g > max)
            lst.Add($"Invalid {nameof(Genre)}");

        try { base.Validate(); }
        catch (ModelValidationException ex) { lst.AddRange(ex.Errors); }

        if (Start < 0)
            lst.Add($"Invalid {nameof(Start)}");

        if (lst.Count > 0)
            throw new ModelValidationException { Errors = lst };
    }

    #endregion

    public override string ToString() => Genre.AsString();
}
