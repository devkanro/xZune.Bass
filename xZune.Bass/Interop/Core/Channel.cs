// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Channel.cs
// Version: 20160216

using System;
using System.Runtime.InteropServices;
using xZune.Bass.Interop.Flags;

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     Translates a byte position into time (seconds), based on a channel's format.
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM, or HRECORD. HSAMPLE handles may also be used. </param>
    /// <param name="pos">The position to translate. </param>
    /// <returns>
    ///     If successful, then the translated length is returned, else a negative value is returned. Use
    ///     <see cref="GetErrorCode" /> to
    ///     get the error code.
    /// </returns>
    /// <remarks>
    ///     The translation is based on the channel's initial sample rate, when it was created.
    /// </remarks>
    [BassFunction("BASS_ChannelBytes2Seconds")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassDoubleVerification]
    public delegate double ChannelBytes2Seconds(IntPtr handle, UInt64 pos);

    /// <summary>
    ///     Modifies and retrieves a channel's flags.
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM. </param>
    /// <param name="flags">A combination of these flags. </param>
    /// <param name="mask">
    ///     The flags (as above) to modify. Flags that are not included in this are left as they are, so it can
    ///     be set to 0 in order to just retrieve the current flags. To modify the speaker flags, any of the BASS_SPEAKER_xxx
    ///     flags can be used in the mask (no need to include all of them).
    /// </param>
    /// <returns>
    ///     If successful, the channel's updated flags are returned, else -1 is returned. Use <see cref="GetErrorCode" /> to
    ///     get the
    ///     error code.
    /// </returns>
    /// <remarks>
    ///     Some flags may not be adjustable in some circumstances, so the return value should be checked to confirm any
    ///     changes. The flags listed above are just the flags that can be modified, and there may be additional flags present
    ///     in the return value. See the BASS_CHANNELINFO documentation for a full list of flags.
    ///     Streams that are created by add-ons may have additional flags available. There is a limited number of possible flag
    ///     values though, so some add-ons may use the same flag value for different things. This means that when using add-on
    ///     specific flags with a stream created via the plug-in system, it is a good idea to first confirm that the add-on is
    ///     handling the stream, by checking its ctype via <see cref="ChannelGetInfo" />.
    ///     <para />
    ///     During playback, the effects of flag changes are not heard instantaneously, due to buffering. To reduce the delay,
    ///     use the BASS_CONFIG_BUFFER configure option to reduce the buffer length.
    ///     <para />
    /// </remarks>
    [BassFunction("BASS_ChannelFlags")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassInt32Verification]
    public delegate int ChannelFlags(IntPtr handle, Flags.ChannelFlags flags, int mask);

    /// <summary>
    ///     Retrieves the 3D attributes of a sample, stream, or MOD music channel with 3D functionality.
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM. </param>
    /// <param name="mode">The 3D processing mode... NULL = don't retrieve it. </param>
    /// <param name="min">The minimum distance... NULL = don't retrieve it. </param>
    /// <param name="max">The maximum distance... NULL = don't retrieve it. </param>
    /// <param name="iangle">The angle of the inside projection cone... NULL = don't retrieve it. </param>
    /// <param name="oangle">The angle of the outside projection cone... NULL = don't retrieve it. </param>
    /// <param name="outvol">The delta-volume outside the outer projection cone... NULL = don't retrieve it. </param>
    /// <returns>
    ///     If successful, then TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     The iangle and oangle parameters must both be retrieved in a single call to this function; one cannot be retrieved
    ///     without the other. See BASS_ChannelSet3DAttributes for an explanation of the parameters.
    /// </remarks>
    [BassFunction("BASS_ChannelGet3DAttributes")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassError(ErrorCode.No3D, "The channel does not have 3D functionality.")]
    [BassBooleanVerification]
    public delegate bool ChannelGet3DAttributes(
        IntPtr handle, ref Channel3DMode mode, ref float min, ref float max, ref uint iangle, ref uint oangle, ref float outvol);

    /// <summary>
    ///     Retrieves the 3D position of a sample, stream, or MOD music channel with 3D functionality.
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM. </param>
    /// <param name="pos">Position of the sound... NULL = don't retrieve it. </param>
    /// <param name="orient">Orientation of the sound... NULL = don't retrieve it. </param>
    /// <param name="vel">Velocity of the sound... NULL = don't retrieve it. </param>
    /// <returns>
    ///     If successful, then TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    [BassFunction("BASS_ChannelGet3DPosition")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassError(ErrorCode.No3D, "The channel does not have 3D functionality.")]
    [BassBooleanVerification]
    public delegate bool ChannelGet3DPosition(IntPtr handle, ref Vector3 pos, ref Vector3 orient, ref Vector3 vel);

    /// <summary>
    ///     Retrieves the value of a channel's attribute.
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM, or HRECORD. </param>
    /// <param name="attrib">The attribute to get the value of... one of the following. </param>
    /// <param name="value">Pointer to a variable to receive the attribute value. </param>
    /// <returns>
    ///     If successful, then TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    [BassFunction("BASS_ChannelGetAttribute")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassError(ErrorCode.NotAvailable, "The attribute is not available.")]
    [BassError(ErrorCode.IllegalType, "attribute is not valid.")]
    [BassBooleanVerification]
    public delegate bool ChannelGetAttribute(IntPtr handle, ChannelAttribute attrib, ref float value);

    /// <summary>
    ///     Retrieves the value of a channel's attribute.
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM, or HRECORD. </param>
    /// <param name="attrib">The attribute to get the value of... one of the following. </param>
    /// <param name="value">Pointer to a buffer to receive the attribute data. </param>
    /// <param name="size">The size of the attribute data... 0 = get the size of the attribute without getting the data. </param>
    /// <returns>
    ///     If successful, the size of the attribute data is returned, else 0 is returned. Use <see cref="GetErrorCode" /> to
    ///     get the error code.
    /// </returns>
    /// <remarks>
    ///     This function also supports the floating-point attributes supported by <see cref="ChannelGetAttribute" />.
    /// </remarks>
    [BassFunction("BASS_ChannelGetAttributeEx")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassError(ErrorCode.NotAvailable, "The attribute is not available.")]
    [BassError(ErrorCode.IllegalType, "attribute is not valid.")]
    [BassError(ErrorCode.IllegalParam, "size is not valid.")]
    [BassInt32Verification]
    public delegate int ChannelGetAttributeEx(IntPtr handle, ChannelAttributeEx attrib, IntPtr value, int size);

    /// <summary>
    ///     Retrieves the immediate sample data (or an FFT representation of it) of a sample channel, stream, MOD music, or
    ///     recording channel.
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM, or HRECORD. </param>
    /// <param name="buffer">
    ///     Pointer to a buffer to receive the data... can be NULL when handle is a recording channel
    ///     (HRECORD), to discard the requested amount of data from the recording buffer.
    /// </param>
    /// <param name="length">Number of bytes wanted (up to 268435455 or 0xFFFFFFF), and/or the following flags. </param>
    /// <returns>
    ///     If an error occurs, -1 is returned, use <see cref="GetErrorCode" /> to get the error code. When requesting FFT
    ///     data, the
    ///     number of bytes read from the channel (to perform the FFT) is returned. When requesting sample data, the number of
    ///     bytes written to buffer will be returned (not necessarily the same as the number of bytes read when using the
    ///     BASS_DATA_FLOAT or BASS_DATA_FIXED flag). When using the BASS_DATA_AVAILABLE flag, the number of bytes in the
    ///     channel's buffer is returned.
    /// </returns>
    /// <remarks>
    ///     Unless the channel is a decoding channel, this function can only return as much data as has been written to the
    ///     channel's playback buffer, so it may not always be possible to get the amount of data requested, especially if it
    ///     is a large amount. If large amounts are needed, the buffer length (BASS_CONFIG_BUFFER) can be increased. The
    ///     BASS_DATA_AVAILABLE flag can be used to check how much data a channel's buffer contains at any time, including when
    ///     stopped or stalled.
    ///     When requesting data from a decoding channel, data is decoded directly from the channel's source (no playback
    ///     buffer) and as much data as the channel has available can be decoded at a time.
    ///     <para />
    ///     When retrieving sample data, 8-bit samples are unsigned (0 to 255), 16-bit samples are signed (-32768 to 32767),
    ///     32-bit floating-point samples range from -1 to +1 (not clipped, so can actually be outside this range). That is
    ///     unless the BASS_DATA_FLOAT flag is used, in which case the sample data will be converted to 32-bit floating-point
    ///     (if it is not already), or if the <see cref="SampleDataType.Fixed" /> flag is used, in which case the data will be
    ///     converted to 8.24 fixed-point.
    ///     <para />
    ///     Unless complex data is requested via the BASS_DATA_FFT_COMPLEX flag, the magnitudes of the first half of an FFT
    ///     result are returned. For example, with a 2048 sample FFT, there will be 1024 floating-point values returned. If the
    ///     BASS_DATA_FIXED flag is used, then the FFT values will be in 8.24 fixed-point form rather than floating-point. Each
    ///     value, or "bin", ranges from 0 to 1 (can actually go higher if the sample data is floating-point and not clipped).
    ///     The 1st bin contains the DC component, the 2nd contains the amplitude at 1/2048 of the channel's sample rate,
    ///     followed by the amplitude at 2/2048, 3/2048, etc. A Hann window is applied to the sample data to reduce leakage,
    ///     unless the <see cref="SampleDataType.FFTNoWindow" /> flag is used. When a window is applied, it causes the DC
    ///     component to leak into the next bin, but that can be removed (reduced to 0) by using the BASS_DATA_FFT_REMOVEDC
    ///     flag. Doing so slightly
    ///     increases the processing required though, so it should only be done when needed, which is when a window is applied
    ///     and the 2nd bin value is important.
    ///     <para />
    ///     Channels that have 2 or more sample channels (ie. stereo or above) may have FFT performed on each individual
    ///     channel, using the <see cref="SampleDataType.FFTIndividual" /> flag. Without this flag, all of the channels are
    ///     combined, and a single
    ///     mono FFT is performed. Performing the extra individual FFTs of course increases the amount of processing required.
    ///     The return values are interleaved in the same order as the channel's sample data, eg. stereo = left,right,left,etc.
    ///     <para />
    ///     This function is most useful if you wish to visualize (eg. spectrum analyze) the sound.
    ///     <para />
    /// </remarks>
    [BassFunction("BASS_ChannelGetData")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassError(ErrorCode.Ended, "The channel has reached the end.")]
    [BassError(ErrorCode.NotAvailable, "The BASS_DATA_AVAILABLE flag was used with a decoding channel.")]
    [BassError(ErrorCode.BufferLost, "Should not happen... check that a valid window handle was used with Initialize()."
        )]
    [BassInt32Verification]
    public delegate int ChannelGetData(IntPtr handle, IntPtr buffer, int length);

    /// <summary>
    ///     Retrieves the device that a channel is using.
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM, or HRECORD. HSAMPLE handles may also be used. </param>
    /// <returns>
    ///     If successful, the device number is returned, else -1 is returned. Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     Recording devices are indicated by the HIWORD of the return value being 1, when this function is called with a
    ///     HRECORD channel.
    /// </remarks>
    [BassFunction("BASS_ChannelGetDevice")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassInt32Verification]
    public delegate int ChannelGetDevice(IntPtr handle);

    /// <summary>
    ///     Retrieves information on a channel.
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM, or HRECORD. </param>
    /// <param name="info">Pointer to structure to receive the channel information. </param>
    /// <returns>
    ///     If successful, TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to get the error code.
    /// </returns>
    [BassFunction("BASS_ChannelGetInfo")]
    [BassError(ErrorCode.BadHandle, "handle is not valid.")]
    [BassBooleanVerification]
    public delegate bool ChannelGetInfo(IntPtr handle, ref ChannelInfo info);

    /// <summary>
    ///     Retrieves the playback length of a channel.
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM. HSAMPLE handles may also be used. </param>
    /// <param name="mode">How to retrieve the length. One of the following. </param>
    /// <param name="other">modes may be supported by add-ons, see the documentation. </param>
    /// <returns>
    ///     If successful, then the channel's length is returned, else -1 is returned. Use <see cref="GetErrorCode"/> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     The exact length of a stream will be returned once the whole file has been streamed, but until then it is not
    ///     always possible to 100% accurately estimate the length. The length is always exact for MP3/MP2/MP1 files when the
    ///     BASS_STREAM_PRESCAN flag is used in the BASS_StreamCreateFile call, otherwise it is an (usually accurate)
    ///     estimation based on the file size. The length returned for OGG files will usually be exact (assuming the file is
    ///     not corrupt), but when streaming from the Internet (or "buffered" user file), it can be a very rough estimation
    ///     until the whole file has been downloaded. It will also be an estimate for chained OGG files that are not
    ///     pre-scanned.
    ///     Unless an OGG file contains a single bit-stream, the number of bit-streams it contains will only be available if it
    ///     was pre-scanned at the stream's creation.
    ///     <para />
    ///     Retrieving the byte length of a MOD music requires that the BASS_MUSIC_PRESCAN flag was used in the
    ///     <see cref="MusicLoad" /> call.
    ///     <para />
    /// </remarks>
    [BassFunction("BASS_ChannelGetLength")]
    [BassError(ErrorCode.BadHandle, "handle is not valid.")]
    [BassError(ErrorCode.NotAvailable, "The requested length is not available.")]
    [BassUInt64Verification]
    public delegate UInt64 ChannelGetLength(IntPtr handle, PositionConfig mode);

    /// <summary>
    ///     Retrieves the level (peak amplitude) of a sample, stream, MOD music, or recording channel.
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM, or HRECORD. </param>
    /// <returns>
    ///     If an error occurs, -1 is returned, Use <see cref="GetErrorCode"/> to get the error code. If successful, the level of the
    ///     left channel is returned in the low word (low 16 bits), and the level of the right channel is returned in the high
    ///     word (high 16 bits). If the channel is mono, then the low word is duplicated in the high word. The level ranges
    ///     linearly from 0 (silent) to 32768 (max). 0 will be returned when a channel is stalled.
    /// </returns>
    /// <remarks>
    ///     This function measures the level of the channel's sample data, not its level in the final output mix, so the
    ///     channel's volume (BASS_ATTRIB_VOL attribute) and panning (BASS_ATTRIB_PAN) does not affect it. The effect of any
    ///     DSP/FX set on the channel is present in the measurement, except for DX8 effects when using the "With FX flag" DX8
    ///     effect implementation.
    ///     For channels that are more than stereo, the left level will include all left channels (eg. front-left, rear-left,
    ///     center), and the right will include all right (front-right, rear-right, LFE). If there are an odd number of
    ///     channels then the left and right levels will include all channels. If the level of each individual channel is
    ///     required, that is available from BASS_ChannelGetLevelEx.
    ///     <para />
    ///     20ms of data is inspected to calculate the level. When used with a decoding channel, that means 20ms of data needs
    ///     to be decoded from the channel in order to calculate the level, and that data is then gone, eg. it is not available
    ///     to a subsequent BASS_ChannelGetData call.
    ///     <para />
    ///     More flexible level retrieval is available with BASS_ChannelGetLevelEx.
    ///     <para />
    /// </remarks>
    [BassFunction("BASS_ChannelGetLevel")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassError(ErrorCode.NoPlay, "The channel is not playing.")]
    [BassError(ErrorCode.Ended, "The decoding channel has reached the end.")]
    [BassError(ErrorCode.BufferLost, "Should not happen... check that a valid window handle was used with Initialize()."
        )]
    [BassInt32Verification]
    public delegate int ChannelGetLevel(IntPtr handle);

    /// <summary>
    ///     Retrieves the level of a sample, stream, MOD music, or recording channel.
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM, or HRECORD. </param>
    /// <param name="levels">An array to receive the levels. </param>
    /// <param name="length">
    ///     The amount of data to inspect to calculate the level, in seconds. The maximum is 1 second. Less
    ///     data than requested may be used if the full amount is not available, eg. if the channel's playback buffer is
    ///     shorter.
    /// </param>
    /// <param name="flags">A combination of these flags. </param>
    /// <returns>
    ///     If successful, TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    /// <remarks>
    ///     This function operates in the same way as BASS_ChannelGetLevel but has greater flexibility on how the level is
    ///     measured. The levels are not clipped, so may exceed +/-1.0 on floating-point channels.
    /// </remarks>
    [BassFunction("BASS_ChannelGetLevelEx")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassError(ErrorCode.IllegalParam, "length is not valid.")]
    [BassError(ErrorCode.NoPlay, "The channel is not playing.")]
    [BassError(ErrorCode.Ended, "The decoding channel has reached the end.")]
    [BassError(ErrorCode.BufferLost, "Should not happen... check that a valid window handle was used with Initialize()."
        )]
    [BassBooleanVerification]
    public delegate bool ChannelGetLevelEx(IntPtr handle, IntPtr levels, float length, LevelConfig flags);

    /// <summary>
    ///     Retrieves the playback position of a sample, stream, or MOD music. Can also be used with a recording channel.
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM, or HRECORD. </param>
    /// <param name="mode">How to retrieve the position. One of the following, with optional flags. </param>
    /// <returns>
    ///     If successful, then the channel's position is returned, else -1 is returned. Use <see cref="GetErrorCode"/> to get the error
    ///     code.
    /// </returns>
    [BassFunction("BASS_ChannelGetPosition")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassError(ErrorCode.NotAvailable, "The requested position is not available.")]
    [BassError(ErrorCode.Unknown, "Some other mystery problem!")]
    [BassUInt64Verification]
    public delegate UInt64 ChannelGetPosition(IntPtr handle, PositionConfig mode);

    /// <summary>
    ///     Retrieves tags/headers from a channel.
    /// </summary>
    /// <param name="handle">The channel handle... a HMUSIC or HSTREAM. </param>
    /// <param name="tags">The tags/headers wanted... one of the following. </param>
    /// <returns>
    ///     If successful, the requested tags are returned, else NULL is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    /// <remarks>
    ///     Some tags (eg. ID3v1) are located at the end of the file, so when streaming a file from the Internet, the tags will
    ///     not be available until the download is complete. A BASS_SYNC_DOWNLOAD sync can be set via BASS_ChannelSetSync, to
    ///     be informed of when the download is complete. A BASS_SYNC_META sync can be used to be informed of new Shoutcast
    ///     metadata, and a BASS_SYNC_OGG_CHANGE sync for when a new logical bit-stream begins in a chained OGG stream, which
    ///     generally brings new OGG tags.
    ///     In a chained OGG file containing multiple bit-streams, each bit-stream will have its own tags. To get the tags from
    ///     a particular one, BASS_ChannelSetPosition can be first used to seek to it.
    ///     <para />
    ///     When a Media Foundation codec is in use, the BASS_TAG_WAVEFORMAT tag can be used to find out what the source format
    ///     is, eg. via the WAVEFORMATEX structure's wFormatTag member. Some typical wFormatTag examples are: 0x0161 = WMA,
    ///     0x0162 = WMA pro, 0x0163 = WMA lossless, 0x1610 = AAC.
    ///     <para />
    /// </remarks>
    [BassFunction("BASS_ChannelGetTags")]
    [BassError(ErrorCode.BadHandle, "handle is not valid.")]
    [BassError(ErrorCode.NotAvailable, "The requested tags are not available.")]
    [BassPointerVerification]
    public delegate IntPtr ChannelGetTags(IntPtr handle, TagType tags);

    /// <summary>
    ///     Checks if a sample, stream, or MOD music is active (playing) or stalled. Can also check if a recording is in
    ///     progress.
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM, or HRECORD. </param>
    /// <returns>
    ///     The return value is one of the following.
    ///     BASS_ACTIVE_STOPPED The channel is not active, or handle is not a valid channel.
    ///     BASS_ACTIVE_PLAYING The channel is playing (or recording).
    ///     BASS_ACTIVE_PAUSED The channel is paused.
    ///     BASS_ACTIVE_STALLED Playback of the stream has been stalled due to a lack of sample data. The playback will
    ///     automatically resume once there is sufficient data to do so.
    ///     <para />
    /// </returns>
    /// <remarks>
    ///     When using this function with a decoding channel, <see cref="ChannelStatus.Playing" /> will be returned while there
    ///     is still data to decode. Once the end has been reached, <see cref="ChannelStatus.Stopped" /> will be returned.
    ///     <see cref="ChannelStatus.Stalled" /> is never returned for decoding channels; you can tell a decoding channel is
    ///     stalled if <see cref="ChannelGetData" /> returns less data than requested, and this function still returns
    ///     <see cref="ChannelStatus.Playing" />.
    /// </remarks>
    [BassFunction("BASS_ChannelIsActive")]
    public delegate ChannelStatus ChannelIsActive(IntPtr handle);

    /// <summary>
    ///     Checks if an attribute (or any attribute) of a sample, stream, or MOD music is sliding.
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HSTREAM or HMUSIC. </param>
    /// <param name="attrib">The attribute to check for sliding... one of the following, or 0 for any attribute. </param>
    /// <returns>
    ///     If the attribute is sliding, then TRUE is returned, else FALSE is returned.
    /// </returns>
    [BassFunction("BASS_ChannelIsSliding")]
    public delegate bool ChannelIsSliding(IntPtr handle, ChannelAttribute attrib);

    /// <summary>
    ///     Locks a stream, MOD music or recording channel to the current thread.
    /// </summary>
    /// <param name="handle">The channel handle... a HMUSIC, HSTREAM or HRECORD. </param>
    /// <param name="@lock">If FALSE, unlock the channel, else lock it. </param>
    /// <returns>
    ///     If successful, TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    /// <remarks>
    ///     Locking a channel prevents other threads from performing most functions on it, including buffer updates. Other
    ///     threads wanting to access a locked channel will block until it is unlocked, so a channel should only be locked very
    ///     briefly. A channel must be unlocked in the same thread that it was locked.
    /// </remarks>
    [BassFunction("BASS_ChannelLock")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassBooleanVerification]
    public delegate bool ChannelLock(IntPtr handle, bool @lock);

    /// <summary>
    ///     Pauses a sample, stream, MOD music, or recording.
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM, or HRECORD. </param>
    /// <returns>
    ///     If successful, TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    /// <remarks>
    ///     Use BASS_ChannelPlay to resume a paused channel. BASS_ChannelStop can be used to stop a paused channel.
    /// </remarks>
    [BassFunction("BASS_ChannelPause")]
    [BassError(ErrorCode.NoPlay, "The channel is not playing (or handle is not a valid channel).")]
    [BassError(ErrorCode.DecodeError, "The channel is not playable; it is a \"decoding channel\".")]
    [BassError(ErrorCode.Already, "The channel is already paused.")]
    [BassBooleanVerification]
    public delegate bool ChannelPause(IntPtr handle);

    /// <summary>
    ///     Starts (or resumes) playback of a sample, stream, MOD music, or recording.
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM, or HRECORD. </param>
    /// <param name="restart">
    ///     Restart playback from the beginning? If handle is a user stream (created with BASS_StreamCreate),
    ///     its current buffer contents are cleared. If it is a MOD music, its BPM/etc are reset to their initial values.
    /// </param>
    /// <returns>
    ///     If successful, TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    /// <remarks>
    ///     When streaming in blocks (BASS_STREAM_BLOCK), the restart parameter is ignored as it is not possible to go back to
    ///     the start. The restart parameter is also of no consequence with recording channels.
    /// </remarks>
    [BassFunction("BASS_ChannelPlay")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassError(ErrorCode.StartFail, "The output is paused/stopped, use BASS_Start to start it.")]
    [BassError(ErrorCode.DecodeError, "The channel is not playable; it is a \"decoding channel\".")]
    [BassError(ErrorCode.BufferLost, "Should not happen... check that a valid window handle was used with BASS_Init.")]
    [BassError(ErrorCode.NoHardware,
        "No hardware voices are available (HCHANNEL only). This only occurs if the sample was loaded/created with the BASS_SAMPLE_VAM flag and BASS_VAM_HARDWARE is set in the sample's VAM mode, and there are no hardware voices available to play it."
        )]
    [BassBooleanVerification]
    public delegate bool ChannelPlay(IntPtr handle, bool restart);

    /// <summary>
    ///     Removes a DSP function from a stream, MOD music, or recording channel.
    /// </summary>
    /// <param name="handle">The channel handle... a HSTREAM, HMUSIC, or HRECORD. </param>
    /// <param name="displayHandle">
    ///     Handle of the DSP function to remove from the channel. This can also be an HFX handle to remove an
    ///     effect.
    /// </param>
    /// <returns>
    ///     If successful, TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    [BassFunction("BASS_ChannelRemoveDSP")]
    [BassError(ErrorCode.BadHandle, "At least one of handle and dsp is not valid.")]
    [BassBooleanVerification]
    public delegate bool ChannelRemoveDSP(IntPtr handle, IntPtr displayHandle);

    /// <summary>
    ///     Removes an effect on a stream, MOD music, or recording channel.
    /// </summary>
    /// <param name="handle">The channel handle... a HSTREAM, HMUSIC, or HRECORD. </param>
    /// <param name="fx">Handle of the effect to remove from the channel. </param>
    /// <returns>
    ///     If successful, TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    /// <remarks>
    ///     Depending on the DX8 effect implementation being used by the channel, the channel may have to be stopped before
    ///     removing a DX8 effect from it. If necessary, that is done automatically and the channel is resumed afterwards.
    ///     BASS_ChannelRemoveDSP can also be used to remove effects.
    ///     <para />
    /// </remarks>
    [BassFunction("BASS_ChannelRemoveFX")]
    [BassError(ErrorCode.BadHandle, "At least one of handle and fx is not valid.")]
    [BassBooleanVerification]
    public delegate bool ChannelRemoveFX(IntPtr handle, IntPtr fx);

    /// <summary>
    ///     Removes a links between two MOD music or stream channels.
    /// </summary>
    /// <param name="handle">The channel handle... a HMUSIC or HSTREAM. </param>
    /// <param name="chan">The handle of the channel to have unlinked with it... a HMUSIC or HSTREAM. </param>
    /// <returns>
    ///     If successful, then TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    [BassFunction("BASS_ChannelRemoveLink")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassError(ErrorCode.Already, "Either chan is not a valid channel, or it is already not linked to handle.")]
    [BassBooleanVerification]
    public delegate bool ChannelRemoveLink(IntPtr handle, IntPtr chan);

    /// <summary>
    ///     Removes a synchronizer from a MOD music, stream or recording channel.
    /// </summary>
    /// <param name="handle">The channel handle... a HMUSIC, HSTREAM or HRECORD. </param>
    /// <param name="sync">Handle of the synchronizer to remove. </param>
    /// <returns>
    ///     If successful, TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    [BassFunction("BASS_ChannelRemoveSync")]
    [BassError(ErrorCode.BadHandle, "At least one of handle and sync is not valid.")]
    [BassBooleanVerification]
    public delegate bool ChannelRemoveSync(IntPtr handle, IntPtr sync);

    /// <summary>
    ///     Translates a time (seconds) position into bytes, based on a channel's format.
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM, or HRECORD. HSAMPLE handles may also be used. </param>
    /// <param name="pos">The position to translate. </param>
    /// <returns>
    ///     If successful, then the translated length is returned, else -1 is returned. Use <see cref="GetErrorCode"/> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     The translation is based on the channel's initial sample rate, when it was created.
    ///     The return value is rounded down to the position of the nearest sample.
    ///     <para />
    /// </remarks>
    [BassFunction("BASS_ChannelSeconds2Bytes")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassUInt64Verification]
    public delegate UInt64 ChannelSeconds2Bytes(IntPtr handle, double pos);

    /// <summary>
    ///     Sets the 3D attributes of a sample, stream, or MOD music channel with 3D functionality.
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM. </param>
    /// <param name="mode">The 3D processing mode... one of these flags, -1 = leave current.</param>
    /// <param name="min">
    ///     The minimum distance. The channel's volume is at maximum when the listener is within this distance...
    ///     0 or less = leave current.
    /// </param>
    /// <param name="max">
    ///     The maximum distance. The channel's volume stops decreasing when the listener is beyond this
    ///     distance... 0 or less = leave current.
    /// </param>
    /// <param name="iangle">
    ///     The angle of the inside projection cone in degrees... 0 (no cone) to 360 (sphere), -1 = leave
    ///     current.
    /// </param>
    /// <param name="oangle">
    ///     The angle of the outside projection cone in degrees... 0 (no cone) to 360 (sphere), -1 = leave
    ///     current.
    /// </param>
    /// <param name="outvol">
    ///     The delta-volume outside the outer projection cone... 0 (silent) to 1 (same as inside the cone),
    ///     less than 0 = leave current.
    /// </param>
    /// <returns>
    ///     If successful, then TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    /// <remarks>
    ///     The iangle and oangle parameters must both be set in a single call to this function; one cannot be set without the
    ///     other. The iangle and oangle angles decide how wide the sound is projected around the orientation angle. Within the
    ///     inside angle the volume level is the channel volume (BASS_ATTRIB_VOL attribute). Outside the outer angle, the
    ///     volume changes according to the outvol value. Between the inner and outer angles, the volume gradually changes
    ///     between the inner and outer volume levels. If the inner and outer angles are 360 degrees, then the sound is
    ///     transmitted equally in all directions.
    ///     As with all 3D functions, use BASS_Apply3D to apply the changes made.
    /// </remarks>
    [BassFunction("BASS_ChannelSet3DAttributes")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassError(ErrorCode.No3D, "The channel does not have 3D functionality.")]
    [BassError(ErrorCode.IllegalParam, "One or more of the attribute values is invalid.")]
    [BassBooleanVerification]
    public delegate bool ChannelSet3DAttributes(
        IntPtr handle, Channel3DMode mode, float min, float max, int iangle, int oangle, float outvol);

    /// <summary>
    ///     Sets the 3D position of a sample, stream, or MOD music channel with 3D functionality.
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM. </param>
    /// <param name="pos">Position of the sound... NULL = leave current. </param>
    /// <param name="orient">Orientation of the sound... NULL = leave current. This is automatically normalized. </param>
    /// <param name="vel">
    ///     Velocity of the sound... NULL = leave current. This is only used to calculate the doppler effect, and
    ///     has no effect on the sound's position.
    /// </param>
    /// <returns>
    ///     If successful, then TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    /// <remarks>
    ///     As with all 3D functions, <see cref="Apply3D" /> must be called to apply the changes made.
    /// </remarks>
    [BassFunction("BASS_ChannelSet3DPosition")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassError(ErrorCode.No3D, "The channel does not have 3D functionality.")]
    [BassBooleanVerification]
    public delegate bool ChannelSet3DPosition(IntPtr handle, ref Vector3 pos, ref Vector3 orient, ref Vector3 vel);

    /// <summary>
    ///     Sets the value of a channel's attribute.
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM, or HRECORD. </param>
    /// <param name="attribute">The attribute to set the value of... one of the following. </param>
    /// <param name="value">The new attribute value. See the attribute's documentation for details on the possible values. </param>
    /// <returns>
    ///     If successful, then TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    /// <remarks>
    ///     The actual attribute value may not be exactly the same as requested, due to precision differences. For example, an
    ///     attribute might only allow whole number values. BASS_ChannelGetAttribute can be used to confirm what the value is.
    /// </remarks>
    [BassFunction("BASS_ChannelSetAttribute")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassError(ErrorCode.IllegalType, "attribute is not valid.")]
    [BassError(ErrorCode.IllegalParam,
        "value is not valid. See the attribute's documentation for the valid range of values.")]
    [BassBooleanVerification]
    public delegate bool ChannelSetAttribute(IntPtr handle, ChannelAttribute attribute, float value);

    /// <summary>
    ///     Sets the value of a channel's attribute.
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM, or HRECORD. </param>
    /// <param name="attribute">The attribute to set the value of... one of the following. </param>
    /// <param name="value">The new attribute data. </param>
    /// <param name="size">The size of the attribute data. </param>
    /// <returns>
    ///     If successful, TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    /// <remarks>
    ///     This function also supports the floating-point attributes supported by BASS_ChannelGetAttribute.
    /// </remarks>
    [BassFunction("BASS_ChannelSetAttributeEx")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassError(ErrorCode.IllegalType, "attribute is not valid.")]
    [BassError(ErrorCode.IllegalParam, "The value content or size is not valid.")]
    [BassBooleanVerification]
    public delegate bool ChannelSetAttributeEx(IntPtr handle, ChannelAttributeEx attribute, IntPtr value, uint size);

    /// <summary>
    ///     Changes the device that a stream, MOD music or sample is using.
    /// </summary>
    /// <param name="handle">The channel or sample handle... a HMUSIC, HSTREAM or HSAMPLE. </param>
    /// <param name="device">The device to use... 0 = no sound, 1 = first real output device. </param>
    /// <returns>
    ///     If successful, TRUE is returned, else FALSE is returned and the channel remains on its current device. Use
    ///     BASS_ErrorGetCode to get the error code.
    /// </returns>
    /// <remarks>
    ///     All of the channel's current settings are carried over to the new device, but if the channel is using the "with FX
    ///     flag" DX8 effect implementation, the internal state (eg. buffers) of the DX8 effects will be reset. When using the
    ///     "without FX flag" DX8 effect implementation, the state of the DX8 effects is preserved.
    ///     When changing a sample's device, all the sample's existing channels (HCHANNELs) are freed. It is not possible to
    ///     change the device of an individual sample channel.
    ///     <para />
    /// </remarks>
    [BassFunction("BASS_ChannelSetDevice")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassError(ErrorCode.InvalidDevice, "device is invalid.")]
    [BassError(ErrorCode.InitializeFail, "The requested device has not been initialized.")]
    [BassError(ErrorCode.Already, "The channel is already using the requested device.")]
    [BassError(ErrorCode.NotAvailable, "Only decoding channels are allowed to use the \"no sound\" device.")]
    [BassError(ErrorCode.IncorrectFormat,
        "The sample format is not supported by the device/drivers. If the channel is more than stereo or the BASS_SAMPLE_FLOAT flag is used, it could be that they are not supported."
        )]
    [BassError(ErrorCode.BadMemory, "There is insufficient memory.")]
    [BassError(ErrorCode.Unknown, "Some other mystery problem!")]
    [BassBooleanVerification]
    public delegate bool ChannelSetDevice(IntPtr handle, int device);

    /// <summary>
    ///     Sets up a user DSP function on a stream, MOD music, or recording channel.
    /// </summary>
    /// <param name="handle">The channel handle... a HSTREAM, HMUSIC, or HRECORD. </param>
    /// <param name="proc">The callback function. </param>
    /// <param name="user">User instance data to pass to the callback function. </param>
    /// <param name="priority">
    ///     The priority of the new DSP, which determines its position in the DSP chain. DSPs with higher
    ///     priority are called before those with lower.
    /// </param>
    /// <returns>
    ///     If successful, then the new DSP's handle is returned, else 0 is returned. Use <see cref="GetErrorCode"/> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     DSP functions can set and removed at any time, including mid-playback. Use BASS_ChannelRemoveDSP to remove a DSP
    ///     function.
    ///     Multiple DSP functions may be used per channel, in which case the order that the functions are called is determined
    ///     by their priorities. Any DSPs that have the same priority are called in the order that they were added.
    ///     <para />
    ///     DSP functions can be applied to MOD musics and streams, but not samples. If you want to apply a DSP function to a
    ///     sample, then you should stream the sample.
    ///     <para />
    /// </remarks>
    [BassFunction("BASS_ChannelSetDSP")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassPointerVerification]
    public delegate IntPtr ChannelSetDSP(IntPtr handle, DisplayHandler proc, IntPtr user, int priority);

    /// <summary>
    ///     Sets an effect on a stream, MOD music, or recording channel.
    /// </summary>
    /// <param name="handle">The channel handle... a HSTREAM, HMUSIC, or HRECORD. </param>
    /// <param name="type">One of the following types of effect. </param>
    /// <param name="priority">
    ///     The priority of the new FX, which determines its position in the DSP chain. DSP/FX with higher
    ///     priority are applied before those with lower. This parameter has no effect with DX8 effects when the "with FX flag"
    ///     DX8 effect implementation is used.
    /// </param>
    /// <returns>
    ///     If successful, then the new effect's handle is returned, else 0 is returned. Use <see cref="GetErrorCode"/> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     Multiple effects may be used per channel. Use <see cref="ChannelRemoveFX" /> to remove an effect. Use
    ///     BASS_FXSetParameters to set an effect's parameters.
    ///     Effects can be applied to MOD musics and streams, but not samples. If you want to apply an effect to a sample, you
    ///     could use a stream instead.
    ///     <para />
    ///     Depending on the DX8 effect implementation being used by the channel, the channel may have to be stopped before
    ///     adding or removing DX8 effects on it. If necessary, that is done automatically and the channel is resumed
    ///     afterwards.
    ///     <para />
    /// </remarks>
    [BassFunction("BASS_ChannelSetFX")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassError(ErrorCode.IllegalType, "type is invalid.")]
    [BassError(ErrorCode.NoFX, "The specified DX8 effect is unavailable.")]
    [BassError(ErrorCode.IncorrectFormat, "The channel's format is not supported by the effect.")]
    [BassError(ErrorCode.Unknown, "Some other mystery problem!")]
    [BassPointerVerification]
    public delegate IntPtr ChannelSetFX(IntPtr handle, FxType type, int priority);

    /// <summary>
    ///     Links two MOD music or stream channels together.
    /// </summary>
    /// <param name="handle">The channel handle... a HMUSIC or HSTREAM. </param>
    /// <param name="chan">The handle of the channel to have linked with it... a HMUSIC or HSTREAM. </param>
    /// <returns>
    ///     If successful, then TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    /// <remarks>
    ///     Linked channels are started/stopped/paused/resumed together. Links are one-way; for example, channel chan will be
    ///     started by channel handle, but not vice versa unless another link has been set in that direction.
    ///     If a linked channel has reached the end, it will not be restarted when a channel it is linked to is started. If you
    ///     want a linked channel to be restarted, you need to have resetted its position using BASS_ChannelSetPosition
    ///     beforehand.
    ///     <para />
    /// </remarks>
    [BassFunction("BASS_ChannelSetLink")]
    [BassError(ErrorCode.BadHandle, "At least one of handle and chan is not a valid channel.")]
    [BassError(ErrorCode.DecodeError, "At least one of handle and chan is a \"decoding channel\", so cannot be linked.")
    ]
    [BassError(ErrorCode.Already, "chan is already linked to handle.")]
    [BassError(ErrorCode.Unknown, "Some other mystery problem!")]
    [BassBooleanVerification]
    public delegate bool ChannelSetLink(IntPtr handle, IntPtr chan);

    /// <summary>
    ///     Sets the playback position of a sample, MOD music, or stream.
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HSTREAM or HMUSIC. </param>
    /// <param name="pos">The position, in units determined by the mode. </param>
    /// <param name="mode">How to set the position. One of the following, with optional flags. </param>
    /// <returns>
    ///     If successful, then TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    /// <remarks>
    ///     Setting the position of a MOD music in bytes (other than 0) requires that the BASS_MUSIC_PRESCAN flag was used in
    ///     the BASS_MusicLoad call, or the use of the BASS_POS_DECODETO flag. When setting the position in orders and rows,
    ///     the channel's byte position (as reported by BASS_ChannelGetPosition) is reset to 0. That is because it is not
    ///     possible to get the byte position of an order/row position; it is possible for an order/row position to never be
    ///     played in the normal course of events, or it may be played multiple times.
    ///     When setting the position of a MOD music, and the BASS_MUSIC_POSRESET flag is active, all notes that were playing
    ///     before the position changed will be stopped. Otherwise, the notes will continue playing until they are stopped in
    ///     the MOD music. When setting the position in bytes, the BPM, speed and global volume are updated to what they would
    ///     normally be at the new position. Otherwise they are left as they were prior to the position change, unless the seek
    ///     position is 0 (the start), in which case they are also reset to the starting values (with the BASS_MUSIC_POSRESET
    ///     flag). When the BASS_MUSIC_POSRESETEX flag is active, the BPM, speed and global volume are reset with every seek.
    ///     <para />
    ///     <para />
    ///     For MP3/MP2/MP1 streams, unless the file is scanned via the BASS_POS_SCAN flag or the BASS_STREAM_PRESCAN flag at
    ///     stream creation, seeking will be approximate but generally still quite accurate. Besides scanning, exact seeking
    ///     can also be achieved with the BASS_POS_DECODETO flag.
    ///     <para />
    ///     Seeking in Internet file (and "buffered" user file) streams is possible once the download has reached the requested
    ///     position, so long as the file is not being streamed in blocks (BASS_STREAM_BLOCK flag).
    ///     <para />
    ///     User streams (created with BASS_StreamCreate) are not seekable, but it is possible to reset a user stream
    ///     (including its buffer contents) by setting its position to byte 0.
    ///     <para />
    ///     The BASS_POS_DECODETO flag can be used to seek forwards in streams that are not normally seekable, like custom
    ///     streams or Internet streams that are using the BASS_STREAM_BLOCK flag, but it will only go as far as what is
    ///     currently available; it will not wait for more data to be downloaded, for example.
    ///     <para />
    ///     In some cases, particularly when the BASS_POS_INEXACT flag is used, the new position may not be what was requested.
    ///     <see cref="ChannelGetPosition" /> can be used to confirm what the new position actually is.
    ///     <para />
    ///     The BASS_POS_SCAN flag works the same way as the <see cref="StreamCreateFile" />
    ///     <see cref="StreamCreateFileConfig.Prescan" /> flag, and can be used to delay the scanning until after the stream
    ///     has been created. When a position beyond the end is requested, the call will fail (BASS_ERROR_POSITION error code)
    ///     but the seek table and exact length will have been scanned. When a file has been scanned, all seeking (even without
    ///     the BASS_POS_SCAN flag) within the scanned part of it will use the scanned infomation.
    ///     <para />
    /// </remarks>
    [BassFunction("BASS_ChannelSetPosition")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassError(ErrorCode.NotFile, "The stream is not a file stream.")]
    [BassError(ErrorCode.PositionError,
        "The requested position is invalid, eg. it is beyond the end or the download has not yet reached it.")]
    [BassError(ErrorCode.NotAvailable,
        "The requested mode is not available. Invalid flags are ignored and do not result in this error.")]
    [BassError(ErrorCode.Unknown, "Some other mystery problem!")]
    [BassBooleanVerification]
    public delegate bool ChannelSetPosition(IntPtr handle, UInt64 pos, PositionConfig mode);

    /// <summary>
    ///     Sets up a synchronizer on a MOD music, stream or recording channel.
    /// </summary>
    /// <param name="handle">The channel handle... a HMUSIC, HSTREAM or HRECORD. </param>
    /// <param name="type">The type of sync. </param>
    /// <param name="param">The sync parameter. Depends on the sync type... see the table below. </param>
    /// <param name="proc">The callback function. </param>
    /// <param name="user">User instance data to pass to the callback function. </param>
    /// <param name="Sync">types, with param and SYNCPROC data definitions. </param>
    /// <returns>
    ///     If successful, then the new synchronizer's handle is returned, else 0 is returned. Use <see cref="GetErrorCode"/> to get the
    ///     error code.
    /// </returns>
    /// <remarks>
    ///     Multiple synchronizers may be used per channel, and they can be set before and while playing. Equally,
    ///     synchronizers can also be removed at any time, using BASS_ChannelRemoveSync. If the BASS_SYNC_ONETIME flag is used,
    ///     then the sync is automatically removed after its first occurrence.
    ///     The BASS_SYNC_MIXTIME flag can be used with BASS_SYNC_END or BASS_SYNC_POS/MUSICPOS syncs to implement custom
    ///     looping, by using BASS_ChannelSetPosition in the callback. A mixtime sync can also be used to make DSP/FX changes
    ///     at specific points, or change a HMUSIC channel's flags or attributes. The BASS_SYNC_MIXTIME flag can also be useful
    ///     with a BASS_SYNC_SETPOS sync, to reset DSP states after seeking.
    ///     <para />
    ///     Several of the sync types are triggered in the process of rendering the channel's sample data; for example,
    ///     BASS_SYNC_POS and BASS_SYNC_END syncs, when the rendering reaches the sync position or the end, respectively. Those
    ///     sync types should be set before starting playback or pre-buffering (ie. before any rendering), to avoid missing any
    ///     early sync events.
    ///     <para />
    ///     With recording channels, BASS_SYNC_POS syncs are triggered just before the RECORDPROC receives the block of data
    ///     containing the sync position.
    ///     <para />
    /// </remarks>
    [BassFunction("BASS_ChannelSetSync")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassError(ErrorCode.IllegalType, "An illegal type was specified.")]
    [BassError(ErrorCode.IllegalParam, "An illegal param was specified.")]
    [BassPointerVerification]
    public delegate IntPtr ChannelSetSync(
        IntPtr handle, SyncHandlerType type, UInt64 param, SyncHandler proc, IntPtr user);

    /// <summary>
    ///     Slides a channel's attribute from its current value to a new value.
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HSTREAM, HMUSIC, or HRECORD. </param>
    /// <param name="attribute">The attribute to slide the value of... one of the following. </param>
    /// <param name="value">The new attribute value. See the attribute's documentation for details on the possible values. </param>
    /// <param name="time">The length of time (in milliseconds) that it should take for the attribute to reach the value. </param>
    /// <returns>
    ///     If successful, then TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    /// <remarks>
    ///     This function is similar to BASS_ChannelSetAttribute, except that the attribute is ramped to the value over the
    ///     specified period of time. Another difference is that the value is not pre-checked. If it is invalid, the slide will
    ///     simply end early.
    ///     If an attribute is already sliding, then the old slide is stopped and replaced by the new one.
    ///     <para />
    ///     BASS_ChannelIsSliding can be used to check if an attribute is currently sliding. A BASS_SYNC_SLIDE sync can also be
    ///     set via BASS_ChannelSetSync, to be triggered at the end of a slide. The sync will not be triggered in the case of
    ///     an existing slide being replaced by a new one.
    ///     <para />
    ///     Attribute slides are unaffected by whether the channel is playing, paused or stopped. They carry on regardless.
    ///     <para />
    /// </remarks>
    [BassFunction("BASS_ChannelSlideAttribute")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassError(ErrorCode.IllegalType, "attribute is not valid.")]
    [BassBooleanVerification]
    public delegate bool ChannelSlideAttribute(IntPtr handle, ChannelAttribute attribute, float value, uint time);

    /// <summary>
    ///     Stops a sample, stream, MOD music, or recording.
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM, or HRECORD. </param>
    /// <returns>
    ///     If successful, TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    /// <remarks>
    ///     Stopping a user stream (created with BASS_StreamCreate) will clear its buffer contents, and stopping a sample
    ///     channel (HCHANNEL) will result in it being freed. Use BASS_ChannelPause instead if you wish to stop a user stream
    ///     or sample and then resume it from the same point.
    ///     When used with a decoding channel, this function will end the channel at its current position, so that it is not
    ///     possible to decode any more data from it. Any BASS_SYNC_END syncs that have been set on the channel will not be
    ///     triggered by this; they are only triggered when reaching the natural end. BASS_ChannelSetPosition can be used to
    ///     reset the channel and start decoding again.
    ///     <para />
    /// </remarks>
    [BassFunction("BASS_ChannelStop")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassBooleanVerification]
    public delegate bool ChannelStop(IntPtr handle);

    /// <summary>
    ///     Updates the playback buffer of a stream or MOD music.
    /// </summary>
    /// <param name="handle">The channel handle... a HMUSIC or HSTREAM. </param>
    /// <param name="length">
    ///     The amount of data to render, in milliseconds... 0 = default (2 x update period). This is capped
    ///     at the space available in the buffer.
    /// </param>
    /// <returns>
    ///     If successful, TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode"/> to get the error code.
    /// </returns>
    /// <remarks>
    ///     When starting playback of a stream or MOD music, after creating it or changing its position, there will be a slight
    ///     delay while the initial data is generated for playback. Usually the delay is not noticeable or important, but if
    ///     you need playback to start instantly when you call BASS_ChannelPlay, then use this function first. The length
    ///     parameter should be at least equal to the update period.
    ///     It may not always be possible to render the requested amount of data, in which case this function will still
    ///     succeed. BASS_ChannelGetData (BASS_DATA_AVAILABLE) can be used to check how much data a channel has buffered for
    ///     playback.
    ///     <para />
    ///     When automatic updating is disabled (BASS_CONFIG_UPDATEPERIOD = 0 or BASS_CONFIG_UPDATETHREADS = 0), this function
    ///     could be used instead of BASS_Update to implement different update periods for different channels, instead of a
    ///     single update period for all. Unlike BASS_Update, this function can also be used while automatic updating is
    ///     enabled.
    ///     <para />
    ///     The CPU usage of this function is not included in the BASS_GetCPU reading, but is included in the channel's
    ///     BASS_ATTRIB_CPU attribute value.
    ///     <para />
    /// </remarks>
    [BassFunction("BASS_ChannelUpdate")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassError(ErrorCode.NotAvailable, "Decoding channels do not have playback buffers.")]
    [BassError(ErrorCode.Ended, "The channel has ended.")]
    [BassError(ErrorCode.Unknown, "Some other mystery problem!")]
    [BassBooleanVerification]
    public delegate bool ChannelUpdate(IntPtr handle, int length);
}