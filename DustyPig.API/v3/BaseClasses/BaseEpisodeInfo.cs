using DustyPig.API.v3.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.BaseClasses;

public abstract class BaseEpisodeInfo : IMedia
{
    #region IMedia

    public string Title { get; set; }

    [JsonPropertyName("tmdbId")]
    public int? TMDB_Id { get; set; }

    public string Description { get; set; }

    public string ArtworkUrl { get; set; }

    #endregion

#if !NET7_0_OR_GREATER
    [JsonConverter(typeof(JsonConverters.DateOnlyConverter))]
#endif
    public DateOnly Date { get; set; }

    public double Length { get; set; }

    public double? IntroStartTime { get; set; }

    public double? IntroEndTime { get; set; }

    public double? CreditsStartTime { get; set; }

    public int SeriesId { get; set; }

    public ushort SeasonNumber { get; set; }

    public ushort EpisodeNumber { get; set; }

    public override string ToString() => $"s{SeasonNumber:00}e{EpisodeNumber:00}";
}
