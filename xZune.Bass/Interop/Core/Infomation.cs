// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Infomation.cs
// Version: 20160215

using System;
using xZune.Bass.Interop.Core.Flags;

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     Retrieves the error code for the most recent BASS function call in the current thread.
    /// </summary>
    /// <returns>
    ///     If no error occurred during the last BASS function call then BASS_OK is returned, else one of the BASS_ERROR
    ///     values is returned.
    /// </returns>
    [BassFuction("BASS_ErrorGetCode")]
    public delegate ErrorCode GetErrorCode();

    /// <summary>
    ///     Frees all resources used by the output device, including all its samples, streams and MOD musics.
    /// </summary>
    /// <returns>
    ///     If successful, then TRUE is returned, else FALSE is returned.Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     This function should be called for all initialized devices before the program closes. It is not necessary to
    ///     individually free the samples/streams/musics as these are all automatically freed by this function.
    ///     <para />
    ///     When using multiple devices, the current thread's device setting (as set with BASS_SetDevice) determines which
    ///     device this function call applies to.
    /// </remarks>
    /// <seealso cref="Initialize" />
    [BassFuction("BASS_Free")]
    [BassError(ErrorCode.InitializeFail, "Initialize() has not been successfully called.")]
    [BassBooleanVerification]
    public delegate bool Free();

    /// <summary>
    ///     Retrieves the current CPU usage of BASS.
    /// </summary>
    /// <returns>The BASS CPU usage as a percentage. </returns>
    /// <remarks>
    ///     This function includes the time taken to render stream (HSTREAM) and MOD music (HMUSIC) channels during playback,
    ///     and any DSP functions set on those channels. It also includes any FX that are not using the "with FX flag" DX8
    ///     effect implementation. The rendering of some add-on stream formats may not be entirely included, if they use
    ///     additional decoding threads; see the add-on documentation for details.
    ///     <para />
    ///     This function does not strictly tell the CPU usage, but rather how timely the processing is. For example, if it
    ///     takes 10ms to generate 100ms of data, that would be 10%. If the reported usage gets to 100%, that means the channel
    ///     data is being played faster than it can be generated and buffer under-runs are likely to occur.
    ///     <para />
    ///     If automatic updating is disabled, then the value returned by this function is only updated after each call to
    ///     BASS_Update. BASS_ChannelUpdate usage is not included. The CPU usage of an individual channel is available via the
    ///     BASS_ATTRIB_CPU attribute.
    /// </remarks>
    [BassFuction("BASS_GetCPU")]
    public delegate float GetCpuUsage();

    /// <summary>
    ///     Retrieves the device setting of the current thread.
    /// </summary>
    /// <returns>
    ///     If successful, the device number is returned, else -1 is returned. Use <see cref="GetErrorCode" /> to get the
    ///     error code.
    /// </returns>
    [BassFuction("BASS_GetDevice")]
    [BassError(ErrorCode.InitializeFail,
        "Initialize() has not been successfully called; there are no initialized devices.")]
    [BassInt32Verification]
    public delegate int GetDevice();

    /// <summary>
    ///     Retrieves information on an output device.
    /// </summary>
    /// <param name="device">The device to get the information of... 0 = first. </param>
    /// <param name="info">Pointer to a structure to receive the information. </param>
    /// <returns>
    ///     If successful, then TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     This function can be used to enumerate the available devices for a setup dialog. Device 0 is always the "no sound"
    ///     device, so you should start at device 1 if you only want to list real output devices.
    /// </remarks>
    [BassFuction("BASS_GetDeviceInfo")]
    [BassError(ErrorCode.InvalidDevice, "device is invalid.")]
    [BassBooleanVerification]
    public delegate bool GetDeviceInfo(int device, ref DeviceInfo info);

    /// <summary>
    ///     Retrieves a pointer to a DirectSound object interface.
    /// </summary>
    /// <param name="obj">
    ///     The interface to retrieve. This can be a HCHANNEL, HMUSIC or HSTREAM handle, in which case an
    ///     IDirectSoundBuffer interface is returned, or one of the <see cref="DSoundObjectType" />.
    /// </param>
    /// <returns>
    ///     If successful, then a pointer to the requested object is returned, otherwise NULL is returned. Use
    ///     <see cref="GetErrorCode" /> to get the error code.
    /// </returns>
    /// <remarks>
    ///     This function allows those that are familiar with DirectSound to access the internal DirectSound object interfaces,
    ///     so that extra external functionality can be "plugged" into BASS. If you create any objects through a retrieved
    ///     interface, make sure you release the objects before calling <see cref="Free" />.
    ///     <para />
    ///     See the DirectX SDK for information on the DirectSound interfaces.
    ///     <para />
    ///     When using multiple devices, and requesting either the <see cref="DSoundObjectType" /> interfaces, the current thread's
    ///     device setting (as set with <see cref="SetDevice" />) determines which device this function call applies to.
    /// </remarks>
    [BassFuction("BASS_GetDSoundObject")]
    [BassError(ErrorCode.InitializeFail, "Initialize() has not been successfully called.")]
    [BassError(ErrorCode.IllegalParam, "object is invalid.")]
    [BassError(ErrorCode.NotAvailable, "The requested object is not available with the current device.")]
    [BassPointerVerification]
    public delegate IntPtr GetDSoundObject(DSoundObjectType obj);

    /// <summary>
    ///     Retrieves information on the device being used.
    /// </summary>
    /// <param name="info">Pointer to a structure to receive the information. </param>
    /// <returns>
    ///     If successful, TRUE is returned, else FALSE is returned. Use calling <see cref="GetErrorCode" /> to get the
    ///     error code.
    /// </returns>
    /// <remarks>
    ///     When using multiple devices, the current thread's device setting (as set with <see cref="SetDevice" />) determines
    ///     which device this function call applies to.
    /// </remarks>
    [BassFuction("BASS_GetInfo")]
    [BassError(ErrorCode.InitializeFail, "Initialize() has not been successfully called.")]
    [BassBooleanVerification]
    public delegate bool GetInfo(ref Info info);

    /// <summary>
    ///     Retrieves the version of BASS that is loaded.
    /// </summary>
    /// <returns>The BASS version. For example, 0x02040103 (hex), would be version 2.4.1.3 </returns>
    /// <remarks>
    ///     There is no guarantee that a previous or future version of BASS supports all the BASS functions that you are using,
    ///     so you should always use this function to make sure the correct version is loaded. It is safe to assume that future
    ///     revisions (indicated in the LOWORD) will be fully compatible.
    ///     <para />
    ///     The BASS API includes a BASSVERSION constant, which can be used to check that the loaded BASS.DLL matches the API
    ///     version used, ignoring revisions.
    /// </remarks>
    [BassFuction("BASS_GetVersion")]
    [BassUInt32Verification]
    public delegate uint GetVersion();

    /// <summary>
    ///     Retrieves the current master volume level.
    /// </summary>
    /// <returns>
    ///     If successful, the volume level is returned, else -1 is returned. Use <see cref="GetErrorCode" /> to get the
    ///     error code.
    /// </returns>
    /// <remarks>
    ///     When using multiple devices, the current thread's device setting (as set with BASS_SetDevice) determines which
    ///     device this function call applies to.
    /// </remarks>
    [BassFuction("BASS_GetVolume")]
    [BassError(ErrorCode.InitializeFail, "Initialize() has not been successfully called.")]
    [BassError(ErrorCode.NotAvailable, "There is no volume control when using the \"no sound\" device.")]
    [BassError(ErrorCode.Unknown, "Some other mystery problem! ")]
    [BassFloatVerification]
    public delegate float GetVolume();

    /// <summary>
    ///     Initializes an output device.
    /// </summary>
    /// <param name="device">
    ///     The device to use... -1 = default device, 0 = no sound, 1 = first real output device.
    ///     BASS_GetDeviceInfo can be used to enumerate the available devices.
    /// </param>
    /// <param name="freq">Output sample rate. </param>
    /// <param name="configs">Initialization configs. </param>
    /// <param name="windowHwnd">The application's main window... 0 = the desktop window (use this for console applications). </param>
    /// <param name="dSoundGuid">
    ///     Class identifier of the object to create, that will be used to initialize DirectSound... NULL
    ///     = use default.
    /// </param>
    /// <returns>
    ///     If the device was successfully initialized, TRUE is returned, else FALSE is returned. Use
    ///     <see cref="GetErrorCode" /> to get the error code.
    /// </returns>
    /// <remarks>
    ///     This function must be successfully called before using any sample, stream or MOD music functions. The recording
    ///     functions may be used without having called this function.
    ///     <para />
    ///     Playback is not possible with the "no sound" device, but it does allow the use of "decoding channels", eg. to
    ///     decode files.
    ///     <para />
    ///     Simultaneously using multiple devices is supported in the BASS API via a context switching system; instead of there
    ///     being an extra "device" parameter in the function calls, the device to be used is set prior to calling the
    ///     functions. <see cref="SetDevice" /> is used to switch the current device. When successful, BASS_Init automatically
    ///     sets the current thread's device to the one that was just initialized.
    ///     <para />
    ///     When using the default device (device = -1), <see cref="GetDevice" /> can be used to find out which device it was
    ///     mapped to.
    /// </remarks>
    [BassFuction("BASS_Init")]
    [BassError(ErrorCode.DirectXError, "DirectX (or ALSA on Linux or OpenSL ES on Android) is not installed. ")]
    [BassError(ErrorCode.InvalidDevice, "device is invalid. ")]
    [BassError(ErrorCode.Already,
        "The device has already been initialized. Free() must be called before it can be initialized again.")]
    [BassError(ErrorCode.IncorrectFormat,
        "The specified format is not supported by the device. Try changing the freq and flags parameters. ")]
    [BassError(ErrorCode.BadMemory, "There is insufficient memory. ")]
    [BassError(ErrorCode.No3D, "Could not initialize 3D support. ")]
    [BassError(ErrorCode.Unknown, "Some other mystery problem! ")]
    [BassBooleanVerification]
    public delegate bool Initialize(
        int device, uint freq, InitializationConfig configs, IntPtr windowHwnd, IntPtr dSoundGuid);

    /// <summary>
    ///     Stops the output, pausing all musics/samples/streams on it.
    /// </summary>
    /// <returns>
    ///     If successful, then TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     Use BASS_Start to resume the output and paused channels.
    ///     <para />
    ///     When using multiple devices, the current thread's device setting (as set with BASS_SetDevice) determines which
    ///     device this function call applies to.
    /// </remarks>
    [BassFuction("BASS_Pause")]
    [BassError(ErrorCode.InitializeFail, "Initialize() has not been successfully called.")]
    [BassBooleanVerification]
    public delegate bool Pause();

    /// <summary>
    ///     Sets the device to use for subsequent calls in the current thread.
    /// </summary>
    /// <param name="device">The device to use... 0 = no sound, 1 = first real output device. </param>
    /// <returns>
    ///     If successful, then TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     Simultaneously using multiple devices is supported in the BASS API via a context switching system; instead of there
    ///     being an extra "device" parameter in the function calls, the device to be used is set prior to calling the
    ///     functions. The device setting is local to the current thread, so calling functions with different devices
    ///     simultaneously in multiple threads is not a problem.
    ///     <para />
    ///     When one of the above functions (or BASS_GetDevice) is called, BASS will check the current thread's device setting,
    ///     and if no device is selected (or the selected device is not initialized), BASS will automatically select the lowest
    ///     device that is initialized. This means that when using a single device, there is no need to use this function; BASS
    ///     will automatically use the device that is initialized. Even if you free the device, and initialize another, BASS
    ///     will automatically switch to the one that is initialized.
    /// </remarks>
    [BassFuction("BASS_SetDevice")]
    [BassError(ErrorCode.InitializeFail, "The device has not been initialized. ")]
    [BassError(ErrorCode.InvalidDevice, "device is invalid. ")]
    [BassBooleanVerification]
    public delegate bool SetDevice(int device);

    /// <summary>
    ///     Sets the output master volume.
    /// </summary>
    /// <param name="volume">The volume level... 0 (silent) to 1 (max). </param>
    /// <returns>
    ///     If successful, then TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     The actual volume level may not be exactly the same as requested, due to underlying precision differences.
    ///     BASS_GetVolume can be used to confirm what the volume is.
    ///     <para />
    ///     When using multiple devices, the current thread's device setting (as set with <see cref="SetDevice" />) determines
    ///     which device this function call applies to.
    /// </remarks>
    [BassFuction("BASS_SetVolume")]
    [BassError(ErrorCode.InitializeFail, "Initialize() has not been successfully called.")]
    [BassError(ErrorCode.IllegalParam, "volume is invalid. ")]
    [BassError(ErrorCode.NotAvailable, "There is no volume control when using the \"no sound\" device.")]
    [BassError(ErrorCode.Unknown, "Some other mystery problem! ")]
    [BassBooleanVerification]
    public delegate bool SetVolume(float volume);

    /// <summary>
    ///     Starts (or resumes) the output.
    /// </summary>
    /// <returns>
    ///     If successful, then TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     The output is automatically started by <see cref="Initialize" />, so there is no need to use this function unless
    ///     you have stopped or paused the output.
    ///     <para />
    ///     When using multiple devices, the current thread's device setting (as set with <see cref="SetDevice" />) determines
    ///     which device this function call applies to.
    /// </remarks>
    [BassFuction("BASS_Start")]
    [BassError(ErrorCode.InitializeFail, "Initialize() has not been successfully called.")]
    [BassBooleanVerification]
    public delegate bool Start();

    /// <summary>
    ///     Stops the output, stopping all musics/samples/streams on it.
    /// </summary>
    /// <returns>
    ///     If successful, then TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     This function can be used after <see cref="Pause" /> to stop the paused channels, so that they will not be resumed
    ///     the next time <see cref="Start" /> is called.
    ///     <para />
    ///     When using multiple devices, the current thread's device setting (as set with <see cref="SetDevice" />) determines
    ///     which device this function call applies to.
    /// </remarks>
    [BassFuction("BASS_Stop")]
    [BassError(ErrorCode.InitializeFail, "Initialize() has not been successfully called.")]
    [BassBooleanVerification]
    public delegate bool Stop();

    /// <summary>
    ///     Updates the HSTREAM and HMUSIC channel playback buffers.
    /// </summary>
    /// <param name="length">The amount of data to render, in milliseconds. </param>
    /// <returns>
    ///     If successful, then TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     When automatic updating is disabled, this function or <see cref="ChannelUpdate" /> needs to be used to keep the
    ///     playback buffers updated. The length parameter should include some safety margin, in case the next update cycle
    ///     gets delayed. For example, if calling this function every 100ms, 200 would be a reasonable length parameter.
    /// </remarks>
    [BassFuction("BASS_Update")]
    [BassError(ErrorCode.NotAvailable, "Updating is already in progress. ")]
    [BassBooleanVerification]
    public delegate bool Update(int length);
}