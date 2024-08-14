using DustyPig.API.v3.Interfaces;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models;

public class HomeScreenListRequest : IValidate
{
    public long ListId { get; set; }

    public int Start { get; set; }

    public bool IncludeDescription { get; set; }


    #region IValidate

    public void Validate()
    {
        var lst = new List<string>();

        if (Start < 0)
            lst.Add($"Invalid {nameof(Start)}");

        if (lst.Count > 0)
            throw new ModelValidationException { Errors = lst };
    }

    #endregion
}
