using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DustyPig.API.v3.Models;

public class TitleRequestSource
{
    /// <summary>
    /// If null, this source is the main profile for the account
    /// </summary>
    public int? FriendId { get; set; }

    public string Name { get; set; }

    public string AvatarUrl { get; set; }
}
