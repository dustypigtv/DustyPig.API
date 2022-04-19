using DustyPig.API.v3.Models;
using DustyPig.REST;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.API.v3.Clients
{
    public class AuthClient
    {
        public const string TEST_EMAIL = "testuser@dustypig.tv";
        public const string TEST_PASSWORD = "test password";


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
        public Task<Response> LoginDeviceWithCodeAsync(string code, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(code) || code.Length != Constants.DEVICE_ACTIVATION_CODE_LENGTH)
                return Task.FromResult(new Response { Error = new ModelValidationException($"Invalid {nameof(code)}") });

            return _client.PostAsync(true, PREFIX + "LoginDeviceWithCode", new SimpleValue<string>(code), cancellationToken);
        }

        /// <summary>
        /// Logs into the account using an OAuth token. If the account only has 1 <see cref="BasicProfile" /> and <see cref="BasicProfile.HasPin"/> = false,
        /// then this returns a profile level token (fully logged in). Otherwise, this will return an account level token
        /// </summary>
        public Task<Response<LoginResponse>> OAuthLoginAsync(OAuthCredentials data, CancellationToken cancellationToken = default) =>
            _client.PostAsync<LoginResponse>(false, PREFIX + "OAuthLogin", data, cancellationToken);


        /// <summary>
        /// Logs into the account using email and password. If the account only has 1 <see cref="BasicProfile" /> and <see cref="BasicProfile.HasPin"/> = false,
        /// then this returns a profile level token (fully logged in). Otherwise, this will return an account level token
        /// </summary>
        public Task<Response<LoginResponse>> PasswordLoginAsync(PasswordCredentials data, CancellationToken cancellationToken = default) =>
            _client.PostAsync<LoginResponse>(false, PREFIX + "PasswordLogin", data, cancellationToken);


        /// <summary>
        /// Requires logged in account. Returns a profile level bearer token
        /// </summary>
        public Task<Response<LoginResponse>> ProfileLoginAsync(ProfileCredentials data, CancellationToken cancellationToken = default) =>
            _client.PostAsync<LoginResponse>(true, PREFIX + "ProfileLogin", data, cancellationToken);


        /// <summary>
        /// Sends a password reset email
        /// </summary>
        public Task<Response> SendPasswordResetEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            var chk = Validators.Validate(nameof(email), email, true, byte.MaxValue);
            if (chk.Valid)
                email = chk.Fixed.ToLower();
            else
                return Task.FromResult(new Response { Error = new ModelValidationException($"Invalid {nameof(email)}") });

            if (!System.StringUtils.IsValidEmail(email))
                return Task.FromResult(new Response { Error = new ModelValidationException($"Invalid {nameof(email)}") });


            if (email == TEST_EMAIL)
                return Task.FromResult(new Response { Error = new ModelValidationException("Test email is not valid for this action") });

            return _client.PostAsync(false, PREFIX + "SendPasswordResetEmail", new SimpleValue<string>(email), cancellationToken);
        }

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
        /// Check the generated code to see if it has been authorized, and if so returns a level bearer token. 
        /// If the account only has 1 <see cref="BasicProfile" /> and <see cref="BasicProfile.HasPin"/> = false,
        /// then this returns a profile level token (fully logged in). Otherwise, this will return an account level token.
        /// Once this returns true, the generated code will be deleted
        /// </summary>
        public Task<Response<DeviceCodeStatus>> VerifyDeviceLoginCodeAsync(string code, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(code) || code.Length != Constants.DEVICE_ACTIVATION_CODE_LENGTH)
                return Task.FromResult(new Response<DeviceCodeStatus> { Error = new ModelValidationException($"Invalid {nameof(code)}") });

            return _client.PostAsync<DeviceCodeStatus>(false, PREFIX + "VerifyDeviceLoginCode", new SimpleValue<string>(code), cancellationToken);
        }

        /// <summary>
        /// Verifies an auth token and returns the type
        /// </summary>
        public Task<Response<VerifyTokenResponse>> VerifyTokenAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync<VerifyTokenResponse>(true, PREFIX + "VerifyToken", cancellationToken);
    }
}
