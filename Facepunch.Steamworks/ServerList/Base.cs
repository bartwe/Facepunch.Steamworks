using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Steamworks.Data;

namespace Steamworks.ServerList;

public abstract class Base : IDisposable {
    /// <summary>
    ///     A list of servers that responded. If you're only interested in servers that responded since you
    ///     last updated, then simply clear this list.
    /// </summary>
    public List<ServerInfo> Responsive = new();

    /// <summary>
    ///     A list of servers that were in the master list but didn't respond.
    /// </summary>
    public List<ServerInfo> Unresponsive = new();

    internal HServerListRequest request;
    internal List<int> watchList = new();
    internal int LastCount;


    public Base() {
        AppId = SteamClient.AppId; // Default AppId is this 
    }

    #region ISteamMatchmakingServers

    internal static ISteamMatchmakingServers Internal {
        get { return SteamMatchmakingServers.Internal; }
    }

    #endregion


    /// <summary>
    ///     Which app we're querying. Defaults to the current app.
    /// </summary>
    public AppId AppId { get; set; }

    internal int Count {
        get { return Internal.GetServerCount(request); }
    }

    internal bool IsRefreshing {
        get { return (request.Value != IntPtr.Zero) && Internal.IsRefreshing(request); }
    }

    public void Dispose() {
        ReleaseQuery();
    }

    /// <summary>
    ///     When a new server is added, this function will get called
    /// </summary>
    public event Action OnChanges;

    /// <summary>
    ///     Called for every responsive server
    /// </summary>
    public event Action<ServerInfo> OnResponsiveServer;

    /// <summary>
    ///     Query the server list. Task result will be true when finished
    /// </summary>
    /// <returns></returns>
    public virtual async Task<bool> RunQueryAsync(float timeoutSeconds = 10) {
        var stopwatch = Stopwatch.StartNew();

        Reset();
        LaunchQuery();

        var thisRequest = request;

        while (IsRefreshing) {
            await Task.Delay(33);

            //
            // The request has been cancelled or changed in some way
            //
            if ((request.Value == IntPtr.Zero) || (thisRequest.Value != request.Value))
                return false;

            if (!SteamClient.IsValid)
                return false;

            var r = Responsive.Count;

            UpdatePending();
            UpdateResponsive();

            if (r != Responsive.Count) {
                InvokeChanges();
            }

            if (stopwatch.Elapsed.TotalSeconds > timeoutSeconds)
                break;
        }

        MovePendingToUnresponsive();
        InvokeChanges();

        return true;
    }

    public virtual void Cancel() {
        Internal.CancelQuery(request);
    }

    // Overrides
    internal abstract void LaunchQuery();

    void Reset() {
        ReleaseQuery();
        LastCount = 0;
        watchList.Clear();
    }

    void ReleaseQuery() {
        if (request.Value != IntPtr.Zero) {
            Cancel();
            Internal.ReleaseRequest(request);
            request = IntPtr.Zero;
        }
    }

    internal void InvokeChanges() {
        OnChanges?.Invoke();
    }

    void UpdatePending() {
        var count = Count;
        if (count == LastCount)
            return;

        for (var i = LastCount; i < count; i++) {
            watchList.Add(i);
        }

        LastCount = count;
    }

    public void UpdateResponsive() {
        _ = watchList.RemoveAll(
            x => {
                var info = Internal.GetServerDetails(request, x);
                if (info.HadSuccessfulResponse) {
                    OnServer(ServerInfo.From(info), info.HadSuccessfulResponse);
                    return true;
                }

                return false;
            }
        );
    }

    void MovePendingToUnresponsive() {
        _ = watchList.RemoveAll(
            x => {
                var info = Internal.GetServerDetails(request, x);
                OnServer(ServerInfo.From(info), info.HadSuccessfulResponse);
                return true;
            }
        );
    }

    void OnServer(ServerInfo serverInfo, bool responded) {
        if (responded) {
            Responsive.Add(serverInfo);
            OnResponsiveServer?.Invoke(serverInfo);
            return;
        }

        Unresponsive.Add(serverInfo);
    }

    #region Filters

    internal List<MatchMakingKeyValuePair> filters = new();

    internal virtual MatchMakingKeyValuePair[] GetFilters() {
        return filters.ToArray();
    }

    public void AddFilter(string key, string value) {
        filters.Add(new() { Key = key, Value = value });
    }

    #endregion
}
