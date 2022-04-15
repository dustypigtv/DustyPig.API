using DustyPig.API.v3.Models;
using DustyPig.REST;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.API.v3.Clients
{
    public class SeriesClient
    {
        private const string PREFIX = "Series/";

        private readonly Client _client;

        internal SeriesClient(Client client) => _client = client;


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response<int>> CreateAsync(CreateSeries data, CancellationToken cancellationToken = default) =>
            _client.PostWithSimpleResponseAsync<int>(true, PREFIX + "Create", data, cancellationToken);


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
        public Task<Response<DetailedSeries>> GetDetailsAsync(int id, CancellationToken cancellationToken = default)
        {
            if (id <= 0)
                return Task.FromResult(new Response<DetailedSeries> { Error = new ModelValidationException($"Invalid {nameof(id)}") });

            return _client.GetAsync<DetailedSeries>(true, PREFIX + $"Details/{id}", cancellationToken);
        }


        /// <summary>
        /// Requires main profile. Designed for admin tools, this will return info on any series owned by the account
        /// </summary>
        public Task<Response<DetailedSeries>> GetAdminDetailsAsync(int id, CancellationToken cancellationToken = default)
        {
            if (id <= 0)
                return Task.FromResult(new Response<DetailedSeries> { Error = new ModelValidationException($"Invalid {nameof(id)}") });

            return _client.GetAsync<DetailedSeries>(true, PREFIX + $"AdminDetails/{id}", cancellationToken);
        }


        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response<List<BasicMedia>>> ListAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<BasicMedia>>(true, PREFIX + "List", cancellationToken);


        /// <summary>
        /// Requires main profile. Returns the next 100 series based on start position and sort order. Designed for admin tools, will return all series owned by the account
        /// </summary>
        public Task<Response<List<BasicMedia>>> AdminListAsync(int start, CancellationToken cancellationToken = default)
        {
            if (start <= 0)
                return Task.FromResult(new Response<List<BasicMedia>> { Error = new ModelValidationException($"Invalid {nameof(start)}") });

            return _client.GetAsync<List<BasicMedia>>(true, PREFIX + $"AdminList/{start}", cancellationToken);
        }


        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response> RemoveFromContinueWatchingAsync(int id, CancellationToken cancellationToken = default)
        {
            if (id <= 0)
                return Task.FromResult(new Response { Error = new ModelValidationException($"Invalid {nameof(id)}") });

            return _client.GetAsync(true, PREFIX + $"RemoveFromContinueWatching/{id}", cancellationToken);
        }


        /// <summary>
        /// Requires profile. Request override access to an existing movie
        /// </summary>
        public Task<Response> RequestAccessOverrideAsync(int id, CancellationToken cancellationToken = default)
        {
            if (id <= 0)
                return Task.FromResult(new Response { Error = new ModelValidationException($"Invalid {nameof(id)}") });

            return _client.GetAsync(true, PREFIX + $"RequestAccessOverride/{id}", cancellationToken);
        }


        /// <summary>
        /// Requires main profile. Set access override for a specific movie
        /// </summary>
        public Task<Response> SetAccessOverrideAsync(TitleOverride info, CancellationToken cancellationToken = default) =>
            _client.PostAsync(true, PREFIX + "SetAccessOverride", info, cancellationToken);


        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response<List<BasicMedia>>> ListSubscriptionsAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<BasicMedia>>(true, PREFIX + "ListSubscriptions", cancellationToken);


        /// <summary>
        /// Requires profile. Subscribe to notifications of new episodes
        /// </summary>
        public Task<Response> SubscribeAsync(int id, CancellationToken cancellationToken = default)
        {
            if (id <= 0)
                return Task.FromResult(new Response { Error = new ModelValidationException($"Invalid {nameof(id)}") });

            return _client.GetAsync(true, PREFIX + $"Subscribe/{id}", cancellationToken);
        }


        /// <summary>
        /// Requires profile. Unsubscribe from notifications of new episodes
        /// </summary>
        public Task<Response> UnsubscribeAsync(int id, CancellationToken cancellationToken = default)
        {
            if (id <= 0)
                return Task.FromResult(new Response { Error = new ModelValidationException($"Invalid {nameof(id)}") });

            return _client.DeleteAsync(true, PREFIX + $"Unsubscribe/{id}", cancellationToken);
        }


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response> UpdateAsync(UpdateSeries data, CancellationToken cancellationToken = default) =>
            _client.PostAsync(true, PREFIX + "Update", data, cancellationToken);
    }
}
