using DustyPig.API.v3.Models;
using DustyPig.REST;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.API.v3.Clients
{
    public class ProfilesClient
    {
        private const string PREFIX = "Profiles/";

        private readonly Client _client;

        internal ProfilesClient(Client client) => _client = client;

        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response<int>> CreateAsync(CreateProfile data, CancellationToken cancellationToken = default) =>
            _client.PostWithSimpleResponseDataAsync<int>(true, PREFIX + "Create", data, cancellationToken);


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response> DeleteAsync(int id, CancellationToken cancellationToken = default) =>
            _client.DeleteAsync(true, PREFIX + $"Delete/{id}", cancellationToken);


        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response<DetailedProfile>> GetDetailsAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetWithResponseDataAsync<DetailedProfile>(true, PREFIX + $"Details/{id}", cancellationToken);


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response> LinkToLibraryAsync(ProfileLibraryLink data, CancellationToken cancellationToken = default) =>
            _client.PostAsync(true, PREFIX + "LinkToLibrary", data, cancellationToken);


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response> UnlinkFromLibraryAsync(ProfileLibraryLink data, CancellationToken cancellationToken = default) =>
            _client.PostAsync(true, PREFIX + "UnLinkFromLibrary", data, cancellationToken);


        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response> UpdateAsync(UpdateProfile data, CancellationToken cancellationToken = default) =>
            _client.PostAsync(true, PREFIX + "Update", data, cancellationToken);


        /// <summary>
        /// Requires account
        /// </summary>
        public Task<Response<List<BasicProfile>>> ListAsync(CancellationToken cancellationToken = default) =>
            _client.GetWithResponseDataAsync<List<BasicProfile>>(true, PREFIX + "List", cancellationToken);
    }
}
