using DustyPig.API.v3.Interfaces;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models;

public class SRTSubtitle : IValidate
{
    /// <summary>
    /// ISO 639.2B 3 character language code. Example: eng
    /// </summary>
    public string Language { get; set; }

    /// <summary>
    /// Friendly name. Example: English
    /// </summary>
    public string Name { get; set; }

    public string Url { get; set; }

    #region IValidate

    public void Validate()
    {
        var lst = new List<string>();

        if (Language == null || Language.Trim().Length != 3)
            lst.Add(nameof(Language) + " must be an ISO 639.2B 3 character language code";
        else
            Language = Language.Trim().ToLower();

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
