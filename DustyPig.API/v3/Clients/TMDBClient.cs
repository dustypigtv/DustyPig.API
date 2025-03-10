﻿using DustyPig.API.v3.Models;
using DustyPig.REST;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.API.v3.Clients;

public class TMDBClient
{
    private const string PREFIX = "TMDB/";

    private readonly Client _client;

    internal TMDBClient(Client client) => _client = client;


    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response<DetailedTMDB>> GetMovieAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return Task.FromResult(new Response<DetailedTMDB> { Error = new ModelValidationException($"Invalid {nameof(id)}") });

        return _client.GetAsync<DetailedTMDB>(true, PREFIX + $"GetMovie/{id}", cancellationToken);
    }


    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response<DetailedTMDB>> GetSeriesAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return Task.FromResult(new Response<DetailedTMDB> { Error = new ModelValidationException($"Invalid {nameof(id)}") });

        return _client.GetAsync<DetailedTMDB>(true, PREFIX + $"GetSeries/{id}", cancellationToken);
    }

    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response<TMDB_Person>> GetPersonAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return Task.FromResult(new Response<TMDB_Person> { Error = new ModelValidationException($"Invalid {nameof(id)}") });

        return _client.GetAsync<TMDB_Person>(true, PREFIX + $"GetPerson/{id}", cancellationToken);
    }

    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response<TitleRequestPermissions?>> GetRequestTitlePermissionAsync(CancellationToken cancellationToken = default) =>
        _client.GetAsync<TitleRequestPermissions?>(true, PREFIX + "GetRequestTitlePermission", cancellationToken);


    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response> RequestTitleAsync(TitleRequest data, CancellationToken cancellationToken = default) =>
        _client.PostAsync(true, PREFIX + "RequestTitle", data, cancellationToken);


    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response> CancelRequestAsync(TitleRequest data, CancellationToken cancellationToken = default) =>
        _client.PostAsync(true, PREFIX + "CancelTitleRequest", data, cancellationToken);


    /// <summary>
    /// Requires main profile
    /// </summary>
    public Task<Response> DenyRequestAsync(TitleRequest data, CancellationToken cancellationToken = default) =>
        _client.PostAsync(true, PREFIX + "DenyTitleRequest", data, cancellationToken);


    /// <summary>
    /// Requires main profile
    /// </summary>
    public Task<Response> GrantRequestAsync(TitleRequest data, CancellationToken cancellationToken = default) =>
        _client.PostAsync(true, PREFIX + "GrantTitleRequest", data, cancellationToken);




    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response<List<TitleRequestSource>>> ListTitleRequestSourcesAsync(CancellationToken cancellationToken = default) =>
        _client.GetAsync<List<TitleRequestSource>>(true, PREFIX + "ListTitleRequestSources", cancellationToken);
}
