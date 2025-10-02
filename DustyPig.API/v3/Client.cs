using DustyPig.API.v3.Clients;
using DustyPig.API.v3.Interfaces;
using DustyPig.API.v3.Models;
using DustyPig.REST;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.API.v3;

public class Client
{
    public const string DEFAULT_BASE_ADDRESS = "https://service.dustypig.tv/api/v3/";

    private static readonly HttpClient _internalHttpClient = new();
    private readonly REST.Client _client;
    private readonly ILogger<Client> _logger;

    
    public Client(HttpClient httpClient = null, ILogger<Client> logger = null)
    {
        _logger = logger;
        _client = new(httpClient ?? _internalHttpClient, logger) { BaseAddress = new Uri(DEFAULT_BASE_ADDRESS) };
    }



        

    public static Version APIVersion => typeof(Client).Assembly.GetName().Version;

    public bool IncludeRawContentInResponse
    {
        get => _client.IncludeRawContentInResponse;
        set => _client.IncludeRawContentInResponse = value;
    }

    public bool AutoThrowIfError { get; set; }


    public Uri BaseAddress
    {
        get => _client.BaseAddress;
        set => _client.BaseAddress = value;
    }



    public string Token { get; set; }

    public AccountClient Account => new(this);

    public AuthClient Auth => new(this);

    public EpisodesClient Episodes => new(this);

    public FriendsClient Friends => new(this);

    public LibrariesClient Libraries => new(this);

    public MediaClient Media => new(this);

    public MoviesClient Movies => new(this);

    public NotificationsClient Notifications => new(this);

    public NoOpClient NoOp => new(this);

    public PlaylistClient Playlists => new(this);

    public ProfilesClient Profiles => new(this);

    public SeriesClient Series => new(this);

    public TMDBClient TMDB => new(this);







    internal Dictionary<string, string> GetHeaders(bool tokenNeeded)
    {
        var ret = new Dictionary<string, string>();
        if (tokenNeeded && !string.IsNullOrWhiteSpace(Token))
            ret.Add("Authorization", "Bearer " + Token);
        return ret;
    }





    private Response FlattenResult(Response<Result> response)
    {
        if (response.Success)
        {
            var ret1 = new Response
            {
                Error = response.Data.Success ? null : new(response.Data.Error),
                RawContent = response.RawContent,
                ReasonPhrase = response.ReasonPhrase,
                StatusCode = response.StatusCode,
                Success = response.Data.Success
            };

            if (AutoThrowIfError)
                ret1.ThrowIfError();
            return ret1;
        }
        else
        {
            var ret2 = new Response
            {
                Error = response.Error,
                RawContent = response.RawContent,
                ReasonPhrase = response.ReasonPhrase,
                StatusCode = response.StatusCode
            };

            if (AutoThrowIfError)
                ret2.ThrowIfError();
            return ret2;
        }
    }

    private Response<T> FlattenResult<T>(Response<Result<T>> response)
    {
        if (response.Success)
        {
            var ret1 = new Response<T>
            {
                Data = response.Data.Data,
                Error = response.Data.Success ? null : new(response.Data.Error),
                RawContent = response.RawContent,
                ReasonPhrase = response.ReasonPhrase,
                StatusCode = response.StatusCode,
                Success = response.Data.Success
            };

            if (AutoThrowIfError)
                ret1.ThrowIfError();
            return ret1;
        }
        else
        {
            var ret2 = new Response<T>
            {
                Error = response.Error,
                RawContent = response.RawContent,
                ReasonPhrase = response.ReasonPhrase,
                StatusCode = response.StatusCode
            };

            if (AutoThrowIfError)
                ret2.ThrowIfError();
            return ret2;
        }
    }





    internal async Task<Response> GetAsync(bool tokenNeeded, string url, CancellationToken cancellationToken)
    {
        var ret = await _client.GetAsync<Result>(url, GetHeaders(tokenNeeded), cancellationToken).ConfigureAwait(false);
        return FlattenResult(ret);
    }

    internal async Task<Response<T>> GetAsync<T>(bool tokenNeeded, string url, CancellationToken cancellationToken)
    {
        var ret = await _client.GetAsync<Result<T>>(url, GetHeaders(tokenNeeded), cancellationToken).ConfigureAwait(false);
        return FlattenResult(ret);
    }



    internal async Task<Response> PostAsync(bool tokenNeeded, string url, object data, CancellationToken cancellationToken)
    {
        if (data is IValidate iv)
            try 
            {
                iv.Validate(); 
            }
            catch (ModelValidationException ex)
            {
                _logger?.LogError(ex, nameof(PostAsync));

                if (AutoThrowIfError)
                    throw;
                return new()
                {
                    Error = ex,
                    ReasonPhrase = ex.Message,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

        var ret = await _client.PostAsync<Result>(url, data, GetHeaders(tokenNeeded), cancellationToken).ConfigureAwait(false);
        return FlattenResult(ret);
    }

    internal async Task<Response<T>> PostAsync<T>(bool tokenNeeded, string url, object data, CancellationToken cancellationToken)
    {
        if (data is IValidate iv)
            try 
            {
                iv.Validate(); 
            }
            catch (ModelValidationException ex)
            {
                _logger?.LogError(ex, nameof(PostAsync));

                if (AutoThrowIfError)
                    throw;
                return new()
                {
                    Error = ex,
                    ReasonPhrase = ex.Message,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

        var ret = await _client.PostAsync<Result<T>>(url, data, GetHeaders(tokenNeeded), cancellationToken).ConfigureAwait(false);
        return FlattenResult(ret);
    }




    internal async Task<Response> DeleteAsync(bool tokenNeeded, string url, CancellationToken cancellationToken)
    {
        var ret = await _client.DeleteAsync<Result>(url, GetHeaders(tokenNeeded), cancellationToken: cancellationToken).ConfigureAwait(false);
        return FlattenResult(ret);
    }


    internal async Task<Response> DeleteAsync(bool tokenNeeded, string url, object data, CancellationToken cancellationToken)
    {
        var ret = await _client.DeleteAsync<Result>(url, GetHeaders(tokenNeeded), data, cancellationToken: cancellationToken).ConfigureAwait(false);
        return FlattenResult(ret);
    }





    internal async Task<Response<T>> GetResponseAsync<T>(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var ret = await _client.GetResponseAsync<Result<T>>(request, cancellationToken).ConfigureAwait(false);
        return FlattenResult(ret);
    }

}