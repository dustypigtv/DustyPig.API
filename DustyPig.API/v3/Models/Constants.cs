using System.Collections.Generic;

namespace DustyPig.API.v3.Models;

public static class Constants
{
    /// <summary>
    /// The max number of media entries returned by the server for most queries
    /// </summary>
    public const int SERVER_RESULT_SIZE = 25;


    public const int MAX_NAME_LENGTH = 200;

    public const int MAX_URL_LENGTH = 1000;

    public const int MAX_DESCRIPTION_LENGTH = 10000;

    public const int MAX_MOBILE_DEVICE_ID_LENGTH = 1024;

    public const int DEVICE_ACTIVATION_CODE_LENGTH = 5;


    public static readonly MediaTypes[] PLAYABLE_MEDIA_TYPES = [MediaTypes.Movie, MediaTypes.Episode];

    public static readonly MediaTypes[] TOP_LEVEL_MEDIA_TYPES = [MediaTypes.Movie, MediaTypes.Series];




    public const string DEFAULT_HOST = "s3.dustypig.tv";



    public const string DEFAULT_PLAYLIST_PATH = "user-art/playlist";

    public const string DEFAULT_PLAYLIST_URL_ROOT = "https://" + DEFAULT_HOST + "/" + DEFAULT_PLAYLIST_PATH + "/";

    public const string DEFAULT_PLAYLIST_IMAGE = DEFAULT_PLAYLIST_URL_ROOT + "default.png";

    public const string DEFAULT_PLAYLIST_BACKDROP = DEFAULT_PLAYLIST_URL_ROOT + "default.backdrop.png";




    public const string DEFAULT_PROFILE_PATH = "user-art/profile";

    public const string DEFAULT_PROFILE_URL_ROOT = "https://" + DEFAULT_HOST + "/" + DEFAULT_PROFILE_PATH + "/";


    public const string DEFAULT_PROFILE_IMAGE_BLUE = DEFAULT_PROFILE_URL_ROOT + "blue.png";

    public const string DEFAULT_PROFILE_IMAGE_GOLD = DEFAULT_PROFILE_URL_ROOT + "gold.png";

    public const string DEFAULT_PROFILE_IMAGE_GREEN = DEFAULT_PROFILE_URL_ROOT + "green.png";

    public const string DEFAULT_PROFILE_IMAGE_GREY = DEFAULT_PROFILE_URL_ROOT + "grey.png";

    public const string DEFAULT_PROFILE_IMAGE_RED = DEFAULT_PROFILE_URL_ROOT + "red.png";

    public static IReadOnlyList<string> DefaultProfileImages() => new List<string>
    {
        DEFAULT_PROFILE_IMAGE_BLUE,
        DEFAULT_PROFILE_IMAGE_GOLD,
        DEFAULT_PROFILE_IMAGE_GREEN,
        DEFAULT_PROFILE_IMAGE_GREY,
        DEFAULT_PROFILE_IMAGE_RED,
    };


    /*
        Through lots of testing on Roku, these image sizes seem to have a good balance between loading quickly and quality.
        However, I'm definately not an expert, and while nobody seems to know this open source project exists, if anyone
        ever stumbles on it and has a better solution, I'm wide open to suggestions!
    
        JPEG uses max of 12 bits/pixel
        I'd like image to be <= 2/3 possible size
    
        bits = w * h * 12
        bytes = bits / 8
        guideline max = ceil(w * h * 12 / 8 * (2 / 3))

        Other calcs would be required for png, webp, etc.
        But these are just guidelines, and I use jpg, so it's all I'm adding for now.

        Processing Logic:
            this would run up to 20 times, but image processing in ffmpeg is blazing fast so
            even if it ran 20 times with exe launching overhead it would still only take like 1-2 seconds


        double q = 1;
        while (image.fileSize > GUIDELINE_MAX_FILESIZE)
        {
            if (image.width > GUIDELINE_MAX_WIDTH || image.height > GUIDELINE_MAX_HEIGHT)
            {
                double scaleW = (double)GUIDELINE_MAX_WIDTH / (double)image.width;
                double scaleH = (double)GUIDELINE_MAX_HEIGHT / (double)image.height;

                int newW = scaleW < scaleH ? maxW : -2;
                int newH = newW == -2 ? maxH : -2;

                ffmpeg args = $" -vf scale={newW}:{newH} -q:v {q}"
            }
            else
            {
                q -= 0.05;
                if(q <= 0.0d)
                    throw new Exception("Could not get image below max file size before quality hit zero");
                ffmpeg args = $" -q:v {q}";
            }

            <run ffmpeg>;
            <reload image>
        }

    */

    public const int GUIDELINE_MAX_JPG_POSTER_WIDTH = 400;
    public const int GUIDELINE_MAX_JPG_POSTER_HEIGHT = 600;
    public const int GUIDELINE_MAX_JPG_POSTER_FILESIZE = 240_000;

    public const int GUIDELINE_MAX_JPG_SCREENSHOT_WIDTH = 470;
    public const int GUIDELINE_MAX_JPG_SCREENSHOT_HEIGHT = 300;
    public const int GUIDELINE_MAX_JPG_SCREENSHOT_FILESIZE = 141_000;

    public const int GUIDELINE_MAX_JPG_BACKDROP_WIDTH = 940;
    public const int GUIDELINE_MAX_JPG_BACKDROP_HEIGHT = 600;
    public const int GUIDELINE_MAX_JPG_BACKDROP_FILESIZE = 564_000;
}
