using DustyPig.API.v3.Models;
using DustyPig.REST;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.API.v3.Clients;

public class EpisodesClient
{
    private const string PREFIX = "Episodes/";

    private readonly Client _client;

    internal EpisodesClient(Client client) => _client = client;

    /// <summary>
    /// Requires main profile
    /// </summary>
    public Task<Response<int?>> CreateAsync(CreateEpisode data, CancellationToken cancellationToken = default) =>
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
    public Task<Response<DetailedEpisodeEx>> GetDetailsAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return Task.FromResult(new Response<DetailedEpisodeEx> { Error = new ModelValidationException($"Invalid {nameof(id)}") });

        return _client.GetAsync<DetailedEpisodeEx>(true, PREFIX + $"Details/{id}", cancellationToken);
    }



    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response> MarkWatchedAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return Task.FromResult(new Response { Error = new ModelValidationException($"Invalid {nameof(id)}") });

        return _client.GetAsync(true, PREFIX + $"MarkWatched/{id}", cancellationToken);
    }



    /// <summary>
    /// Requires main profile
    /// </summary>
    public Task<Response> UpdateAsync(UpdateEpisode data, CancellationToken cancellationToken = default) =>
        _client.PostAsync(true, PREFIX + "Update", data, cancellationToken);



    /// <summary>
    /// Requires main profile. Designed for admin tools, this will return info on any episode owned by the account with the specified tvdb id
    /// </summary>
    public Task<Response<List<DetailedEpisode>>> AdminSearchByTvdbIdAsync(int tvdbId, int libraryId = 0, CancellationToken cancellationToken = default)
    {
        if (tvdbId <= 0)
            return Task.FromResult(new Response<List<DetailedEpisode>> { Error = new ModelValidationException($"Invalid {nameof(tvdbId)}") });

        return _client.GetAsync<List<DetailedEpisode>>(true, PREFIX + $"AdminSearchByTvdbId?libraryId={libraryId}&tvdbId={tvdbId}", cancellationToken);
    }


    /// <summary>
    /// Requires main profile. Designed for admin tools, this will return info on any episode owned by the account with the specified imdb id
    /// </summary>
    public Task<Response<List<DetailedEpisode>>> AdminSearchByImdbIdAsync(string imdbId, int libraryId = 0, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(imdbId))
            return Task.FromResult(new Response<List<DetailedEpisode>> { Error = new ModelValidationException($"Invalid {nameof(imdbId)}") });

        return _client.GetAsync<List<DetailedEpisode>>(true, PREFIX + $"AdminSearchByImdbId?libraryId={libraryId}&imdbId={imdbId}", cancellationToken);
    }
}
