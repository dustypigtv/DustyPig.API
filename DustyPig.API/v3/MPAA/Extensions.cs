using System.Collections.Generic;

namespace DustyPig.API.v3.MPAA
{
    public static partial class Extensions
    {
        public static string AsString(this MovieRatings rating) => RatingsUtils.AsString(rating);

        public static string AsString(this TVRatings rating) => RatingsUtils.AsString(rating);



        public static MovieRatings ToMovieRatings(this string s) => RatingsUtils.ToMovieRatings(s);

        public static MovieRatings ToMovieRatings(this TVRatings value) => RatingsUtils.ToMovieRatings(value);



        public static TVRatings ToTVRatings(this string s) => RatingsUtils.ToTVRatings(s);

        public static TVRatings ToTVRatings(this MovieRatings value) => RatingsUtils.ToTVRatings(value);




        public static string AsString(this Genres g) => GenresUtils.AsString(g);

        public static Genres ToGenres(this string s) => GenresUtils.ToGenres(s);

        public static List<string> ExtractUnknownGenres(this string s) => GenresUtils.ExtractUnknownGenres(s);

        public static bool IsKnownGenre(this string s) => GenresUtils.IsKnownGenre(s);


    }
}
