using DustyPig.API.v3.Interfaces;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models;

public class UpdateFriend : IValidate
{
    public int Id { get; set; }

    public bool Accepted { get; set; }

    public string DisplayName { get; set; }

    #region IValidate

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

    #endregion

    public override string ToString() => DisplayName;
}
