using DustyPig.API.v3.Models;
using DustyPig.REST;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.API.v3.Clients;

public class ProfilesClient
{
    private const string PREFIX = "Profiles/";

    private readonly Client _client;

    internal ProfilesClient(Client client) => _client = client;

    /// <summary>
    /// Requires main profile
    /// </summary>
    public Task<Response<int?>> CreateAsync(CreateProfile data, CancellationToken cancellationToken = default) =>
        _client.PostAsync<int?>(true, PREFIX + "Create", data, cancellationToken);


    /// <summary>
    /// Requires main profile
    /// </summary>
    public Task<Response> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return Task.FromResult(new Response { Error = new ModelValidationException($"Invalid {nameof(id)}") });

        return _client.DeleteAsync(true, PREFIX + $"Delete/{id}", cancellationToken);
    }


    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response<DetailedProfile>> GetDetailsAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return Task.FromResult(new Response<DetailedProfile> { Error = new ModelValidationException($"Invalid {nameof(id)}") });

        return _client.GetAsync<DetailedProfile>(true, PREFIX + $"Details/{id}", cancellationToken);
    }


    /// <summary>
    /// Requires main profile
    /// </summary>
    public Task<Response> LinkToLibraryAsync(ProfileLibraryLink data, CancellationToken cancellationToken = default) =>
        _client.PostAsync(true, PREFIX + "LinkToLibrary", data, cancellationToken);

    /// <summary>
    /// Requires main profile
    /// </summary>
    public Task<Response> LinkToLibraryAsync(int profileId, int libraryId, CancellationToken cancellationToken = default) =>
        LinkToLibraryAsync(new ProfileLibraryLink
        {
            ProfileId = profileId,
            LibraryId = libraryId
        }, cancellationToken);


    /// <summary>
    /// Requires main profile
    /// </summary>
    public Task<Response> UnlinkFromLibraryAsync(ProfileLibraryLink data, CancellationToken cancellationToken = default) =>
        _client.PostAsync(true, PREFIX + "UnLinkFromLibrary", data, cancellationToken);

    /// <summary>
    /// Requires main profile
    /// </summary>
    public Task<Response> UnlinkFromLibraryAsync(int profileId, int libraryId, CancellationToken cancellationToken = default) =>
        UnlinkFromLibraryAsync(new ProfileLibraryLink
        {
            LibraryId = libraryId,
            ProfileId = profileId
        }, cancellationToken);


    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response> UpdateAsync(UpdateProfile data, CancellationToken cancellationToken = default) =>
        _client.PostAsync(true, PREFIX + "Update", data, cancellationToken);


    /// <summary>
    /// Requires account
    /// </summary>
    public Task<Response<List<BasicProfile>>> ListAsync(CancellationToken cancellationToken = default) =>
        _client.GetAsync<List<BasicProfile>>(true, PREFIX + "List", cancellationToken);


    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response<string>> ResetAvatarAsync(CancellationToken cancellationToken = default) =>
        _client.GetAsync<string>(true, PREFIX + "ResetAvatar", cancellationToken);


    /// <summary>
    /// Requires profile. The avatar data must be less than 5MB. This will update the profiles AvatarUrl
    /// </summary>
    public Task<Response<string>> SetProfileAvatarAsync(int id, byte[] avatar, CancellationToken cancellationToken = default)
    {
        const int MAX_LENGTH = 1024 * 1024 * 5;

        if (avatar != null && avatar.Length == 0)
            avatar = null;
        ArgumentNullException.ThrowIfNull(avatar, nameof(avatar));

        if (avatar.Length > MAX_LENGTH)
        {
            var ex = new ModelValidationException($"Validation failed: {nameof(avatar)} must not exceed {MAX_LENGTH} bytes");

            if (_client.AutoThrowIfError)
                throw ex;

            return Task.FromResult(new Response<string>
            {
                Error = ex,
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                ReasonPhrase = ex.Message
            });
        }

        if (!(IsJpeg(avatar) || IsPng(avatar)))
        {
            var ex = new ModelValidationException($"Validation failed: {nameof(avatar)} must does not appear to be a jpg or png file");

            if (_client.AutoThrowIfError)
                throw ex;

            return Task.FromResult(new Response<string>
            {
                Error = ex,
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                ReasonPhrase = ex.Message
            });
        }

        var data = new UpdateProfileAvatar
        {
            Id = id,
            Base64Image = Convert.ToBase64String(avatar)
        };

        return _client.PostAsync<string>(true, PREFIX + "SetProfileAvatar", data, cancellationToken);
    }

    static bool IsJpeg(byte[] data)
    {
        const int MIN_JPG_LENGTH = 107;

        return
            data.Length >= MIN_JPG_LENGTH &&
            data[0] == 0xFF &&
            data[1] == 0xD8;
    }


    static bool IsPng(byte[] data)
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
