namespace DustyPig.API.v3.MPAA
{
    //[Flags]
    //public enum Ratings
    //{
    //    None = 0,

    //    G = 1 << 0,
    //    PG = 1 << 1,
    //    PG_13 = 1 << 2,
    //    R = 1 << 3,
    //    NC_17 = 1 << 4,
    //    Unrated = 1 << 5,

    //    TV_Y = 1 << 6,
    //    TV_Y7 = 1 << 7,
    //    TV_G = 1 << 8,
    //    TV_PG = 1 << 9,
    //    TV_14 = 1 << 10,
    //    TV_MA = 1 << 11,

    //    TV_NotRated = 1 << 12,

    //    All = ~(-1 << 13)
    //}

    public enum MovieRatings
    {
        None = 0,
        G = 1,
        PG = 2,
        PG_13 = 3,
        R = 4,
        NC_17 = 5,
        Unrated = 6
    }

    public enum TVRatings
    {
        None = 0,
        TV_Y = 1,
        TV_Y7 = 2,
        TV_G = 3,
        TV_PG = 4,
        TV_14 = 5,
        TV_MA = 6,
        NotRated = 7
    }
}
