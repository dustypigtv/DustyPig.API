using DustyPig.API.v3.Models;

namespace DustyPig.API.v3.MPAA
{
    class RatingsMap
    {
        public MediaTypes EntryType { get; set; }
        public string Country { get; set; }
        public string Rating { get; set; }
        public string Meaning { get; set; }
        public string US_Equivalent { get; set; }
        public int Rank { get; set; }
    }
}
