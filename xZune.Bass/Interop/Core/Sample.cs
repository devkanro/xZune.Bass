// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Sample.cs
// Version: 20160216

using System;
using xZune.Bass.Interop.Core.Flags;

namespace xZune.Bass.Interop.Core
{
    /// <summary> 
    /// Creates a new sample. 
    /// </summary>
    /// <param name="length">The sample's length, in bytes. </param>
    /// <param name="freq">The default sample rate. </param>
    /// <param name="chans">The number of channels... 1 = mono, 2 = stereo, etc. </param>
    /// <param name="max">Maximum number of simultaneous playbacks... 1 (min) - 65535 (max)... use one of the BASS_SAMPLE_OVER flags to choose the override decider, in the case of there being no free channel available for playback (ie. the sample is already playing max times). </param>
    /// <param name="config">Configure of sample. </param>
    /// <returns>
    /// If successful, the new sample's handle is returned, else 0 is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    /// <remarks>
    /// The sample's initial content is undefined. BASS_SampleSetData should be used to set the sample's data.
    /// Unless the BASS_SAMPLE_SOFTWARE flag is used, the sample will use hardware mixing if hardware resources are available. Use BASS_GetInfo to see if there are hardware mixing resources available, and which sample formats are supported by the hardware. The BASS_SAMPLE_VAM flag allows a sample to be played by both hardware and software, with the decision made when the sample is played rather than when it is loaded. A sample's VAM options are set via BASS_SampleSetInfo.
    /// <para/>
    /// To play a sample, first a channel must be obtained using BASS_SampleGetChannel, which can then be played using BASS_ChannelPlay.
    /// <para/>
    /// If you want to play a large or one-off sample, then it would probably be better to stream it instead with BASS_StreamCreate.
    /// <para/>
    /// </remarks>
    [BassFunction("BASS_SampleCreate")]
    [BassError(ErrorCode.InitializeFail, "Initialize() has not been successfully called.")]
    [BassError(ErrorCode.NotAvailable, "Sample functions are not available when using the \"no sound\" device.")]
    [BassError(ErrorCode.IllegalParam, "max is invalid.")]
    [BassError(ErrorCode.IncorrectFormat, "The sample format is not supported by the device/drivers.")]
    [BassError(ErrorCode.BadMemory, "There is insufficient memory.")]
    [BassError(ErrorCode.No3D, "Could not initialize 3D support.")]
    [BassError(ErrorCode.Unknown, "Some other mystery problem!")]
    [BassPointerVerificationAttribute]
    public delegate IntPtr SampleCreate(int length, int freq, int chans, int max, SampleConfig config);

    /// <summary> 
    /// Frees a sample's resources. 
    /// </summary>
    /// <param name="handle">The sample handle. </param>
    /// <returns>
    /// If successful, TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    [BassFunction("BASS_SampleFree")]
    [BassError(ErrorCode.BadHandle, "handle is not valid.")]
    [BassBooleanVerificationAttribute]
    public delegate bool SampleFree(IntPtr handle);

    /// <summary> 
    /// Creates/initializes a playback channel for a sample. 
    /// </summary>
    /// <param name="handle">Handle of the sample to play. </param>
    /// <param name="onlynew">Do not recycle/override one of the sample's existing channels? </param>
    /// <returns>
    /// If successful, the handle of the new channel is returned, else NULL is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    /// <remarks>
    /// Use BASS_SampleGetInfo and BASS_SampleSetInfo to set a sample's default attributes, which are used when creating a channel. After creation, a channel's attributes can be changed via BASS_ChannelSetAttribute, BASS_ChannelSet3DAttributes and BASS_ChannelSet3DPosition. BASS_Apply3D should be called before starting playback of a 3D sample, even if you just want to use the default settings.
    /// If a sample has a maximum number of simultaneous playbacks of 1 (the max parameter was 1 when calling BASS_SampleLoad or BASS_SampleCreate), then the HCHANNEL handle returned will be identical to the HSAMPLE handle. That means you can use the HSAMPLE handle with functions that usually require a HCHANNEL handle, but you must still call this function first to initialize the channel.
    /// <para/>
    /// When channel overriding has been enabled via a BASS_SAMPLE_OVER flag and there are multiple candidates for overriding (eg. with identical volume), the oldest of them will be chosen to make way for the new channel.
    /// <para/>
    /// A sample channel is automatically freed when it's overridden by a new channel, or when stopped by BASS_ChannelStop, BASS_SampleStop or BASS_Stop. If you wish to stop a channel and re-use it, BASS_ChannelPause should be used to pause it instead. Determining whether a channel still exists can be done by trying to use the handle in a function call. A list of all the sample's existing channels can also be retrieved via BASS_SampleGetChannels.
    /// <para/>
    /// The new channel will have an initial state of being paused (BASS_ACTIVE_PAUSED). This prevents the channel being claimed by another call of this function before it has been played, unless it gets overridden due to a lack of free channels.
    /// <para/>
    /// All of a sample's channels share the same sample data, and just have their own individual playback state information (volume/position/etc).
    /// <para/>
    /// </remarks>
    [BassFunction("BASS_SampleGetChannel")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid sample handle.")]
    [BassError(ErrorCode.NoChannel, "The sample has no free channels... the maximum number of simultaneous playbacks has been reached, and no BASS_SAMPLE_OVER flag was specified for the sample or onlynew = TRUE.")]
    [BassError(ErrorCode.TimeOut, "The sample's minimum time gap (BASS_SAMPLE) has not yet passed since the last channel was created.")]
    [BassPointerVerificationAttribute]
    public delegate IntPtr SampleGetChannel(IntPtr handle, bool onlynew);

    /// <summary> 
    /// Retrieves all a sample's existing channels. 
    /// </summary>
    /// <param name="handle">The sample handle. </param>
    /// <param name="channels">An array to put the sample's channel handles in. The array should be the same size as the sample's max setting when the sample was created, which can be retrieved using BASS_SampleGetInfo. NULL can be used to just check how many channels exist. </param>
    /// <returns>
    /// If successful, the number of existing channels is returned, else -1 is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    /// <remarks>
    /// To determine whether a particular sample channel still exists, it is simplest to just try it in a function call.
    /// </remarks>
    [BassFunction("BASS_SampleGetChannels")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid sample handle.")]
    [BassInt32VerificationAttribute]
    public delegate int SampleGetChannels(IntPtr handle, IntPtr channels);

    /// <summary> 
    /// Retrieves a copy of a sample's data. 
    /// </summary>
    /// <param name="handle">The sample handle. </param>
    /// <param name="buffer">Pointer to a buffer to receive the data. </param>
    /// <returns>
    /// If successful, TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    /// <remarks>
    /// The buffer must be big enough to receive the sample's data, the size of which can be retrieved via BASS_SampleGetInfo.
    /// </remarks>
    [BassFunction("BASS_SampleGetData")]
    [BassError(ErrorCode.BadHandle, "handle is not valid.")]
    [BassError(ErrorCode.Unknown, "Some other mystery problem!")]
    [BassBooleanVerificationAttribute]
    public delegate bool SampleGetData(IntPtr handle, IntPtr buffer);

    /// <summary> 
    /// Retrieves a sample's default attributes and other information. 
    /// </summary>
    /// <param name="handle">The sample handle. </param>
    /// <param name="info">Pointer to a structure to receive the sample information. </param>
    /// <returns>
    /// If successful, TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    /// <remarks>
    /// Use this function and <see cref="SampleSetInfo"/> to edit a sample's default attributes.
    /// </remarks>
    [BassFunction("BASS_SampleGetInfo")]
    [BassError(ErrorCode.BadHandle, "The handle is invalid.")]
    [BassBooleanVerificationAttribute]
    public delegate bool SampleGetInfo(IntPtr handle, ref SampleInfo info);

    /// <summary> 
    /// Loads a WAV, AIFF, MP3, MP2, MP1, OGG or plugin supported sample. 
    /// </summary>
    /// <param name="mem">TRUE = load the sample from memory. </param>
    /// <param name="file">Filename (mem = FALSE) or a memory location (mem = TRUE). </param>
    /// <param name="offset">File offset to load the sample from (only used if mem = FALSE). </param>
    /// <param name="length">Data length... 0 = use all data up to the end of file (if mem = FALSE). If length over-runs the end of the file, it will automatically be lowered to the end of the file. </param>
    /// <param name="max">Maximum number of simultaneous playbacks... 1 (min) - 65535 (max). Use one of the BASS_SAMPLE_OVER flags to choose the override decider, in the case of there being no free channel available for playback (ie. the sample is already playing max times). </param>
    /// <param name="config">Configure of load sample. </param>
    /// <returns>
    /// If successful, the loaded sample's handle is returned, else 0 is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    /// <remarks>
    /// This function supports the same file formats as BASS_StreamCreateFile does, including those supported via the plug-in system.
    /// Unless the BASS_SAMPLE_SOFTWARE flag is used, the sample will use hardware mixing if hardware resources are available. Use BASS_GetInfo to see if there are hardware mixing resources available, and which sample formats are supported by the hardware. The BASS_SAMPLE_VAM flag allows a sample to be played by both hardware and software, with the decision made when the sample is played rather than when it is loaded. A sample's VAM options are set via BASS_SampleSetInfo.
    /// <para/>
    /// To play a sample, first a channel must be obtained using BASS_SampleGetChannel, which can then be played using BASS_ChannelPlay.
    /// <para/>
    /// After loading a sample from memory (mem = TRUE), the memory can safely be discarded, as a copy is made.
    /// <para/>
    /// If you want to play a large or one-off sample, then it would probably be better to stream it instead with BASS_StreamCreateFile.
    /// <para/>
    /// </remarks>
    [BassFunction("BASS_SampleLoad")]
    [BassError(ErrorCode.InitializeFail, "Initialize() has not been successfully called.")]
    [BassError(ErrorCode.NotAvailable, "Sample functions are not available when using the \"no sound\" device.")]
    [BassError(ErrorCode.IllegalParam, "max and/or length is invalid. The length must be specified when loading from memory.")]
    [BassError(ErrorCode.FileOpenFail, "The file could not be opened.")]
    [BassError(ErrorCode.IncorrectFileFromat, "The file's format is not recognized/supported.")]
    [BassError(ErrorCode.CodecError, "The file uses a codec that is not available/supported. This can apply to WAV and AIFF files, and also MP3 files when using the \"MP3-free\" BASS version.")]
    [BassError(ErrorCode.IncorrectFormat, "The sample format is not supported by the device/drivers. If the sample is more than stereo or the BASS_SAMPLE_FLOAT flag is used, it could be that they are not supported.")]
    [BassError(ErrorCode.BadMemory, "There is insufficient memory.")]
    [BassError(ErrorCode.No3D, "Could not initialize 3D support.")]
    [BassError(ErrorCode.Unknown, "Some other mystery problem!")]
    [BassPointerVerificationAttribute]
    public delegate IntPtr SampleLoad(bool mem, IntPtr file, UInt64 offset, int length, int max, SampleLoadConfig config);

    /// <summary> 
    /// Sets a sample's data. 
    /// </summary>
    /// <param name="handle">The sample handle. </param>
    /// <param name="buffer">Pointer to the data. </param>
    /// <returns>
    /// If successful, TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    /// <remarks>
    /// The required length and format of the data can be retrieved via BASS_SampleGetInfo.
    /// A sample's data can be set at any time, including during playback.
    /// <para/>
    /// </remarks>
    [BassFunction("BASS_SampleSetData")]
    [BassError(ErrorCode.BadHandle, "handle is not valid.")]
    [BassError(ErrorCode.Unknown, "Some other mystery problem!")]
    [BassBooleanVerificationAttribute]
    public delegate bool SampleSetData(IntPtr handle, IntPtr buffer);

    /// <summary> 
    /// Sets a sample's default attributes. 
    /// </summary>
    /// <param name="handle">The sample handle. </param>
    /// <param name="info">Pointer to the sample information structure. </param>
    /// <returns>
    /// If successful, TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    /// <remarks>
    /// Use this function and BASS_SampleGetInfo to edit a sample's default attributes. Changing a sample's default attributes does not affect any existing channels, it only affects channels subsequently created via BASS_SampleGetChannel. The exception is the VAM settings, changes to that apply to all the sample's channels at their next playback (BASS_ChannelPlay). Use BASS_ChannelSetAttribute and BASS_ChannelSet3DAttributes to change the attributes of an existing sample channel.
    /// The sample's maximum number of simultaneous playbacks can be changed via the max member of the BASS_SAMPLE structure. If the new maximum is lower than the existing number of channels, the channels will remain existing until they are stopped.
    /// <para/>
    /// The length, origres and chans members of the BASS_SAMPLE structure cannot be modified; any changes are ignored. The BASS_SAMPLE_8BITS, BASS_SAMPLE_MONO, BASS_SAMPLE_3D, BASS_SAMPLE_MUTEMAX, BASS_SAMPLE_SOFTWARE and BASS_SAMPLE_VAM flags also cannot be changed.
    /// <para/>
    /// </remarks>
    [BassFunction("BASS_SampleSetInfo")]
    [BassError(ErrorCode.BadHandle, "The handle is invalid.")]
    [BassError(ErrorCode.IllegalParam, "The BASS_SAMPLE max value is invalid.")]
    [BassBooleanVerificationAttribute]
    public delegate bool SampleSetInfo(IntPtr handle, ref SampleInfo info);

    /// <summary> 
    /// Stops all instances of a sample. 
    /// </summary>
    /// <param name="handle">The sample handle. </param>
    /// <returns>
    /// If successful, TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    /// <remarks>
    /// If a sample is playing simultaneously multiple times, calling this function will stop them all, which is obviously simpler than calling BASS_ChannelStop multiple times.
    /// </remarks>
    [BassFunction("BASS_SampleStop")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid sample.")]
    [BassBooleanVerificationAttribute]
    public delegate bool SampleStop(IntPtr handle);
}