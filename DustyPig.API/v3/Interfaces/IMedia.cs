namespace DustyPig.API.v3.Interfaces
{
    public interface IMedia
    {
        public string Title { get; set; }

        public int? TMDB_Id { get; set; }

        public string Description { get; set; }

        public string ArtworkUrl { get; set; }
    }
}
