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







        internal Dictionary<string, string> GetHeaders(bool tokenNeeded)
        {
            var ret = new Dictionary<string, string>();
            if (tokenNeeded && !string.IsNullOrWhiteSpace(Token))
                ret.Add("Authorization", "Bearer " + Token);
            return ret;
        }


        internal async Task<Response> GetAsync(bool tokenNeeded, string url, CancellationToken cancellationToken)
        {
            var response = await _client.GetAsync<ResponseWrapper>(url, null, GetHeaders(tokenNeeded), cancellationToken).ConfigureAwait(false);
            return ConvertToResponse(response);
        }

        internal async Task<Response<T>> GetAsync<T>(bool tokenNeeded, string url, CancellationToken cancellationToken)
        {
            var response = await _client.GetAsync<ResponseWrapper<T>>(url, null, GetHeaders(tokenNeeded), cancellationToken).ConfigureAwait(false);
            return ConvertToDataResponse(response);
        }

        internal async Task<Response<T>> GetSimpleAsync<T>(bool tokenNeeded, string url, CancellationToken cancellationToken)
        {
            var response = await _client.GetAsync<ResponseWrapper<SimpleValue<T>>>(url, null, GetHeaders(tokenNeeded), cancellationToken).ConfigureAwait(false);
            return ConvertToSimpleResponse(response);
        }

        internal async Task<Response> PostAsync(bool tokenNeeded, string url, object data, CancellationToken cancellationToken)
        {
            if (data is IValidate iv)
                try { iv.Validate(); }
                catch (ModelValidationException ex) { return new Response { Error = ex }; }

            var response = await _client.PostAsync<ResponseWrapper>(url, data, GetHeaders(tokenNeeded), cancellationToken).ConfigureAwait(false);
            return ConvertToResponse(response);
        }

        internal async Task<Response<T>> PostAsync<T>(bool tokenNeeded, string url, object data, CancellationToken cancellationToken)
        {
            if (data is IValidate iv)
                try { iv.Validate(); }
                catch (ModelValidationException ex) { return new Response<T> { Error = ex }; }

            var response = await _client.PostAsync<ResponseWrapper<T>>(url, data, GetHeaders(tokenNeeded), cancellationToken).ConfigureAwait(false);
            return ConvertToDataResponse(response);
        }

        internal async Task<Response<T>> PostWithSimpleResponseAsync<T>(bool tokenNeeded, string url, object data, CancellationToken cancellationToken)
        {
            if (data is IValidate iv)
                try { iv.Validate(); }
                catch (ModelValidationException ex) { return new Response<T> { Error = ex }; }

            var response = await _client.PostAsync<ResponseWrapper<SimpleValue<T>>>(url, data, GetHeaders(tokenNeeded), cancellationToken).ConfigureAwait(false);
            return ConvertToSimpleResponse(response);
        }

        internal async Task<Response> DeleteAsync(bool tokenNeeded, string url, CancellationToken cancellationToken)
        {
            var response = await _client.DeleteAsync<ResponseWrapper>(url, null, GetHeaders(tokenNeeded), cancellationToken).ConfigureAwait(false);
            return ConvertToResponse(response);
        }


        internal async Task<Response> GetResponseAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await _client.GetResponseAsync<ResponseWrapper>(request, cancellationToken).ConfigureAwait(false);
            return ConvertToResponse(response);
        }

        internal async Task<Response<T>> GetResponseAsync<T>(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await _client.GetResponseAsync<ResponseWrapper<T>>(request, cancellationToken).ConfigureAwait(false);
            return ConvertToDataResponse(response);
        }

        internal async Task<Response<T>> GetSimpleResponseAsync<T>(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await _client.GetResponseAsync<ResponseWrapper<SimpleValue<T>>>(request, cancellationToken).ConfigureAwait(false);
            return ConvertToSimpleResponse(response);
        }


        static Response ConvertToResponse(Response<ResponseWrapper> rw)
        {
            if (rw.Success)
                return new Response
                {
                    Success = rw.Data.Success,
                    Error = rw.Data.Success ? null : new Exception(rw.Data.Error),
                    RawContent = rw.RawContent,
                    ReasonPhrase = rw.ReasonPhrase,
                    StatusCode = rw.StatusCode
                };
            else
                return new Response
                {
                    Success = false,
                    Error = rw.Error,
                    RawContent = rw.RawContent,
                    ReasonPhrase = rw.ReasonPhrase,
                    StatusCode = rw.StatusCode
                };
        }

        static Response<T> ConvertToDataResponse<T>(Response<ResponseWrapper<T>> rw)
        {
            if (rw.Success)
                return new Response<T>
                {
                    Success = rw.Data.Success,
                    Error = rw.Data.Success ? null : new Exception(rw.Data.Error),
                    Data = rw.Data.Data,
                    RawContent = rw.RawContent,
                    ReasonPhrase = rw.ReasonPhrase,
                    StatusCode = rw.StatusCode
                };
            else
                return new Response<T>
                {
                    Success = false,
                    Error = rw.Error,
                    RawContent = rw.RawContent,
                    ReasonPhrase = rw.ReasonPhrase,
                    StatusCode = rw.StatusCode
                };
        }

        static Response<T> ConvertToSimpleResponse<T>(Response<ResponseWrapper<SimpleValue<T>>> rw)
        {
            if (rw.Success)
                return new Response<T>
                {
                    Success = rw.Data.Success,
                    Error = rw.Data.Success ? null : new Exception(rw.Data.Error),
                    Data = rw.Data.Data.Value,
                    RawContent = rw.RawContent,
                    ReasonPhrase = rw.ReasonPhrase,
                    StatusCode = rw.StatusCode
                };
            else
                return new Response<T>
                {
                    Success = false,
                    Error = rw.Error,
                    RawContent = rw.RawContent,
                    ReasonPhrase = rw.ReasonPhrase,
                    StatusCode = rw.StatusCode
                };
        }
    }
}