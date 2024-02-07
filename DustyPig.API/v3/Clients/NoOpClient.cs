using DustyPig.REST;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.API.v3.Clients
{
    public class NoOpClient
    {
        private const string PREFIX = "NoOp/";

        private readonly Client _client;

        internal NoOpClient(Client client) => _client = client;

        public Task<Response> HelloEveryoneAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync(false, PREFIX + "HelloEveryone", cancellationToken);

        public Task<Response> HelloAccountAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync(true, PREFIX + "HelloAccount", cancellationToken);

        public Task<Response> HelloProfileAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync(true, PREFIX + "HelloProfile", cancellationToken);

        public Task<Response> HelloMainProfileAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync(true, PREFIX + "HelloMainProfile", cancellationToken);

    }
}
