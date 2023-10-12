using DustyPig.API.v3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DustyPig.API.v3.MPAA
{
    public static class RatingsUtils
    {
        private static readonly IReadOnlyList<RatingsMap> _ratingsMaps = JsonConvert.DeserializeObject<List<RatingsMap>>(Encoding.UTF8.GetString(Properties.Resources.ratings_maps));

        public static string MapMovieRatings(string country, string rating)
        {
            if (string.IsNullOrWhiteSpace(country) || string.IsNullOrWhiteSpace(rating))
                return null;

            foreach (var map in _ratingsMaps.Where(item => item.EntryType == MediaTypes.Movie).Where(item => item.Rank == 1))
                if (map.Country.ICEquals(country))
                    if (map.Rating.ICEquals(rating))
                        return map.US_Equivalent;


            int max = _ratingsMaps.Where(item => item.EntryType == MediaTypes.Movie).Max(item => item.Rank);
            for (int rank = 2; rank < max; rank++)
                foreach (var map in _ratingsMaps.Where(item => item.EntryType == MediaTypes.Movie).Where(item => item.Rank == rank))
                    if (map.Country.ICEquals(country))
                        if (map.Rating.ICEquals(rating))
                            return map.US_Equivalent + " *";

            return null;
        }

        public static string MapTVRatings(string country, string rating)
        {
            if (string.IsNullOrWhiteSpace(country) || string.IsNullOrWhiteSpace(rating))
                return null;

            foreach (var map in _ratingsMaps.Where(item => item.EntryType == MediaTypes.Series).Where(item => item.Rank == 1))
                if (map.Country.ICEquals(country))
                    if (map.Rating.ICEquals(rating))
                        return map.US_Equivalent;

            int max = _ratingsMaps.Where(item => item.EntryType == MediaTypes.Series).Max(item => item.Rank);
            for (int rank = 2; rank < max; rank++)
                foreach (var map in _ratingsMaps.Where(item => item.EntryType == MediaTypes.Series).Where(item => item.Rank == rank))
                    if (map.Country.ICEquals(country))
                        if (map.Rating.ICEquals(rating))
                            return map.US_Equivalent + " *";

            return null;
        }


        public static string AsString(MovieRatings self)
        {
            return self.ToString().Replace("_", "-");
        }

        public static MovieRatings ToMovieRatings(string self)
        {
            foreach(MovieRatings rating in Enum.GetValues(typeof(MovieRatings)))
                if (rating.AsString().ICEquals(self) || rating.ToString().ICEquals(self))
                    return rating;
            return MovieRatings.None;
        }



        public static string AsString(TVRatings self)
        {
            var ret = self.ToString().Replace("_", "-");
            if (ret == "NotRated")
                ret = "Not Rated";
            return ret;
        }

        public static TVRatings ToTVRatings(string self)
        {
            foreach(TVRatings rating in Enum.GetValues(typeof(TVRatings)))
                if(rating.AsString().ICEquals(self) || rating.ToString().ICEquals(self))
                    return rating;
            return TVRatings.None;
        }




    }
}
