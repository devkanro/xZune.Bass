// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: ChannelDisplayCallback.cs
// Version: 20160218

using System;
using xZune.Bass.Interop.Core;

namespace xZune.Bass
{
    /// <summary>
    ///     A channel display callback.
    /// </summary>
    public class ChannelDisplayCallback : ChannelCallback<DisplayHandler>
    {
        /// <summary>
        ///     Create a <see cref="ChannelDisplayCallback" /> with a handler and priority.
        /// </summary>
        /// <param name="handler">Display callback handler.</param>
        /// <param name="priority">
        ///     The priority of the new display callback, which determines its position in the display chain.
        ///     display callbacks with higher priority are called before those with lower.
        /// </param>
        public ChannelDisplayCallback(DisplayHandler handler, int priority) : base(handler)
        {
            Priority = priority;
        }

        /// <summary>
        ///     The priority of the new display callback, which determines its position in the display chain. display callbacks
        ///     with higher priority are called before those with lower.
        /// </summary>
        public int Priority { get; private set; }

        internal override void AttachToChannel(Channel channel)
        {
            Handle = ((IChannelInternal) channel).SetDisplayCallback(Callback, IntPtr.Zero, Priority);
            Channel = channel;
        }

        internal override void DeattachToChannel()
        {
            if (Channel == null) return;
            if (Handle == IntPtr.Zero) return;

            ((IChannelInternal) Channel).RemoveDisplayCallback(Handle);
        }
    }
}