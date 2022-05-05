using DustyPig.API.v3.BaseClasses;
using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateMovie : BaseMovieInfo, IMedia, ITopLevelMedia, IPlayableMedia, IValidate
    {
        #region IMedia

        //Completely handled by BaseMovieInfo

        #endregion



        #region ITopLevelMedia

        //Partially handled by BaseMovieINfo

        [JsonProperty("extra_search_terms")]
        public List<string> ExtraSearchTerms { get; set; } = new List<string>();

        #endregion



        #region IPlayableMedia

        //Partially handled by BaseMovieInfo

        [JsonProperty("bif_url")]
        public string BifUrl { get; set; }

        [JsonProperty("video_url")]
        public string VideoUrl { get; set; }

        [JsonProperty("srt_subtitles")]
        public List<ExternalSubtitle> ExternalSubtitles { get; set; } = new List<ExternalSubtitle>();

        #endregion





        public void Validate()
        {
            var lst = new List<string>();

            lst.AddRange(Validators.Validate(this as IMedia));
            lst.AddRange(Validators.Validate(this as ITopLevelMedia));
            lst.AddRange(Validators.Validate(this as IPlayableMedia));

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
