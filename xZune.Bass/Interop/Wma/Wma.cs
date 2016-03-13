// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Wma.cs
// Version: 20160313

using System;
using xZune.Bass.Interop.Core;
using xZune.Bass.Interop.Flags;

namespace xZune.Bass.Interop.Wma
{
    /// <summary>
    ///     Retrieves a pointer to the IWMReader interface of a WMA stream, or IWMWriter interface of a WMA encoder.
    /// </summary>
    /// <param name="handle">The WMA stream or encoder handle. </param>
    /// <returns>
    ///     If successful, then a pointer to the requested object is returned, otherwise NULL is returned. Use
    ///     BASS_ErrorGetCode to get the error code.
    /// </returns>
    /// <remarks>
    ///     This function allows those that are familiar with the Windows Media Format SDK to access the internal object
    ///     interface, for extra functionality. If you create any objects through a retrieved interface, make sure you release
    ///     the objects before calling BASS_StreamFree or BASS_WMA_EncodeClose.
    ///     When streaming local (not Internet) files, this function will usually actually return an IWMSyncReader interface
    ///     instead of an IWMReader interface. The type of interface can be determined by querying other interfaces from it,
    ///     eg. IWMReaderAdvanced.
    ///     <para />
    ///     See the Windows Media Format SDK for information on the IWMReader, IWMWriter, and associated interfaces.
    /// </remarks>
    [BassFunction("BASS_WMA_GetWMObject")]
    [BassPlugin(BassPlugin.BassWma)]
    [BassError(ErrorCode.BadHandle, "handle is not valid.")]
    public delegate IntPtr WmaGetWMObject(int handle);

    /// <summary>
    ///     Creates a sample stream from a WMA file or URL.
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
    /// <remarks>
    ///     Use BASS_ChannelGetInfo to retrieve information on the format (sample rate, resolution, channels) of the stream.
    ///     The bitrate (amongst other things) can be retrieved through BASS_ChannelGetTags (BASS_TAG_WMA), which will return a
    ///     pointer to a series of null-terminated UTF-8 strings, the final string ending with a double null. If the stream
    ///     contains mid-stream tags (script), the latest tag can be retrieved through BASS_ChannelGetTags (BASS_TAG_WMA_META),
    ///     which will return a single UTF-8 string. Each tag is in the form of "key=value".
    ///     A description of the codec used by the file is also available from BASS_ChannelGetTags (BASS_TAG_WMA_CODEC). 2
    ///     null-terminated UTF-8 strings are returned, with the 1st string being the name of the codec, and the 2nd containing
    ///     additional information like what VBR setting was used.
    ///     <para />
    ///     The playback length of the stream can be retrieved using BASS_ChannelGetLength. Until the whole file has been
    ///     streamed, whatever length the file's header says is returned, which may or may not be exact.
    ///     <para />
    ///     Although the Windows Media modules uses its own Internet streaming routines (not BASS's), the BASS_CONFIG_NET_PROXY
    ///     and BASS_CONFIG_NET_TIMEOUT configure options do have effect when opening WMA streams. When the
    ///     BASS_CONFIG_NET_PLAYLIST configure option is enabled, BASSWMA will process ASX and WPL files. None of the other NET
    ///     configure options apply.
    ///     <para />
    ///     Unless the BASS_CONFIG_WMA_BASSFILE configure option is enabled, the Windows Media modules uses its own file
    ///     reading
    ///     routines, and the offset and length parameters are ignored, except that length is still the length when playing
    ///     from memory. Also, BASS_StreamGetFilePosition is not fully supported. The file size (BASS_FILEPOS_END) can be
    ///     retrieved, but the decode position (BASS_FILEPOS_CURRENT) is not available. The download progress of streamed files
    ///     (BASS_FILEPOS_DOWNLOAD) can also be retrieved. The buffering progress (percentage) can be retrieved using the
    ///     BASS_FILEPOS_WMA_BUFFER mode.
    ///     <para />
    ///     When streaming a file from the Internet, it is not possible to seek with BASS_ChannelSetPosition until the whole
    ///     file has been downloaded. A sync (BASS_SYNC_DOWNLOAD) can be set to be notified when the file has been downloaded.
    ///     When streaming from the Internet, the WMA decoding is performed in a separate thread, so the CPU used to decode the
    ///     stream during playback will not be included in the BASS_GetCPU return value.
    ///     <para />
    ///     The playback rate of local files can be altered with BASS_ChannelSetAttribute. The playback rate of Internet
    ///     streams should not be changed, because they are delivered at a fixed rate: the rate required to sustain playback at
    ///     normal speed. So increasing the rate will result in playback stalling.
    ///     <para />
    /// </remarks>
    [BassFunction("BASS_WMA_StreamCreateFile")]
    [BassPlugin(BassPlugin.BassWma)]
    [BassError(ErrorCode.WmaError, "The Windows Media modules (v9 or above) are not installed.")]
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
    [BassError(ErrorCode.WmaLicenseError, "The WMA file cannot be played because it is protected.")]
    [BassError(ErrorCode.Unknown, "Some other mystery problem!")]
    [BassPointerVerification]
    public delegate IntPtr WmaStreamCreateFile(bool memory, IntPtr file, UInt64 offset, UInt64 length, WmaStreamCreateConfig configs);

    /// <summary>
    ///     Creates a sample stream from a WMA file or URL, optionally with a user name and password to authenticate.
    /// </summary>
    /// <param name="memory">TRUE = stream the file from memory. </param>
    /// <param name="file">Filename (memory = FALSE) or a memory location (memory = TRUE). </param>
    /// <param name="offset">File offset to begin streaming from (only used if memory = FALSE). </param>
    /// <param name="length">Data length... 0 = use all data up to the end of the file (if memory = FALSE). </param>
    /// <param name="configs">Configure of create a steam. </param>
    /// <param name="user">
    ///     User name to use in connecting to the server... if either this or pass is NULL, then no user
    ///     name/password is sent to the server.
    /// </param>
    /// <param name="pass">Password to use in connecting to the server. </param>
    /// <returns>
    ///     If successful, the new stream's handle is returned, else 0 is returned. Use BASS_ErrorGetCode to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     This function is identical to BASS_WMA_StreamCreateFile, but with the additional authentication options.
    /// </remarks>
    [BassFunction("BASS_WMA_StreamCreateFileAuth")]
    [BassPlugin(BassPlugin.BassWma)]
    [BassError(ErrorCode.WmaError, "The Windows Media modules (v9 or above) are not installed.")]
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
    [BassError(ErrorCode.WmaDenied, "Access was denied. Check the user and pass.")]
    [BassError(ErrorCode.WmaLicenseError, "The WMA file cannot be played because it is protected.")]
    [BassError(ErrorCode.Unknown, "Some other mystery problem!")]
    [BassPointerVerification]
    public delegate IntPtr WmaStreamCreateFileAuth(
        bool memory, IntPtr file, UInt64 offset, UInt64 length, WmaStreamCreateConfig configs, IntPtr user, IntPtr pass);

    /// <summary>
    ///     Creates a sample stream from a WMA file via user callback functions.
    /// </summary>
    /// <param name="system">File system to use, one of the following. STREAMFILE_NOBUFFER Unbuffered. </param>
    /// <param name="configs">Configure of create a steam. </param>
    /// <param name="procs">The user defined file functions. </param>
    /// <param name="user">User instance data to pass to the callback functions. </param>
    /// <returns>
    ///     If successful, the new stream's handle is returned, else 0 is returned. Use BASS_ErrorGetCode to get the error
    ///     code.
    /// </returns>
    [BassFunction("BASS_WMA_StreamCreateFileUser")]
    [BassPlugin(BassPlugin.BassWma)]
    [BassError(ErrorCode.WmaError, "The Windows Media modules (v9 or above) are not installed.")]
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
    [BassError(ErrorCode.WmaLicenseError, "The WMA file can not be played because it is protected.")]
    [BassError(ErrorCode.Unknown, "Some other mystery problem!")]
    [BassPointerVerification]
    public delegate IntPtr WmaStreamCreateFileUser(
        StreamFileSystemType system, WmaStreamCreateConfig configs, ref FileHandlers procs, IntPtr user);
}