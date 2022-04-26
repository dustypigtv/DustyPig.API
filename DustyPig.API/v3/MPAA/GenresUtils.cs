using System;
using System.Collections.Generic;
using System.Linq;

namespace DustyPig.API.v3.MPAA
{
    public static class GenresUtils
    {
        private static readonly IReadOnlyDictionary<Genres, string> AllGenres = new Dictionary<Genres, string>
        {
            { Genres.Unknown, "Unknown" },
            { Genres.Action, "Action"},
            { Genres.Adventure, "Adventure"},
            { Genres.Animation, "Animation"},
            { Genres.Anime, "Anime"},
            { Genres.Awards_Show, "Awards Show"},
            { Genres.Children, "Children"},
            { Genres.Comedy, "Comedy"},
            { Genres.Crime, "Crime"},
            { Genres.Documentary, "Documentary"},
            { Genres.Drama, "Drama"},
            { Genres.Family, "Family"},
            { Genres.Fantasy, "Fantasy"},
            { Genres.Food, "Food"},
            { Genres.Game_Show, "Game Show"},
            { Genres.History, "History"},
            { Genres.Home_and_Garden, "Home and Garden"},
            { Genres.Horror, "Horror"},
            { Genres.Indie, "Indie"},
            { Genres.Martial_Arts, "Martial Arts"},
            { Genres.Mini_Series, "Mini-Series"},
            { Genres.Music, "Music"},
            { Genres.Musical, "Musical"},
            { Genres.Mystery, "Mystery"},
            { Genres.News, "News"},
            { Genres.Podcast, "Podcast"},
            { Genres.Political, "Political" },
            { Genres.Reality, "Reality"},
            { Genres.Romance, "Romance"},
            { Genres.Science_Fiction, "Science Fiction"},
            { Genres.Soap, "Soap"},
            { Genres.Sports, "Sports"},
            { Genres.Suspense, "Suspense"},
            { Genres.Talk_Show, "Talk Show"},
            { Genres.Thriller, "Thriller"},
            { Genres.Travel, "Travel"},
            { Genres.TV_Movie, "TV Movie"},
            { Genres.War, "War"},
            { Genres.Western, "Western"}
        };

        private class MapItem
        {
            public Genres Genre { get; set; }
            public long LongValue => (long)Genre;
            public string Text { get; set; }
        }

        private static List<MapItem> GenreMaps => new List<MapItem>(AllGenres.Select(item => new MapItem { Genre = item.Key, Text = item.Value }));

        public static string AsString(Genres g)
        {
            //The Enum flags don't work above 32 bits, so work around by converting to a long and using bitmask ops
            var lst = new List<string>();
            long lg = (long)g;
            foreach (var mi in GenreMaps)
                if ((lg & mi.LongValue) != 0)
                    lst.Add(mi.Text);

            if (lst.Count == 0)
                return AllGenres[Genres.Unknown];

            lst.Sort();
            return string.Join(",", lst);
        }

        public static Genres ToGenres(string s)
        {
            //The Enum flags don't work above 32 bits, so work around by converting to a long and using bitmask ops
            long ret = (long)Genres.Unknown;

            if (!string.IsNullOrWhiteSpace(s))
                if (!s.Equals(AllGenres[Genres.Unknown], StringComparison.CurrentCultureIgnoreCase))
                    foreach (string part in s.Split(',').Select(item => item.Trim()))
                        foreach (string fixedGenre in FixGenre(part))
                            foreach (var mi in GenreMaps)
                                if (fixedGenre.Equals(mi.Text, StringComparison.CurrentCultureIgnoreCase))
                                    ret |= mi.LongValue;

            return (Genres)ret;
        }

        private static string[] FixGenre(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return new string[] { AllGenres[Genres.Unknown] };

            s = s.Trim();

            if (s.ICEquals("Animated"))
                return new string[] { AllGenres[Genres.Animation] };

            if (s.ICEquals("Anime"))
                return new string[] { AllGenres[Genres.Animation] };

            if (s.ICEquals("Kids"))
                return new string[] { AllGenres[Genres.Children] };

            if (s.ICEquals("Talk"))
                return new string[] { AllGenres[Genres.Talk_Show] };

            if (s.Equals("Sci-Fi"))
                return new string[] { AllGenres[Genres.Science_Fiction] };

            if (s.Equals("Sci-Fi & Fantasy"))
                return new string[] { AllGenres[Genres.Science_Fiction], AllGenres[Genres.Fantasy] };

            if (s.Equals("War & Politics"))
                return new string[] { AllGenres[Genres.War], AllGenres[Genres.Political] };


            return new string[] { s };
        }


        public static List<string> ExtractUnknownGenres(string s)
        {
            var ret = new List<string>();

            if (!string.IsNullOrWhiteSpace(s))
                if (!s.Equals(AllGenres[Genres.Unknown], StringComparison.CurrentCultureIgnoreCase))
                    foreach (string part in s.Split(',').Select(item => item.Trim()))
                        if (!part.IsKnownGenre())
                            ret.Add(part);

            return ret;
        }

        public static bool IsKnownGenre(string s)
        {
            s += string.Empty;
            if (!string.IsNullOrWhiteSpace(s))
                foreach (string fx in FixGenre(s))
                    foreach (var mi in GenreMaps)
                        if (fx.Equals(mi.Text, StringComparison.CurrentCultureIgnoreCase))
                            return true;

            return false;
        }

    }
}
