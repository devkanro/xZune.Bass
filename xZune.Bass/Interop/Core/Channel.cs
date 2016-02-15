// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Channel.cs
// Version: 20160215

using System;
using xZune.Bass.Interop.Core.Flags;

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
    [BassFuction("BASS_ChannelBytes2Seconds")]
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
    [BassFuction("BASS_ChannelFlags")]
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
    [BassFuction("BASS_ChannelGet3DAttributes")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassError(ErrorCode.No3D, "The channel does not have 3D functionality.")]
    [BassBooleanVerification]
    public delegate bool ChannelGet3DAttributes(
        IntPtr handle, ref uint mode, ref float min, ref float max, ref uint iangle, ref uint oangle, ref float outvol);

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
    [BassFuction("BASS_ChannelGet3DPosition")]
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
    [BassFuction("BASS_ChannelGetAttribute")]
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
    [BassFuction("BASS_ChannelGetAttributeEx")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassError(ErrorCode.NotAvailable, "The attribute is not available.")]
    [BassError(ErrorCode.IllegalType, "attribute is not valid.")]
    [BassError(ErrorCode.IllegalParam, "size is not valid.")]
    [BassInt32Verification]
    public delegate int ChannelGetAttributeEx(IntPtr handle, ChannelAttribute attrib, IntPtr value, int size);

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
    [BassFuction("BASS_ChannelGetData")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassError(ErrorCode.Ended, "The channel has reached the end.")]
    [BassError(ErrorCode.NotAvailable, "The BASS_DATA_AVAILABLE flag was used with a decoding channel.")]
    [BassError(ErrorCode.BufferLost, "Should not happen... check that a valid window handle was used with Initialize()."
        )]
    [BassInt32Verification]
    public delegate int ChannelGetData(IntPtr handle, IntPtr buffer, SampleDataType length);

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
    [BassFuction("BASS_ChannelGetDevice")]
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
    [BassFuction("BASS_ChannelGetInfo")]
    [BassError(ErrorCode.BadHandle, "handle is not valid.")]
    [BassBooleanVerification]
    public delegate bool ChannelGetInfo(IntPtr handle, IntPtr info);

    /// <summary> 
    /// Retrieves the playback length of a channel. 
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM. HSAMPLE handles may also be used. </param>
    /// <param name="mode">How to retrieve the length. One of the following. </param>
    /// <param name="other">modes may be supported by add-ons, see the documentation. </param>
    /// <returns>
    /// If successful, then the channel's length is returned, else -1 is returned. Use BASS_ErrorGetCode to get the error code.
    /// </returns>
    /// <remarks>
    /// The exact length of a stream will be returned once the whole file has been streamed, but until then it is not always possible to 100% accurately estimate the length. The length is always exact for MP3/MP2/MP1 files when the BASS_STREAM_PRESCAN flag is used in the BASS_StreamCreateFile call, otherwise it is an (usually accurate) estimation based on the file size. The length returned for OGG files will usually be exact (assuming the file is not corrupt), but when streaming from the internet (or "buffered" user file), it can be a very rough estimation until the whole file has been downloaded. It will also be an estimate for chained OGG files that are not pre-scanned.
    /// Unless an OGG file contains a single bit-stream, the number of bit-streams it contains will only be available if it was pre-scanned at the stream's creation.
    /// <para/>
    /// Retrieving the byte length of a MOD music requires that the BASS_MUSIC_PRESCAN flag was used in the <see cref="MusicLoad"/> call.
    /// <para/>
    /// </remarks>
    [BassFuction("BASS_ChannelGetLength")]
    [BassError(ErrorCode.BadHandle, "handle is not valid.")]
    [BassError(ErrorCode.NotAvailable, "The requested length is not available.")]
    [BassUInt64VerificationAttribute]
    public delegate UInt64 ChannelGetLength(IntPtr handle, PositionConfig mode);

    /// <summary> 
    /// Retrieves the level (peak amplitude) of a sample, stream, MOD music, or recording channel. 
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM, or HRECORD. </param>
    /// <returns>
    /// If an error occurs, -1 is returned, use BASS_ErrorGetCode to get the error code. If successful, the level of the left channel is returned in the low word (low 16 bits), and the level of the right channel is returned in the high word (high 16 bits). If the channel is mono, then the low word is duplicated in the high word. The level ranges linearly from 0 (silent) to 32768 (max). 0 will be returned when a channel is stalled.
    /// </returns>
    /// <remarks>
    /// This function measures the level of the channel's sample data, not its level in the final output mix, so the channel's volume (BASS_ATTRIB_VOL attribute) and panning (BASS_ATTRIB_PAN) does not affect it. The effect of any DSP/FX set on the channel is present in the measurement, except for DX8 effects when using the "With FX flag" DX8 effect implementation.
    /// For channels that are more than stereo, the left level will include all left channels (eg. front-left, rear-left, center), and the right will include all right (front-right, rear-right, LFE). If there are an odd number of channels then the left and right levels will include all channels. If the level of each individual channel is required, that is available from BASS_ChannelGetLevelEx.
    /// <para/>
    /// 20ms of data is inspected to calculate the level. When used with a decoding channel, that means 20ms of data needs to be decoded from the channel in order to calculate the level, and that data is then gone, eg. it is not available to a subsequent BASS_ChannelGetData call.
    /// <para/>
    /// More flexible level retrieval is available with BASS_ChannelGetLevelEx.
    /// <para/>
    /// </remarks>
    [BassFuction("BASS_ChannelGetLevel")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassError(ErrorCode.NoPlay, "The channel is not playing.")]
    [BassError(ErrorCode.Ended, "The decoding channel has reached the end.")]
    [BassError(ErrorCode.BufferLost, "Should not happen... check that a valid window handle was used with Initialize().")]
    [BassInt32VerificationAttribute]
    public delegate int ChannelGetLevel(IntPtr handle);

    /// <summary> 
    /// Retrieves the level of a sample, stream, MOD music, or recording channel. 
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM, or HRECORD. </param>
    /// <param name="levels">An array to receive the levels. </param>
    /// <param name="length">The amount of data to inspect to calculate the level, in seconds. The maximum is 1 second. Less data than requested may be used if the full amount is not available, eg. if the channel's playback buffer is shorter. </param>
    /// <param name="flags">A combination of these flags. </param>
    /// <returns>
    /// If successful, TRUE is returned, else FALSE is returned. Use BASS_ErrorGetCode to get the error code.
    /// </returns>
    /// <remarks>
    /// This function operates in the same way as BASS_ChannelGetLevel but has greater flexibility on how the level is measured. The levels are not clipped, so may exceed +/-1.0 on floating-point channels.
    /// </remarks>
    [BassFuction("BASS_ChannelGetLevelEx")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassError(ErrorCode.IllegalParam, "length is not valid.")]
    [BassError(ErrorCode.NoPlay, "The channel is not playing.")]
    [BassError(ErrorCode.Ended, "The decoding channel has reached the end.")]
    [BassError(ErrorCode.BufferLost, "Should not happen... check that a valid window handle was used with Initialize().")]
    [BassBooleanVerificationAttribute]
    public delegate bool ChannelGetLevelEx(IntPtr handle, ref float levels, float length, LevelConfig flags);

    /// <summary> 
    /// Retrieves the playback position of a sample, stream, or MOD music. Can also be used with a recording channel. 
    /// </summary>
    /// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM, or HRECORD. </param>
    /// <param name="mode">How to retrieve the position. One of the following, with optional flags. </param>
    /// <returns>
    /// If successful, then the channel's position is returned, else -1 is returned. Use BASS_ErrorGetCode to get the error code.
    /// </returns>
    [BassFuction("BASS_ChannelGetPosition")]
    [BassError(ErrorCode.BadHandle, "handle is not a valid channel.")]
    [BassError(ErrorCode.NotAvailable, "The requested position is not available.")]
    [BassError(ErrorCode.Unknown, "Some other mystery problem!")]
    [BassUInt64VerificationAttribute]
    public delegate UInt64 ChannelGetPosition(int handle, PositionConfig mode);

    /// <summary> 
    /// Retrieves tags/headers from a channel. 
    /// </summary>
    /// <param name="handle">The channel handle... a HMUSIC or HSTREAM. </param>
    /// <param name="tags">The tags/headers wanted... one of the following. </param>
    /// <returns>
    /// If successful, the requested tags are returned, else NULL is returned. Use BASS_ErrorGetCode to get the error code.
    /// </returns>
    /// <remarks>
    /// Some tags (eg. ID3v1) are located at the end of the file, so when streaming a file from the Internet, the tags will not be available until the download is complete. A BASS_SYNC_DOWNLOAD sync can be set via BASS_ChannelSetSync, to be informed of when the download is complete. A BASS_SYNC_META sync can be used to be informed of new Shoutcast metadata, and a BASS_SYNC_OGG_CHANGE sync for when a new logical bitstream begins in a chained OGG stream, which generally brings new OGG tags.
    /// In a chained OGG file containing multiple bit-streams, each bit-stream will have its own tags. To get the tags from a particular one, BASS_ChannelSetPosition can be first used to seek to it.
    /// <para/>
    /// When a Media Foundation codec is in use, the BASS_TAG_WAVEFORMAT tag can be used to find out what the source format is, eg. via the WAVEFORMATEX structure's wFormatTag member. Some typical wFormatTag examples are: 0x0161 = WMA, 0x0162 = WMA pro, 0x0163 = WMA lossless, 0x1610 = AAC.
    /// <para/>
    /// </remarks>
    [BassFuction("BASS_ChannelGetTags")]
    [BassError(ErrorCode.BadHandle, "handle is not valid.")]
    [BassError(ErrorCode.NotAvailable, "The requested tags are not available.")]
    [BassPointerVerification]
    public delegate IntPtr ChannelGetTags(int handle, TagType tags);
}