namespace DustyPig.API.v3.Models;

public class BasicPlaylist : CreatePlaylist
{
    public int Id { get; set; }

    public string ArtworkUrl { get; set; }

    public string BackdropUrl { get; set; }

    public override string ToString() => base.ToString();
}
