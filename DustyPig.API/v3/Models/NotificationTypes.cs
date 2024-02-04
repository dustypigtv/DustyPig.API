namespace DustyPig.API.v3.Models
{
    public enum NotificationTypes
    {
        /// <summary>
        /// A request or answer to have a new movie added
        /// </summary>
        NewMovieRequest,

        /// <summary>
        /// A request or answer to have a new series added
        /// </summary>
        NewSeriesRequest,


        /// <summary>
        /// New movie that is being monitored has been added and is available for viewing
        /// </summary>
        NewMovieAvailable,


        /// <summary>
        /// Season 1 Episode 1 of a series that is being monitored has been added and is available for viewing
        /// </summary>
        NewSeriesAvailable,

        /// <summary>
        /// A new episode of a series subscription is available and is available for viewing
        /// </summary>
        NewEpisodeAvailable,

        /// <summary>
        /// A new request or answer for overriding parental controls
        /// </summary>
        OverrideRequest,

        /// <summary>
        /// Friendship request or answer
        /// </summary>
        Friendship
    }
}
