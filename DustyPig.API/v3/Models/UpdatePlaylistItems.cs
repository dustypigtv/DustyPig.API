using DustyPig.API.v3.Interfaces;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class UpdatePlaylistItems : IValidate
    {
        public int Id { get; set; }

        /// <summary>
        /// New list of media ids, in the order desired
        /// </summary>
        public List<int> MediaIds { get; set; } = [];


        #region IValidate

        public void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(Id), Id, lst);

            if (MediaIds == null || MediaIds.Count == 0)
                lst.Add($"{nameof(MediaIds)} cannot be empty");

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

        #endregion

    }
}
