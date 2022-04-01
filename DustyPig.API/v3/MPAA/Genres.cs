﻿using System;

namespace DustyPig.API.v3.MPAA
{
    [Flags]
    public enum Genres : long
    {
        Unknown = 0,
        Action = 1L << 0,
        Adventure = 1L << 1,
        Animation = 1L << 2,
        Anime = 1L << 3,
        Awards_Show = 1L << 4,
        Children = 1L << 5,
        Comedy = 1L << 6,
        Crime = 1L << 7,
        Documentary = 1L << 8,
        Drama = 1L << 9,
        Family = 1L << 10,
        Fantasy = 1L << 11,
        Food = 1L << 12,
        Game_Show = 1L << 13,
        History = 1L << 14,
        Home_and_Garden = 1L << 15,
        Horror = 1L << 16,
        Indie = 1L << 17,
        Martial_Arts = 1L << 18,
        Mini_Series = 1L << 19,
        Music = 1L << 20,
        Musical = 1L << 21,
        Mystery = 1L << 22,
        News = 1L << 23,
        Podcast = 1L << 24,
        Political = 1L << 25,
        Reality = 1L << 26,
        Romance = 1L << 27,
        Science_Fiction = 1L << 28,
        Soap = 1L << 29,
        Sports = 1L << 30,
        Suspense = 1L << 31,
        Talk_Show = 1L << 32,
        Thriller = 1L << 33,
        Travel = 1L << 34,
        TV_Movie = 1L << 35,
        War = 1L << 36,
        Western = 1L << 37,
    }
}
