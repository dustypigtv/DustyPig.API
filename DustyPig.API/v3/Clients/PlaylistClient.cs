using DustyPig.API.v3.Models;
using DustyPig.REST;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.API.v3.Clients
{
    public class PlaylistClient
    {
        private const string PREFIX = "Playlists/";

        private readonly Client _client;

        internal PlaylistClient(Client client) => _client = client;


        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response<List<BasicPlaylist>>> ListAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<BasicPlaylist>>(true, PREFIX + "List", cancellationToken);


        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response<DetailedPlaylist>> GetDetailsAsync(int id, CancellationToken cancellationToken = default)
        {
            if (id <= 0)
                return Task.FromResult(new Response<DetailedPlaylist> { Error = new ModelValidationException($"Invalid {nameof(id)}") });

            return _client.GetAsync<DetailedPlaylist>(true, PREFIX + $"Details/{id}", cancellationToken);
        }


        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response<int>> CreateAsync(CreatePlaylist data, CancellationToken cancellationToken = default) =>
            _client.PostWithSimpleResponseAsync<int>(true, PREFIX + "Create", data, cancellationToken);

        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response<int>> CreateAsync(string name, CancellationToken cancellationToken = default) =>
            CreateAsync(new CreatePlaylist
            {
                Name = name
            }, cancellationToken);


        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response> UpdateAsync(UpdatePlaylist data, CancellationToken cancellationToken = default) =>
            _client.PostAsync(true, PREFIX + "Update", data, cancellationToken);


        /// <summary>
        /// Requires profile
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
        public Task<Response> SetPlaylistProgress(SetPlaylistProgress data, CancellationToken cancellationToken = default) =>
            _client.PostAsync(true, PREFIX + "SetPlaylistProgress", data, cancellationToken);

        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response> SetPlaylistProgress(int playlistId, int newIndex, double newProgress, CancellationToken cancellationToken = default) =>
            SetPlaylistProgress(new SetPlaylistProgress
            {
                PlaylistId = playlistId,
                NewIndex = newIndex,
                NewProgress = newProgress
            }, cancellationToken);



        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response<int>> AddItemAsync(AddPlaylistItem data, CancellationToken cancellationToken = default) =>
            _client.PostWithSimpleResponseAsync<int>(true, PREFIX + "AddItem", data, cancellationToken);

        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response<int>> AddItemAsync(int playlistId, int mediaId, CancellationToken cancellationToken = default) =>
            AddItemAsync(new AddPlaylistItem
            {
                MediaId = mediaId,
                PlaylistId = playlistId
            }, cancellationToken);



        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response> AddSeriesAsync(AddPlaylistItem data, CancellationToken cancellationToken = default) =>
            _client.PostAsync(true, PREFIX + "AddSeries", data, cancellationToken);

        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response> AddSeriesAsync(int playlistId, int mediaId, CancellationToken cancellationToken = default) =>
            AddSeriesAsync(new AddPlaylistItem
            {
                MediaId = mediaId,
                PlaylistId = playlistId
            }, cancellationToken);


        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response> DeleteItemAsync(int id, CancellationToken cancellationToken = default)
        {
            if (id <= 0)
                return Task.FromResult(new Response { Error = new ModelValidationException($"Invalid {nameof(id)}") });

            return _client.DeleteAsync(true, PREFIX + $"DeleteItem/{id}", cancellationToken);
        }

        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response> MoveItemToNewIndexAsync(ManagePlaylistItem data, CancellationToken cancellationToken = default) =>
            _client.PostAsync(true, PREFIX + "MoveItemToNewIndex", data, cancellationToken);

        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response> MoveItemToNewIndexAsync(int id, int mediaId, int index, CancellationToken cancellationToken = default) =>
            MoveItemToNewIndexAsync(new ManagePlaylistItem
            {
                Id = id,
                MediaId = mediaId,
                Index = index
            }, cancellationToken);


        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response> UpdatePlaylistItems(UpdatePlaylistItemsData data, CancellationToken cancellationToken = default) =>
            _client.PostAsync(true, PREFIX + "UpdatePlaylistItems", data, cancellationToken);
    }
}
