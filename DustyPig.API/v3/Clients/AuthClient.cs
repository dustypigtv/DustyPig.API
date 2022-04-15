using DustyPig.API.v3.Models;
using DustyPig.REST;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.API.v3.Clients
{
    public class AuthClient
    {
        private const string PREFIX = "Auth/";

        private readonly Client _client;

        internal AuthClient(Client client) => _client = client;

        /// <summary>
        /// Returns a code that can be used to login to a device with no keyboard (streaming devices, smart tvs, etc)
        /// </summary>
        public Task<Response<string>> GenerateDeviceLoginCodeAsync(CancellationToken cancellationToken = default) =>
            _client.GetSimpleAsync<string>(false, PREFIX + "GenerateDeviceLoginCode", cancellationToken);


        /// <summary>
        /// Requires logged in profile. Associates the generated code with logged in user account, allowing a subsequent call to <see cref="VerifyDeviceLoginCodeAsync"/> by the device to get an account token
        /// </summary>
        public Task<Response> LoginDeviceWithCodeAsync(string code, CancellationToken cancellationToken = default) =>
            _client.PostAsync(true, PREFIX + "LoginDeviceWithCode", new SimpleValue<string>(code), cancellationToken);


        /// <summary>
        /// Logs into the account using an OAuth token, and returns an account level bearer token
        /// </summary>
        public Task<Response<string>> OAuthLoginAsync(OAuthCredentials data, CancellationToken cancellationToken = default) =>
            _client.PostWithSimpleResponseAsync<string>(false, PREFIX + "OAuthLogin", data, cancellationToken);


        /// <summary>
        /// Returns an account level bearer token
        /// </summary>
        public Task<Response<string>> PasswordLoginAsync(PasswordCredentials data, CancellationToken cancellationToken = default) =>
            _client.PostWithSimpleResponseAsync<string>(false, PREFIX + "PasswordLogin", data, cancellationToken);


        /// <summary>
        /// Requires logged in account. Returns a profile level bearer token
        /// </summary>
        public Task<Response<string>> ProfileLoginAsync(ProfileCredentials data, CancellationToken cancellationToken = default) =>
            _client.PostWithSimpleResponseAsync<string>(true, PREFIX + "ProfileLogin", data, cancellationToken);


        /// <summary>
        /// Sends a password reset email
        /// </summary>
        public Task<Response> SendPasswordResetEmailAsync(string email, CancellationToken cancellationToken = default) =>
            _client.PostAsync(false, PREFIX + "SendPasswordResetEmail", new SimpleValue<string>(email), cancellationToken);


        /// <summary>
        /// Sends a verification email
        /// </summary>
        public Task<Response> SendVerificationEmailAsync(PasswordCredentials data, CancellationToken cancellationToken = default) =>
            _client.PostAsync(false, PREFIX + "SendVerificationEmail", data, cancellationToken);


        /// <summary>
        /// If called by a logged in profile, will sign out of the profile. If called by a logged in account, will sign out of the account
        /// </summary>
        public Task<Response> SignoutAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync(true, PREFIX + "Signout", cancellationToken);


        /// <summary>
        /// Requires main profile. Sign all users out of all devices
        /// </summary>
        public Task<Response> SignoutEverywhereAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync(true, PREFIX + "SignoutEverywhere", cancellationToken);


        /// <summary>
        /// Check the generated code to see if it has been authorized, and if so returns an account level bearer token. Once this returns true, the generated code will be deleted
        /// </summary>
        public Task<Response<DeviceCodeStatus>> VerifyDeviceLoginCodeAsync(string code, CancellationToken cancellationToken = default) =>
            _client.PostAsync<DeviceCodeStatus>(false, PREFIX + "VerifyDeviceLoginCode", new SimpleValue<string>(code), cancellationToken);

    }
}
