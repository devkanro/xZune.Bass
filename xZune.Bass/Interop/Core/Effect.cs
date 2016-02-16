// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Effect.cs
// Version: 20160216

using System;

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     Retrieves the parameters of an effect.
    /// </summary>
    /// <param name="handle">The effect handle. </param>
    /// <param name="param">Pointer to the parameters structure to fill. The structure used depends on the effect type. </param>
    /// <returns>
    ///     If successful, TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    [BassFuction("BASS_FXGetParameters")]
    [BassError(ErrorCode.BadHandle, "handle is invalid.")]
    [BassBooleanVerification]
    public delegate bool FXGetParameters(IntPtr handle, IntPtr param);

    /// <summary>
    ///     Resets the state of an effect or all effects on a channel.
    /// </summary>
    /// <param name="handle">The effect or channel handle... a HFX, HSTREAM, HMUSIC, or HRECORD. </param>
    /// <returns>
    ///     If successful, TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    /// <remarks>
    ///     This function flushes the internal buffers of the effect(s). Effects are automatically reset by
    ///     <see cref="ChannelSetPosition"/>, except when called from a "mixtime" <see cref="SyncHandler"/>.
    /// </remarks>
    [BassFuction("BASS_FXReset")]
    [BassError(ErrorCode.BadHandle, "handle is invalid.")]
    [BassError(ErrorCode.Unknown, "Some other mystery problem!")]
    [BassBooleanVerification]
    public delegate bool FXReset(IntPtr handle);

    /// <summary>
    ///     Sets the parameters of an effect.
    /// </summary>
    /// <param name="handle">The effect handle. </param>
    /// <param name="param">Pointer to the parameters structure. The structure used depends on the effect type. </param>
    /// <returns>
    ///     If successful, TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    [BassFuction("BASS_FXSetParameters")]
    [BassError(ErrorCode.BadHandle, "handle is invalid.")]
    [BassError(ErrorCode.IllegalParam,
        "One or more of the parameters are invalid, make sure all the values are within the valid ranges.")]
    [BassError(ErrorCode.Unknown, "Some other mystery problem!")]
    [BassBooleanVerification]
    public delegate bool FXSetParameters(IntPtr handle, IntPtr param);
}