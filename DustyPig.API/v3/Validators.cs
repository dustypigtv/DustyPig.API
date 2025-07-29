using DustyPig.API.v3.Interfaces;
using DustyPig.API.v3.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DustyPig.API.v3;

static class Validators
{

    public static List<string> Validate(IMedia media)
    {
        var ret = new List<string>();

        var chk = Validate(nameof(media.Title), media.Title, true, Constants.MAX_NAME_LENGTH);
        if (chk.Valid)
            media.Title = chk.Fixed;
        else
            ret.Add(chk.Error);

        chk = Validate(nameof(media.Description), media.Description, true, Constants.MAX_DESCRIPTION_LENGTH);
        if (chk.Valid)
            media.Description = chk.Fixed;
        else
            ret.Add(chk.Error);

        if (media.TMDB_Id != null && media.TMDB_Id <= 0)
            ret.Add($"tmdbId must be > 0 when specified");


        chk = Validate(nameof(media.ArtworkUrl), media.ArtworkUrl, true, Constants.MAX_URL_LENGTH);
        if (chk.Valid)
            media.ArtworkUrl = chk.Fixed;
        else
            ret.Add(chk.Error);

        return ret;
    }




    public static List<string> Validate(IPlayableMedia media)
    {
        var ret = new List<string>();

        if (media.Length <= 0)
            ret.Add($"{nameof(media.Length)} must be > 0");

        if (media.IntroStartTime == null)
        {
            if (media.IntroEndTime != null)
                ret.Add($"{nameof(media.IntroStartTime)} must be specified when {nameof(media.IntroEndTime)} is specified");
        }
        else
        {
            if (media.IntroStartTime < 0)
                ret.Add($"{nameof(media.IntroStartTime)} must be > 0");

            if (media.IntroEndTime == null)
                ret.Add($"{nameof(media.IntroEndTime)} must be specified when {nameof(media.IntroStartTime)} is specified");
            else if (media.IntroEndTime <= media.IntroStartTime)
                ret.Add($"{nameof(media.IntroEndTime)} must be > {nameof(media.IntroStartTime)}");
        }

        var chk = Validate(nameof(media.BifUrl), media.BifUrl, false, Constants.MAX_URL_LENGTH);
        if (chk.Valid)
            media.BifUrl = chk.Fixed;
        else
            ret.Add(chk.Error);

        chk = Validate(nameof(media.VideoUrl), media.VideoUrl, true, Constants.MAX_URL_LENGTH);
        if (chk.Valid)
            media.VideoUrl = chk.Fixed;
        else
            ret.Add(chk.Error);

        
        return ret;
    }










    public static List<string> Validate(ITopLevelMedia media)
    {
        var ret = new List<string>();

        if (media.LibraryId <= 0)
            ret.Add($"{nameof(media.LibraryId)} must be > 0");

        var chk = Validate(nameof(media.BackdropUrl), media.BackdropUrl, false, Constants.MAX_URL_LENGTH);
        if (chk.Valid)
            media.BackdropUrl = chk.Fixed;
        else
            ret.Add(chk.Error);


        return ret;
    }





    public static (bool Valid, string Fixed, string Error) Validate(string name, string val, bool required, int maxLength)
    {
        val = StringUtils.FixSpaces(val);
        if (val == string.Empty)
        {
            if (required)
                return (false, null, $"Missing {name}");
            val = null;
        }
        else
        {
            if (val.Length > maxLength)
                return (false, val, $"{name} is too long. Max length is {maxLength} characters");
        }


        return (true, val, null);
    }




    public static void ValidateId(string name, int id, List<string> lst)
    {
        if (id <= 0)
            lst.Add($"Invalid {name}");
    }





    public static void ValidatePassword(string name, string password, List<string> lst)
    {
        if (string.IsNullOrEmpty(password))
        {
            lst.Add($"{name} cannot be empty");
            return;
        }

        if (password.Length > byte.MaxValue)
        {
            lst.Add($"{name} is too long. Max length is {byte.MaxValue} characters");
            return;
        }
    }




    public static void ValidateNewPassword(string name, string password, List<string> lst)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            lst.Add($"{name} cannot be empty or all spaces");
            return;
        }

        if (password.Length < 6)
        {
            lst.Add($"{name} must be at least 6 characters");
            return;
        }

        if (password.Length > byte.MaxValue)
        {
            lst.Add($"{name} is too long. Max length is {byte.MaxValue} characters");
            return;
        }
    }
}
