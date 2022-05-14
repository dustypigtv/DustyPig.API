using DustyPig.API.v3.Models;
using DustyPig.API.v3.MPAA;
using DustyPig.REST;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.API.v3.Clients
{
    public class MediaClient
    {
        public const long ID_CONTINUE_WATCHING = -500;
        public const long ID_WATCHLIST = -400;
        public const long ID_PLAYLISTS = -300;


        private const string PREFIX = "Media/";

        private readonly Client _client;

        internal MediaClient(Client client) => _client = client;

        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response<HomeScreen>> GetHomeScreenAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync<HomeScreen>(true, PREFIX + "HomeScreen", cancellationToken);


        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response<List<BasicMedia>>> ListGenreItemsAsync(GenreListRequest data, CancellationToken cancellationToken = default) =>
            _client.PostAsync<List<BasicMedia>>(true, PREFIX + "ListGenreItems", data, cancellationToken);

        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response<List<BasicMedia>>> ListGenreItemsAsync(Genres genre, int start = 0, CancellationToken cancellationToken = default) =>
            ListGenreItemsAsync(new GenreListRequest
            {
                Genre = genre,
                Start = start,
            }, cancellationToken);


        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response<List<BasicMedia>>> ListLibraryItemsAsync(LibraryListRequest data, CancellationToken cancellationToken = default) =>
            _client.PostAsync<List<BasicMedia>>(true, PREFIX + "ListLibraryItems", data, cancellationToken);

        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response<List<BasicMedia>>> ListLibraryItemsAsync(int libraryId, int start = 0, SortOrder sortOrder = SortOrder.Alphabetical, CancellationToken cancellationToken = default) =>
            ListLibraryItemsAsync(new LibraryListRequest
            {
                LibraryId = libraryId,
                Start = start,
                Sort = sortOrder
            }, cancellationToken);


        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response<List<BasicMedia>>> LoadMoreHomeScreenItemsAsync(IDListRequest data, CancellationToken cancellationToken = default) =>
            _client.PostAsync<List<BasicMedia>>(true, PREFIX + "LoadMoreHomeScreenItems", data, cancellationToken);

        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response<List<BasicMedia>>> LoadMoreHomeScreenItemsAsync(long listId, int start = 0, CancellationToken cancellationToken = default) =>
            LoadMoreHomeScreenItemsAsync(new IDListRequest
            {
                ListId = listId,
                Start = start
            }, cancellationToken);


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
    }
}
