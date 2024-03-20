using DustyPig.API.v3.Interfaces;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.Models;

public class CreateLibrary : IValidate
{
    public string Name { get; set; }

    [JsonPropertyName("isTV")]
    public bool IsTV { get; set; }


    #region IValidate

    public void Validate()
    {
        var lst = new List<string>();

        var (Valid, Fixed, Error) = Validators.Validate(nameof(Name), Name, true, Constants.MAX_NAME_LENGTH);
        if (Valid)
            Name = Fixed;
        else
            lst.Add(Error);

        if (lst.Count > 0)
            throw new ModelValidationException { Errors = lst };
    }

    #endregion


    public override string ToString() => Name;
}
