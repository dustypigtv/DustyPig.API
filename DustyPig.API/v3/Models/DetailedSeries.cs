﻿using DustyPig.API.v3.Interfaces;
using DustyPig.API.v3.JsonConverters;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.Models;

public class DetailedSeries : CreateSeries, ICredits
{
    public int Id { get; set; }

    public string Owner { get; set; }

    public List<DetailedEpisode> Episodes { get; set; } = [];

    public bool InWatchlist { get; set; }

    public bool CanPlay { get; set; }

    public bool CanManage { get; set; }

    [JsonConverter(typeof(TitleRequestPermissionsConverter))]
    public TitleRequestPermissions TitleRequestPermission { get; set; }

    [JsonConverter(typeof(OverrideRequestStatusConverter))]
    public OverrideRequestStatus AccessRequestedStatus { get; set; }

    public bool Subscribed { get; set; }

    #region ICredits

    public List<BasicPerson> Credits { get; set; } = [];

    #endregion

    /// <summary>
    /// Timestamp when movie was added to the server
    /// </summary>
    public DateTime Added { get; set; }

    public override string ToString() => base.ToString();
}
