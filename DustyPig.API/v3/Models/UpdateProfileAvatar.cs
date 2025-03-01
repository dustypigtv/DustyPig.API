using DustyPig.API.v3.Interfaces;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models;

public class UpdateProfileAvatar : IValidate
{
    public int Id { get; set; }

    public string Base64Image { get; set; }

    public void Validate()
    {
        var lst = new List<string>();

        Validators.ValidateId(nameof(Id), Id, lst);

        if(string.IsNullOrWhiteSpace(Base64Image))
            lst.Add($"{nameof(Base64Image)} cannot be null");

        if (lst.Count > 0)
            throw new ModelValidationException { Errors = lst };
    }
}
