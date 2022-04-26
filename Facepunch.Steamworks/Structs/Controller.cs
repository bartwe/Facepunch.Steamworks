using Steamworks.Data;

namespace Steamworks;

public struct Controller {
    internal InputHandle_t Handle;

    internal Controller(InputHandle_t inputHandle_t) {
        Handle = inputHandle_t;
    }

    public ulong Id => Handle.Value;

    public InputType InputType => SteamInput.Internal.GetInputTypeForHandle(Handle);

    /// <summary>
    ///     Reconfigure the controller to use the specified action set (ie 'Menu', 'Walk' or 'Drive')
    ///     This is cheap, and can be safely called repeatedly. It's often easier to repeatedly call it in
    ///     our state loops, instead of trying to place it in all of your state transitions.
    /// </summary>
    public string ActionSet {
        set => SteamInput.Internal.ActivateActionSet(Handle, SteamInput.Internal.GetActionSetHandle(value));
    }

    public void DeactivateLayer(string layer) {
        SteamInput.Internal.DeactivateActionSetLayer(Handle, SteamInput.Internal.GetActionSetHandle(layer));
    }

    public void ActivateLayer(string layer) {
        SteamInput.Internal.ActivateActionSetLayer(Handle, SteamInput.Internal.GetActionSetHandle(layer));
    }

    public void ClearLayers() {
        SteamInput.Internal.DeactivateAllActionSetLayers(Handle);
    }


    /// <summary>
    ///     Returns the current state of the supplied digital game action
    /// </summary>
    public DigitalState GetDigitalState(string actionName) {
        return SteamInput.Internal.GetDigitalActionData(Handle, SteamInput.GetDigitalActionHandle(actionName));
    }

    /// <summary>
    ///     Returns the current state of these supplied analog game action
    /// </summary>
    public AnalogState GetAnalogState(string actionName) {
        return SteamInput.Internal.GetAnalogActionData(Handle, SteamInput.GetAnalogActionHandle(actionName));
    }


    public override string ToString() {
        return $"{InputType}.{Handle.Value}";
    }


    public static bool operator ==(Controller a, Controller b) {
        return a.Equals(b);
    }

    public static bool operator !=(Controller a, Controller b) {
        return !(a == b);
    }

    public override bool Equals(object p) {
        return Equals((Controller)p);
    }

    public override int GetHashCode() {
        return Handle.GetHashCode();
    }

    public bool Equals(Controller p) {
        return p.Handle == Handle;
    }
}
