#include <assert.h>
#include <stdbool.h>
#include <stdint.h>

static int inventory;

void *SteamAPI_SteamInventory_v003(void)
{
	return &inventory;
}

bool SteamAPI_ISteamInventory_GetItemPrice(void *self, int32_t definition,
	uint64_t *current_price, uint64_t *base_price)
{
	assert(self == &inventory);

	switch (definition)
	{
		case 1: // Discounted item.
			*current_price = 799;
			*base_price = 1299;
			return true;
		case 2: // Full-price item.
			*current_price = 1299;
			*base_price = 1299;
			return true;
		default:
			return false;
	}
}
