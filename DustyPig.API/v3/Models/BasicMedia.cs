namespace DustyPig.API.v3.Models
{
    public class BasicMedia
    {
        public int Id { get; set; }

        public MediaTypes MediaType { get; set; }

        public string ArtworkUrl { get; set; }

        public string BackdropUrl { get; set; }

        public string Title { get; set; }

        public CreditRoles? Role { get; set; }

        public override string ToString() => Title;

    }
}
