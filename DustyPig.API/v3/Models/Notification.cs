using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Notification : IEquatable<Notification>
    {
        [JsonRequired]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonRequired]
        [JsonProperty("profile_id")]
        public int ProfileId { get; set; }

        [JsonRequired]
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonRequired]
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("notification_type")]
        public NotificationTypes NotificationType { get; set; }

        /// <summary>
        /// For new media requests, this will be the TMDB id.
        /// For new movie/series fulfilled notifications, this will be the media id in the database.
        /// For new episode available notifications, this will be the media id of the series in the database.
        /// For friendship notifications, this will be null.
        /// </summary>
        [JsonProperty("media_id")]
        public int? MediaId { get; set; }

        /// <summary>
        /// This will only by used for friendship notifications.
        /// For media notifications, this will be null.
        /// </summary>
        [JsonProperty("friendship_id")]
        public int? FriendshipId { get; set; }


        [JsonRequired]
        [JsonProperty("seen")]
        public bool Seen { get; set; }

        [JsonRequired]
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as Notification);
        }

        public bool Equals(Notification other)
        {
            return !(other is null) &&
                   Id == other.Id &&
                   ProfileId == other.ProfileId &&
                   Title == other.Title &&
                   Message == other.Message &&
                   NotificationType == other.NotificationType &&
                   MediaId == other.MediaId &&
                   FriendshipId == other.FriendshipId &&
                   Seen == other.Seen &&
                   Timestamp == other.Timestamp;
        }

        public override int GetHashCode()
        {
            int hashCode = 269522376;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + ProfileId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Message);
            hashCode = hashCode * -1521134295 + NotificationType.GetHashCode();
            hashCode = hashCode * -1521134295 + MediaId.GetHashCode();
            hashCode = hashCode * -1521134295 + FriendshipId.GetHashCode();
            hashCode = hashCode * -1521134295 + Seen.GetHashCode();
            hashCode = hashCode * -1521134295 + Timestamp.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Notification left, Notification right)
        {
            return EqualityComparer<Notification>.Default.Equals(left, right);
        }

        public static bool operator !=(Notification left, Notification right)
        {
            return !(left == right);
        }

        #endregion
    }
}
