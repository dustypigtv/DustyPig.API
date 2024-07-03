using DustyPig.API.v3.Interfaces;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models;

public class DetailedMovie : CreateMovie, ICredits
{
    public int Id { get; set; }

    public string Owner { get; set; }

    public double? Played { get; set; }

    public bool InWatchlist { get; set; }

    public bool CanPlay { get; set; }

    public bool CanManage { get; set; }

    public TitleRequestPermissions TitleRequestPermission { get; set; }

    public OverrideRequestStatus AccessRequestedStatus { get; set; }

    #region ICredits

    public List<BasicPerson> Credits { get; set; } = [];

    #endregion

    /// <summary>
    /// Timestamp when movie was added to the server
    /// </summary>
    public DateTime Added { get; set; }

    public override string ToString() => base.ToString();
}
