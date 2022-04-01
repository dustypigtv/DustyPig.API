using Newtonsoft.Json;

namespace DustyPig.API.v3.Models
{
    public class LibraryFriendLink
    {
        [JsonProperty("library_id")]
        public int LibraryId { get; set; }

        [JsonProperty("friend_id")]
        public int FriendId { get; set; }
    }
}
