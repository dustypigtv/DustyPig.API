﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DustyPig.API.v3.Models;

/// <summary>
/// Returned when calling <see cref="Clients.EpisodesClient.GetDetailsAsync"/>
/// </summary>
public class DetailedEpisodeEx : DetailedEpisode
{
    public string SeriesTitle { get; set; }

    public string SeriesArtworkUrl { get; set; }

    public string SeriesBackdropUrl { get; set; }
}
