#include <stdbool.h>
#include <stdint.h>
#include <stdlib.h>

static bool accepted;
static uint32_t item_state;
static void (*on_download)(void);

void ConfigureDownload(bool accept, uint32_t state, void (*callback)(void))
{
    accepted = accept;
    item_state = state;
    on_download = callback;
}

void *SteamAPI_SteamUGC_v016(void)
{
    return &item_state;
}

bool SteamAPI_ISteamUGC_DownloadItem(void *self, uint64_t file_id, bool high_priority)
{
    if (self != &item_state || file_id == 0 || !high_priority)
        abort();
    if (on_download)
        on_download();
    return accepted;
}

uint32_t SteamAPI_ISteamUGC_GetItemState(void *self, uint64_t file_id)
{
    if (self != &item_state || file_id == 0)
        abort();
    return item_state;
}
