using System.Collections.Generic;

namespace DustyPig.API.v3.Models;

public class AccountLoginResponse : ProfileLoginResponse
{
    public string AccountToken { get; set; }

    public List<BasicProfile> Profiles { get; set; } = [];
}
