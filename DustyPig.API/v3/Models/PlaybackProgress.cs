using DustyPig.API.v3.Interfaces;
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

    public void Validate()
    {
        var lst = new List<string>();

        Validators.ValidateId(nameof(Id), Id, lst);
        if (Seconds < 0)
            lst.Add(nameof(Seconds) + " must be >= 0");

        if (lst.Count > 0)
            throw new ModelValidationException { Errors = lst };
    }
}
