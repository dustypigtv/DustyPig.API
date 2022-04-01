using DustyPig.API.v3.Clients;
using DustyPig.API.v3.Models;
using DustyPig.REST;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.API.v3
{
    public class Client
    {
#if DEBUG
        private const string BASE_URL = "https://localhost:5001/api/v3/";
#else
        private const string BASE_URL = "https://dustypig.azurewebsites.net/api/v3/";
#endif

        private static readonly REST.Client _client = new REST.Client() { BaseAddress = new Uri(BASE_URL) };

        public Client()
        {
#if DEBUG
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
#endif
        }


        public static Version APIVersion => typeof(Client).Assembly.GetName().Version;
            

        public string Token { get; set; }

        public AccountClient Account => new AccountClient(this);

        public AuthClient Auth => new AuthClient(this);

        public EpisodesClient Episodes => new EpisodesClient(this);

        public FriendsClient Friends => new FriendsClient(this);

        public LibrariesClient Libraries => new LibrariesClient(this);

        public MediaClient Media => new MediaClient(this);

        public MoviesClient Movies => new MoviesClient(this);

        public NotificationsClient Notifications => new NotificationsClient(this);

        public ProfilesClient Profiles => new ProfilesClient(this);

        public SeriesClient Series => new SeriesClient(this);

        public ServiceCredentialsClient ServiceCredentials => new ServiceCredentialsClient(this);

        public TMDBClient TMDB => new TMDBClient(this);



        #region API Calls

        private void SetupToken(bool tokenNeeded)
        {
            _client.DefaultRequestHeaders.Clear();
            if (tokenNeeded && !string.IsNullOrWhiteSpace(Token))
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
        }

        internal Task<Response> GetAsync(bool tokenNeeded, string url, CancellationToken cancellationToken)
        {
            SetupToken(tokenNeeded);
            return _client.GetAsync(url, cancellationToken);
        }

        internal Task<Response<T>> GetWithResponseDataAsync<T>(bool tokenNeeded, string url, CancellationToken cancellationToken)
        {
            SetupToken(tokenNeeded);
            return _client.GetWithResponseDataAsync<T>(url, cancellationToken);
        }

        internal async Task<Response<T>> GetWithSimpleResponseDataAsync<T>(bool tokenNeeded, string url, CancellationToken cancellationToken)
        {
            SetupToken(tokenNeeded);
            var ret = await _client.GetWithResponseDataAsync<SimpleValue<T>>(url, cancellationToken).ConfigureAwait(false);
            if (ret.Success)
                return new Response<T> { Data = ret.Data.Value, Success = true };
            return new Response<T> { Error = ret.Error };
        }

        internal Task<Response> PostAsync(bool tokenNeeded, string url, object data, CancellationToken cancellationToken)
        {
            SetupToken(tokenNeeded);
            return _client.PostAsync(url, data, cancellationToken);
        }

        internal Task<Response<T>> PostWithResponseDataAsync<T>(bool tokenNeeded, string url, object data, CancellationToken cancellationToken)
        {
            SetupToken(tokenNeeded);
            return _client.PostWithResponseDataAsync<T>(url, data, cancellationToken);
        }

        internal async Task<Response<T>> PostWithSimpleResponseDataAsync<T>(bool tokenNeeded, string url, object data, CancellationToken cancellationToken)
        {
            SetupToken(tokenNeeded);
            var ret = await _client.PostWithResponseDataAsync<SimpleValue<T>>(url, data, cancellationToken).ConfigureAwait(false);
            if (ret.Success)
                return new Response<T> { Data = ret.Data.Value, Success = true };
            return new Response<T> { Error = ret.Error };
        }

        internal Task<Response> DeleteAsync(bool tokenNeeded, string url, CancellationToken cancellationToken)
        {
            SetupToken(tokenNeeded);
            return _client.DeleteAsync(url, cancellationToken);
        }

        #endregion

    }
}
