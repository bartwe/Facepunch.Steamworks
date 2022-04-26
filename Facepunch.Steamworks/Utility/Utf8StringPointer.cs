using System;
using System.Text;

namespace Steamworks;

struct Utf8StringPointer {
#pragma warning disable 649
    internal IntPtr ptr;
#pragma warning restore 649

    public static unsafe implicit operator string(Utf8StringPointer p) {
        if (p.ptr == IntPtr.Zero)
            return null;

        var bytes = (byte*)p.ptr;

        var dataLen = 0;
        while (dataLen < (1024 * 1024 * 64)) {
            if (bytes[dataLen] == 0)
                break;

            dataLen++;
        }

        return Encoding.UTF8.GetString(bytes, dataLen);
    }
}