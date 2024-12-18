﻿using DustyPig.API.v3.Interfaces;
using DustyPig.API.v3.MPAA;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models;

public class DetailedTMDB : BasicTMDB, ICredits
{
    public int Year { get; set; }

    public string Rated { get; set; }

    public string Description { get; set; }

    public Genres Genres { get; set; }

    public List<BasicMedia> Available { get; set; } = [];

    public TitleRequestPermissions RequestPermission { get; set; }

    public RequestStatus RequestStatus { get; set; }

    public bool RequestedOfThisProfile { get; set; }

    public List<string> Requestors { get; set; } = [];

    #region ICredits

    public List<BasicPerson> Credits { get; set; } = [];

    #endregion

    public override string ToString() => base.ToString();
}
