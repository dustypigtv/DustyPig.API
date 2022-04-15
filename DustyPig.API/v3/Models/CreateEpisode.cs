using DustyPig.API.v3.BaseClasses;
using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateEpisode : BaseEpisodeInfo, IMedia, IPlayableMedia, IValidate
    {
        #region IMedia

        //Completely handled by BaseEpisodeInfo

        #endregion


        #region IPlayableMedia

        //Partially handled by BaseEpisodeInfo

        [JsonProperty("bif_asset")]
        public CreateStreamingAsset BifAsset { get; set; }

        [JsonRequired]
        [JsonProperty("video_asset")]
        public CreateStreamingAsset VideoAsset { get; set; }

        [JsonProperty("srt_subtitles")]
        public List<CreateExternalSubtitle> ExternalSubtitles { get; set; } = new List<CreateExternalSubtitle>();

        #endregion


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
    }
}
