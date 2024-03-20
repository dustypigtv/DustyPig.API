using DustyPig.API.v3.MPAA;
using System.Collections.Generic;

namespace DustyPig.API.v3.Interfaces;

public interface ITopLevelMedia
{
    public int LibraryId { get; set; }

    public string BackdropUrl { get; set; }

    /// <summary>
    /// Size in Bytes
    /// </summary>
    public ulong BackdropSize { get; set; }

    public Genres Genres { get; set; }

    public List<string> ExtraSearchTerms { get; set; }
}
