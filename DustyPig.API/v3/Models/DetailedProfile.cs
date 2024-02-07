using DustyPig.API.v3.BaseClasses;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class DetailedProfile : BaseProfile
    {
        public int Id { get; set; }

        public bool HasPin { get; set; }

        public List<BasicLibrary> AvailableLibraries { get; set; }

        public bool IsMain { get; set; }

        public override string ToString() => base.ToString();

    }
}