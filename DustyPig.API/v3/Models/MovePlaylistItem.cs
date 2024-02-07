using DustyPig.API.v3.Interfaces;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class MovePlaylistItem : IValidate
    {
        /// <summary>
        /// Playlist Item Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// New Index
        /// </summary>
        public int NewIndex { get; set; }


        #region IValidate

        public void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(Id), Id, lst);

            if (NewIndex < 0)
                lst.Add($"Invalid {nameof(NewIndex)}");

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

        #endregion
    }
}
