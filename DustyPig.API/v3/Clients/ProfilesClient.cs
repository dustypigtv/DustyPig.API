using DustyPig.API.v3.Models;
using DustyPig.REST;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
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
    public Task<Response<DetailedProfile>> GetMainProfileDetailsAsync(CancellationToken cancellationToken = default) =>
        _client.GetAsync<DetailedProfile>(true, PREFIX + "GetMainProfileDetails", cancellationToken);





    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response<PresignedUploadUrl>> GetAvatarUploadUrlAsync(int profileId, FileInfo avatarFile, CancellationToken cancellationToken = default)
    {
        var data = new AvatarUploadInfo
        {
            ProfileId = profileId,
            ContentType = Utils.AvatarUploadContentType(avatarFile.Extension),
            Size = avatarFile.Length
        };
        return _client.PostAsync<PresignedUploadUrl>(true, PREFIX + "GetAvatarUploadUrl", data, cancellationToken);
    }


    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response<PresignedUploadUrl>> GetCroppedAvatarUploadUrlAsync(int profileId, FileInfo avatarFile, CancellationToken cancellationToken = default)
    {
        var data = new AvatarUploadInfo
        {
            ProfileId = profileId,
            ContentType = Utils.AvatarUploadContentType("jpg"),
            Size = avatarFile.Length
        };
        return _client.PostAsync<PresignedUploadUrl>(true, PREFIX + "GetCroppedAvatarUploadUrl", data, cancellationToken);
    }



    /// <summary>
    /// Requires the presigned url from <see cref="GetAvatarUploadUrlAsync"/> or <see cref="GetCroppedAvatarUploadUrlAsync"/>
    /// </summary>
    public async Task<Response> UploadAvatarAsync(FileInfo avatarFile, string uploadUrl, CancellationToken cancellationToken = default)
    {
        string rawContent = null;
        string reasonPhrase = null;
        System.Net.HttpStatusCode statusCode = System.Net.HttpStatusCode.BadRequest;
        try
        {
            string contentType = Utils.AvatarUploadContentType(avatarFile.Extension);
            using var fileStream = avatarFile.OpenRead();
            using var content = new StreamContent(fileStream);
            content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            content.Headers.ContentLength = avatarFile.Length;
            using var request = new HttpRequestMessage(HttpMethod.Put, uploadUrl) { Content = content };
            request.Headers.Add("Cache-Control", Constants.DEFAULT_IMAGE_CACHE_CONTROL);
            var response = await _client.HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
            
            statusCode = response.StatusCode;
            reasonPhrase = response.ReasonPhrase;
            try
            {
                if (_client.IncludeRawContentInResponse)
                    rawContent = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
            }
            catch { }
            response.EnsureSuccessStatusCode();

            return new Response
            {
                Success = true,
                StatusCode = statusCode,
                ReasonPhrase = reasonPhrase,
                RawContent = rawContent
            };
        }
        catch (Exception ex)
        {
            return new Response
            {
                Error = ex,
                RawContent = rawContent,
                ReasonPhrase = reasonPhrase,
                StatusCode = statusCode,
                Success = false
            };
        }
    }


    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response<string>> ResetAvatarAsync(int id, CancellationToken cancellationToken = default) =>
        _client.GetAsync<string>(true, PREFIX + $"ResetAvatar/{id}", cancellationToken);



    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response> UpdateAvatarInfoAsync(UpdateAvatarInfo data, CancellationToken cancellationToken = default) =>
        _client.PostAsync(true, PREFIX + "UpdateAvatarInfo", data, cancellationToken);

}
