// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Aac.cs
// Version: 20160316

using System;
using xZune.Bass.Interop.Core;
using xZune.Bass.Interop.Flags;

namespace xZune.Bass.Interop.Aac
{
    /// <summary>
    ///     Creates a sample stream from a AAC file.
    /// </summary>
    /// <param name="memory">TRUE = stream the file from memory. </param>
    /// <param name="file">Filename (memory = FALSE) or a memory location (memory = TRUE). </param>
    /// <param name="offset">File offset to begin streaming from (only used if memory = FALSE). </param>
    /// <param name="length">Data length... 0 = use all data up to the end of the file (if memory = FALSE). </param>
    /// <param name="configs">Configure of create a steam. </param>
    /// <returns>
    ///     If successful, the new stream's handle is returned, else 0 is returned. Use BASS_ErrorGetCode to get the error
    ///     code.
    /// </returns>
    [BassFunction("BASS_AAC_StreamCreateFile")]
    [BassPlugin(BassPlugin.BassAac)]
    [BassError(ErrorCode.InitializeFail, "BASS_Init has not been successfully called.")]
    [BassError(ErrorCode.NotAvailable,
        "Only decoding channels (BASS_STREAM_DECODE) are allowed when using the \"no sound\" device. The BASS_STREAM_AUTOFREE flag is also unavailable to decoding channels."
        )]
    [BassError(ErrorCode.IllegalParam, "One or more of the parameters are invalid.")]
    [BassError(ErrorCode.FileOpenFail, "The file could not be opened.")]
    [BassError(ErrorCode.IncorrectFileFromat, "The file's format is not recognised/supported.")]
    [BassError(ErrorCode.CodecError,
        "There is no appropriate codec installed to decode the file. Try installing the latest Windows Media codecs.")]
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
    public delegate IntPtr AacStreamCreateFile(
        bool memory, IntPtr file, UInt64 offset, UInt64 length, AacStreamCreateFileConfig configs);

    /// <summary>
    ///     Creates a sample stream from a AAC file on the Internet, optionally receiving the downloaded data in a callback
    ///     function.
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
    ///     If successful, the new stream's handle is returned, else 0 is returned. Use <see cref="GetErrorCode" /> to get the
    ///     error
    ///     code.
    /// </returns>
    [BassFunction("BASS_AAC_StreamCreateUrl")]
    [BassPlugin(BassPlugin.BassAac)]
    [BassError(ErrorCode.InitializeFail, "BASS_Init has not been successfully called.")]
    [BassError(ErrorCode.NotAvailable,
        "Only decoding channels (BASS_STREAM_DECODE) are allowed when using the \"no sound\" device. The BASS_STREAM_AUTOFREE flag is also unavailable to decoding channels."
        )]
    [BassError(ErrorCode.IllegalParam, "One or more of the parameters are invalid.")]
    [BassError(ErrorCode.FileOpenFail, "The file could not be opened.")]
    [BassError(ErrorCode.IncorrectFileFromat, "The file's format is not recognised/supported.")]
    [BassError(ErrorCode.CodecError,
        "There is no appropriate codec installed to decode the file. Try installing the latest Windows Media codecs.")]
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
    public delegate IntPtr AacStreamCreateUrl(
        IntPtr url, int offset, AacStreamCreateUrlConfig configs, DownloadHandler proc, IntPtr user);

    /// <summary>
    ///     Creates a sample stream from a AAC file via user callback functions.
    /// </summary>
    /// <param name="system">File system to use, one of the following. STREAMFILE_NOBUFFER Unbuffered. </param>
    /// <param name="configs">Configure of create a steam. </param>
    /// <param name="procs">The user defined file functions. </param>
    /// <param name="user">User instance data to pass to the callback functions. </param>
    /// <returns>
    ///     If successful, the new stream's handle is returned, else 0 is returned. Use BASS_ErrorGetCode to get the error
    ///     code.
    /// </returns>
    [BassFunction("BASS_AAC_StreamCreateFileUser")]
    [BassPlugin(BassPlugin.BassAac)]
    [BassError(ErrorCode.InitializeFail, "BASS_Init has not been successfully called.")]
    [BassError(ErrorCode.NotAvailable,
        "Only decoding channels (BASS_STREAM_DECODE) are allowed when using the \"no sound\" device. The BASS_STREAM_AUTOFREE flag is also unavailable to decoding channels."
        )]
    [BassError(ErrorCode.IllegalParam, "system is not valid.")]
    [BassError(ErrorCode.IncorrectFileFromat, "The file's format is not recognised/supported.")]
    [BassError(ErrorCode.CodecError,
        "There is no appropriate codec installed to decode the file. Try installing the latest Windows Media codecs.")]
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
    public delegate IntPtr AacStreamCreateFileUser(
        StreamFileSystemType system, AacStreamCreateFileUserConfig configs, ref FileHandlers procs, IntPtr user);

    /// <summary>
    ///     Creates a sample stream from a MP4 file.
    /// </summary>
    /// <param name="memory">TRUE = stream the file from memory. </param>
    /// <param name="file">Filename (memory = FALSE) or a memory location (memory = TRUE). </param>
    /// <param name="offset">File offset to begin streaming from (only used if memory = FALSE). </param>
    /// <param name="length">Data length... 0 = use all data up to the end of the file (if memory = FALSE). </param>
    /// <param name="configs">Configure of create a steam. </param>
    /// <returns>
    ///     If successful, the new stream's handle is returned, else 0 is returned. Use BASS_ErrorGetCode to get the error
    ///     code.
    /// </returns>
    [BassFunction("BASS_MP4_StreamCreateFile")]
    [BassPlugin(BassPlugin.BassAac)]
    [BassError(ErrorCode.Mp4NoStream, "non-streamable due to MP4 atom order (\"MDAT\" before \"MOOV\").")]
    [BassError(ErrorCode.InitializeFail, "BASS_Init has not been successfully called.")]
    [BassError(ErrorCode.NotAvailable,
        "Only decoding channels (BASS_STREAM_DECODE) are allowed when using the \"no sound\" device. The BASS_STREAM_AUTOFREE flag is also unavailable to decoding channels."
        )]
    [BassError(ErrorCode.IllegalParam, "One or more of the parameters are invalid.")]
    [BassError(ErrorCode.FileOpenFail, "The file could not be opened.")]
    [BassError(ErrorCode.IncorrectFileFromat, "The file's format is not recognised/supported.")]
    [BassError(ErrorCode.CodecError,
        "There is no appropriate codec installed to decode the file. Try installing the latest Windows Media codecs.")]
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
    public delegate IntPtr Mp4StreamCreateFile(
        bool memory, IntPtr file, UInt64 offset, UInt64 length, AacStreamCreateFileConfig configs);

    /// <summary>
    ///     Creates a sample stream from a MP4 file via user callback functions.
    /// </summary>
    /// <param name="system">File system to use, one of the following. STREAMFILE_NOBUFFER Unbuffered. </param>
    /// <param name="configs">Configure of create a steam. </param>
    /// <param name="procs">The user defined file functions. </param>
    /// <param name="user">User instance data to pass to the callback functions. </param>
    /// <returns>
    ///     If successful, the new stream's handle is returned, else 0 is returned. Use BASS_ErrorGetCode to get the error
    ///     code.
    /// </returns>
    [BassFunction("BASS_MP4_StreamCreateFileUser")]
    [BassPlugin(BassPlugin.BassAac)]
    [BassError(ErrorCode.Mp4NoStream, "non-streamable due to MP4 atom order (\"MDAT\" before \"MOOV\").")]
    [BassError(ErrorCode.InitializeFail, "BASS_Init has not been successfully called.")]
    [BassError(ErrorCode.NotAvailable,
        "Only decoding channels (BASS_STREAM_DECODE) are allowed when using the \"no sound\" device. The BASS_STREAM_AUTOFREE flag is also unavailable to decoding channels."
        )]
    [BassError(ErrorCode.IllegalParam, "system is not valid.")]
    [BassError(ErrorCode.IncorrectFileFromat, "The file's format is not recognised/supported.")]
    [BassError(ErrorCode.CodecError,
        "There is no appropriate codec installed to decode the file. Try installing the latest Windows Media codecs.")]
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
    public delegate IntPtr Mp4StreamCreateFileUser(
        StreamFileSystemType system, AacStreamCreateFileUserConfig configs, ref FileHandlers procs, IntPtr user);
}