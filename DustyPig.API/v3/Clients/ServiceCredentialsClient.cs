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
        public Task<Response<int>> CreateAsync(CreateGoogleDriveCredential data, CancellationToken cancellationToken = default) =>
            _client.PostWithSimpleResponseDataAsync<int>(true, PREFIX + "CreateGoogleDrive", data, cancellationToken);


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response<int>> CreateAsync(CreateS3Credential data, CancellationToken cancellationToken = default) =>
            _client.PostWithSimpleResponseDataAsync<int>(true, PREFIX + "CreateS3", data, cancellationToken);


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response> DeleteAsync(int id, CancellationToken cancellationToken) =>
            _client.DeleteAsync(true, PREFIX + $"Delete/{id}", cancellationToken);


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response<GoogleDriveCredential>> GetGoogleDriveDetailsAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetWithResponseDataAsync<GoogleDriveCredential>(true, PREFIX + $"GetGoogleDriveDetails/{id}", cancellationToken);


        /// <summary>
        /// Requires profile
        /// </summary>
        public Task<Response<GoogleDriveToken>> GetGoogleDriveTokenAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetWithResponseDataAsync<GoogleDriveToken>(true, PREFIX + $"GetGoogleDriveToken/{id}", cancellationToken);


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response<S3Credential>> GetS3DetailsAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetWithResponseDataAsync<S3Credential>(true, PREFIX + $"GetS3Details/{id}", cancellationToken);


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response<List<ServiceCredential>>> ListAsync(CancellationToken cancellationToken = default) =>
            _client.GetWithResponseDataAsync<List<ServiceCredential>>(true, PREFIX + "List", cancellationToken);


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response> UpdateGoogleDriveAsync(GoogleDriveCredential data, CancellationToken cancellationToken = default) =>
            _client.PostAsync(true, PREFIX + "UpdateGoogleDrive", data, cancellationToken);


        /// <summary>
        /// Requires main profile
        /// </summary>
        public Task<Response> UpdateS3Async(S3Credential data, CancellationToken cancellationToken = default) =>
            _client.PostAsync(true, PREFIX + "UpdateS3", data, cancellationToken);
    }
}
