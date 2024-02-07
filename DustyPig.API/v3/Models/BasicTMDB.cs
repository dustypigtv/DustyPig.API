﻿using System.Text.Json.Serialization;

namespace DustyPig.API.v3.Models
{
    public class BasicTMDB
    {
        [JsonPropertyName("tmdb_Id")]
        public int TMDB_ID { get; set; }

        public TMDB_MediaTypes MediaType { get; set; }

        public string ArtworkUrl { get; set; }

        public string BackdropUrl { get; set; }

        public string Title { get; set; }

        public override string ToString() => Title;
    }
}
