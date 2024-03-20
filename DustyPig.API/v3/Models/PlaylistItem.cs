using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.Models;

public class PlaylistItem
{
    public int Id { get; set; }

    public int Index { get; set; }

    public int MediaId { get; set; }

    public int? SeriesId { get; set; }

    public MediaTypes MediaType { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string ArtworkUrl { get; set; }

    /// <summary>
    /// Size in Bytes
    /// </summary>
    public ulong ArtworkSize { get; set; }

    public double Length { get; set; }

    public double? IntroStartTime { get; set; }

    public double? IntroEndTime { get; set; }

    public double? CreditsStartTime { get; set; }


    public string BifUrl { get; set; }

    /// <summary>
    /// Size in Bytes
    /// </summary>
    public ulong BifSize { get; set; }

    public string VideoUrl { get; set; }

    /// <summary>
    /// Size in Bytes
    /// </summary>
    public ulong VideoSize { get; set; }

    [JsonPropertyName("srtSubtitles")]
    public List<SRTSubtitle> SRTSubtitles { get; set; } = [];
}
