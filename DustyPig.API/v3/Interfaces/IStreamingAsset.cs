namespace DustyPig.API.v3.Interfaces
{
    public interface IStreamingAsset
    {
        public string Url { get; set; }

        public int? ServiceCredentialId { get; set; }
    }
}
