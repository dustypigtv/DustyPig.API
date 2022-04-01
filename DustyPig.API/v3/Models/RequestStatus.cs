namespace DustyPig.API.v3.Models
{
    public enum RequestStatus
    {
        /// <summary>
        /// Request senti
        /// </summary>
        Requested = 0,

        /// <summary>
        /// Request denied
        /// </summary>
        Denied = 1,

        /// <summary>
        /// Request granted and pending fufillment
        /// </summary>
        Pending = 2,

        /// <summary>
        /// Request fufilled
        /// </summary>
        Fufilled = 3
    }
}
