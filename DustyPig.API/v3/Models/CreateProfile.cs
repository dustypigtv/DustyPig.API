using DustyPig.API.v3.BaseClasses;
using DustyPig.API.v3.Interfaces;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models;

public class CreateProfile : BaseProfile, IValidate
{
    public ushort? Pin { get; set; }

    /// <summary>
    /// If not null, this will set or the libraries the profile has access to
    /// </summary>
    public List<int> LibraryIds { get; set; }

    #region IValidate

    public new void Validate()
    {
        var lst = new List<string>();

        try { base.Validate(); }
        catch (ModelValidationException ex) { lst.AddRange(ex.Errors); }

        if (Pin != null && (Pin < 1000 || Pin > 9999))
            lst.Add($"{nameof(Pin)} must be between 1000 and 9999");

        if (LibraryIds != null)
            foreach (var id in LibraryIds)
                Validators.ValidateId("LibraryId", id, lst);

        if (lst.Count > 0)
            throw new ModelValidationException { Errors = lst };
    }

    #endregion

    public override string ToString() => Name;
}