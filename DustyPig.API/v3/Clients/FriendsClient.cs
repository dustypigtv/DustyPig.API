using DustyPig.API.v3.Models;
using DustyPig.REST;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.API.v3.Clients
{
    public class FriendsClient
    {
        private const string PREFIX = "Friends/";

        private readonly Client _client;

        internal FriendsClient(Client client) => _client = client;

        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response<DetailedFriend>> GetDetailsAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetAsync<DetailedFriend>(true, PREFIX + $"Details/{id}", cancellationToken);


        /// <summary>
        /// Requires main profile. Invites a new friend using their email
        /// </summary>
        public Task<Response> InviteAsync(string email, CancellationToken cancellationToken = default) =>
            _client.PostAsync(true, PREFIX + "Invite", new SimpleValue<string>(email), cancellationToken);


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response<List<BasicFriend>>> ListAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<BasicFriend>>(true, PREFIX + "List", cancellationToken);


        /// <summary>
        /// Requires main profile. Shares a library with a friend
        /// </summary>
        public Task<Response> ShareLibraryAsync(LibraryFriendLink data, CancellationToken cancellationToken = default) =>
            _client.PostAsync(true, PREFIX + "ShareLibrary", data, cancellationToken);


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response> UnfriendAsync(int id, CancellationToken cancellationToken = default) =>
            _client.DeleteAsync(true, PREFIX + $"Unfriend/{id}", cancellationToken);


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response> UnshareLibraryAsync(LibraryFriendLink data, CancellationToken cancellationToken = default) =>
            _client.PostAsync(true, PREFIX + "UnShareLibrary", data, cancellationToken);


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response> UpdateAsync(UpdateFriend data, CancellationToken cancellationToken = default) =>
             _client.PostAsync(true, PREFIX + "Update", data, cancellationToken);
    }
}
