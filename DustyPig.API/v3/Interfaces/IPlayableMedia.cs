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


        public CreateStreamingAsset BifAsset { get; set; }

        public CreateStreamingAsset VideoAsset { get; set; }

        public List<CreateExternalSubtitle> ExternalSubtitles { get; set; }
    }
}
