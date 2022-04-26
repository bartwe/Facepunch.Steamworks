using System;

namespace Steamworks;

/// <summary>
///     Prevent unity from stripping shit we depend on
///     https://docs.unity3d.com/Manual/ManagedCodeStripping.html
/// </summary>
sealed class PreserveAttribute : Attribute { }