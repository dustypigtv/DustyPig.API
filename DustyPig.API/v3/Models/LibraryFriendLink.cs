using DustyPig.API.v3.Interfaces;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models;

public class LibraryFriendLink : IValidate
{
    public int LibraryId { get; set; }

    public int FriendId { get; set; }


    #region IValidate

    public void Validate()
    {
        var lst = new List<string>();

        Validators.ValidateId(nameof(LibraryId), LibraryId, lst);
        Validators.ValidateId(nameof(FriendId), FriendId, lst);

        if (lst.Count > 0)
            throw new ModelValidationException { Errors = lst };
    }

    #endregion
}
