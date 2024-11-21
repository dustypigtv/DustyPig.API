using DustyPig.API.v3.Interfaces;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models;

public class ChangeEmailAddressRequest : IValidate
{
    public string EmailAddress { get; set; }

    public string Password { get; set; }

    public string NewEmailAddress { get; set; }

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


        Validators.ValidatePassword(nameof(Password), Password, lst);



        chk = Validators.Validate(nameof(NewEmailAddress), NewEmailAddress, true, int.MaxValue);
        if (chk.Valid)
        {
            NewEmailAddress = chk.Fixed.ToLower();
            if (!StringUtils.IsValidEmail(NewEmailAddress))
                lst.Add($"Invalid {nameof(NewEmailAddress)}");
        }
        else
        {
            lst.Add(chk.Error);
        }

        if (NewEmailAddress == Clients.AuthClient.TEST_EMAIL)
            lst.Add("Test email is not valid for this action");


        if (lst.Count > 0)
            throw new ModelValidationException { Errors = lst };
    }

    #endregion
}
