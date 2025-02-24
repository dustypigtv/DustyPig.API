using DustyPig.API.v3.Interfaces;
using DustyPig.API.v3.JsonConverters;
using DustyPig.API.v3.Models;
using DustyPig.API.v3.MPAA;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.BaseClasses;

public abstract class BaseProfile : IValidate
{
    public string Name { get; set; }

    public string AvatarUrl { get; set; }

    [JsonConverter(typeof(MovieRatingsConverter))]
    public MovieRatings MaxMovieRating { get; set; }

    [JsonPropertyName("maxTVRating")]
    [JsonConverter(typeof(TVRatingsConverter))]
    public TVRatings MaxTVRating { get; set; }

    [JsonConverter(typeof(TitleRequestPermissionsConverter))]
    public TitleRequestPermissions TitleRequestPermissions { get; set; }

    public bool Locked { get; set; }


    #region IValidate

    public void Validate()
    {
        var lst = new List<string>();

        var chk = Validators.Validate(nameof(Name), Name, true, Constants.MAX_NAME_LENGTH);
        if (chk.Valid)
            Name = chk.Fixed;
        else
            lst.Add(chk.Error);

        chk = Validators.Validate(nameof(AvatarUrl), AvatarUrl, false, Constants.MAX_URL_LENGTH);
        if (chk.Valid)
            AvatarUrl = chk.Fixed;
        else
            lst.Add(chk.Error);




        if (MaxMovieRating == MovieRatings.None)
        {
            lst.Add(nameof(MaxMovieRating) + " not specified");
        }
        else
        {
            bool realRating = false;
            foreach (MovieRatings rating in Enum.GetValues(typeof(MovieRatings)))
            {
                if (rating == MaxMovieRating)
                {
                    realRating = true;
                    break;
                }
            }
            if (!realRating)
                lst.Add($"Invalid {nameof(MaxMovieRating)}");
        }



        if (MaxTVRating == TVRatings.None)
        {
            lst.Add(nameof(MaxTVRating) + " not specified");
        }
        else
        {
            bool realRating = false;
            foreach (TVRatings rating in Enum.GetValues(typeof(TVRatings)))
            {
                if (rating == MaxTVRating)
                {
                    realRating = true;
                    break;
                }
            }
            if (!realRating)
                lst.Add($"Invalid {nameof(MaxTVRating)}");
        }


        if (lst.Count > 0)
            throw new ModelValidationException { Errors = lst };
    }

    #endregion

    public override string ToString() => Name;
}
