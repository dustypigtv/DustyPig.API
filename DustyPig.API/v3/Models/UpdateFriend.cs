using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class UpdateFriend : IValidate
    {
        [JsonRequired]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonRequired]
        [JsonProperty("accepted")]
        public bool Accepted { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }


        public void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(Id), Id, lst);

            var (Valid, Fixed, Error) = Validators.Validate(nameof(DisplayName), DisplayName, false, Constants.MAX_NAME_LENGTH);
            if (Valid)
                DisplayName = Fixed;
            else
                lst.Add(Error);

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
