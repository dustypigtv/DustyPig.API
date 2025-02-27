﻿using DustyPig.API.v3.Interfaces;
using DustyPig.API.v3.JsonConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.Models;

public class ListRequest : IValidate
{
    public int Start { get; set; }

    [JsonConverter(typeof(SortOrderConverter))]
    public SortOrder Sort { get; set; }

    #region IValidate

    public void Validate()
    {
        var lst = new List<string>();

        if (Start < 0)
            Start = 0;

        if (!Enum.GetNames(typeof(SortOrder)).Contains(Sort.ToString()))
            lst.Add($"Invalid {nameof(Sort)}");

        if (lst.Count > 0)
            throw new ModelValidationException { Errors = lst };
    }

    #endregion
}
