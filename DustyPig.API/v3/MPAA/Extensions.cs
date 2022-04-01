using System.Collections.Generic;

namespace DustyPig.API.v3.MPAA
{
    public static partial class Extensions
    {
        public static string AsString(this Ratings rating) => RatingsUtils.AsString(rating);

        public static Ratings ToRatings(this string s) => RatingsUtils.ToRatings(s);

        public static Ratings ToRatings(this IEnumerable<string> lst) => RatingsUtils.ToRatings(lst);



        public static string AsString(this Genres g) => GenresUtils.AsString(g);

        public static Genres ToGenres(this string s) => GenresUtils.ToGenres(s);

        public static List<string> ExtractUnknownGenres(this string s) => GenresUtils.ExtractUnknownGenres(s);

        public static bool IsKnownGenre(this string s) => GenresUtils.IsKnownGenre(s);


    }
}
