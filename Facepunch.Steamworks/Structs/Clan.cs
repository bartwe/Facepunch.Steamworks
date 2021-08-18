using System.Collections.Generic;
using System.Threading.Tasks;

namespace Steamworks {
    public struct Clan {
        public SteamId Id;

        public Clan(SteamId id) {
            Id = id;
        }

        public string Name {
            get { return SteamFriends.Internal.GetClanName(Id); }
        }

        public string Tag {
            get { return SteamFriends.Internal.GetClanTag(Id); }
        }

        public int ChatMemberCount {
            get { return SteamFriends.Internal.GetClanChatMemberCount(Id); }
        }

        public Friend Owner {
            get { return new(SteamFriends.Internal.GetClanOwner(Id)); }
        }

        public bool Public {
            get { return SteamFriends.Internal.IsClanPublic(Id); }
        }

        /// <summary>
        ///     Is the clan an official game group?
        /// </summary>
        public bool Official {
            get { return SteamFriends.Internal.IsClanOfficialGameGroup(Id); }
        }

        /// <summary>
        ///     Asynchronously fetches the officer list for a given clan
        /// </summary>
        /// <returns>Whether the request was successful or not</returns>
        public async Task<bool> RequestOfficerList() {
            var req = await SteamFriends.Internal.RequestClanOfficerList(Id);
            return req.HasValue && (req.Value.Success != 0x0);
        }

        public IEnumerable<Friend> GetOfficers() {
            for (var i = 0; i < SteamFriends.Internal.GetClanOfficerCount(Id); i++) {
                yield return new(SteamFriends.Internal.GetClanOfficerByIndex(Id, i));
            }
        }
    }
}
