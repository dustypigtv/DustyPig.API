using DustyPig.API.v3.Models;
using System.Collections.Generic;

namespace DustyPig.API.v3.Interfaces
{
    public interface ICredits
    {
        public List<Person> Cast { get; set; }

        public List<Person> Directors { get; set; }

        public List<Person> Producers { get; set; }

        public List<Person> Writers { get; set; }
    }
}
