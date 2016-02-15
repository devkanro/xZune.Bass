// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Channel3DMode.cs
// Version: 20160215

namespace xZune.Bass.Interop.Core.Flags
{
    /// <summary>
    /// 3D mode of channel.
    /// </summary>
    public enum Channel3DMode
    {
        /// <summary>
        /// Normal 3D processing.
        /// </summary>
        Normal = Internal.Channel3DMode.Normal,

        /// <summary>
        /// The channel's 3D position (position/velocity/orientation) is relative to the listener. When the listener's position/velocity/orientation is changed with <see cref="Set3DPosition"/>, the channel's position relative to the listener does not change.
        /// </summary>
        Relative = Internal.Channel3DMode.Relative,

        /// <summary>
        /// Turn off 3D processing on the channel, the sound will be played in the centre.
        /// </summary>
        Off = Internal.Channel3DMode.Off
    }
}