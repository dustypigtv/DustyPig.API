using DustyPig.API.v3.Models;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.API.v3.Clients;

public class PollingClient
{
    private readonly Client _client;

    internal PollingClient(Client client) => _client = client;

    private async Task<long> GetVersion(string url, int profileId, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _client.HttpClient.GetStringAsync(url + profileId.ToString(), cancellationToken).ConfigureAwait(false);
            return long.Parse(response);
        }
        catch { }

        return 0;
    }


    /// <summary>
    /// Requires logged in profile
    /// </summary>
    public Task<long> PollAlertsAsync(int profileId, CancellationToken cancellationToken = default) =>
        GetVersion(Constants.UPDATE_POLLING_ALERT_URL, profileId, cancellationToken);


    /// <summary>
    /// Requires logged in profile
    /// </summary>
    public Task<long> PollHomeScreenAsync(int profileId, CancellationToken cancellationToken = default) =>
        GetVersion(Constants.UPDATE_POLLING_HOMESCREEN_URL, profileId, cancellationToken);


    /// <summary>
    /// Requires logged in profile
    /// </summary>
    public Task<long> PollContinueWatchingAsync(int profileId, CancellationToken cancellationToken = default) =>
        GetVersion(Constants.UPDATE_POLLING_CONTINUE_WATCHING_URL, profileId, cancellationToken);


    /// <summary>
    /// Requires logged in profile
    /// </summary>
    public Task<long> PollWatchlistAsync(int profileId, CancellationToken cancellationToken = default) =>
        GetVersion(Constants.UPDATE_POLLING_WATCHLIST_URL, profileId, cancellationToken);


    /// <summary>
    /// Requires logged in profile
    /// </summary>
    public Task<long> PollPlaylistsAsync(int profileId, CancellationToken cancellationToken = default) =>
        GetVersion(Constants.UPDATE_POLLING_PLAYLISTS_URL, profileId, cancellationToken);
}
