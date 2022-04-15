using DustyPig.API.v3.Interfaces;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class AddPlaylistItem : IValidate
    {
        public int PlaylistId { get; set; }

        public int MediaId { get; set; }

        public void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(PlaylistId), PlaylistId, lst);
            Validators.ValidateId(nameof(MediaId), MediaId, lst);

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
