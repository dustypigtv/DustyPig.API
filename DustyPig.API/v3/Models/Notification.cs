using System;

namespace DustyPig.API.v3.Models;

public class Notification
{
    public int Id { get; set; }

    public int ProfileId { get; set; }

    public string Title { get; set; }

    public string Message { get; set; }

    public NotificationTypes NotificationType { get; set; }

    /// <summary>
    /// For new media requests, this will be the TMDB id.
    /// For new movie/series fulfilled notifications, this will be the media id in the database.
    /// For new episode available notifications, this will be the media id of the series in the database.
    /// For friendship notifications, this will be null.
    /// </summary>
    public int? MediaId { get; set; }

    /// <summary>
    /// Only used for media requests
    /// </summary>
    public MediaTypes? MediaType { get; set; }

    /// <summary>
    /// This will only by used for friendship notifications.
    /// For media notifications, this will be null.
    /// </summary>
    public int? FriendshipId { get; set; }


    public bool Seen { get; set; }

    public DateTime Timestamp { get; set; }
}
