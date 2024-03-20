using DustyPig.API.v3.Models;
using System.Collections.Generic;

namespace DustyPig.API.v3.Interfaces;

public interface ICredits
{
    public List<BasicPerson> Credits { get; set; }
}
