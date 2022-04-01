﻿using DustyPig.API.v3.MPAA;
using System.Collections.Generic;

namespace DustyPig.API.v3.Interfaces
{
    public interface ITopLevelMedia
    {
        public int LibraryId { get; set; }

        public Ratings Rated { get; set; }

        public Genres Genres { get; set; }

        public List<string> Cast { get; set; }

        public List<string> Directors { get; set; }

        public List<string> Producers { get; set; }

        public List<string> Writers { get; set; }

        public List<string> ExtraSearchTerms { get; set; }
    }
}
