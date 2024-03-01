﻿using DustyPig.API.v3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace DustyPig.API.v3.MPAA
{
    public static class RatingsUtils
    {
        private static readonly IReadOnlyList<RatingsMap> _ratingsMaps = JsonSerializer.Deserialize<List<RatingsMap>>(Encoding.UTF8.GetString(Properties.Resources.ratings_maps));

        public static string MapMovieRatings(string country, string rating)
        {
            if (string.IsNullOrWhiteSpace(country) || string.IsNullOrWhiteSpace(rating))
                return null;

            int max = _ratingsMaps.Where(item => item.EntryType == MediaTypes.Movie).Max(item => item.Rank);
            for (int rank = 1; rank < max; rank++)
                foreach (var map in _ratingsMaps.Where(item => item.EntryType == MediaTypes.Movie).Where(item => item.Rank == rank))
                    if (map.Country.ICEquals(country))
                        if (map.Rating.ICEquals(rating))
                            return map.US_Equivalent + (rank == 1 ? string.Empty : " *");

            return null;
        }

        public static string MapTVRatings(string country, string rating)
        {
            if (string.IsNullOrWhiteSpace(country) || string.IsNullOrWhiteSpace(rating))
                return null;

            int max = _ratingsMaps.Where(item => item.EntryType == MediaTypes.Series).Max(item => item.Rank);
            for (int rank = 1; rank < max; rank++)
                foreach (var map in _ratingsMaps.Where(item => item.EntryType == MediaTypes.Series).Where(item => item.Rank == rank))
                    if (map.Country.ICEquals(country))
                        if (map.Rating.ICEquals(rating))
                            return map.US_Equivalent + (rank == 1 ? string.Empty : " *");

            return null;
        }


        public static string AsString(MovieRatings value)
        {
            return value.ToString().Replace("_", "-");
        }

        public static MovieRatings ToMovieRatings(string value)
        {
            value = value.Replace("*", null).Trim();
            foreach (MovieRatings rating in Enum.GetValues(typeof(MovieRatings)))
                if (rating.AsString().ICEquals(value) || rating.ToString().ICEquals(value))
                    return rating;
            return MovieRatings.None;
        }

        public static MovieRatings ToMovieRatings(TVRatings value) => value switch
        {
            TVRatings.NotRated => MovieRatings.Unrated,
            TVRatings.TV_14 => MovieRatings.PG_13,
            TVRatings.TV_G => MovieRatings.G,
            TVRatings.TV_MA => MovieRatings.NC_17,
            TVRatings.TV_PG => MovieRatings.PG,
            TVRatings.TV_Y7 => MovieRatings.G,
            TVRatings.TV_Y => MovieRatings.G,
            _ => MovieRatings.None
        };



        public static string AsString(TVRatings value)
        {
            var ret = value.ToString().Replace("_", "-");
            if (ret == "NotRated")
                ret = "Not Rated";
            return ret;
        }

        public static TVRatings ToTVRatings(string value)
        {
            value = value.Replace("*", null).Trim();
            foreach (TVRatings rating in Enum.GetValues(typeof(TVRatings)))
                if (rating.AsString().ICEquals(value) || rating.ToString().ICEquals(value))
                    return rating;
            return TVRatings.None;
        }

        public static TVRatings ToTVRatings(MovieRatings value) => value switch
        {
            MovieRatings.G => TVRatings.TV_G,
            MovieRatings.PG => TVRatings.TV_PG,
            MovieRatings.PG_13 => TVRatings.TV_14,
            MovieRatings.R => TVRatings.TV_MA,
            MovieRatings.NC_17 => TVRatings.TV_MA,
            MovieRatings.Unrated => TVRatings.NotRated,
            _ => TVRatings.None
        };
    }
}
