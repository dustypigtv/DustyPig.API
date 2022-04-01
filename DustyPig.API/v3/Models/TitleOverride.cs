namespace DustyPig.API.v3.Models
{
    public class TitleOverride
    {
        public int MediaEntryId { get; set; }

        public int ProfileId { get; set; }

        public int? RequestId { get; set; }

        public OverrideState State { get; set; }

    }
}
