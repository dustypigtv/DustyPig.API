using DustyPig.API.v3.Models;
using DustyPig.REST;
using System;
using System.Collections.Generic;
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
    /// Requires profile. The avatar data must be less than 1 MB. This will update the profiles AvatarUrl
    /// </summary>
    public Task<Response<string>> SetProfileAvatarAsync(int id, byte[] avatar, CancellationToken cancellationToken = default)
    {
        const int MAX_LENGTH = 1024 * 1024;

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

        var request = new HttpRequestMessage(HttpMethod.Put, new Uri(_client.BaseAddress, PREFIX + $"SetProfileAvatarBinary/{id}"));
        foreach (var header in _client.GetHeaders(true))
            request.Headers.TryAddWithoutValidation(header.Key, header.Value);
        request.Content = new ByteArrayContent(avatar);
        request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

        return _client.GetResponseAsync<string>(request, cancellationToken);
    }
}
