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



        public const string DEFAULT_PLAYLIST_IMAGE = "https://user-art.dustypig.tv/playlist/default.jpg";

        public const string DEFAULT_PROFILE_IMAGE_BLUE = "https://user-art.dustypig.tv/profile/blue.png";
        
        public const string DEFAULT_PROFILE_IMAGE_GOLD = "https://user-art.dustypig.tv/profile/gold.png";
        
        public const string DEFAULT_PROFILE_IMAGE_GREEN = "https://user-art.dustypig.tv/profile/green.png";
        
        public const string DEFAULT_PROFILE_IMAGE_GREY = "https://user-art.dustypig.tv/profile/grey.png";
        
        public const string DEFAULT_PROFILE_IMAGE_RED = "https://user-art.dustypig.tv/profile/red.png";
    }
}
