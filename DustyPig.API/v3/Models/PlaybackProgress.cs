using DustyPig.API.v3.Interfaces;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models;

public class PlaybackProgress : IValidate
{
    /// <summary>
    /// For playlists, this is the <see cref="PlaylistItem.Id"/>. Otherwise, this is the movie or episode id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Set to 0 to reset
    /// </summary>
    public double Seconds { get; set; }

    /// <summary>
    /// UTC Date-Timestamp of when this progress occured. It helps the server keep offline watch progress in sync
    /// </summary>
    public DateTime AsOfUTC { get; set; }

    public void Validate()
    {
        var lst = new List<string>();

        Validators.ValidateId(nameof(Id), Id, lst);
        if (Seconds < 0)
            lst.Add(nameof(Seconds) + " must be >= 0");

        if (AsOfUTC == default)
            lst.Add(nameof(AsOfUTC) + " must be set");

        if (lst.Count > 0)
            throw new ModelValidationException { Errors = lst };
    }
}
