using System.Collections.Generic;

namespace DustyPig.API.v3.Models;

public class TitlePermissions
{
    public int MediaId { get; set; }

    public List<ProfileTitleOverride> SubProfiles { get; set; } = [];

    public List<ProfileTitleOverride> FriendProfiles { get; set; } = [];

}
