using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class DetailedLibrary : BasicLibrary
    {
        public List<BasicProfile> Profiles { get; set; }

        public List<BasicFriend> SharedWith { get; set; }

        public override string ToString() => base.ToString();
    }
}
