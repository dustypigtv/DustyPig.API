using DustyPig.API.v3.JsonConverters;
using System;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.Models;

public class ProfileTitleOverride : IComparable<ProfileTitleOverride>
{
    public int ProfileId { get; set; }

    public string Name { get; set; }

    public string AvatarUrl { get; set; }

    [JsonConverter(typeof(OverrideStateConverter))]
    public OverrideState OverrideState { get; set; }

    public int CompareTo(ProfileTitleOverride other)
    {
        return Name.CompareTo(other.Name);
    }
}
