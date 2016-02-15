// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: PositionConfig.cs
// Version: 20160215
namespace xZune.Bass.Interop.Core.Flags
{
    /// <summary>
    /// Configure used in <see cref="ChannelGetLength"/>, <see cref="GetPosition"/> or <see cref="SetPosition"/>.
    /// </summary>
    public enum PositionConfig
    {
        /// <summary>
        /// Get the length in bytes. 
        /// </summary>
        Byte = Internal.PositionConfig.Byte,
        /// <summary>
        /// Get the length in orders. (HMUSIC only) 
        /// </summary>
        MusicOrder = Internal.PositionConfig.MusicOrder,
        /// <summary>
        /// Get the number of bitstreams in an OGG file. 
        /// </summary>
        Ogg = Internal.PositionConfig.Ogg,
        Inexact = Internal.PositionConfig.Inexact,
        /// <summary>
        /// Flag: Get the decoding/rendering position, which may be ahead of the playback position due to buffering. This flag is unnecessary with decoding channels because the decoding position will always be given for them anyway, as they do not have playback buffers. 
        /// </summary>
        Decode = Internal.PositionConfig.Decode,
        DecodeTo = Internal.PositionConfig.DecodeTo,
        Scan = Internal.PositionConfig.Scan
    }
}