using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models;

public class DetailedFriend : BasicFriend
{
    public DateTime Timestamp { get; set; }

    public List<BasicLibrary> SharedWithFriend { get; set; } = [];

    public List<BasicLibrary> SharedWithMe { get; set; } = [];

    public override string ToString() => base.ToString();
}
