using DustyPig.API.v3.Clients;
using DustyPig.API.v3.Models;
using DustyPig.REST;
using System;
using System.Collections.Generic;
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



        private Dictionary<string, string> GetHeaders(bool tokenNeeded)
        {
            var ret = new Dictionary<string, string>();
            if (tokenNeeded && !string.IsNullOrWhiteSpace(Token))
                ret.Add("Authorization", "Bearer " + Token);
            return ret;
        }

        internal Task<Response> GetAsync(bool tokenNeeded, string url, CancellationToken cancellationToken) =>
            _client.GetAsync(url, null, GetHeaders(tokenNeeded), cancellationToken);
        

        internal Task<Response<T>> GetAsync<T>(bool tokenNeeded, string url, CancellationToken cancellationToken) => 
            _client.GetAsync<T>(url, null, GetHeaders(tokenNeeded), cancellationToken);
        

        internal async Task<Response<T>> GetSimpleAsync<T>(bool tokenNeeded, string url, CancellationToken cancellationToken)
        {
            var ret = await _client.GetAsync<SimpleValue<T>>(url, null, GetHeaders(tokenNeeded), cancellationToken).ConfigureAwait(false);
            if (ret.Success)
                return new Response<T> { Data = ret.Data.Value, Success = true };
            return new Response<T> { Error = ret.Error };
        }

        internal Task<Response> PostAsync(bool tokenNeeded, string url, object data, CancellationToken cancellationToken) =>
            _client.PostAsync(url, data, GetHeaders(tokenNeeded), cancellationToken);
        

        internal Task<Response<T>> PostAsync<T>(bool tokenNeeded, string url, object data, CancellationToken cancellationToken) =>
            _client.PostAsync<T>(url, data, GetHeaders(tokenNeeded), cancellationToken);
        

        internal async Task<Response<T>> PostWithSimpleResponseAsync<T>(bool tokenNeeded, string url, object data, CancellationToken cancellationToken)
        {
            var ret = await _client.PostAsync<SimpleValue<T>>(url, data, GetHeaders(tokenNeeded), cancellationToken).ConfigureAwait(false);
            if (ret.Success)
                return new Response<T> { Data = ret.Data.Value, Success = true };
            return new Response<T> { Error = ret.Error };
        }

        internal Task<Response> DeleteAsync(bool tokenNeeded, string url, CancellationToken cancellationToken) =>
            _client.DeleteAsync(url, null, GetHeaders(tokenNeeded), cancellationToken);
        
        #endregion

    }
}
