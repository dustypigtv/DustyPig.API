using DustyPig.API.v3.Models;
using System;
using System.Collections.Generic;

#if !NET7_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace DustyPig.API.v3.Interfaces;

public interface IPlayableMedia
{
#if !NET7_0_OR_GREATER
    [JsonConverter(typeof(JsonConverters.DateOnlyConverter))]
#endif
    public DateOnly Date { get; set; }

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

    public List<SRTSubtitle> SRTSubtitles { get; set; }
}