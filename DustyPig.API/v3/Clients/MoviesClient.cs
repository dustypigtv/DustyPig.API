using DustyPig.API.v3.Models;
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
        public Task<Response<int?>> CreateAsync(CreateMovie data, CancellationToken cancellationToken = default) =>
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
        public Task<Response<DetailedMovie>> GetDetailsAsync(int id, CancellationToken cancellationToken = default)
        {
            if (id <= 0)
                return Task.FromResult(new Response<DetailedMovie> { Error = new ModelValidationException($"Invalid {nameof(id)}") });

            return _client.GetAsync<DetailedMovie>(true, PREFIX + $"Details/{id}", cancellationToken);
        }


        /// <summary>
        /// Requires main profile. Designed for admin tools, this will return info on any movie owned by the account
        /// </summary>
        public Task<Response<DetailedMovie>> GetAdminDetailsAsync(int id, CancellationToken cancellationToken = default)
        {
            if (id <= 0)
                return Task.FromResult(new Response<DetailedMovie> { Error = new ModelValidationException($"Invalid {nameof(id)}") });

            return _client.GetAsync<DetailedMovie>(true, PREFIX + $"AdminDetails/{id}", cancellationToken);
        }


        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response<List<BasicMedia>>> ListAsync(ListRequest data, CancellationToken cancellationToken = default) =>
            _client.PostAsync<List<BasicMedia>>(true, PREFIX + "List", data, cancellationToken);

        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response<List<BasicMedia>>> ListAsync(int start = 0, SortOrder sort = SortOrder.Alphabetical, CancellationToken cancellationToken = default) =>
            ListAsync(new ListRequest
            {
                Start = start,
                Sort = sort
            }, cancellationToken);


        /// <summary>
        /// Requires main profile. Returns the next 100 movies based on start position and sort order. Designed for admin tools, will return all movies owned by the account
        /// </summary>
        public Task<Response<List<BasicMedia>>> AdminListAsync(int start, CancellationToken cancellationToken = default) =>
            AdminListAsync(start, 0, cancellationToken);

        /// <summary>
        /// Requires main profile. Returns the next 100 movies based on start position and sort order. Designed for admin tools, will return all movies owned by the account
        /// </summary>
        public Task<Response<List<BasicMedia>>> AdminListAsync(int start, int libId, CancellationToken cancellationToken = default)
        {
            if (start < 0)
                return Task.FromResult(new Response<List<BasicMedia>> { Error = new ModelValidationException($"Invalid {nameof(start)}") });

            return _client.GetAsync<List<BasicMedia>>(true, PREFIX + $"AdminList/{start}/{libId}", cancellationToken);
        }






        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response> UpdateAsync(UpdateMovie data, CancellationToken cancellationToken = default) =>
            _client.PostAsync(true, PREFIX + "Update", data, cancellationToken);


    }
}
