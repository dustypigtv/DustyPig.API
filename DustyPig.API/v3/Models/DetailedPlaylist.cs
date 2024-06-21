using System.Collections.Generic;

namespace DustyPig.API.v3.Models;

public class DetailedPlaylist : BasicPlaylist
{
    public int CurrentItemId { get; set; }

    public double CurrentProgress { get; set; }

    public List<PlaylistItem> Items { get; set; } = [];

    public override string ToString() => base.ToString();
}
