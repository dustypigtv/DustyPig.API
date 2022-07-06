namespace DustyPig.API.v3.Models
{
    public enum RequestStatus
    {
        NotRequested = 0,

        /// <summary>
        /// Sub profile requested a title from the Main profile. Main can deny, set to pending/fulfilled, or send to a friend account
        /// </summary>
        RequestSentToMain = 1,

        /// <summary>
        /// Request has been sent to a friend account
        /// </summary>
        RequestSentToAccount = 2,

        Denied = 3,

        Pending = 4,

        Fulfilled = 5
    }
}
