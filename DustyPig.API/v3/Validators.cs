using DustyPig.API.v3.Interfaces;
using DustyPig.API.v3.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DustyPig.API.v3
{
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

            if (media.SRTSubtitles != null)
                foreach (var subtitle in media.SRTSubtitles)
                    ret.AddRange(Validate(subtitle).Select(item => $"{nameof(media.SRTSubtitles)}: {item}"));


            return ret;
        }






        public static List<string> Validate(SRTSubtitle exSub)
        {
            var ret = new List<string>();


            var chk = Validate(nameof(exSub.Url), exSub.Url, true, Constants.MAX_URL_LENGTH);
            if (chk.Valid)
                exSub.Url = chk.Fixed;
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

            ret.AddRange(ValidatePeople(media.Cast).Select(item => $"{nameof(media.Cast)}: {item}"));
            ret.AddRange(ValidatePeople(media.Directors).Select(item => $"{nameof(media.Directors)}: {item}"));
            ret.AddRange(ValidatePeople(media.Producers).Select(item => $"{nameof(media.Producers)}: {item}"));
            ret.AddRange(ValidatePeople(media.Writers).Select(item => $"{nameof(media.Writers)}: {item}"));

            return ret;
        }






        static List<string> ValidatePeople(List<string> lst)
        {
            var ret = new List<string>();

            if (lst == null)
                return ret;

            lst.RemoveAll(item => string.IsNullOrWhiteSpace(item));


            //Not ref, so make a copy to dedup
            var newLst = new List<string>();
            foreach (string item in lst)
            {
                var (Valid, Fixed, Error) = Validate("Person", item, true, Constants.MAX_NAME_LENGTH);
                if (Valid)
                {
                    if (!newLst.Contains(item))
                        newLst.Add(item);
                }
                else
                {
                    ret.Add(Error);
                }
            }
            lst.Clear();
            lst.AddRange(newLst);

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
    }
}
