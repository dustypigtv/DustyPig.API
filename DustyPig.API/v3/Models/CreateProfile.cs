using DustyPig.API.v3.Interfaces;
using DustyPig.API.v3.MPAA;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateProfile : IValidate
    {
        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonRequired]
        [JsonProperty("allowed_ratings")]
        public Ratings AllowedRatings { get; set; }

        [JsonProperty("pin")]
        public short? Pin { get; set; }

        [JsonRequired]
        [JsonProperty("title_request_permissions")]
        public TitleRequestPermissions TitleRequestPermissions { get; set; }

        [JsonRequired]
        [JsonProperty("locked")]
        public bool Locked { get; set; }

        /// <summary>
        /// Whether to send weekly updates of all new content
        /// </summary>
        [JsonRequired]
        [JsonProperty("weekly_summary")]
        public bool WeeklySummary { get; set; }

        [JsonRequired]
        [JsonProperty("notification_methods")]
        public NotificationMethods NotificationMethods { get; set; }


        public void Validate()
        {
            var lst = new List<string>();

            var chk = Validators.Validate(nameof(Name), Name, true, Constants.MAX_NAME_LENGTH);
            if (chk.Valid)
                Name = chk.Fixed;
            else
                lst.Add(chk.Error);

            chk = Validators.Validate(nameof(AvatarUrl), AvatarUrl, false, Constants.MAX_NAME_LENGTH);
            if (chk.Valid)
                AvatarUrl = chk.Fixed;
            else
                lst.Add(chk.Error);

            if (Pin != null && (Pin < 1000 || Pin > 9999))
                lst.Add($"{nameof(Pin)} must be between 1000 and 9999");


            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

        public override string ToString() => Name;
    }
}
