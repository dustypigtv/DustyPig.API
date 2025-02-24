using DustyPig.API.v3.Models;
using System;

namespace DustyPig.API.v3;

static class Utils
{
    /*
        JPEG
        bits = w * h * 12
        bytes = bits / 8
        guideline max = ceil(w * h * 12 / 8 * (2 / 3))
    */

    const double TWELVE_EIGHTS = (12d / 8d);
    const double TWO_THIRDS = (2d / 3d);
    const double MULTIPLIER = TWELVE_EIGHTS * TWO_THIRDS;

    const double BACKDROP_RATIO = 0.5625d;


    public static int GetGuidlinePosterJpgHeight(int width) => Convert.ToInt32(width / TWO_THIRDS);

    public static int GetGuidlinePosterJpgWidth(int height) => Convert.ToInt32(height * TWO_THIRDS);

    public static int GetGuidlineBackdropJpgHeight(int width) => Convert.ToInt32(width * BACKDROP_RATIO);

    public static int GetGuidlineBackdropJpgWidth(int height) => Convert.ToInt32(height / BACKDROP_RATIO);

    public static int GetGuidelineMaxJpgSize(int width, int height) =>
        Convert.ToInt32(Math.Ceiling(width * height * TWELVE_EIGHTS * TWO_THIRDS));
}

