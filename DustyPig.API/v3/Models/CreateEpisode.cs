using DustyPig.API.v3.BaseClasses;
using DustyPig.API.v3.Interfaces;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.Models
{
    public class CreateEpisode : BaseEpisodeInfo, IMedia, IPlayableMedia, IValidate
    {
        #region IMedia

        //Completely handled by BaseEpisodeInfo

        #endregion


        #region IPlayableMedia

        //Partially handled by BaseEpisodeInfo

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


        [JsonPropertyName("srtSubtitles")]
        public List<SRTSubtitle> SRTSubtitles { get; set; }


        #endregion


        #region IValidate

        public void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(SeriesId), SeriesId, lst);

            if (SeasonNumber < 0)
                lst.Add($"{nameof(SeasonNumber)} must be >= 0");

            if (EpisodeNumber <= 0)
                lst.Add($"{nameof(EpisodeNumber)} must be > 0");

            lst.AddRange(Validators.Validate(this as IMedia));
            lst.AddRange(Validators.Validate(this as IPlayableMedia));

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

        #endregion

        public override string ToString() => base.ToString();
    }
}
