using DustyPig.API.v3.Interfaces;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models;

public class UpdateAvatarInfo : IValidate
{
    public int ProfileId { get; set; }

    /// <summary>
    /// Scale factor the cropped image
    /// </summary>
    public double Scale { get; set; } = 1.0;

    /// <summary>
    /// X-Coordinate of the crop circle's center
    /// </summary>
    public int CenterX { get; set; }

    /// <summary>
    /// Y-Coordinate of the crop circle's center
    /// </summary>
    public int CenterY { get; set; }


    public void Validate()
    {
        var lst = new List<string>();

        if (Scale <= 0)
            lst.Add(nameof(Scale) + " must be > 0");

        if (CenterX < 0)
            lst.Add(nameof(CenterX) + " must be >= 0");

        if (CenterY < 0)
            lst.Add(nameof(CenterY) + " must be >= 0");
        
        if (lst.Count > 0)
            throw new ModelValidationException { Errors = lst };
    }
}
