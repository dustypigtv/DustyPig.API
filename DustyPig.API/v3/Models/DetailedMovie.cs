namespace DustyPig.API.v3.Models
{
    public class DetailedMovie : CreateMovie
    {
        public int Id { get; set; }

        public string Owner { get; set; }

        public double? Played { get; set; }

        public bool InWatchlist { get; set; }

        public bool CanPlay { get; set; }

        public bool CanManage { get; set; }

        public TitleRequestPermissions TitleRequestPermission { get; set; }

        public OverrideRequestStatus AccessRequestedStatus { get; set; }

        public override string ToString() => base.ToString();
    }
}
