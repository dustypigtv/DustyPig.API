﻿using DustyPig.API.v3.Clients;
using DustyPig.API.v3.Interfaces;
using DustyPig.API.v3.Models;
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

        private readonly RestClient _client = new RestClient(new Uri(DEFAULT_BASE_ADDRESS));

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

        public NoOpClient NoOp => new NoOpClient(this);

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





        private static Response FlattenResult(Response<Result> response)
        {
            if (response.Success)
                return new Response
                {
                    Error = response.Data.Success ? null : new Exception(response.Data.Error),
                    RawContent = response.RawContent,
                    ReasonPhrase = response.ReasonPhrase,
                    StatusCode = response.StatusCode,
                    Success = response.Data.Success
                };

            return new Response
            {
                Error = response.Error,
                RawContent = response.RawContent,
                ReasonPhrase = response.ReasonPhrase,
                StatusCode = response.StatusCode
            };
        }

        private static Response<T> FlattenResult<T>(Response<Result<T>> response)
        {
            if (response.Success)
                return new Response<T>
                {
                    Data = response.Data.Data,
                    Error = response.Data.Success ? null : new Exception(response.Data.Error),
                    RawContent = response.RawContent,
                    ReasonPhrase = response.ReasonPhrase,
                    StatusCode = response.StatusCode,
                    Success = response.Data.Success
                };

            return new Response<T>
            {
                Error = response.Error,
                RawContent = response.RawContent,
                ReasonPhrase = response.ReasonPhrase,
                StatusCode = response.StatusCode
            };
        }





        internal async Task<Response> GetAsync(bool tokenNeeded, string url, CancellationToken cancellationToken)
        {
            var ret = await _client.GetAsync<Result>(url, GetHeaders(tokenNeeded), cancellationToken).ConfigureAwait(false);
            return FlattenResult(ret);
        }

        internal async Task<Response<T>> GetAsync<T>(bool tokenNeeded, string url, CancellationToken cancellationToken)
        {
            var ret = await _client.GetAsync<Result<T>>(url, GetHeaders(tokenNeeded), cancellationToken).ConfigureAwait(false);
            return FlattenResult(ret);
        }



        internal async Task<Response> PostAsync(bool tokenNeeded, string url, object data, CancellationToken cancellationToken)
        {
            if (data is IValidate iv)
                try { iv.Validate(); }
                catch (ModelValidationException ex)
                {
                    if (AutoThrowIfError)
                        throw;
                    return new Response
                    {
                        Error = ex,
                        ReasonPhrase = ex.Message,
                        StatusCode = HttpStatusCode.BadRequest
                    };
                }

            var ret = await _client.PostAsync<Result>(url, data, GetHeaders(tokenNeeded), cancellationToken).ConfigureAwait(false);
            return FlattenResult(ret);
        }

        internal async Task<Response<T>> PostAsync<T>(bool tokenNeeded, string url, object data, CancellationToken cancellationToken)
        {
            if (data is IValidate iv)
                try { iv.Validate(); }
                catch (ModelValidationException ex)
                {
                    if (AutoThrowIfError)
                        throw;
                    return new Response<T>
                    {
                        Error = ex,
                        ReasonPhrase = ex.Message,
                        StatusCode = HttpStatusCode.BadRequest
                    };
                }

            var ret = await _client.PostAsync<Result<T>>(url, data, GetHeaders(tokenNeeded), cancellationToken).ConfigureAwait(false);
            return FlattenResult(ret);
        }




        internal async Task<Response> DeleteAsync(bool tokenNeeded, string url, CancellationToken cancellationToken)
        {
            var ret = await _client.DeleteAsync<Result>(url, GetHeaders(tokenNeeded), cancellationToken: cancellationToken).ConfigureAwait(false);
            return FlattenResult(ret);
        }




        internal async Task<Response<T>> GetResponseAsync<T>(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var ret = await _client.GetResponseAsync<Result<T>>(request, cancellationToken).ConfigureAwait(false);
            return FlattenResult(ret);
        }

    }
}