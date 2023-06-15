namespace DustyPig.API.v3.Models
{
    public enum OverrideState
    {
        /// <summary>
        /// Default is used by the server only. If you try to set it in a call to <see cref="Clients.MediaClient.SetTitlePermissionsAsync(TitlePermissionInfo, System.Threading.CancellationToken)"/>, the server will return a validation error
        /// </summary>
        Default = 0,


        Allow = 1,
        Block = 2
    }
}
