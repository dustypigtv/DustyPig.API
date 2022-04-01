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
        public Task<Response<DetailedTMDB>> GetMovieAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetWithResponseDataAsync<DetailedTMDB>(true, PREFIX + $"GetMovie/{id}", cancellationToken);


        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response<DetailedTMDB>> GetSeriesAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetWithResponseDataAsync<DetailedTMDB>(true, PREFIX + $"GetSeries/{id}", cancellationToken);
    }
}
