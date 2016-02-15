// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: ChannelStatus.cs
// Version: 20160215

namespace xZune.Bass.Interop.Core.Flags
{
    /// <summary>
    ///     Status of channel.
    /// </summary>
    public enum ChannelStatus
    {
        /// <summary>
        ///     The channel is not active, or handle is not a valid channel.
        /// </summary>
        Stopped = Internal.ChannelStatus.Stopped,

        /// <summary>
        ///     The channel is playing (or recording).
        /// </summary>
        Playing = Internal.ChannelStatus.Playing,

        /// <summary>
        ///     Playback of the stream has been stalled due to a lack of sample data. The playback will automatically resume once
        ///     there is sufficient data to do so.
        /// </summary>
        Stalled = Internal.ChannelStatus.Stalled,

        /// <summary>
        ///     The channel is paused.
        /// </summary>
        Paused = Internal.ChannelStatus.Paused
    }
}