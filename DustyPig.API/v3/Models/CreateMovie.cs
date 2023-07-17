using DustyPig.API.v3.BaseClasses;
using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateMovie : BaseMovieInfo, IMedia, ITopLevelMedia, IPlayableMedia, IValidate, IEquatable<CreateMovie>
    {
        #region IMedia

        //Completely handled by BaseMovieInfo

        #endregion


        #region ITopLevelMedia

        //Completely handled by BaseMovieINfo

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


        #region IValidate 

        public void Validate()
        {
            var lst = new List<string>();

            lst.AddRange(Validators.Validate(this as IMedia));
            lst.AddRange(Validators.Validate(this as ITopLevelMedia));
            lst.AddRange(Validators.Validate(this as IPlayableMedia));

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

        #endregion


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as CreateMovie);
        }

        public bool Equals(CreateMovie other)
        {
            return !(other is null) &&
                   base.Equals(other) &&
                   BifUrl == other.BifUrl &&
                   VideoUrl == other.VideoUrl &&
                   EqualityComparer<List<ExternalSubtitle>>.Default.Equals(ExternalSubtitles, other.ExternalSubtitles);
        }

        public override int GetHashCode()
        {
            int hashCode = 874782302;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(BifUrl);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(VideoUrl);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<ExternalSubtitle>>.Default.GetHashCode(ExternalSubtitles);
            return hashCode;
        }


        public static bool operator ==(CreateMovie left, CreateMovie right)
        {
            return EqualityComparer<CreateMovie>.Default.Equals(left, right);
        }

        public static bool operator !=(CreateMovie left, CreateMovie right)
        {
            return !(left == right);
        }

        #endregion


        public override string ToString() => base.ToString();
    }
}
