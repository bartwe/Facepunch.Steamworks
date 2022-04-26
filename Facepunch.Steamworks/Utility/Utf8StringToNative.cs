using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks;

sealed unsafe class Utf8StringToNative : ICustomMarshaler {
    public IntPtr MarshalManagedToNative(object managedObj) {
        if (managedObj == null)
            return IntPtr.Zero;

        if (managedObj is string str) {
            fixed (char* strPtr = str) {
                var len = Encoding.UTF8.GetByteCount(str);
                var mem = Marshal.AllocHGlobal(len + 1);

                var wlen = Encoding.UTF8.GetBytes(strPtr, str.Length, (byte*)mem, len + 1);

                ((byte*)mem)[wlen] = 0;

                return mem;
            }
        }

        return IntPtr.Zero;
    }

    public object MarshalNativeToManaged(IntPtr pNativeData) {
        throw new NotImplementedException();
    }

    public void CleanUpNativeData(IntPtr pNativeData) {
        Marshal.FreeHGlobal(pNativeData);
    }

    public void CleanUpManagedData(object managedObj) {
        throw new NotImplementedException();
    }

    public int GetNativeDataSize() {
        return -1;
    }

    [Preserve]
    public static ICustomMarshaler GetInstance(string cookie) {
        return new Utf8StringToNative();
    }
}
