using DustyPig.API.v3.Interfaces;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models;

public class UpdateProfile : CreateProfile, IValidate
{
    public int Id { get; set; }


    /// <summary>
    /// If the Pin is set, it will update. However, since the Pin can be null, if Pin = null, then the server will only clear the Pin if this field is true
    /// </summary>
    public bool ClearPin { get; set; }


    #region IValidate

    public new void Validate()
    {
        var lst = new List<string>();

        Validators.ValidateId(nameof(Id), Id, lst);

        try { base.Validate(); }
        catch (ModelValidationException ex) { lst.AddRange(ex.Errors); }

        if (lst.Count > 0)
            throw new ModelValidationException { Errors = lst };
    }

    #endregion



    public override string ToString() => base.ToString();

}