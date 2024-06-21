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
}
