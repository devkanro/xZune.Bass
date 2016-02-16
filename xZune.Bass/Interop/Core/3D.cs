// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: 3D.cs
// Version: 20160216

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     Applies changes made to the 3D system.
    /// </summary>
    /// <remarks>
    ///     This function must be called to apply any changes made with <see cref="Set3DFactors" />,
    ///     <see cref="Set3DPosition" />, <see cref="ChannelSet3DAttributes" /> or <see cref="ChannelSet3DPosition" />. This
    ///     allows multiple changes to be synchronized, and also improves performance.
    ///     This function applies 3D changes on all the initialized devices. There is no need to re-call it for each individual
    ///     device when using multiple devices.
    ///     <para />
    /// </remarks>
    [BassFuction("BASS_Apply3D")]
    public delegate void Apply3D();

    /// <summary>
    ///     Retrieves the factors that affect the calculations of 3D sound.
    /// </summary>
    /// <param name="distf">The distance factor... NULL = don't retrieve it. </param>
    /// <param name="rollf">The rolloff factor... NULL = don't retrieve it. </param>
    /// <param name="doppf">The doppler factor... NULL = don't retrieve it. </param>
    /// <returns>
    ///     If successful, then TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     When using multiple devices, the current thread's device setting (as set with <see cref="SetDevice" />) determines
    ///     which device this function call applies to.
    /// </remarks>
    [BassFuction("BASS_Get3DFactors")]
    [BassError(ErrorCode.InitializeFail, "Initialize() has not been successfully called.")]
    [BassError(ErrorCode.No3D, "The device was not initialized with 3D support.")]
    [BassBooleanVerification]
    public delegate bool Get3DFactors(ref float distf, ref float rollf, ref float doppf);

    /// <summary>
    ///     Retrieves the position, velocity, and orientation of the listener.
    /// </summary>
    /// <param name="pos">The position of the listener... NULL = don't retrieve it. </param>
    /// <param name="vel">The listener's velocity... NULL = don't retrieve it. </param>
    /// <param name="front">The direction that the listener's front is pointing... NULL=don't retrieve it. </param>
    /// <param name="top">The direction that the listener's top is pointing... NULL = don't retrieve it. </param>
    /// <returns>
    ///     If successful, then TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     The front and top parameters must both be retrieved in a single call, they cannot be retrieved individually.
    ///     When using multiple devices, the current thread's device setting (as set with <see cref="SetDevice" />) determines
    ///     which device this function call applies to.
    ///     <para />
    /// </remarks>
    [BassFuction("BASS_Get3DPosition")]
    [BassError(ErrorCode.InitializeFail, "Initialize() has not been successfully called.")]
    [BassError(ErrorCode.No3D, "The device was not initialized with 3D support.")]
    [BassBooleanVerification]
    public delegate bool Get3DPosition(ref Vector3 pos, ref Vector3 vel, ref Vector3 front, ref Vector3 top);

    /// <summary>
    ///     Sets the factors that affect the calculations of 3D sound.
    /// </summary>
    /// <param name="distf">
    ///     The distance factor... 0 or less = leave current... examples: 1.0 = use meters, 0.9144 = use yards,
    ///     0.3048 = use feet. By default BASS measures distances in meters, you can change this setting if you are using a
    ///     different unit of measurement.
    /// </param>
    /// <param name="rollf">
    ///     The rolloff factor, how fast the sound quietens with distance... 0.0 (min) - 10.0 (max), less than
    ///     0.0 = leave current... examples: 0.0 = no rolloff, 1.0 = real world, 2.0 = 2x real.
    /// </param>
    /// <param name="doppf">
    ///     The doppler factor... 0.0 (min) - 10.0 (max), less than 0.0 = leave current... examples: 0.0 = no
    ///     doppler, 1.0 = real world, 2.0 = 2x real. The doppler effect is the way a sound appears to change pitch when it is
    ///     moving towards or away from you. The listener and sound velocity settings are used to calculate this effect, this
    ///     doppf value can be used to lessen or exaggerate the effect.
    /// </param>
    /// <returns>
    ///     If successful, then TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     As with all 3D functions, use BASS_Apply3D to apply the changes.
    ///     When using multiple devices, the current thread's device setting (as set with <see cref="SetDevice" />) determines
    ///     which device this function call applies to.
    ///     <para />
    /// </remarks>
    [BassFuction("BASS_Set3DFactors")]
    [BassError(ErrorCode.InitializeFail, "Initialize() has not been successfully called.")]
    [BassError(ErrorCode.No3D, "The device was not initialized with 3D support.")]
    [BassBooleanVerification]
    public delegate bool Set3DFactors(float distf, float rollf, float doppf);

    /// <summary>
    ///     Sets the position, velocity, and orientation of the listener (ie. the player).
    /// </summary>
    /// <param name="pos">The position of the listener... NULL = leave current. </param>
    /// <param name="vel">
    ///     The listener's velocity in units (as set with BASS_Set3DFactors) per second... NULL = leave current.
    ///     This is only used to calculate the doppler effects, and in no way affects the listener's position.
    /// </param>
    /// <param name="front">
    ///     The direction that the listener's front is pointing... NULL = leave current. This is automatically
    ///     normalized.
    /// </param>
    /// <param name="top">
    ///     The direction that the listener's top is pointing... NULL = leave current. This is automatically
    ///     normalized, and adjusted to be at a right-angle to the front vector if necessary.
    /// </param>
    /// <returns>
    ///     If successful, then TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     The front and top parameters must both be set in a single call, they cannot be set individually. As with all 3D
    ///     functions, use BASS_Apply3D to apply the changes.
    ///     When using multiple devices, the current thread's device setting (as set with BASS_SetDevice) determines which
    ///     device this function call applies to.
    ///     <para />
    /// </remarks>
    [BassFuction("BASS_Set3DPosition")]
    [BassError(ErrorCode.InitializeFail, "Initialize() has not been successfully called.")]
    [BassError(ErrorCode.No3D, "The device was not initialized with 3D support.")]
    [BassBooleanVerification]
    public delegate bool Set3DPosition(ref Vector3 pos, ref Vector3 vel, ref Vector3 front, ref Vector3 top);
}