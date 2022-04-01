﻿using DustyPig.API.v3.Models;
using DustyPig.REST;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.API.v3.Clients
{
    public class MoviesClient
    {
        private const string PREFIX = "Movies/";

        private readonly Client _client;

        internal MoviesClient(Client client) => _client = client;

        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response<int>> CreateAsync(CreateMovie data, CancellationToken cancellationToken = default) =>
            _client.PostWithSimpleResponseDataAsync<int>(true, PREFIX + "Create", data, cancellationToken);


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response> DeleteAsync(int id, CancellationToken cancellationToken = default) =>
            _client.DeleteAsync(true, PREFIX + $"Delete/{id}", cancellationToken);


        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response<DetailedMovie>> GetDetailsAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetWithResponseDataAsync<DetailedMovie>(true, PREFIX + $"Details/{id}", cancellationToken);


        /// <summary>
        /// Requires main profile. Designed for admin tools, this will return info on any movie owned by the account
        /// </summary>
        public Task<Response<DetailedMovie>> GetAdminDetailsAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetWithResponseDataAsync<DetailedMovie>(true, PREFIX + $"AdminDetails/{id}", cancellationToken);


        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response<List<BasicMedia>>> ListAsync(ListRequest data, CancellationToken cancellationToken = default) =>
            _client.PostWithResponseDataAsync<List<BasicMedia>>(true, PREFIX + "List", data, cancellationToken);


        /// <summary>
        /// Requires main profile. Returns the next 100 movies based on start position and sort order. Designed for admin tools, will return all movies owned by the account
        /// </summary>
        public Task<Response<List<BasicMedia>>> AdminListAsync(int start, CancellationToken cancellationToken = default) =>
            _client.GetWithResponseDataAsync<List<BasicMedia>>(true, PREFIX + $"AdminList/{start}", cancellationToken);


        /// <summary>
        /// Requires profile. Request override access to an existing movie
        /// </summary>
        public Task<Response> RequestAccessOverrideAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetAsync(true, PREFIX + $"RequestAccessOverride/{id}", cancellationToken);


        /// <summary>
        /// Requires main profile. Set access override for a specific movie
        /// </summary>
        public Task<Response> SetAccessOverrideAsync(TitleOverride info, CancellationToken cancellationToken = default) =>
            _client.PostAsync(true, PREFIX + "SetAccessOverride", info, cancellationToken);


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response> UpdateAsync(UpdateMovie data, CancellationToken cancellationToken = default) =>
            _client.PostAsync(true, PREFIX + "Update", data, cancellationToken);


        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response> UpdatePlaybackProgressAsync(PlaybackProgress data, CancellationToken cancellationToken = default) =>
            _client.PostAsync(true, PREFIX + "UpdatePlaybackProgress", data, cancellationToken);
    }
}
