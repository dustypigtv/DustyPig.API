using DustyPig.API.v3.Interfaces;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models;

public class StringValue : IValidate
{
    public string Value { get; set; }

    #region IValidate

    public void Validate()
    {
        var lst = new List<string>();
        var (Valid, Fixed, Error) = Validators.Validate(nameof(Value), Value, true, Constants.MAX_DESCRIPTION_LENGTH);
        if (Valid)
            Value = Fixed;
        else
            lst.Add(Error);

        if (lst.Count > 0)
            throw new ModelValidationException { Errors = lst };
    }

    #endregion
}
