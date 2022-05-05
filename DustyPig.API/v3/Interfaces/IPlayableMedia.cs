using DustyPig.API.v3.Models;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Interfaces
{
    public interface IPlayableMedia
    {
        public DateTime Date { get; set; }

        public double Length { get; set; }

        public double? IntroStartTime { get; set; }

        public double? IntroEndTime { get; set; }

        public double? CreditsStartTime { get; set; }


        public string BifUrl { get; set; }

        public string VideoUrl { get; set; }

        public List<ExternalSubtitle> ExternalSubtitles { get; set; }
    }
}
