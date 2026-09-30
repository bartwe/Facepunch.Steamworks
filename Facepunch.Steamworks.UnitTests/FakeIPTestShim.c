#include <assert.h>
#include <stdbool.h>
#include <stdint.h>

/* Only the native boundary is replaced; tests execute the real managed wrappers. */
static int reserved_ports;
static int last_fake_port_index = -1;

void *SteamAPI_SteamNetworkingSockets_SteamAPI_v012(void)
{
	return &reserved_ports;
}

bool SteamAPI_ISteamNetworkingSockets_BeginAsyncRequestFakeIP(void *self, int num_ports)
{
	assert(self == &reserved_ports);
	assert(num_ports > 0 && num_ports <= 4);
	reserved_ports = num_ports;
	last_fake_port_index = -1;
	return true;
}

uint32_t SteamAPI_ISteamNetworkingSockets_CreateListenSocketP2PFakeIP(
	void *self, int fake_port_index, int num_options, const void *options)
{
	assert(self == &reserved_ports);
	assert(num_options == 0);
	(void)options;
	last_fake_port_index = fake_port_index;
	if (fake_port_index < 0 || fake_port_index >= reserved_ports)
		return 0;
	return (uint32_t)fake_port_index + 1;
}

int FakeIPTest_GetLastPortIndex(void)
{
	return last_fake_port_index;
}

uint32_t SteamAPI_ISteamNetworkingSockets_CreatePollGroup(void *self)
{
	assert(self == &reserved_ports);
	return 1;
}

bool SteamAPI_ISteamNetworkingSockets_DestroyPollGroup(void *self, uint32_t poll_group)
{
	assert(self == &reserved_ports);
	assert(poll_group == 1);
	return true;
}

bool SteamAPI_ISteamNetworkingSockets_CloseListenSocket(void *self, uint32_t socket)
{
	assert(self == &reserved_ports);
	assert(socket > 0 && socket <= (uint32_t)reserved_ports);
	return true;
}
