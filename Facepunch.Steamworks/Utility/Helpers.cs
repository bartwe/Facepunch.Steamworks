using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks;

static class Helpers {
    public const int MemoryBufferSize = 1024 * 32;

    static readonly IntPtr[] MemoryPool = {
            Marshal.AllocHGlobal(MemoryBufferSize), Marshal.AllocHGlobal(MemoryBufferSize), Marshal.AllocHGlobal(MemoryBufferSize), Marshal.AllocHGlobal(MemoryBufferSize),
        };

    static int MemoryPoolIndex;


    static readonly byte[][] BufferPool = new byte[4][];
    static int BufferPoolIndex;

    public static unsafe IntPtr TakeMemory() {
        lock (MemoryPool) {
            MemoryPoolIndex++;

            if (MemoryPoolIndex >= MemoryPool.Length)
                MemoryPoolIndex = 0;

            var take = MemoryPool[MemoryPoolIndex];

            ((byte*)take)[0] = 0;

            return take;
        }
    }

    /// <summary>
    ///     Returns a buffer. This will get returned and reused later on.
    ///     We shouldn't really be using this anymore.
    /// </summary>
    public static byte[] TakeBuffer(int minSize) {
        lock (BufferPool) {
            BufferPoolIndex++;

            if (BufferPoolIndex >= BufferPool.Length)
                BufferPoolIndex = 0;

            if (BufferPool[BufferPoolIndex] == null)
                BufferPool[BufferPoolIndex] = new byte[1024 * 256];

            if (BufferPool[BufferPoolIndex].Length < minSize) {
                BufferPool[BufferPoolIndex] = new byte[minSize + 1024];
            }

            return BufferPool[BufferPoolIndex];
        }
    }

    internal static unsafe string MemoryToString(IntPtr ptr) {
        var len = 0;

        for (len = 0; len < MemoryBufferSize; len++) {
            if (((byte*)ptr)[len] == 0)
                break;
        }

        if (len == 0)
            return string.Empty;

        return Encoding.UTF8.GetString((byte*)ptr, len);
    }
}

sealed class MonoPInvokeCallbackAttribute : Attribute { }

/// <summary>
///     Prevent unity from stripping shit we depend on
///     https://docs.unity3d.com/Manual/ManagedCodeStripping.html
/// </summary>
sealed class PreserveAttribute : Attribute { }
