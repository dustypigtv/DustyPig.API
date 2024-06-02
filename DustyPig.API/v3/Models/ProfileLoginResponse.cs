namespace DustyPig.API.v3.Models;

public enum LoginType
{
    Account = 0,
    MainProfile = 1,
    SubProfile = 2
}


public class ProfileLoginResponse
{
    public string Token { get; set; }

    public LoginType LoginType { get; set; }

    /// <summary>
    /// If <see cref="LoginType"/> != <see cref="LoginType.Account"/>, this will hold the id of the logged in profile
    /// </summary>
    public int? ProfileId { get; set; }
}
