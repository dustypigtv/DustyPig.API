using DustyPig.API.v3.BaseClasses;
using DustyPig.API.v3.Interfaces;
using DustyPig.API.v3.MPAA;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.Models;

public class CreateMovie : BaseMovieInfo, IMedia, ITopLevelMedia, IPlayableMedia, IValidate
{
    #region IMedia

    //Completely handled by BaseMovieInfo

    #endregion


    #region ITopLevelMedia

    //Completely handled by BaseMovieInfo

    #endregion


    #region IPlayableMedia

    //Partially handled by BaseMovieInfo

    public string BifUrl { get; set; }

    /// <summary>
    /// Size in Bytes
    /// </summary>
    public ulong BifSize { get; set; }

    public string VideoUrl { get; set; }

    /// <summary>
    /// Size in Bytes
    /// </summary>
    public ulong VideoSize { get; set; }

    [JsonPropertyName("srtSubtitles")]
    public List<SRTSubtitle> SRTSubtitles { get; set; } = [];


    #endregion


    #region IValidate 

    public void Validate()
    {
        var lst = new List<string>();

        lst.AddRange(Validators.Validate(this as IMedia));
        lst.AddRange(Validators.Validate(this as ITopLevelMedia));
        lst.AddRange(Validators.Validate(this as IPlayableMedia));

        if (Rated == MovieRatings.None)
        {
            lst.Add(nameof(Rated) + " not specified");
        }
        else
        {
            bool realRating = false;
            foreach (MovieRatings rating in Enum.GetValues(typeof(MovieRatings)))
            {
                if (rating == Rated)
                {
                    realRating = true;
                    break;
                }
            }
            if (!realRating)
                lst.Add($"Invalid {nameof(Rated)}");
        }


        if (lst.Count > 0)
            throw new ModelValidationException { Errors = lst };
    }

    #endregion

    public override string ToString() => base.ToString();
}
