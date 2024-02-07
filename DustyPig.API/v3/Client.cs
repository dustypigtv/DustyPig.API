using DustyPig.API.v3.Clients;
using DustyPig.API.v3.Interfaces;
using DustyPig.API.v3.Models;
using DustyPig.REST;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.API.v3
{
    public class Client : IDisposable
    {
#if DEBUG
        public const string DEFAULT_BASE_ADDRESS = "https://localhost:5001/api/v3/";
#else
        public const string DEFAULT_BASE_ADDRESS = "https://service.dustypig.tv/api/v3/";
#endif

        private readonly REST.Client _client = new REST.Client() { BaseAddress = new Uri(DEFAULT_BASE_ADDRESS) };

        public Client()
        {
#if DEBUG
            IncludeRawContentInResponse = true;
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
#endif
        }

        public void Dispose()
        {
            _client.Dispose();
            GC.SuppressFinalize(this);
        }




        public static Version APIVersion => typeof(Client).Assembly.GetName().Version;

        public bool IncludeRawContentInResponse
        {
            get => _client.IncludeRawContentInResponse;
            set => _client.IncludeRawContentInResponse = value;
        }

        public Uri BaseUrl
        {
            get => _client.BaseAddress;
            set => _client.BaseAddress = value;
        }

        public bool AutoThrowIfError
        {
            get => _client.AutoThrowIfError;
            set => _client.AutoThrowIfError = value;
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







        internal Dictionary<string, string> GetHeaders(bool tokenNeeded)
        {
            var ret = new Dictionary<string, string>();
            if (tokenNeeded && !string.IsNullOrWhiteSpace(Token))
                ret.Add("Authorization", "Bearer " + Token);
            return ret;
        }


        internal Task<Response> GetAsync(bool tokenNeeded, string url, CancellationToken cancellationToken) =>
            _client.GetAsync(url, GetHeaders(tokenNeeded), cancellationToken);


        internal Task<Response<T>> GetAsync<T>(bool tokenNeeded, string url, CancellationToken cancellationToken) =>
            _client.GetAsync<T>(url, GetHeaders(tokenNeeded), cancellationToken);


        internal async Task<Response<string>> GetStringAsync(bool tokenNeeded, string url, CancellationToken cancellationToken)
        {
            var response = await _client.GetAsync<StringValue>(url, GetHeaders(tokenNeeded), cancellationToken).ConfigureAwait(false);
            return new Response<string>
            {
                Data = response.Success ? response.Data.Value : null,
                Error = response.Error,
                RawContent = response.RawContent,
                ReasonPhrase = response.ReasonPhrase,
                StatusCode = response.StatusCode,
                Success = response.Success,
            };
        }

        internal async Task<Response<int?>> GetIntAsync(bool tokenNeeded, string url, CancellationToken cancellationToken)
        {
            var response = await _client.GetAsync<IntValue>(url, GetHeaders(tokenNeeded), cancellationToken).ConfigureAwait(false);
            return new Response<int?>
            {
                Data = response.Success ? response.Data.Value : null,
                Error = response.Error,
                RawContent = response.RawContent,
                ReasonPhrase = response.ReasonPhrase,
                StatusCode = response.StatusCode,
                Success = response.Success,
            };
        }


        internal Task<Response> PostAsync(bool tokenNeeded, string url, object data, CancellationToken cancellationToken)
        {
            if (data is IValidate iv)
                try { iv.Validate(); }
                catch (ModelValidationException ex)
                {
                    if (AutoThrowIfError)
                        throw;
                    return Task.FromResult(new Response
                    {
                        Error = ex,
                        ReasonPhrase = ex.Message,
                        StatusCode = HttpStatusCode.BadRequest
                    });
                }

            return _client.PostAsync(url, data, GetHeaders(tokenNeeded), cancellationToken);
        }

        internal Task<Response<T>> PostAsync<T>(bool tokenNeeded, string url, object data, CancellationToken cancellationToken)
        {
            if (data is IValidate iv)
                try { iv.Validate(); }
                catch (ModelValidationException ex)
                {
                    if (AutoThrowIfError)
                        throw;
                    return Task.FromResult(new Response<T>
                    {
                        Error = ex,
                        ReasonPhrase = ex.Message,
                        StatusCode = HttpStatusCode.BadRequest
                    });
                }

            return _client.PostAsync<T>(url, data, GetHeaders(tokenNeeded), cancellationToken);
        }

        internal async Task<Response<string>> PostAndGetStringAsync(bool tokenNeeded, string url, object data, CancellationToken cancellationToken)
        {
            var response = await _client.PostAsync<StringValue>(url, data, GetHeaders(tokenNeeded), cancellationToken).ConfigureAwait(false);
            return new Response<string>
            {
                Data = response.Success ? response.Data.Value : null,
                Error = response.Error,
                RawContent = response.RawContent,
                ReasonPhrase = response.ReasonPhrase,
                StatusCode = response.StatusCode,
                Success = response.Success,
            };
        }

        internal async Task<Response<int?>> PostAndGetIntAsync(bool tokenNeeded, string url, object data, CancellationToken cancellationToken)
        {
            var response = await _client.PostAsync<IntValue>(url, data, GetHeaders(tokenNeeded), cancellationToken).ConfigureAwait(false);
            return new Response<int?>
            {
                Data = response.Success ? response.Data.Value : null,
                Error = response.Error,
                RawContent = response.RawContent,
                ReasonPhrase = response.ReasonPhrase,
                StatusCode = response.StatusCode,
                Success = response.Success,
            };
        }


        internal Task<Response> DeleteAsync(bool tokenNeeded, string url, CancellationToken cancellationToken) =>
            _client.DeleteAsync(url, GetHeaders(tokenNeeded), cancellationToken);




        internal Task<Response<T>> GetResponseAsync<T>(HttpRequestMessage request, CancellationToken cancellationToken) =>
            _client.GetResponseAsync<T>(request, cancellationToken);

    }
}