using DustyPig.API.v3.Models;
using DustyPig.REST;
using System;
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
        public Task<Response<DetailedFriend>> GetDetailsAsync(int id, CancellationToken cancellationToken = default)
        {
            if (id <= 0)
                return Task.FromResult(new Response<DetailedFriend> { Error = new ModelValidationException($"Invalid {nameof(id)}") });

            return _client.GetAsync<DetailedFriend>(true, PREFIX + $"Details/{id}", cancellationToken);
        }


        /// <summary>
        /// Requires main profile. Invites a new friend using their email
        /// </summary>
        public Task<Response> InviteAsync(string email, CancellationToken cancellationToken = default)
        {
            var chk = Validators.Validate(nameof(email), email, true, byte.MaxValue);
            if (chk.Valid)
                email = chk.Fixed.ToLower();
            else
                return Task.FromResult(new Response { Error = new ModelValidationException($"Invalid {nameof(email)}") });

            if (!StringUtils.IsValidEmail(email))
                return Task.FromResult(new Response { Error = new ModelValidationException($"Invalid {nameof(email)}") });

            if (email == AuthClient.TEST_EMAIL)
                return Task.FromResult(new Response { Error = new ModelValidationException("Test email is not valid for this action") });

            return _client.PostAsync(true, PREFIX + "Invite", new SimpleValue<string>(email), cancellationToken);
        }


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
        public Task<Response> UnfriendAsync(int id, CancellationToken cancellationToken = default)
        {
            if (id <= 0)
                return Task.FromResult(new Response { Error = new ModelValidationException($"Invalid {nameof(id)}") });

            return _client.DeleteAsync(true, PREFIX + $"Unfriend/{id}", cancellationToken);
        }


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
