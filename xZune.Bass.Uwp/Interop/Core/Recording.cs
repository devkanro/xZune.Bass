// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Recording.cs
// Version: 20160216

using System;
using xZune.Bass.Interop.Flags;

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     Frees all resources used by the recording device.
    /// </summary>
    /// <returns>
    ///     If successful, then TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     This function should be called for all initialized recording devices before your program exits.
    ///     <para />
    ///     When using multiple recording devices, the current thread's device setting (as set with
    ///     <see cref="RecordSetDevice" />) determines which device this function call applies to.
    /// </remarks>
    [BassFunction("BASS_RecordFree")]
    [BassError(ErrorCode.InitializeFail, "RecordInit() has not been successfully called.")]
    [BassBooleanVerification]
    public delegate bool RecordFree();

    /// <summary>
    ///     Retrieves the recording device setting of the current thread.
    /// </summary>
    /// <returns>
    ///     If successful, the device number is returned, else -1 is returned. Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    [BassFunction("BASS_RecordGetDevice")]
    [BassError(ErrorCode.InitializeFail,
        "RecordInit() has not been successfully called; there are no initialized devices.")]
    [BassInt32Verification]
    public delegate int RecordGetDevice();

    /// <summary>
    ///     Retrieves information on a recording device.
    /// </summary>
    /// <param name="device">The device to get the information of... 0 = first. </param>
    /// <param name="info">Pointer to a structure to receive the information. </param>
    /// <returns>
    ///     If successful, then TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     This function can be used to enumerate the available devices for a setup dialog.
    /// </remarks>
    [BassFunction("BASS_RecordGetDeviceInfo")]
    [BassError(ErrorCode.DirectXError, "A sufficient version of DirectX is not installed.")]
    [BassError(ErrorCode.InvalidDevice, "device is invalid.")]
    [BassBooleanVerification]
    public delegate bool RecordGetDeviceInfo(int device, ref DeviceInfo info);

    /// <summary>
    ///     Retrieves information on the recording device being used.
    /// </summary>
    /// <param name="info">Pointer to a structure to receive the information. </param>
    /// <returns>
    ///     If successful, TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to get the error code.
    /// </returns>
    [BassFunction("BASS_RecordGetInfo")]
    [BassError(ErrorCode.InitializeFail, "RecordInit() has not been successfully called.")]
    [BassBooleanVerification]
    public delegate bool RecordGetInfo(ref RecordInfo info);

    /// <summary>
    ///     Retrieves the current settings of a recording input source.
    /// </summary>
    /// <param name="input">The input to get the settings of... 0 = first, -1 = master. </param>
    /// <param name="volume">Pointer to a variable to receive the volume... NULL = don't retrieve the volume. </param>
    /// <returns>
    ///     If an error occurs, -1 is returned, Use <see cref="GetErrorCode" /> to get the error code. If successful, then the
    ///     settings are returned. The BASS_INPUT_OFF flag will be set if the input is disabled, otherwise the input is
    ///     enabled. The type of input is also indicated in the high 8 bits (use BASS_INPUT_TYPE_MASK to test) of the return
    ///     value, and can be one of the following. If the volume is requested but not available, volume will receive -1.
    /// </returns>
    [BassFunction("BASS_RecordGetInput")]
    [BassError(ErrorCode.InitializeFail, "RecordInit() has not been successfully called.")]
    [BassError(ErrorCode.IllegalParam, "input is invalid.")]
    [BassError(ErrorCode.NotAvailable, "A master input is not available.")]
    [BassError(ErrorCode.Unknown, "Some other mystery problem!")]
    [BassInt32Verification]
    public delegate RecordInputType RecordGetInput(int input, ref float volume);

    /// <summary>
    ///     Retrieves the text description of a recording input source.
    /// </summary>
    /// <param name="input">The input to get the description of... 0 = first, -1 = master. </param>
    /// <returns>
    ///     If successful, then a pointer to the description is returned, else NULL is returned. Use
    ///     <see cref="GetErrorCode" /> to get the error code.
    /// </returns>
    [BassFunction("BASS_RecordGetInputName")]
    [BassError(ErrorCode.InitializeFail, "RecordInit() has not been successfully called.")]
    [BassError(ErrorCode.IllegalParam, "input is invalid.")]
    [BassError(ErrorCode.NotAvailable, "A master input is not available.")]
    [BassPointerVerification]
    public delegate IntPtr RecordGetInputName(int input);

    /// <summary>
    ///     Initializes a recording device.
    /// </summary>
    /// <param name="device">
    ///     The device to use... -1 = default device, 0 = first. BASS_RecordGetDeviceInfo can be used to
    ///     enumerate the available devices.
    /// </param>
    /// <returns>
    ///     If successful, TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to get the error code.
    /// </returns>
    /// <remarks>
    ///     This function must be successfully called before using the recording features.
    ///     Simultaneously using multiple devices is supported in the BASS API via a context switching system; instead of there
    ///     being an extra "device" parameter in the function calls, the device to be used is set prior to calling the
    ///     functions. BASS_RecordSetDevice is used to switch the current recording device. When successful, BASS_RecordInit
    ///     automatically sets the current thread's device to the one that was just initialized.
    ///     <para />
    ///     When using the default device (device = -1), <see cref="RecordGetDevice" /> can be used to find out which device it
    ///     was mapped to.
    ///     <para />
    /// </remarks>
    [BassFunction("BASS_RecordInit")]
    [BassError(ErrorCode.DirectXError, "A sufficient version of DirectX (or ALSA) is not installed.")]
    [BassError(ErrorCode.InvalidDevice, "device is invalid.")]
    [BassError(ErrorCode.Already,
        "The device has already been initialized. BASS_RecordFree must be called before it can be initialized again.")]
    [BassError(ErrorCode.DriverError, "There is no available device driver.")]
    [BassBooleanVerification]
    public delegate bool RecordInit(int device);

    /// <summary>
    ///     Sets the recording device to use for subsequent calls in the current thread.
    /// </summary>
    /// <param name="device">The device to use... 0 = first. </param>
    /// <returns>
    ///     If successful, then TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     Simultaneously using multiple devices is supported in the BASS API via a context switching system; instead of there
    ///     being an extra "device" parameter in the function calls, the device to be used is set prior to calling the
    ///     functions. The device setting is local to the current thread, so calling functions with different devices
    ///     simultaneously in multiple threads is not a problem.
    ///     The functions that use the recording device selection are the following: BASS_RecordFree, BASS_RecordGetInfo,
    ///     BASS_RecordGetInput, BASS_RecordGetInputName, BASS_RecordSetInput, BASS_RecordStart.
    ///     <para />
    ///     When one of the above functions (or <see cref="RecordGetDevice" />) is called, BASS will check the current thread's
    ///     recording device setting, and if no device is selected (or the selected device is not initialized), BASS will
    ///     automatically select the lowest device that is initialized. This means that when using a single device, there is no
    ///     need to use this function; BASS will automatically use the device that's initialized. Even if you free the device,
    ///     and initialize another, BASS will automatically switch to the one that is initialized.
    ///     <para />
    /// </remarks>
    [BassFunction("BASS_RecordSetDevice")]
    [BassError(ErrorCode.InvalidDevice, "device is invalid.")]
    [BassError(ErrorCode.InitializeFail, "The device has not been initialized.")]
    [BassBooleanVerification]
    public delegate bool RecordSetDevice(int device);

    /// <summary>
    ///     Adjusts the settings of a recording input source.
    /// </summary>
    /// <param name="input">The input to adjust the settings of... 0 = first, -1 = master. </param>
    /// <param name="status">The new setting... a combination of these flags. </param>
    /// <param name="volume">The volume level... 0 (silent) to 1 (max), less than 0 = leave current. </param>
    /// <returns>
    ///     If successful, TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to get the error code.
    /// </returns>
    /// <remarks>
    ///     The actual volume level may not be exactly the same as requested, due to underlying precision differences.
    ///     BASS_RecordGetInput can be used to confirm what the volume is.
    ///     The volume curve used by this function is always linear; the BASS_CONFIG_CURVE_VOL config option setting has no
    ///     effect on this.
    ///     <para />
    ///     Changes made by this function are system-wide, ie. other software using the device will be affected by it.
    ///     <para />
    /// </remarks>
    [BassFunction("BASS_RecordSetInput")]
    [BassError(ErrorCode.InitializeFail, "RecordInit() has not been successfully called.")]
    [BassError(ErrorCode.IllegalParam, "input or volume is invalid.")]
    [BassError(ErrorCode.NotAvailable,
        "The input does not have the necessary controls to apply the flags and/or volume. If attempting to set both at the same time, try separating them to determine which is unavailable."
        )]
    [BassError(ErrorCode.Unknown, "Some other mystery problem!")]
    [BassBooleanVerification]
    public delegate bool RecordSetInput(int input, RecordInputStatus status, float volume);

    /// <summary>
    ///     Starts recording.
    /// </summary>
    /// <param name="freq">The sample rate to record at. </param>
    /// <param name="chans">The number of channels... 1 = mono, 2 = stereo, etc. </param>
    /// <param name="configs">A combination of these flags. </param>
    /// <param name="proc">
    ///     The user defined function to receive the recorded sample data... can be NULL if you do not wish to
    ///     use a callback.
    /// </param>
    /// <param name="user">User instance data to pass to the callback function. </param>
    /// <returns>
    ///     If successful, the new recording's handle is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to
    ///     get the error code.
    /// </returns>
    /// <remarks>
    ///     Use BASS_ChannelStop to stop the recording and free its resources. BASS_ChannelPause can be used to pause the
    ///     recording; it can also be started in a paused state via the BASS_RECORD_PAUSE flag, which allows DSP/FX to be set
    ///     on it before any data reaches the callback function.
    ///     The sample data will generally arrive from the recording device in blocks rather than in a continuous stream, so
    ///     when specifying a very short period between callbacks, some calls may be skipped due to there being no new data
    ///     available since the last call.
    ///     <para />
    ///     When not using a callback (proc = NULL), the recorded data is instead retrieved via <see cref="ChannelGetData." />
    ///     To keep latency at a minimum, the amount of data in the recording buffer should be monitored (also done via
    ///     <see cref="ChannelGetData." />, with the <see cref="SampleDataType.Available" /> flag) to check that there is not
    ///     too much data; freshly recorded data will only be retrieved after the older data in the buffer is.
    ///     <para />
    /// </remarks>
    [BassFunction("BASS_RecordStart")]
    [BassError(ErrorCode.InitializeFail, "RecordInit() has not been successfully called.")]
    [BassError(ErrorCode.Busy,
        "The device is busy. An existing recording may need to be stopped before starting another one.")]
    [BassError(ErrorCode.NotAvailable,
        "The recording device is not available. Another application may already be recording with it, or it could be a half-duplex device that is currently being used for playback."
        )]
    [BassError(ErrorCode.IncorrectFormat,
        "The requested format is not supported. If using the BASS_SAMPLE_FLOAT flag, it could be that floating-point recording is not supported."
        )]
    [BassError(ErrorCode.BadMemory, "There is insufficient memory.")]
    [BassError(ErrorCode.Unknown, "Some other mystery problem!")]
    [BassPointerVerification]
    public delegate IntPtr RecordStart(
        uint freq, uint chans, uint configs, RecordHandler proc, IntPtr user);
}