using DustyPig.API.v3.Interfaces;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models;

public class SRTSubtitle : IValidate
{
    public string Name { get; set; }

    public string Url { get; set; }

    #region IValidate

    public void Validate()
    {
        var lst = new List<string>();

        var chk = Validators.Validate(nameof(Name), Name, true, Constants.MAX_NAME_LENGTH);
        if (chk.Valid)
            Name = chk.Fixed;
        else
            lst.Add(chk.Error);

        chk = Validators.Validate(nameof(Url), Url, true, Constants.MAX_URL_LENGTH);
        if (chk.Valid)
            Url = chk.Fixed;
        else
            lst.Add(chk.Error);

        if (lst.Count > 0)
            throw new ModelValidationException { Errors = lst };

    }

    #endregion

    public override string ToString() => Name;
}
