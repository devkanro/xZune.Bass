// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: CallBack.cs
// Version: 20160215

using System;
using xZune.Bass.Interop.Core.Flags;

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     User stream writing callback function.
    /// </summary>
    /// <param name="handle">The stream that needs writing. </param>
    /// <param name="buffer">
    ///     Pointer to the buffer to write the sample data in. The data should be as follows: 8-bit samples
    ///     are unsigned, 16-bit samples are signed, 32-bit floating-point samples range from -1 to +1.
    /// </param>
    /// <param name="length">The maximum number of bytes to write. </param>
    /// <param name="user">The user instance data given when <see cref="StreamCreate" /> was called. </param>
    /// <returns>
    ///     The number of bytes written by the function, optionally using the
    ///     <see cref="PresetStreamProcess.StreamProcessEndFlag" /> flag to signify that the end of the stream is reached.
    /// </returns>
    /// <remarks>
    ///     A stream writing function should be as quick as possible, because other streams (and MOD musics) cannot be updated
    ///     until it has finished. It is better to return less data quickly, rather than spending a long time delivering
    ///     exactly the amount requested.
    ///     <para />
    ///     Although a STREAMPROC may return less data than BASS requests, be careful not to do so by too much, too often. If
    ///     the buffer gets exhausted, BASS will automatically stall playback of the stream, until more data is provided.
    ///     BASS_ChannelGetData (BASS_DATA_AVAILABLE) can be used to check the buffer level, and BASS_ChannelIsActive can be
    ///     used to check if playback has stalled. A BASS_SYNC_STALL sync can also be set via BASS_ChannelSetSync, to be
    ///     triggered upon playback stalling or resuming. If you do return less than the requested amount of data, the number
    ///     of bytes should still equate to a whole number of samples.
    ///     <para />
    ///     Some functions can cause problems if called from within a stream (or DSP) function. Do not call BASS_Stop or
    ///     BASS_Free from within a stream callback, and do not call BASS_ChannelStop or BASS_StreamFree with the same handle
    ///     as received by the callback.
    ///     <para />
    ///     When streaming multi-channel sample data, the channel order of each sample is as follows.
    ///     <para>3 channels         left-front, right-front, center. </para>
    ///     <para>4 channels         left-front, right-front, left-rear/side, right-rear/side. </para>
    ///     <para>5 channels         left-front, right-front, center, left-rear/side, right-rear/side. </para>
    ///     <para>6 channels (5.1)   left-front, right-front, center, LFE, left-rear/side, right-rear/side. </para>
    ///     <para>
    ///         8 channels (7.1)   left-front, right-front, center, LFE, left-rear/side, right-rear/side, left-rear center,
    ///         right-rear center.
    ///     </para>
    /// </remarks>
    public delegate uint SteamProcessHandler(IntPtr handle, IntPtr buffer, uint length, IntPtr user);

    /// <summary>
    ///     User file stream close callback function.
    /// </summary>
    /// <param name="user">The user instance data given when <see cref="StreamCreateFileUser" /> was called. </param>
    /// <remarks>
    ///     With a buffered file stream, this function is called as soon as reading reaches the end of the file. If the stream
    ///     is freed before then, this function could be called while its FILEREADPROC function is in progress. If that
    ///     happens, the FILEREADPROC function call should be immediately canceled.
    /// </remarks>
    public delegate void FileCloseHandler(IntPtr user);

    /// <summary>
    ///     User file stream length callback function.
    /// </summary>
    /// <param name="user">The user instance data given when <see cref="StreamCreateFileUser" /> was called. </param>
    /// <returns>
    ///     The length of the file in bytes. Returning 0 for a buffered file stream makes BASS stream the file in blocks
    ///     and is equivalent to using the <see cref="StreamCreateFileUserConfig.Block" /> flag in the
    ///     <see cref="StreamCreateFileUser" /> call.
    /// </returns>
    /// <remarks>
    ///     This function is called first thing, and only the once with buffered streams. With unbuffered streams, it may be
    ///     called again when testing for EOF (end of file), allowing the file to grow in size.
    /// </remarks>
    public delegate UInt64 FileLengthHandler(IntPtr user);

    /// <summary>
    ///     User file stream read callback function.
    /// </summary>
    /// <param name="buffer">Pointer to the buffer to put the data in. </param>
    /// <param name="length">Maximum number of bytes to read.</param>
    /// <param name="user">The user instance data given when <see cref="StreamCreateFileUser" /> was called. </param>
    /// <returns>The number of bytes read... -1 = end of file, 0 = end of file (buffered file stream only). </returns>
    /// <remarks>
    ///     During creation of the stream, this function should try to return the amount of data requested. After that, it can
    ///     just return whatever is available up to the requested amount.
    ///     <para />
    ///     For an unbuffered file stream, this function should be as quick as possible during playback; any delays will not
    ///     only affect the decoding of the current stream, but can also affect other streams and MOD musics that are playing.
    ///     It is better to return less data (even none) rather than wait for more data. A buffered file stream is not affected
    ///     by delays like this, as this function runs in its own thread then.
    /// </remarks>
    public delegate uint FileReadHandler(IntPtr buffer, uint length, IntPtr user);

    /// <summary>
    ///     User file stream seek callback function.
    /// </summary>
    /// <param name="offset">Position in bytes to seek to. </param>
    /// <param name="user">The user instance data given when <see cref="StreamCreateFileUser" /> was called. </param>
    /// <returns>TRUE if successful, else FALSE. </returns>
    public delegate bool FileSeekHandler(uint offset, IntPtr user);

    /// <summary>
    ///     Internet stream download callback function.
    /// </summary>
    /// <param name="buffer">Pointer to the downloaded data... NULL = finished downloading. </param>
    /// <param name="length">The number of bytes in the buffer... 0 = HTTP or ICY tags. </param>
    /// <param name="user">The user instance data given when <see cref="StreamCreateUrl" /> was called. </param>
    /// <remarks>
    ///     The callback will be called before the <see cref="StreamCreateUrl" /> call returns (if it's successful), with the
    ///     initial downloaded data. So any initialization (eg. creating the file if writing to disk) needs to be done either
    ///     before the call, or in the callback function.
    ///     <para />
    ///     When the <see cref="StreamCreateUrlConfig.Status" /> flag is specified in the <see cref="StreamCreateUrl" /> call,
    ///     HTTP and ICY tags may be passed to the callback during connection, before any stream data is received. The tags are
    ///     given exactly as would be returned by <see cref="ChannelGetTags" />. You can distinguish between HTTP and ICY tags
    ///     by checking what the first string starts with: "HTTP" or "ICY".
    ///     <para />
    ///     A download callback function could be used in conjunction with a BASS_SYNC_META sync set via
    ///     <see cref="ChannelSetSync" /> to save individual tracks to disk from a Shoutcast stream.
    /// </remarks>
    public delegate void DownloadHandler(IntPtr buffer, uint length, IntPtr user);
}