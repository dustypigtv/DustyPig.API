using DustyPig.API.v3.MPAA;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class DetailedTMDB : BasicTMDB
    {
        public int Year { get; set; }

        public string Rated { get; set; }

        public string Description { get; set; }

        public Genres Genres { get; set; }

        public List<string> Cast { get; set; }

        public List<string> Directors { get; set; }

        public List<string> Producers { get; set; }

        public List<string> Writers { get; set; }

        public List<BasicMedia> Available { get; set; }

        public TitleRequestPermissions RequestPermission { get; set; }

        public RequestStatus RequestStatus { get; set; }

        public override string ToString() => base.ToString();
    }
}
