using System;

namespace DustyPig.API.v3.Models;

public class ProfileTitleOverride : IComparable<ProfileTitleOverride>
{
    public int ProfileId { get; set; }

    public string Name { get; set; }

    public string AvatarUrl { get; set; }

    public OverrideState OverrideState { get; set; }

    public int CompareTo(ProfileTitleOverride other)
    {
        return Name.CompareTo(other.Name);
    }
}
