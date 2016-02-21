// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Flac.cs
// Version: 20160221

using System;
using xZune.Bass.Interop.Core;
using xZune.Bass.Interop.Flags;

namespace xZune.Bass.Interop.Flac
{
    /// <summary>
    /// Creates a sample stream from a FLAC file. 
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
    /// All FLAC sample resolutions from 8 to 32-bit are supported, but the output will be restricted to 16-bit unless the <see cref="StreamCreateFileConfig.Float"/> flag is used. The file's original resolution is available via <see cref="ChannelGetInfo"/>. 
    ///     <para />
    /// Use <remarks>ChannelGetInfo</remarks> to retrieve information on the format (sample rate, resolution, channels) of the stream. The playback length of the stream can be retrieved using <see cref="ChannelGetLength"/>. Until the whole file has been streamed, whatever length the file's header says is returned, which may or may not be exact. 
    ///     <para />
    /// FLAC streams have a few different types of tag available via <see cref="ChannelGetTags"/>. The FLAC format uses Ogg Vorbis tags, so the standard BASS_TAG_OGG and BASS_TAG_VENDOR tags apply for those. Embedded cuesheets are supported and are available via the BASS_TAG_FLAC_CUE tag, which gives a pointer to a TAG_FLAC_CUE structure. Embedded images are also supported and are available via the BASS_TAG_FLAC_PICTURE+<index> tag (index=0 is the first picture), which gives a pointer to a TAG_FLAC_PICTURE structure. 
    ///     <para />
    /// To stream a file from the Internet, use BASS_FLAC_StreamCreateURL. To stream from other locations, see BASS_FLAC_StreamCreateFileUser. 
    /// </remarks>
    [BassFunction("BASS_FLAC_StreamCreateFile")]
    [BassPlugin(BassPlugin.BassFlac)]
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
    public delegate IntPtr FlacStreamCreateFile(
        bool memory, IntPtr file, UInt64 offset, UInt64 length, StreamCreateFileConfig configs);

    /// <summary>
    /// Creates a sample stream from a FLAC file via user callback functions. 
    /// </summary>
    /// <param name="system">File system to use, one of the <see cref="StreamFileSystemType" />.</param>
    /// <param name="configs">Configure of create a steam. </param>
    /// <param name="procs">The user defined file functions. </param>
    /// <param name="user">User instance data to pass to the callback functions. </param>
    /// <returns>
    ///     If successful, the new stream's handle is returned, else 0 is returned. Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    [BassFunction("BASS_FLAC_StreamCreateFileUser")]
    [BassPlugin(BassPlugin.BassFlac)]
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
    public delegate IntPtr FlacStreamCreateFileUser(
    StreamFileSystemType system, StreamCreateFileUserConfig configs, ref FileHandlers procs, IntPtr user);

    /// <summary>
    /// Creates a sample stream from an FLAC file on the Internet, optionally receiving the downloaded data in a callback. 
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
    [BassFunction("BASS_Flac_StreamCreateURL")]
    [BassPlugin(BassPlugin.BassFlac)]
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
    public delegate IntPtr FlacStreamCreateUrl(
        IntPtr url, int offset, StreamCreateUrlConfig configs, DownloadHandler proc, IntPtr user);
}