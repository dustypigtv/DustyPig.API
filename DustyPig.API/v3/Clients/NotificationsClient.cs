﻿using DustyPig.API.v3.Models;
using DustyPig.REST;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace DustyPig.API.v3.Clients;

public class NotificationsClient
{
    private const string PREFIX = "Notifications/";

    private readonly Client _client;

    internal NotificationsClient(Client client) => _client = client;

    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return Task.FromResult(new Response { Error = new ModelValidationException($"Invalid {nameof(id)}") });

        return _client.DeleteAsync(true, PREFIX + $"Delete/{id}", cancellationToken);
    }


    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response<List<Notification>>> ListAsync(int start = 0, CancellationToken cancellationToken = default) =>
        _client.GetAsync<List<Notification>>(true, PREFIX + $"List/{start}", cancellationToken);


    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response> MarkAsReadAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return Task.FromResult(new Response { Error = new ModelValidationException($"Invalid {nameof(id)}") });

        return _client.GetAsync(true, PREFIX + $"MarkAsRead/{id}", cancellationToken);
    }

    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response> MarkAllReadAsync(CancellationToken cancellationToken = default) =>
        _client.GetAsync(true, PREFIX + "MarkAllRead", cancellationToken);

    /// <summary>
    /// Requires profile
    /// </summary>
    public Task<Response> DeleteAllAsync(CancellationToken cancellationToken = default) =>
        _client.DeleteAsync(true, PREFIX + "DeleteAll", cancellationToken);
}
