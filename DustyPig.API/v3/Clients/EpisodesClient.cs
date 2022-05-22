using DustyPig.API.v3.Models;
using DustyPig.REST;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.API.v3.Clients
{
    public class EpisodesClient
    {
        private const string PREFIX = "Episodes/";

        private readonly Client _client;

        internal EpisodesClient(Client client) => _client = client;

        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response<int>> CreateAsync(CreateEpisode data, CancellationToken cancellationToken = default) =>
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
        public Task<Response<DetailedEpisode>> GetDetailsAsync(int id, CancellationToken cancellationToken = default)
        {
            if (id <= 0)
                return Task.FromResult(new Response<DetailedEpisode> { Error = new ModelValidationException($"Invalid {nameof(id)}") });

            return _client.GetAsync<DetailedEpisode>(true, PREFIX + $"Details/{id}", cancellationToken);
        }


        /// <summary>
        /// Requires main profile. Returns the next 100 movies based on start position and sort order. Designed for admin tools, will return all mvoies owned by the account
        /// </summary>
        public Task<Response<List<BasicMedia>>> AdminListAsync(int start, CancellationToken cancellationToken = default)
        {
            if (start < 0)
                return Task.FromResult(new Response<List<BasicMedia>> { Error = new ModelValidationException($"Invalid {nameof(start)}") });

            return _client.GetAsync<List<BasicMedia>>(true, PREFIX + $"AdminList/{start}", cancellationToken);
        }
        
        
        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response> UpdateAsync(UpdateEpisode data, CancellationToken cancellationToken = default) =>
            _client.PostAsync(true, PREFIX + "Update", data, cancellationToken);
    }
}
