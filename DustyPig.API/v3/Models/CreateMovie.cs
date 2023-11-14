using DustyPig.API.v3.BaseClasses;
using DustyPig.API.v3.Interfaces;
using DustyPig.API.v3.MPAA;
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

        //Completely handled by BaseMovieInfo

        #endregion


        #region IPlayableMedia

        //Partially handled by BaseMovieInfo

        [JsonProperty("bif_url")]
        public string BifUrl { get; set; }

        /// <summary>
        /// Size in Bytes
        /// </summary>
        [JsonProperty("bif_size")]
        public ulong BifSize { get; set; }

        [JsonProperty("video_url")]
        public string VideoUrl { get; set; }

        /// <summary>
        /// Size in Bytes
        /// </summary>
        [JsonProperty("video_size")]
        public ulong VideoSize { get; set; }

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

            if (Rated == MovieRatings.None)
            {
                lst.Add(nameof(Rated) + " not specified");
            }
            else
            {
                bool realRating = false;
                foreach (MovieRatings rating in Enum.GetValues(typeof(MovieRatings)))
                {
                    if (rating == Rated)
                    {
                        realRating = true;
                        break;
                    }
                }
                if (!realRating)
                    lst.Add($"Invalid {nameof(Rated)}");
            }


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
                   BifSize == other.BifSize &&
                   VideoUrl == other.VideoUrl &&
                   VideoSize == other.VideoSize &&
                   EqualityComparer<List<ExternalSubtitle>>.Default.Equals(ExternalSubtitles, other.ExternalSubtitles);
        }

        public override int GetHashCode()
        {
            int hashCode = 874782302;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(BifUrl);
            hashCode = hashCode * -1521134295 + BifSize.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(VideoUrl);
            hashCode = hashCode * -1521134295 + VideoUrl.GetHashCode();
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
