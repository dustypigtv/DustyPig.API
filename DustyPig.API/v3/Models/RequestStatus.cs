namespace DustyPig.API.v3.Models
{
    public enum RequestStatus
    {
        NotRequested = 0,

        /// <summary>
        /// Request sent
        /// </summary>
        Requested = 1,

        /// <summary>
        /// Request denied
        /// </summary>
        Denied = 2,

        /// <summary>
        /// Request granted and pending fufillment
        /// </summary>
        Pending = 3,

        /// <summary>
        /// Request fufilled
        /// </summary>
        Fufilled = 4
    }
}
