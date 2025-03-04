using DustyPig.API.v3.Interfaces;
using DustyPig.REST;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DustyPig.API.v3.Models;

public class UpdateProfileAvatar : IValidate
{
    public int Id { get; set; }

    /// <summary>
    /// This must be less than 5MB
    /// </summary>
    public string Base64Image { get; set; }

    public void Validate()
    {
        var lst = new List<string>();

        Validators.ValidateId(nameof(Id), Id, lst);

        const int MAX_LENGTH = 1024 * 1024 * 5;

        if (string.IsNullOrWhiteSpace(Base64Image))
            lst.Add($"{nameof(Base64Image)} cannot be null");

        if (Base64Image.Length > MAX_LENGTH)
            lst.Add($"Validation failed: {nameof(Base64Image)} must not exceed {MAX_LENGTH} bytes");

        if (!IsPngOrJpg(Convert.FromBase64String(Base64Image)))
            lst.Add($"{nameof(Base64Image)} does not appear to be either png or jpg");

        if (lst.Count > 0)
            throw new ModelValidationException { Errors = lst };
    }

    static bool IsPngOrJpg(byte[] data) => IsPng(data) || IsJpeg(data);

    public static bool IsJpeg(byte[] data)
    {
        const int MIN_JPG_LENGTH = 107;

        return
            data.Length >= MIN_JPG_LENGTH &&
            data[0] == 0xFF &&
            data[1] == 0xD8;
    }


    public static bool IsPng(byte[] data)
    {
        const int MIN_PNG_LENGTH = 67;

        return
            data.Length >= MIN_PNG_LENGTH &&
            data[0] == 0x89 &&
            data[1] == 0x50 &&
            data[2] == 0x4E &&
            data[3] == 0x47 &&
            data[4] == 0x0D &&
            data[5] == 0x0A &&
            data[6] == 0x1A &&
            data[7] == 0x0A;
    }

}
