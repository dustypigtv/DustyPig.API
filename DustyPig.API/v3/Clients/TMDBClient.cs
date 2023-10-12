using DustyPig.API.v3.Models;
using DustyPig.REST;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.API.v3.Clients
{
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
        public Task<Response<TitleRequestPermissions>> GetRequestTitlePermissionAsync(CancellationToken cancellationToken = default) =>
            _client.GetSimpleAsync<TitleRequestPermissions>(true, PREFIX + "GetRequestTitlePermission", cancellationToken);


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

    }
}
