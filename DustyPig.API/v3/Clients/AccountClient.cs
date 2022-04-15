using DustyPig.API.v3.Models;
using DustyPig.REST;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.API.v3.Clients
{
    public class AccountClient
    {
        private const string PREFIX = "Account/";

        private readonly Client _client;

        internal AccountClient(Client client) => _client = client;


        /// <summary>
        /// Create the Firebase account and send a confirmation email
        /// </summary>
        public Task<Response<CreateAccountResponse>> CreateAsync(CreateAccount data, CancellationToken cancellationToken = default) =>
            _client.PostAsync<CreateAccountResponse>(false, PREFIX + "Create", data, cancellationToken);


        /// <summary>
        /// Requires main profile. WARNING: This will permanently delete the account and ALL data. This is not recoverable!
        /// </summary>
        public Task<Response> DeleteAsync(CancellationToken cancellationToken = default) =>
            _client.DeleteAsync(true, PREFIX + "Delete", cancellationToken);

    }
}
