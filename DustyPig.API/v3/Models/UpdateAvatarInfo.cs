using DustyPig.API.v3.Interfaces;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models;

public class UpdateAvatarInfo : IValidate
{
    public int ProfileId { get; set; }

    public string OriginalImage { get; set; }

    public string CroppedImage { get; set; }

    public void Validate()
    {
        var lst = new List<string>();
        Validators.ValidateId(nameof(ProfileId), ProfileId, lst);
        Validators.ValidateUrl(nameof(OriginalImage), OriginalImage, lst);
        Validators.ValidateUrl(nameof(CroppedImage), CroppedImage, lst);
        
        if (lst.Count > 0)
            throw new ModelValidationException { Errors = lst };
    }
}
