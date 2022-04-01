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






        public static string AsString(Ratings rating)
        {
            if (rating == Ratings.None || rating == Ratings.All)
                return rating.ToString();

            var lst = new List<string>();
            foreach (var candidate in RealValues)
                if (rating.HasFlag(candidate))
                {
                    var s = candidate
                        .ToString()
                        .Replace('_', '-');
                    if (s == "NR")
                        s = "Not Rated";
                    lst.Add(s);
                }

            if (lst.Count > 0)
                return String.Join(", ", lst);

            return null;
        }

        public static Ratings ToRatings(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return Ratings.None;

            foreach (Ratings r in RealValues)
            {
                if (s.Equals(r.AsString(), StringComparison.CurrentCultureIgnoreCase))
                    return r;
                if (s.Equals(r.ToString(), StringComparison.CurrentCultureIgnoreCase))
                    return r;
            }

            return Ratings.None;
        }



        public static Ratings ToRatings(IEnumerable<string> lst)
        {
            var ret = Ratings.None;

            foreach (var s in lst)
                foreach (var candidate in RealValues)
                    if (s.Equals(candidate.AsString(), StringComparison.CurrentCultureIgnoreCase))
                        ret |= candidate;

            return ret;
        }


        public static IReadOnlyList<Ratings> RealValues
        {
            get
            {
                var ret = new List<Ratings>();

                foreach (Ratings rating in Enum.GetValues(typeof(Ratings)))
                    if (rating != Ratings.All && rating != Ratings.None)
                        ret.Add(rating);

                return ret;
            }
        }

        public static IReadOnlyList<Ratings> MovieRatings => new List<Ratings>()
        {
            Ratings.G,
            Ratings.PG,
            Ratings.PG_13,
            Ratings.R,
            Ratings.NC_17,
            Ratings.Unrated
        };

        public static IReadOnlyList<Ratings> TVRatings => new List<Ratings>()
        {
            Ratings.TV_Y,
            Ratings.TV_Y7,
            Ratings.TV_G,
            Ratings.TV_PG,
            Ratings.TV_14,
            Ratings.TV_MA,
            Ratings.Unrated
        };


    }
}
