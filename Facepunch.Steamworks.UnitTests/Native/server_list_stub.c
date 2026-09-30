#include <assert.h>
#include <stdbool.h>
#include <stddef.h>
#include <stdint.h>
#include <stdatomic.h>

static atomic_int requests;
static atomic_int cancellations;
static atomic_int releases;
static atomic_bool active;
static atomic_bool refreshing;
static atomic_bool complete_immediately;

struct state
{
    int requests;
    int cancellations;
    int releases;
};

void Test_Reset(void)
{
    assert(!active);
    requests = cancellations = releases = 0;
    refreshing = complete_immediately = false;
}

void Test_CompleteQueries(void)
{
    complete_immediately = true;
    refreshing = false;
}

struct state Test_GetState(void)
{
    return (struct state){ requests, cancellations, releases };
}

static void validate_request(void *self, void *request)
{
    assert(self == (void *)1);
    assert(active);
    assert(request == (void *)(intptr_t)requests);
}

void *SteamAPI_SteamMatchmakingServers_v002(void)
{
    return (void *)1;
}

void *SteamAPI_ISteamMatchmakingServers_RequestInternetServerList(
    void *self, uint32_t app, void *filters, uint32_t filter_count, void *response)
{
    (void)app;
    assert(self == (void *)1);
    assert(!active);
    assert(filters != NULL);
    assert(filter_count >= 2 && filter_count <= 17);
    assert(response == NULL);
    requests++;
    active = true;
    refreshing = !complete_immediately;
    return (void *)(intptr_t)requests;
}

bool SteamAPI_ISteamMatchmakingServers_IsRefreshing(void *self, void *request)
{
    validate_request(self, request);
    return refreshing;
}

int SteamAPI_ISteamMatchmakingServers_GetServerCount(void *self, void *request)
{
    validate_request(self, request);
    return 0;
}

void SteamAPI_ISteamMatchmakingServers_CancelQuery(void *self, void *request)
{
    validate_request(self, request);
    cancellations++;
    refreshing = false;
}

void SteamAPI_ISteamMatchmakingServers_ReleaseRequest(void *self, void *request)
{
    validate_request(self, request);
    assert(!refreshing);
    releases++;
    active = false;
}
