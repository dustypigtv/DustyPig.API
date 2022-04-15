using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class SetPlaylistIndex : IValidate
    {
        [JsonRequired]
        [JsonProperty("playlist_id")]
        public int PlaylistId { get; set; }

        [JsonRequired]
        [JsonProperty("current_index")]
        public int CurrentIndex { get; set; }

        public void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(PlaylistId), PlaylistId, lst);

            if (CurrentIndex < 0)
                lst.Add($"Invalid {nameof(CurrentIndex)}");

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
