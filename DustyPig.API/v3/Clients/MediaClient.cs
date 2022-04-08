using DustyPig.API.v3.Models;
using DustyPig.REST;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.API.v3.Clients
{
    public class MediaClient
    {
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
        public Task<Response<List<BasicMedia>>> ListLibraryItemsAsync(LibraryListRequest data, CancellationToken cancellationToken = default) =>
            _client.PostAsync<List<BasicMedia>>(true, PREFIX + "ListLibraryItems", data, cancellationToken);


        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response<List<BasicMedia>>> LoadMoreHomeScreenItemsAsync(IDListRequest data, CancellationToken cancellationToken = default) =>
            _client.PostAsync<List<BasicMedia>>(true, PREFIX + "LoadMoreHomeScreenItems", data, cancellationToken);


        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response<SearchResults>> SearchAsync(string query, CancellationToken cancellationToken = default) =>
            _client.PostAsync<SearchResults>(true, PREFIX + "Search", new SimpleValue<string>(query), cancellationToken);


        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response> AddToWatchlistAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetAsync(true, PREFIX + $"AddToWatchlist/{id}", cancellationToken);


        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response> DeleteFromWatchlistAsync(int id, CancellationToken cancellationToken = default) =>
            _client.DeleteAsync(true, PREFIX + $"DeleteFromWatchlist/{id}", cancellationToken);
    }
}
