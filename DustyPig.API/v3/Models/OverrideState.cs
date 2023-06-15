namespace DustyPig.API.v3.Models
{
    public enum OverrideState
    {
        /// <summary>
        /// If set to Default, then the ability to see/play a title will depend on library shares and ratings controls
        /// </summary>
        Default = 0,
        Allow = 1,
        Block = 2
    }
}
