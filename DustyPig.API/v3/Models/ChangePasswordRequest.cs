using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DustyPig.API.v3.Interfaces;

namespace DustyPig.API.v3.Models;

public class ChangePasswordRequest : IValidate
{
    public string EmailAddress { get; set; }

    public string Password { get; set; }

    public string NewPassword { get; set; }

    #region IValidate

    public void Validate()
    {
        var lst = new List<string>();

        var chk = Validators.Validate(nameof(EmailAddress), EmailAddress, true, int.MaxValue);
        if (chk.Valid)
        {
            EmailAddress = chk.Fixed.ToLower();
            if (!StringUtils.IsValidEmail(EmailAddress))
                lst.Add($"Invalid {nameof(EmailAddress)}");
        }
        else
        {
            lst.Add(chk.Error);
        }

        if (EmailAddress == Clients.AuthClient.TEST_EMAIL)
            lst.Add("Test email is not valid for this action");

        chk = Validators.Validate(nameof(Password), Password, true, int.MaxValue);
        if (chk.Valid)
            Password = chk.Fixed;
        else
            lst.Add(chk.Error);



        chk = Validators.Validate(nameof(NewPassword), NewPassword, true, int.MaxValue);
        if (chk.Valid)
        {
            NewPassword = chk.Fixed.ToLower();
            if (!StringUtils.IsValidEmail(NewPassword))
                lst.Add($"Invalid {nameof(NewPassword)}");
        }
        else
        {
            lst.Add(chk.Error);
        }


        if (lst.Count > 0)
            throw new ModelValidationException { Errors = lst };
    }

    #endregion
}
