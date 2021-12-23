using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steamworks.ServerList;

public sealed class IpList : Internet {
    public List<string> Ips = new();
    bool wantsCancel;

    public IpList(IEnumerable<string> list) {
        Ips.AddRange(list);
    }

    public IpList(params string[] list) {
        Ips.AddRange(list);
    }

    public override async Task<bool> RunQueryAsync(float timeoutSeconds = 10) {
        var blockSize = 16;
        var pointer = 0;

        var ips = Ips.ToArray();

        while (true) {
            var sublist = ips.Skip(pointer).Take(blockSize);
            if (sublist.Count() == 0)
                break;

            using (var list = new Internet()) {
                list.AddFilter("or", sublist.Count().ToString());

                foreach (var server in sublist) {
                    list.AddFilter("gameaddr", server);
                }

                _ = await list.RunQueryAsync(timeoutSeconds);

                if (wantsCancel)
                    return false;

                Responsive.AddRange(list.Responsive);
                Responsive = Responsive.Distinct().ToList();
                Unresponsive.AddRange(list.Unresponsive);
                Unresponsive = Unresponsive.Distinct().ToList();
            }

            pointer += sublist.Count();

            InvokeChanges();
        }

        return true;
    }

    public override void Cancel() {
        wantsCancel = true;
    }
}
