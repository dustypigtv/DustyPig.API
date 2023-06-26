using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class SetPlaylistProgress : IValidate
    {
        [JsonRequired]
        [JsonProperty("playlist_id")]
        public int PlaylistId { get; set; }

        [JsonRequired]
        [JsonProperty("new_index")]
        public int NewIndex { get; set; }

        [JsonRequired]
        [JsonProperty("new_progress")]
        public double NewProgress { get; set; }

        public void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(PlaylistId), PlaylistId, lst);

            if (NewIndex < 0)
                lst.Add($"Invalid {nameof(NewIndex)}");

            if (NewProgress < 0)
                lst.Add($"Invalid {nameof(NewProgress)}");

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
