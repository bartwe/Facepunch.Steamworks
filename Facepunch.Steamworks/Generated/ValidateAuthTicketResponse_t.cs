using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct ValidateAuthTicketResponse_t : ICallbackData {
    internal ulong SteamID; // m_SteamID CSteamID
    internal AuthResponse AuthSessionResponse; // m_eAuthSessionResponse EAuthSessionResponse
    internal ulong OwnerSteamID; // m_OwnerSteamID CSteamID

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(ValidateAuthTicketResponse_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.ValidateAuthTicketResponse;

#endregion
}