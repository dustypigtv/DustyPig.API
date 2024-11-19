using DustyPig.API.v3.Models;
using DustyPig.REST;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.API.v3.Clients;

public class AccountClient
{
    private const string PREFIX = "Account/";

    private readonly Client _client;

    internal AccountClient(Client client) => _client = client;


    /// <summary>
    /// Create the Firebase account and send a confirmation email
    /// </summary>
    public Task<Response> CreateAsync(CreateAccount data, CancellationToken cancellationToken = default) =>
        _client.PostAsync(false, PREFIX + "Create", data, cancellationToken);


    /// <summary>
    /// Requires main profile. WARNING: This will permanently delete the account and ALL data. This is not recoverable!
    /// </summary>
    public Task<Response> DeleteAsync(DeleteAccountRequest data, CancellationToken cancellationToken = default) =>
        _client.DeleteAsync(true, PREFIX + "Delete", data, cancellationToken);


    /// <summary>
    /// Change the password
    /// </summary>
    public Task<Response> ChangePasswordAsync(ChangePasswordRequest data, CancellationToken cancellationToken = default) =>
        _client.PostAsync(true, PREFIX + "ChangePassword", data, cancellationToken);

    /// <summary>
    /// Requires main profile. Change the email address. 
    /// </summary>
    public Task<Response> ChangeEmailAddressAsync(ChangeEmailAddressRequest data, CancellationToken cancellationToken = default) =>
        _client.PostAsync(true, PREFIX + "ChangeEmailAddress", data, cancellationToken);
}
