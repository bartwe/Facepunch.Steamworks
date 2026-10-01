#include <assert.h>
#include <stdbool.h>
#include <stdint.h>

static int32_t result_handle;
static int32_t destroy_count;
static int32_t last_destroyed_handle;

void ResetInventoryStub(int32_t handle)
{
	result_handle = handle;
	destroy_count = 0;
	last_destroyed_handle = -1;
}

int32_t GetDestroyCount(void) { return destroy_count; }
int32_t GetLastDestroyedHandle(void) { return last_destroyed_handle; }

void *SteamAPI_SteamInventory_v003(void) { return &result_handle; }

bool SteamAPI_ISteamInventory_GetAllItems(void *self, int32_t *handle)
{
	assert(self == &result_handle);
	*handle = result_handle;
	return true;
}

int32_t SteamAPI_ISteamInventory_GetResultStatus(void *self, int32_t handle)
{
	assert(self == &result_handle);
	assert(handle == result_handle);
	return 1; /* k_EResultOK */
}

void SteamAPI_ISteamInventory_DestroyResult(void *self, int32_t handle)
{
	assert(self == &result_handle);
	last_destroyed_handle = handle;
	destroy_count++;
}
