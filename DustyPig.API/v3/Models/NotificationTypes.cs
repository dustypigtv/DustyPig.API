namespace DustyPig.API.v3.Models;

public enum NotificationTypes : int
{
    NewMediaRequested = 1,
    NewMediaPending = 2,
    NewMediaFulfilled = 3,
    NewMediaRejected = 4,
    NewMediaAvailable = 5,

    OverrideMediaRequested = 6,
    OverrideMediaGranted = 7,
    OverrideMediaRejected = 8,

    FriendshipInvited = 9,
    FriendshipAccepted = 10
}
