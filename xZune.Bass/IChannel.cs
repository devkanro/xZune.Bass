// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: IChannel.cs
// Version: 20160216

namespace xZune.Bass
{
    /// <summary>
    ///     A "channel" can be a sample playback channel (<see cref="ISample" />), a sample stream (<see cref="IStream" />), a
    ///     MOD music (<see cref="IMusic" />), or a recording (<see cref="IRecord" />). Each "Channel" function can be used
    ///     with one or more of these channel types.
    /// </summary>
    public interface IChannel : IHandleObject
    {
        void Free();

        bool IsAvailable { get; }
    }
}