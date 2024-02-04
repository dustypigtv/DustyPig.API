namespace DustyPig.API.v3.Models
{
    public enum NotificationTypes
    {
        NewMovieRequested = 1,
        NewMoviePending = 2,
        NewMovieFulfilled = 3,
        NewMovieRejected = 4,

        NewSeriesRequested = 5,
        NewSeriesPending = 6,
        NewSeriesFulfilled = 7,
        NewSeriesRejected = 8,

        NewEpisodeAvailable = 9,

        OverrideMovieRequested = 10,
        OverrideMovieGranted = 11,
        OverrideMovieRejected = 12,

        OverrideSeriesRequested = 13,
        OverrideSeriesGranted = 14,
        OverrideSeriesRejected = 15,

        FriendshipInvited = 16,
        FriendshipAccepted = 17
    }
}
