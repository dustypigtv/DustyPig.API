namespace DustyPig.API.v3.Models
{
    public static class Constants
    {
        public const int MAX_NAME_LENGTH = 200;

        public const int MAX_URL_LENGTH = 1000;

        public const int MAX_DESCRIPTION_LENGTH = 10000;

        public const int MAX_MOBILE_DEVICE_ID_LENGTH = 1024;

        public const int DEVICE_ACTIVATION_CODE_LENGTH = 5;


        public static readonly MediaTypes[] PLAYABLE_MEDIA_TYPES = new MediaTypes[] { MediaTypes.Movie, MediaTypes.Episode };

        public static readonly MediaTypes[] TOP_LEVEL_MEDIA_TYPES = new MediaTypes[] { MediaTypes.Movie, MediaTypes.Series };

        public const string DEFAULT_PLAYLIST_IMAGE = "https://s3.us-central-1.wasabisys.com/dustypig/media/playlist.svg";
    }
}
