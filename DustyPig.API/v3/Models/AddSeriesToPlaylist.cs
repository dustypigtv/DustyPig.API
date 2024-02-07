namespace DustyPig.API.v3.Models
{
    public class AddSeriesToPlaylist : AddPlaylistItem
    {
        /// <summary>
        /// Automatically add new episodes to this playlist when they become available in the series
        /// </summary>
        public bool AutoAddNewEpisodes { get; set; }

    }
}
