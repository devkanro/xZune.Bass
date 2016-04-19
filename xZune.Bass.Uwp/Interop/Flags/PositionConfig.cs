// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: PositionConfig.cs
// Version: 20160216

using xZune.Bass.Interop.Core;

namespace xZune.Bass.Interop.Flags
{
    /// <summary>
    ///     Configure used in <see cref="ChannelGetLength" />, <see cref="ChannelGetPosition" /> or <see cref="ChannelSetPosition" />.
    /// </summary>
    public enum PositionConfig : uint
    {
        /// <summary>
        ///     Get the length in bytes.
        /// </summary>
        Byte = Internal.PositionConfig.Byte,

        /// <summary>
        ///     Get the length in orders. (HMUSIC only)
        /// </summary>
        MusicOrder = Internal.PositionConfig.MusicOrder,

        /// <summary>
        ///     Get the number of bit-streams in an OGG file.
        /// </summary>
        Ogg = Internal.PositionConfig.Ogg,

        Inexact = Internal.PositionConfig.Inexact,

        /// <summary>
        ///     Flag: Get the decoding/rendering position, which may be ahead of the playback position due to buffering. This flag
        ///     is unnecessary with decoding channels because the decoding position will always be given for them anyway, as they
        ///     do not have playback buffers.
        /// </summary>
        Decode = Internal.PositionConfig.Decode,

        /// <summary>
        ///     Flag: Decode/render up to the position rather than seeking to it. This is useful for streams that are unseekable or
        ///     that have inexact seeking, but it is generally slower than normal seeking and the requested position cannot be
        ///     behind the current decoding position. This flag can only be used with the BASS_POS_BYTE mode.
        /// </summary>
        DecodeTo = Internal.PositionConfig.DecodeTo,

        /// <summary>
        ///     Flag: Scan the file to build a seek table up to the position, if it has not already been scanned. Scanning will
        ///     continue from where it left off previously rather than restarting from the beginning of the file each time. This
        ///     flag only applies to MP3/MP2/MP1 files and will be ignored with other file formats.
        /// </summary>
        Scan = Internal.PositionConfig.Scan,

        /// <summary>
        ///     Flag: Stop all notes. This flag is applied automatically if it has been set on the channel, eg. via
        ///     <see cref="ChannelFlags" />. (HMUSIC)
        /// </summary>
        PosRest = Internal.MusicConfig.PosReset,

        /// <summary>
        ///     Flag: Stop all notes and reset bpm/etc. This flag is applied automatically if it has been set on the channel, eg.
        ///     via <see cref="ChannelFlags" />. (HMUSIC)
        /// </summary>
        PosResetEx = Internal.MusicConfig.PosResetEx
    }
}