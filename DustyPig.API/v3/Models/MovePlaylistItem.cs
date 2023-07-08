using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class MovePlaylistItem : IValidate
    {
        /// <summary>
        /// Playlist Item Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// New Index
        /// </summary>
        [JsonRequired]
        [JsonProperty("new_index")]
        public int NewIndex { get; set; }

        public void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(Id), Id, lst);

            if (NewIndex < 0)
                lst.Add($"Invalid {nameof(NewIndex)}");

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
