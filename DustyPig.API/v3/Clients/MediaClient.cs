using DustyPig.API.v3.Models;
using DustyPig.REST;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.API.v3.Clients;

public class MediaClient
{
    //Reserved list ids
    public const long ID_CONTINUE_WATCHING = -500;
    public const string ID_CONTINUE_WATCHING_TITLE = "Continue Watching";

    public const long ID_WATCHLIST = -400;
    public const string ID_WATCHLIST_TITLE = "Watchlist";

    public const long ID_PLAYLISTS = -300;
    public const string ID_PLAYLISTS_TITLE = "Playlists";

    public const long ID_RECENTLY_ADDED = -200;
    public const string ID_RECENTLY_ADDED_TITLE = "Recently Added";

    public const long ID_POPULAR = -100;
    public const string ID_POPULAR_TITLE = "Popular";

    public static IReadOnlyDictionary<long, string> GetAllHomesScreenSections() => new Dictionary<long, string>
    {
        { ID_CONTINUE_WATCHING, ID_CONTINUE_WATCHING_TITLE },
        { ID_WATCHLIST, ID_WATCHLIST_TITLE },
        { ID_PLAYLISTS, ID_PLAYLISTS_TITLE },
        { ID_RECENTLY_ADDED, ID_RECENTLY_ADDED_TITLE },
        { ID_POPULAR, ID_POPULAR_TITLE }
    };


    private const string PREFIX = "Media/";

    private readonly Client _client;

    internal MediaClient(Client client) => _client = client;

    /// <summary>
    /// Requires profile.
    /// </summary>
    public Task<Response<HomeScreen>> GetHomeScreenAsync(int? itemsPerSection = Constants.SERVER_RESULT_SIZE, CancellationToken cancellationToken = default)
    {
        string url = PREFIX + "HomeScreen";
        if (itemsPerSection.HasValue)
        {
            itemsPerSection = Math.Min(Math.Max(itemsPerSection.Value, 25), 100);
            url += $"?itemsPerSection={itemsPerSection.Value}";
        }
        return _client.GetAsync<HomeScreen>(true, url, cancellationToken);
    }


    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response<List<BasicMedia>>> LoadMoreHomeScreenItemsAsync(HomeScreenListRequest data, CancellationToken cancellationToken = default) =>
        _client.PostAsync<List<BasicMedia>>(true, PREFIX + "LoadMoreHomeScreenItems", data, cancellationToken);

    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response<List<BasicMedia>>> LoadMoreHomeScreenItemsAsync(long listId, int start = 0, CancellationToken cancellationToken = default) =>
        LoadMoreHomeScreenItemsAsync(new HomeScreenListRequest
        {
            ListId = listId,
            Start = start
        }, cancellationToken);


    /// <summary>
    /// Requires profile. Request override access to an existing movie or series
    /// </summary>
    public Task<Response> RequestAccessOverrideAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return Task.FromResult(new Response { Error = new ModelValidationException($"Invalid {nameof(id)}") });

        return _client.GetAsync(true, PREFIX + $"RequestAccessOverride/{id}", cancellationToken);
    }


    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response<SearchResults>> SearchAsync(SearchRequest data, CancellationToken cancellationToken = default) =>
        _client.PostAsync<SearchResults>(true, PREFIX + "Search", data, cancellationToken);


    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response<SearchResults>> SearchAsync(string query, bool searchTMDB, CancellationToken cancellationToken = default) =>
        SearchAsync(new SearchRequest
        {
            Query = query,
            SearchTMDB = searchTMDB
        }, cancellationToken);


    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response> AddToWatchlistAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return Task.FromResult(new Response { Error = new ModelValidationException($"Invalid {nameof(id)}") });

        return _client.GetAsync(true, PREFIX + $"AddToWatchlist/{id}", cancellationToken);
    }


    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response> DeleteFromWatchlistAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return Task.FromResult(new Response { Error = new ModelValidationException($"Invalid {nameof(id)}") });

        return _client.DeleteAsync(true, PREFIX + $"DeleteFromWatchlist/{id}", cancellationToken);
    }


    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response> UpdatePlaybackProgressAsync(PlaybackProgress data, CancellationToken cancellationToken = default) =>
        _client.PostAsync(true, PREFIX + "UpdatePlaybackProgress", data, cancellationToken);

    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response> UpdatePlaybackProgressAsync(int id, double seconds, CancellationToken cancellationToken = default) =>
        UpdatePlaybackProgressAsync(new PlaybackProgress
        {
            Id = id,
            Seconds = seconds
        }, cancellationToken);


    /// <summary>
    /// Requires main profile
    /// </summary>
    public Task<Response<TitlePermissions>> GetTitlePermissionsAsync(int id, CancellationToken cancellation = default) =>
        _client.GetAsync<TitlePermissions>(true, PREFIX + $"GetTitlePermissions/{id}", cancellation);

    /// <summary>
    /// Requires main profile. Set access override for a specific movie or series
    /// </summary>
    public Task<Response> SetTitlePermissionsAsync(SetTitlePermission data, CancellationToken cancellationToken = default) =>
        _client.PostAsync(true, PREFIX + "SetTitlePermissions", data, cancellationToken);

    public Task<Response> SetTitlePermissionsAsync(int mediaId, int profileId, OverrideState overrideState, CancellationToken cancellationToken = default) =>
        SetTitlePermissionsAsync(new SetTitlePermission
        {
            MediaId = mediaId,
            ProfileId = profileId,
            OverrideState = overrideState
        }, cancellationToken);

}
