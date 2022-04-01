namespace DustyPig.API.v3.Models
{
    public static class Constants
    {
        public const int MAX_NAME_LENGTH = 100;

        public const int MAX_URL_LENGTH = 1000;

        public const int MAX_DESCRIPTION_LENGTH = 2500;


        public static readonly MediaTypes[] PLAYABLE_MEDIA_TYPES = new MediaTypes[] { MediaTypes.Movie, MediaTypes.Episode };

        public static readonly MediaTypes[] TOP_LEVEL_MEDIA_TYPES = new MediaTypes[] { MediaTypes.Movie, MediaTypes.Series };
    }
}
