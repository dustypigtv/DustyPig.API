using DustyPig.API.v3.JsonConverters;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.Models;

public class PlaylistItem
{
    public int Id { get; set; }

    public int Index { get; set; }

    public int MediaId { get; set; }

    public int? SeriesId { get; set; }

    [JsonConverter(typeof(MediaTypesConverter))]
    public MediaTypes MediaType { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string ArtworkUrl { get; set; }

    public double Length { get; set; }

    public double? IntroStartTime { get; set; }

    public double? IntroEndTime { get; set; }

    public double? CreditsStartTime { get; set; }


    public string BifUrl { get; set; }

    public string VideoUrl { get; set; }

    [JsonPropertyName("srtSubtitles")]
    public List<SRTSubtitle> SRTSubtitles { get; set; } = [];
}
