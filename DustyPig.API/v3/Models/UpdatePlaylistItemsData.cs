using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class UpdatePlaylistItemsData : IValidate
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// New list of media ids, in the order desired
        /// </summary>
        [JsonProperty("media_ids")]
        [JsonRequired]
        public List<int> MediaIds { get; set; } = new List<int>();

        public void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(Id), Id, lst);

            if (MediaIds == null || MediaIds.Count == 0)
                lst.Add($"{nameof(MediaIds)} cannot be empty");

            if(lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
