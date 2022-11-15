using DustyPig.API.v3.Clients;
using DustyPig.API.v3.Interfaces;
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
        public const string DEFAULT_BASE_ADDRESS = "https://localhost:5001/api/v3/";
#else
        public const string DEFAULT_BASE_ADDRESS = "https://service.dustypig.tv/api/v3/";
#endif

        private static readonly REST.Client _client = new REST.Client() { BaseAddress = new Uri(DEFAULT_BASE_ADDRESS) };

        public static bool IncludeRawContentInResponse
        {
            get => _client.IncludeRawContentInResponse;
            set => _client.IncludeRawContentInResponse = value;
        }

        public static bool AutoThrowIfError
        {
            get => _client.AutoThrowIfError;
            set => _client.AutoThrowIfError = value;
        }


        public Client()
        {
#if DEBUG
            IncludeRawContentInResponse = true;
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
#endif
        }
        

        public static Version APIVersion => typeof(Client).Assembly.GetName().Version;
        
        public static Uri BaseUrl
        {
            get => _client.BaseAddress;
            set => _client.BaseAddress = value;
        }

        public string Token { get; set; }

        public AccountClient Account => new AccountClient(this);

        public AuthClient Auth => new AuthClient(this);

        public EpisodesClient Episodes => new EpisodesClient(this);

        public FriendsClient Friends => new FriendsClient(this);

        public LibrariesClient Libraries => new LibrariesClient(this);

        public MediaClient Media => new MediaClient(this);

        public MoviesClient Movies => new MoviesClient(this);

        public NotificationsClient Notifications => new NotificationsClient(this);

        public PlaylistClient Playlists => new PlaylistClient(this);

        public ProfilesClient Profiles => new ProfilesClient(this);

        public SeriesClient Series => new SeriesClient(this);

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
                return new Response<T>
                {
                    Data = ret.Data.Value,
                    Success = true,
                    RawContent = ret.RawContent,
                    ReasonPhrase = ret.ReasonPhrase,
                    StatusCode = ret.StatusCode
                };

            return new Response<T> 
            {
                Error = ret.Error,
                RawContent = ret.RawContent,
                ReasonPhrase = ret.ReasonPhrase,
                StatusCode = ret.StatusCode
            };
        }

        internal Task<Response> PostAsync(bool tokenNeeded, string url, object data, CancellationToken cancellationToken)
        {
            if (data is IValidate iv)
                try { iv.Validate(); }
                catch (ModelValidationException ex) { return Task.FromResult(new Response { Error = ex }); }
           
            return _client.PostAsync(url, data, GetHeaders(tokenNeeded), cancellationToken);
        }

        internal Task<Response<T>> PostAsync<T>(bool tokenNeeded, string url, object data, CancellationToken cancellationToken)
        {
            if (data is IValidate iv)
                try { iv.Validate(); }
                catch (ModelValidationException ex) { return Task.FromResult(new Response<T> { Error = ex }); }

            return _client.PostAsync<T>(url, data, GetHeaders(tokenNeeded), cancellationToken);
        }

        internal async Task<Response<T>> PostWithSimpleResponseAsync<T>(bool tokenNeeded, string url, object data, CancellationToken cancellationToken)
        {
            if (data is IValidate iv)
                try { iv.Validate(); }
                catch (ModelValidationException ex) { return new Response<T> { Error = ex }; }

            var ret = await _client.PostAsync<SimpleValue<T>>(url, data, GetHeaders(tokenNeeded), cancellationToken).ConfigureAwait(false);
            if (ret.Success)
                return new Response<T>
                {
                    Data = ret.Data.Value,
                    Success = true,
                    RawContent = ret.RawContent,
                    ReasonPhrase = ret.ReasonPhrase,
                    StatusCode = ret.StatusCode
                };

            return new Response<T>
            {
                Error = ret.Error,
                RawContent = ret.RawContent,
                ReasonPhrase = ret.ReasonPhrase,
                StatusCode = ret.StatusCode
            };
        }

        internal Task<Response> DeleteAsync(bool tokenNeeded, string url, CancellationToken cancellationToken) =>
            _client.DeleteAsync(url, null, GetHeaders(tokenNeeded), cancellationToken);
        
        #endregion

    }
}
