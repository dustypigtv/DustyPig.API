using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class UpdatePlaylist : BasicPlaylist
    {
        public new void Validate()
        {
            var lst = new List<string>();

            if (Id <= 0)
                lst.Add("Invalid Id");

            try { base.Validate(); }
            catch (ModelValidationException ex) { lst.AddRange(ex.Errors); }

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };

        }
    }
}
