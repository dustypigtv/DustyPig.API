using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class SearchResults
    {
        public List<BasicMedia> Available { get; set; } = [];

        public bool OtherTitlesAllowed { get; set; }

        public List<BasicTMDB> OtherTitles { get; set; } = [];

        public List<BasicPerson> AvailablePeople { get; set; } = [];

        public List<BasicPerson> OtherPeople { get; set; } = [];
    }
}
