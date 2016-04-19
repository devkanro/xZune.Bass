// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Configure.cs
// Version: 20160215

using System;
using xZune.Bass.Interop.Flags;

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     Retrieves the value of a configure option.
    /// </summary>
    /// <param name="option">The option to get the value of... one of the following. </param>
    /// <returns>
    ///     If successful, the value of the requested configure option is returned, else -1 is returned. Use
    ///     <see cref="GetErrorCode" /> to get the error code.
    /// </returns>
    [BassFunction("BASS_GetConfig")]
    [BassError(ErrorCode.IllegalParam, "option is invalid.")]
    [BassInt32Verification]
    public delegate int GetConfig(ConfigureType option);

    /// <summary>
    ///     Retrieves the value of a pointer configure option.
    /// </summary>
    /// <param name="option">The option to set the value of... one of the following. </param>
    /// <returns>
    ///     If successful, the value of the requested configure option is returned, else NULL is returned. NULL may also be a
    ///     valid setting with some configure options, in which case the error code should be used to confirm whether it's an
    ///     error. Use <see cref="GetErrorCode" /> to get the error code.
    /// </returns>
    [BassFunction("BASS_GetConfigPtr")]
    [BassError(ErrorCode.IllegalParam, "option is invalid.")]
    public delegate IntPtr GetConfigPtr(PointerConfigureType option);

    /// <summary>
    ///     Sets the value of a configure option.
    /// </summary>
    /// <param name="option">The option to set the value of... one of the following. </param>
    /// <param name="value">The new option setting. See the option's documentation for details on the possible values. </param>
    /// <returns>
    ///     If successful, TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to get the error code.
    /// </returns>
    /// <remarks>
    ///     Some configure options have a restricted range of values, so the configure's actual value may not be the same as
    ///     requested if it was out of range. <see cref="GetConfig" /> can be used to confirm what the value is.
    ///     Configure options can be used at any time and are independent of initialization, ie. BASS_Init does not need to
    ///     have been called beforehand.
    ///     <para />
    ///     Where a configure option is shown to have a "BOOL" value, 0 (zero) is taken to be "FALSE" and anything else is
    ///     taken to be "TRUE".
    ///     <para />
    /// </remarks>
    [BassFunction("BASS_SetConfig")]
    [BassError(ErrorCode.IllegalParam, "option is invalid.")]
    [BassBooleanVerification]
    public delegate bool SetConfig(ConfigureType option, int value);

    /// <summary>
    ///     Sets the value of a pointer configure option.
    /// </summary>
    /// <param name="option">The option to set the value of... one of the following. </param>
    /// <param name="value">The new option setting. See the option's documentation for details on the possible values. </param>
    /// <returns>
    ///     If successful, TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to get the error code.
    /// </returns>
    /// <remarks>
    ///     Configure options can be used at any time and are independent of initialization, ie. BASS_Init does not need to
    ///     have been called beforehand.
    /// </remarks>
    [BassFunction("BASS_SetConfigPtr")]
    [BassError(ErrorCode.IllegalParam, "option is invalid.")]
    [BassBooleanVerification]
    public delegate bool SetConfigPtr(PointerConfigureType option, IntPtr value);
}