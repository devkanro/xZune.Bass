// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Stream.cs
// Version: 20160215

using System;
using xZune.Bass.Interop.Core.Flags;

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     Creates a user sample stream.
    /// </summary>
    /// <param name="freq">The default sample rate. The sample rate can be changed using BASS_ChannelSetAttribute. </param>
    /// <param name="chans">The number of channels... 1 = mono, 2 = stereo, 4 = quadraphonic, 6 = 5.1, 8 = 7.1. </param>
    /// <param name="configs">Configure of create a steam. </param>
    /// <param name="proc">The user defined stream writing function, or one of the <see cref="PresetStreamProcess" />. </param>
    /// <param name="user">User instance data to pass to the callback function. Unused when creating a dummy or push stream. </param>
    /// <returns>
    ///     If successful, the new stream's handle is returned, else 0 is returned. Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     Sample streams allow any sample data to be played through BASS, and are particularly useful for playing a large
    ///     amount of sample data without requiring a large amount of memory. If you wish to play a sample format that BASS
    ///     does not support, then you can create a stream and decode the sample data into it.
    ///     BASS can automatically stream MP3, MP2, MP1, OGG, WAV and AIFF files, using BASS_StreamCreateFile, and also from
    ///     HTTP and FTP servers, using BASS_StreamCreateURL. BASS_StreamCreateFileUser allows streaming from other sources
    ///     too.
    /// </remarks>
    [BassFuction("BASS_StreamCreate")]
    [BassError(ErrorCode.InitializeFail, "Initialize() has not been successfully called.")]
    [BassError(ErrorCode.NotAvailable,
        "Only decoding channels (BASS_STREAM_DECODE) are allowed when using the \"no sound\" device. The BASS_STREAM_AUTOFREE flag is also unavailable to decoding channels."
        )]
    [BassError(ErrorCode.IncorrectFormat,
        "The sample format is not supported by the device/drivers. If the stream is more than stereo or the BASS_SAMPLE_FLOAT flag is used, it could be that they are not supported."
        )]
    [BassError(ErrorCode.SpeakerError,
        "The specified SPEAKER flags are invalid. The device/drivers do not support them, they are attempting to assign a stereo stream to a mono speaker or 3D functionality is enabled."
        )]
    [BassError(ErrorCode.BadMemory, "There is insufficient memory.")]
    [BassError(ErrorCode.No3D, "Could not initialize 3D support.")]
    [BassError(ErrorCode.Unknown, "Some other mystery problem!")]
    [BassPointerVerification]
    public delegate IntPtr StreamCreate(int freq, int chans, StreamCreateConfig configs, IntPtr proc, IntPtr user);

    /// <summary>
    ///     Creates a sample stream from an MP3, MP2, MP1, OGG, WAV, AIFF or plug-in supported file.
    /// </summary>
    /// <param name="memory">TRUE = stream the file from memory. </param>
    /// <param name="file">Filename (memory = FALSE) or a memory location (memory = TRUE). </param>
    /// <param name="offset">File offset to begin streaming from (only used if memory = FALSE). </param>
    /// <param name="length">Data length... 0 = use all data up to the end of the file (if memory = FALSE). </param>
    /// <param name="configs">Configure of create a steam. </param>
    /// <returns>
    ///     If successful, the new stream's handle is returned, else 0 is returned. Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     BASS has built-in support for MPEG, OGG, WAV and AIFF files. Support for additional formats is available through
    ///     BASS_PluginLoad.
    ///     MPEG 1.0, 2.0 and 2.5 layer 3 (MP3) files are supported, layers 1 (MP1) and 2 (MP2) are also supported. Standard
    ///     RIFF and RF64 WAV files are supported. All PCM formats from 8 to 32-bit are supported in WAV and AIFF files, but
    ///     the output will be restricted to 16-bit unless the BASS_SAMPLE_FLOAT flag is used. 64-bit floating-point WAV and
    ///     AIFF files are also supported, but they are rendered in 16-bit or 32-bit floating-point depending on the flags. The
    ///     file's original resolution is available from BASS_ChannelGetInfo.
    ///     <para />
    ///     Chained OGG files containing multiple logical bit-streams are supported, but seeking within them is only fully
    ///     supported if the BASS_STREAM_PRESCAN flag is used (or the BASS_CONFIG_OGG_PRESCAN option is enabled) to have them
    ///     pre-scanned. Without pre-scanning, seeking will only be possible back to the start. The BASS_POS_OGG \"mode\" can
    ///     be used with BASS_ChannelGetLength to get the number of bit-streams and with BASS_ChannelSetPosition to seek to a
    ///     particular one. A BASS_SYNC_OGG_CHANGE sync can be set via BASS_ChannelSetSync to be informed of when a new
    ///     bit-streams begins during decoding/playback.
    ///     <para />
    ///     Multi-channel (ie. more than stereo) OGG, WAV and AIFF files are supported.
    ///     <para />
    ///     Use BASS_ChannelGetInfo to retrieve information on the format (sample rate, resolution, channels) of the stream.
    ///     The playback length of the stream can be retrieved using BASS_ChannelGetLength.
    ///     <para />
    ///     If length = 0 (use all data up to the end of the file), and the file length increases after creating the stream
    ///     (ie. the file is still being written), then BASS will play the extra data too, but the length returned by
    ///     BASS_ChannelGetLength will not be updated until the end is reached. The BASS_StreamGetFilePosition return values
    ///     will be updated during playback of the extra data though.
    ///     <para />
    ///     When streaming from memory (memory = TRUE), the memory must not be freed before the stream is freed. There may be
    ///     exceptions to that with some add-ons (see the documentation).
    ///     <para />
    ///     To stream a file from the Internet, use <see cref="StreamCreateUrl" />. To stream from other locations, see
    ///     <see cref="StreamCreateFileUser" />.
    ///     <para />
    /// </remarks>
    [BassFuction("BASS_StreamCreateFile")]
    [BassError(ErrorCode.InitializeFail, "Initialize() has not been successfully called.")]
    [BassError(ErrorCode.NotAvailable,
        "Only decoding channels (BASS_STREAM_DECODE) are allowed when using the \"no sound\" device. The BASS_STREAM_AUTOFREE flag is also unavailable to decoding channels."
        )]
    [BassError(ErrorCode.IllegalParam, "The length must be specified when streaming from memory.")]
    [BassError(ErrorCode.FileOpenFail, "The file could not be opened.")]
    [BassError(ErrorCode.IncorrectFileFromat, "The file's format is not recognized/supported.")]
    [BassError(ErrorCode.CodecError,
        "The file uses a codec that is not available/supported. This can apply to WAV and AIFF files, and also MP3 files when using the \"MP3 - free\" BASS version."
        )]
    [BassError(ErrorCode.IncorrectFormat,
        "The sample format is not supported by the device/drivers. If the stream is more than stereo or the BASS_SAMPLE_FLOAT flag is used, it could be that they are not supported."
        )]
    [BassError(ErrorCode.SpeakerError,
        "The specified SPEAKER flags are invalid. The device/drivers do not support them, they are attempting to assign a stereo stream to a mono speaker or 3D functionality is enabled."
        )]
    [BassError(ErrorCode.BadMemory, "There is insufficient memory.")]
    [BassError(ErrorCode.No3D, "Could not initialize 3D support.")]
    [BassError(ErrorCode.Unknown, "Some other mystery problem!")]
    [BassPointerVerification]
    public delegate IntPtr StreamCreateFile(
        bool memory, IntPtr file, UInt64 offset, UInt64 length, StreamCreateFileConfig configs);

    /// <summary>
    ///     Creates a sample stream from an MP3, MP2, MP1, OGG, WAV, AIFF or plug-in supported file via user callback
    ///     functions.
    /// </summary>
    /// <param name="system">File system to use, one of the <see cref="StreamFileSystemType" />.</param>
    /// <param name="configs">Configure of create a steam. </param>
    /// <param name="procs">The user defined file functions. </param>
    /// <param name="user">User instance data to pass to the callback functions. </param>
    /// <returns>
    ///     If successful, the new stream's handle is returned, else 0 is returned. Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     The buffered file system (STREAMFILE_BUFFER) is what is used by BASS_StreamCreateURL. As the name suggests, data
    ///     from the file is buffered so that it is readily available for decoding; BASS creates a thread dedicated to
    ///     "downloading" the data. This is ideal for when the data is coming from a source that has high latency, like the
    ///     Internet. It is not possible to seek in buffered file streams, until the download has reached the requested
    ///     position; it is not possible to seek at all if it is being streamed in blocks.
    ///     The push buffered file system (STREAMFILE_BUFFERPUSH) is the same, except that instead of the file data being
    ///     pulled from the FILEREADPROC function in a "download" thread, the data is pushed to the stream via
    ///     BASS_StreamPutFileData. A FILEREADPROC function is still required, to get the initial data used in the creation of
    ///     the stream.
    ///     <para />
    ///     The unbuffered file system (STREAMFILE_NOBUFFER) is what is used by BASS_StreamCreateFile. In this system, BASS
    ///     does not do any intermediate buffering; it simply requests data from the file as and when it needs it. This means
    ///     that reading (FILEREADPROC) must be quick, otherwise the decoding will be delayed and playback buffer underruns
    ///     (old data repeated) are a possibility. It is not so important for seeking (FILESEEKPROC) to be fast, as that is
    ///     generally not required during decoding, except when looping a file.
    ///     <para />
    ///     In all cases, BASS will automatically stall playback of the stream when insufficient data is available, and resume
    ///     it when enough data does become available.
    ///     <para />
    ///     A copy is made of the procs callback function table, so it does not need to persist beyond this function call.
    ///     <para />
    /// </remarks>
    [BassFuction("BASS_StreamCreateFileUser")]
    [BassError(ErrorCode.InitializeFail, "Initialize() has not been successfully called.")]
    [BassError(ErrorCode.NotAvailable,
        "Only decoding channels (BASS_STREAM_DECODE) are allowed when using the \"no sound\" device. The BASS_STREAM_AUTOFREE flag is also unavailable to decoding channels."
        )]
    [BassError(ErrorCode.IllegalParam, "system is not valid.")]
    [BassError(ErrorCode.IncorrectFileFromat, "The file's format is not recognized/supported.")]
    [BassError(ErrorCode.CodecError,
        "The file uses a codec that is not available/supported. This can apply to WAV and AIFF files, and also MP3 files when using the \"MP3-free\" BASS version."
        )]
    [BassError(ErrorCode.IncorrectFormat,
        "The sample format is not supported by the device/drivers. If the stream is more than stereo or the BASS_SAMPLE_FLOAT flag is used, it could be that they are not supported."
        )]
    [BassError(ErrorCode.SpeakerError,
        "The specified SPEAKER flags are invalid. The device/drivers do not support them, they are attempting to assign a stereo stream to a mono speaker or 3D functionality is enabled."
        )]
    [BassError(ErrorCode.BadMemory, "There is insufficient memory.")]
    [BassError(ErrorCode.No3D, "Could not initialize 3D support.")]
    [BassError(ErrorCode.Unknown, "Some other mystery problem!")]
    [BassPointerVerification]
    public delegate IntPtr StreamCreateFileUser(
        int system, StreamCreateFileUserConfig configs, ref FileHandlers procs, IntPtr user);

    /// <summary>
    ///     Creates a sample stream from an MP3, MP2, MP1, OGG, WAV, AIFF or plug-in supported file on the Internet, optionally
    ///     receiving the downloaded data in a callback function.
    /// </summary>
    /// <param name="url">
    ///     URL of the file to stream. Should begin with "http://" or "https://" or "ftp://", or another add-on
    ///     supported protocol. The URL can be followed by custom HTTP request headers to be sent to the server; the URL and
    ///     each header should be terminated with a carriage return and line feed ("\r\n").
    /// </param>
    /// <param name="offset">
    ///     File position to start streaming from. This is ignored by some servers, specifically when the
    ///     length is unknown/undefined.
    /// </param>
    /// <param name="configs">Configure of create a steam. </param>
    /// <param name="proc">Callback function to receive the file as it is downloaded... NULL = no callback. </param>
    /// <param name="user">User instance data to pass to the callback function. </param>
    /// <returns>
    ///     If successful, the new stream's handle is returned, else 0 is returned. Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     Use BASS_ChannelGetInfo to retrieve information on the format (sample rate, resolution, channels) of the stream.
    ///     The playback length of the stream can be retrieved using BASS_ChannelGetLength.
    ///     When playing the stream, BASS will stall the playback if there is insufficient data to continue playing. Playback
    ///     will automatically be resumed when sufficient data has been downloaded. BASS_ChannelIsActive can be used to check
    ///     if the playback is stalled, and the progress of the file download can be checked with BASS_StreamGetFilePosition.
    ///     <para />
    ///     When streaming in blocks (BASS_STREAM_BLOCK flag), be careful not to stop/pause the stream for too long, otherwise
    ///     the connection may timeout due to there being no activity and the stream will end prematurely.
    ///     <para />
    ///     When streaming from Shoutcast servers, metadata (track titles) may be sent by the server. The data can be retrieved
    ///     with BASS_ChannelGetTags. A BASS_SYNC_META sync can also be set via BASS_ChannelSetSync to be informed when
    ///     metadata is received. A BASS_SYNC_OGG_CHANGE sync can be used to be informed of when a new logical bit-stream
    ///     begins
    ///     in an Icecast/OGG stream.
    ///     <para />
    ///     When using an offset, the file length returned by BASS_StreamGetFilePosition can be used to check that it was
    ///     successful by comparing it with the original file length. Another way to check is to inspect the HTTP headers
    ///     retrieved with BASS_ChannelGetTags.
    ///     <para />
    ///     Custom HTTP request headers may be ignored by some plug-ins, notably BASSWMA.
    ///     <para />
    /// </remarks>
    [BassFuction("BASS_StreamCreateURL")]
    [BassError(ErrorCode.InitializeFail, "Initialize() has not been successfully called.")]
    [BassError(ErrorCode.NotAvailable,
        "Only decoding channels (BASS_STREAM_DECODE) are allowed when using the \"no sound\" device. The BASS_STREAM_AUTOFREE flag is also unavailable to decoding channels."
        )]
    [BassError(ErrorCode.NoNetwork, "No Internet connection could be opened. Can be caused by a bad proxy setting.")]
    [BassError(ErrorCode.IllegalParam, "URL is not a valid URL.")]
    [BassError(ErrorCode.SSLError, "SSL/HTTPS support is not available.")]
    [BassError(ErrorCode.TimeOut,
        "The server did not respond to the request within the timeout period, as set with the BASS_CONFIG_NET_TIMEOUT configure option."
        )]
    [BassError(ErrorCode.FileOpenFail, "The file could not be opened.")]
    [BassError(ErrorCode.IncorrectFileFromat, "The file's format is not recognized/supported.")]
    [BassError(ErrorCode.CodecError,
        "The file uses a codec that is not available/supported. This can apply to WAV and AIFF files, and also MP3 files when using the \"MP3-free\" BASS version."
        )]
    [BassError(ErrorCode.IncorrectFormat,
        "The sample format is not supported by the device/drivers. If the stream is more than stereo or the BASS_SAMPLE_FLOAT flag is used, it could be that they are not supported."
        )]
    [BassError(ErrorCode.SpeakerError,
        "The specified SPEAKER flags are invalid. The device/drivers do not support them, they are attempting to assign a stereo stream to a mono speaker or 3D functionality is enabled."
        )]
    [BassError(ErrorCode.BadMemory, "There is insufficient memory.")]
    [BassError(ErrorCode.No3D, "Could not initialize 3D support.")]
    [BassError(ErrorCode.Unknown, "Some other mystery problem!")]
    [BassPointerVerification]
    public delegate IntPtr StreamCreateUrl(
        IntPtr url, int offset, StreamCreateUrlConfig configs, DownloadHandler proc, IntPtr user);

    /// <summary>
    ///     Frees a sample stream's resources, including any sync/DSP/FX it has.
    /// </summary>
    /// <param name="handle">The stream handle. </param>
    /// <returns>
    ///     If successful, TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to get the error code.
    /// </returns>
    [BassFuction("BASS_StreamFree")]
    [BassError(ErrorCode.BadHandle, "handle is not valid.")]
    [BassBooleanVerification]
    public delegate bool StreamFree(IntPtr handle);

    /// <summary>
    ///     Retrieves the file position/status of a stream.
    /// </summary>
    /// <param name="handle">The stream handle. </param>
    /// <param name="mode">The file position/status to retrieve. One of the following. </param>
    /// <returns>
    ///     If successful, then the requested file position/status is returned, else -1 is returned. Use <see cref="GetErrorCode" /> to
    ///     get the error code.
    /// </returns>
    /// <remarks>
    ///     ID3 tags (both v1 and v2) and WAVE headers, as well as any other rubbish at the start of the file, are excluded
    ///     from the BASS_FILEPOS_CURRENT, BASS_FILEPOS_DOWNLOAD, and BASS_FILEPOS_END positions. This is useful for average
    ///     bit-rate calculations, but it means that they may not be actual file positions. The BASS_FILEPOS_START position can
    ///     be added to get the actual file position.
    ///     When streaming a file from the Internet or a "buffered" user file stream, the entire file is downloaded even if the
    ///     audio data ends before that, in case there are tags to be read. This means that the BASS_FILEPOS_DOWNLOAD position
    ///     may go beyond the BASS_FILEPOS_END position.
    ///     <para />
    ///     It is unwise to use the BASS_FILEPOS_CURRENT position for syncing purposes because it gives the position that is
    ///     being decoded, not the position that is being heard. Use BASS_ChannelGetPosition and/or BASS_ChannelSetSync
    ///     instead.
    ///     <para />
    /// </remarks>
    [BassFuction("BASS_StreamGetFilePosition")]
    [BassError(ErrorCode.BadHandle, "handle is not valid.")]
    [BassError(ErrorCode.NotFile, "The stream is not a file stream.")]
    [BassError(ErrorCode.NotAvailable, "The requested file position/status is not available.")]
    [BassUInt64Verification]
    public delegate UInt64 StreamGetFilePosition(IntPtr handle, FilePositionMode mode);

    /// <summary>
    ///     Adds sample data to a "push" stream.
    /// </summary>
    /// <param name="handle">The stream handle. </param>
    /// <param name="buffer">
    ///     Pointer to the sample data... NULL = allocate space in the queue buffer so that there is at least
    ///     length bytes of free space.
    /// </param>
    /// <param name="length">
    ///     The amount of data in bytes, optionally using the BASS_STREAMPROC_END flag to signify the end of
    ///     the stream. 0 can be used to just check how much data is queued.
    /// </param>
    /// <returns>
    ///     If successful, the amount of queued data is returned, else -1 is returned. Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     As much data as possible will be placed in the stream's playback buffer, and any remainder will be queued for when
    ///     more space becomes available, ie. as the buffered data is played. With a decoding channel, there is no playback
    ///     buffer, so all data is queued in that case. There is no limit to the amount of data that can be queued (besides
    ///     available memory); the queue buffer will be automatically enlarged as required to hold the data, but it can also be
    ///     enlarged in advance. The queue buffer is freed when the stream ends or is reset, eg. via BASS_ChannelPlay (with
    ///     restart = TRUE) or BASS_ChannelSetPosition (with pos = 0).
    ///     DSP/FX are applied when the data reaches the playback buffer, or the BASS_ChannelGetData call in the case of a
    ///     decoding channel.
    ///     <para />
    ///     Data should be provided at a rate sufficient to sustain playback. If the buffer gets exhausted, BASS will
    ///     automatically stall playback of the stream, until more data is provided. BASS_ChannelGetData (BASS_DATA_AVAILABLE)
    ///     can be used to check the buffer level, and <see cref="ChannelIsActive" /> can be used to check if playback has
    ///     stalled. A
    ///     BASS_SYNC_STALL sync can also be set via <see cref="ChannelSetSync" />, to be triggered upon playback stalling or
    ///     resuming.
    ///     <para />
    /// </remarks>
    [BassFuction("BASS_StreamPutData")]
    [BassError(ErrorCode.BadHandle, "handle is not valid.")]
    [BassError(ErrorCode.NotAvailable, "The stream is not using the push system.")]
    [BassError(ErrorCode.IllegalParam, "length is not valid, it must equate to a whole number of samples.")]
    [BassError(ErrorCode.Ended, "The stream has ended.")]
    [BassError(ErrorCode.BadMemory, "There is insufficient memory.")]
    [BassInt32Verification]
    public delegate int StreamPutData(IntPtr handle, IntPtr buffer, int length);

    /// <summary>
    ///     Adds data to a "push buffered" user file stream's buffer.
    /// </summary>
    /// <param name="handle">The stream handle. </param>
    /// <param name="buffer">Pointer to the file data. </param>
    /// <param name="length">The amount of data in bytes, or BASS_FILEDATA_END to end the file. </param>
    /// <returns>
    ///     If successful, the number of bytes read from buffer is returned, else -1 is returned. Use <see cref="GetErrorCode" /> to get
    ///     the error code.
    /// </returns>
    /// <remarks>
    ///     If there is not enough space in the stream's file buffer to receive all of the data, then only the amount that will
    ///     fit is read from buffer. BASS_StreamGetFilePosition can be used to check the amount of space in the buffer.
    ///     File data should be provided at a rate sufficient to sustain playback. If there is insufficient file data, and the
    ///     playback buffer is subsequently exhausted, BASS will automatically stall playback of the stream, until more data is
    ///     available. A BASS_SYNC_STALL sync can be set via BASS_ChannelSetSync, to be triggered upon playback stalling or
    ///     resuming.
    ///     <para />
    /// </remarks>
    [BassFuction("BASS_StreamPutFileData")]
    [BassError(ErrorCode.BadHandle, "handle is not valid.")]
    [BassError(ErrorCode.NotAvailable, "The stream is not using the BufferPut file system.")]
    [BassError(ErrorCode.Ended, "The file has ended.")]
    [BassInt32Verification]
    public delegate int StreamPutFileData(IntPtr handle, IntPtr buffer, int length);

    /// <summary>
    ///     Preset stream process function.
    /// </summary>
    public static class PresetStreamProcess
    {
        /// <summary>
        ///     End of user stream flag.
        /// </summary>
        public static uint StreamProcessEndFlag { get; } = 0x80000000;

        /// <summary>
        ///     Create a "dummy" stream. A dummy stream does not have any sample data of its own, but a decoding dummy stream (with
        ///     <see cref="StreamCreateConfig.Decode" /> flag) can be used to apply DSP/FX processing to any sample data, by
        ///     setting
        ///     DSP/FX on the stream and feeding the data through <see cref="ChannelGetData" />. The dummy stream should have the
        ///     same sample format as the data being fed through it.
        /// </summary>
        public static IntPtr Dummy { get; } = IntPtr.Zero;

        /// <summary>
        ///     Create a "push" stream. Instead of BASS pulling data from a STREAMPROC function, data is pushed to BASS via
        ///     <see cref="StreamPutData" />.
        /// </summary>
        public static IntPtr Push { get; } = (IntPtr) (-1);
    }
}