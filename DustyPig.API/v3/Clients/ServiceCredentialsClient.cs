using DustyPig.API.v3.Models;
using DustyPig.REST;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.API.v3.Clients
{
    public class ServiceCredentialsClient
    {
        private const string PREFIX = "ServiceCredentials/";

        private readonly Client _client;

        internal ServiceCredentialsClient(Client client) => _client = client;


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response<int>> CreateAsync(CreateS3Credential data, CancellationToken cancellationToken = default) =>
            _client.PostWithSimpleResponseAsync<int>(true, PREFIX + "CreateS3", data, cancellationToken);


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response<int>> CreateAsync(CreateDPFSCredential data, CancellationToken cancellationToken = default) =>
            _client.PostWithSimpleResponseAsync<int>(true, PREFIX + "CreateDPFS", data, cancellationToken);



        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            if (id <= 0)
                return Task.FromResult(new Response { Error = new ModelValidationException($"Invalid {nameof(id)}") });

            return _client.DeleteAsync(true, PREFIX + $"Delete/{id}", cancellationToken);
        }


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response<S3Credential>> GetS3DetailsAsync(int id, CancellationToken cancellationToken = default)
        {
            if (id <= 0)
                return Task.FromResult(new Response<S3Credential> { Error = new ModelValidationException($"Invalid {nameof(id)}") });

            return _client.GetAsync<S3Credential>(true, PREFIX + $"GetS3Details/{id}", cancellationToken);
        }


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response<DPFSCredential>> GetDPFSDetailsAsync(int id, CancellationToken cancellationToken = default)
        {
            if (id <= 0)
                return Task.FromResult(new Response<DPFSCredential> { Error = new ModelValidationException($"Invalid {nameof(id)}") });

            return _client.GetAsync<DPFSCredential>(true, PREFIX + $"GetDPFSDetails/{id}", cancellationToken);
        }

        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response<List<ServiceCredential>>> ListAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<ServiceCredential>>(true, PREFIX + "List", cancellationToken);


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response> UpdateS3Async(S3Credential data, CancellationToken cancellationToken = default) =>
            _client.PostAsync(true, PREFIX + "UpdateS3", data, cancellationToken);


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response> UpdateDPFSAsync(DPFSCredential data, CancellationToken cancellationToken = default) =>
            _client.PostAsync(true, PREFIX + "UpdateDPFS", data, cancellationToken);
    }
}
