using System;

namespace DustyPig.API.v3.Models
{
    [Flags]
    public enum NotificationMethods
    {
        InAppOnly = 0,
        Email = 1,
        MobileNotifications = 2
    }
}
