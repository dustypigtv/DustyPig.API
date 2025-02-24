using DustyPig.API.v3.JsonConverters;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.Models;

public enum LoginType
{
    Account = 0,
    MainProfile = 1,
    SubProfile = 2
}


public class ProfileLoginResponse
{
    [JsonConverter(typeof(LoginTypeConverter))]
    public LoginType LoginType { get; set; }

    /// <summary>
    /// If <see cref="LoginType"/> != <see cref="LoginType.Account"/>, this will hold the new profile token
    /// </summary>
    public string ProfileToken { get; set; }

    /// <summary>
    /// If <see cref="LoginType"/> != <see cref="LoginType.Account"/>, this will hold the id of the logged in profile
    /// </summary>
    public int? ProfileId { get; set; }
}
