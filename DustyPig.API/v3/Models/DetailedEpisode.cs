namespace DustyPig.API.v3.Models
{
    public class DetailedEpisode : CreateEpisode
    {
        public int Id { get; set; }

        public double? Played { get; set; }

        public bool UpNext { get; set; }

        /// <summary>
        /// Helpful info for clients
        /// </summary>
        public string SeriesTitle { get; set; }

        public override string ToString() => base.ToString();
    }
}
