using DustyPig.API.v3.Interfaces;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models;

public class AvatarUploadInfo : IValidate
{
    private const int MAX_SIZE = 1024 * 1024 * 10;

    public string ContentType { get; set; }

    public long Size { get; set; }

    public void Validate()
    {
        var lst = new List<string>();

        if (string.IsNullOrWhiteSpace(ContentType))
            lst.Add("File must be one of: " + string.Join(", ", Constants.VALID_AVATAR_EXTENSIONS));

        if (Size > MAX_SIZE)
            lst.Add("File size must be <= than 10 MB (10,485,760 bytes)");

        if (lst.Count > 0)
            throw new ModelValidationException { Errors = lst };
    }
}
