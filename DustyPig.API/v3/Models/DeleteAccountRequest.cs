using DustyPig.API.v3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DustyPig.API.v3.Models;

public class DeleteAccountRequest : IValidate
{
    public string Email { get; set; }

    public string Password { get; set; }


    #region IValidate

    public void Validate()
    {
        var lst = new List<string>();

        var chk = Validators.Validate(nameof(Email), Email, true, int.MaxValue);
        if (chk.Valid)
        {
            Email = chk.Fixed.ToLower();
            if (!StringUtils.IsValidEmail(Email))
                lst.Add($"Invalid {nameof(Email)}");
        }
        else
        {
            lst.Add(chk.Error);
        }


        chk = Validators.Validate(nameof(Password), Password, true, int.MaxValue);
        if (chk.Valid)
            Password = chk.Fixed;
        else
            lst.Add(chk.Error);

        if (Email == Clients.AuthClient.TEST_EMAIL)
            lst.Add("Test email is not valid for this action");


        if (lst.Count > 0)
            throw new ModelValidationException { Errors = lst };
    }

    #endregion
}
