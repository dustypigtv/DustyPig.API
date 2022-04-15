using DustyPig.API.v3.Models;
using DustyPig.REST;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace DustyPig.API.v3.Clients
{
    public class LibrariesClient
    {
        private const string PREFIX = "Libraries/";

        private readonly Client _client;

        internal LibrariesClient(Client client) => _client = client;

        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response<int>> CreateAsync(CreateLibrary data, CancellationToken cancellationToken = default) =>
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
        /// Requires main profile
        /// </summary>
        public Task<Response<DetailedLibrary>> GetDetailsAsync(int id, CancellationToken cancellationToken = default)
        {
            if (id <= 0)
                return Task.FromResult(new Response<DetailedLibrary> { Error = new ModelValidationException($"Invalid {nameof(id)}") });

            return _client.GetAsync<DetailedLibrary>(true, PREFIX + $"Details/{id}", cancellationToken);
        }


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response> LinkToProfileAsync(ProfileLibraryLink data, CancellationToken cancellationToken = default) =>
            _client.PostAsync(true, PREFIX + "LinkToProfile", data, cancellationToken);


        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response<List<BasicLibrary>>> ListAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<BasicLibrary>>(true, PREFIX + "List", cancellationToken);


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response> ShareWithFriendAsync(LibraryFriendLink data, CancellationToken cancellationToken = default) =>
            _client.PostAsync(true, PREFIX + "ShareWithFriend", data, cancellationToken);


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response> UnlinkFromProfileAsync(ProfileLibraryLink data, CancellationToken cancellationToken = default) =>
            _client.PostAsync(true, PREFIX + "UnLinkFromProfile", data, cancellationToken);


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response> UnshareWithFriendAsync(LibraryFriendLink data, CancellationToken cancellationToken) =>
            _client.PostAsync(true, PREFIX + "UnShareWithFriend", data, cancellationToken);


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response> UpdateAsync(UpdateLibrary data, CancellationToken cancellationToken = default) =>
            _client.PostAsync(true, PREFIX + "Update", data, cancellationToken);
    }
}
