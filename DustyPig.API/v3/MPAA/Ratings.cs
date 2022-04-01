﻿using System;

namespace DustyPig.API.v3.MPAA
{
    [Flags]
    public enum Ratings
    {
        None = 0,

        G = 1 << 0,
        PG = 1 << 1,
        PG_13 = 1 << 2,
        R = 1 << 3,
        NC_17 = 1 << 4,
        Unrated = 1 << 5,

        TV_Y = 1 << 6,
        TV_Y7 = 1 << 7,
        TV_G = 1 << 8,
        TV_PG = 1 << 9,
        TV_14 = 1 << 10,
        TV_MA = 1 << 11,

        NR = 1 << 12,

        All = ~(-1 << 13)
    }
}
