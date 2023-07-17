using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class PlaylistItem : IEquatable<PlaylistItem>
    {
        [JsonProperty("id")]
        [JsonRequired]
        public int Id { get; set; }

        [JsonProperty("index")]
        [JsonRequired]
        public int Index { get; set; }

        [JsonProperty("media_id")]
        [JsonRequired]
        public int MediaId { get; set; }


        [JsonProperty("series_id")]
        public int? SeriesId { get; set; }

        [JsonRequired]
        [JsonProperty("media_type")]
        public MediaTypes MediaType { get; set; }

        [JsonRequired]
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonRequired]
        [JsonProperty("artwork_url")]
        public string ArtworkUrl { get; set; }

        [JsonProperty("played")]
        public double? Played { get; set; }

        [JsonProperty("length")]
        public double Length { get; set; }

        [JsonProperty("bif_url")]
        public string BifUrl { get; set; }

        [JsonProperty("video_url")]
        public string VideoUrl { get; set; }

        [JsonProperty("srt_subtitles")]
        public List<ExternalSubtitle> ExternalSubtitles { get; set; }


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as PlaylistItem);
        }

        public bool Equals(PlaylistItem other)
        {
            return !(other is null) &&
                   Id == other.Id &&
                   Index == other.Index &&
                   MediaId == other.MediaId &&
                   SeriesId == other.SeriesId &&
                   MediaType == other.MediaType &&
                   Title == other.Title &&
                   Description == other.Description &&
                   ArtworkUrl == other.ArtworkUrl &&
                   Played == other.Played &&
                   Length == other.Length &&
                   BifUrl == other.BifUrl &&
                   VideoUrl == other.VideoUrl &&
                   EqualityComparer<List<ExternalSubtitle>>.Default.Equals(ExternalSubtitles, other.ExternalSubtitles);
        }

        public override int GetHashCode()
        {
            int hashCode = -1867576467;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + Index.GetHashCode();
            hashCode = hashCode * -1521134295 + MediaId.GetHashCode();
            hashCode = hashCode * -1521134295 + SeriesId.GetHashCode();
            hashCode = hashCode * -1521134295 + MediaType.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ArtworkUrl);
            hashCode = hashCode * -1521134295 + Played.GetHashCode();
            hashCode = hashCode * -1521134295 + Length.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(BifUrl);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(VideoUrl);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<ExternalSubtitle>>.Default.GetHashCode(ExternalSubtitles);
            return hashCode;
        }

        public static bool operator ==(PlaylistItem left, PlaylistItem right)
        {
            return EqualityComparer<PlaylistItem>.Default.Equals(left, right);
        }

        public static bool operator !=(PlaylistItem left, PlaylistItem right)
        {
            return !(left == right);
        }

        #endregion
    }
}
