// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: ChannelSyncCallback.cs
// Version: 20160218

using System;
using xZune.Bass.Interop.Core;
using xZune.Bass.Interop.Core.Flags;

namespace xZune.Bass
{
    /// <summary>
    ///     A channel sync callback.
    /// </summary>
    public class ChannelSyncCallback : ChannelCallback<SyncHandler>
    {
        /// <summary>
        ///     Create <see cref="ChannelSyncCallback" /> with a handler, type of callback, and parameter.
        /// </summary>
        /// <param name="handler">Sync callback handler.</param>
        /// <param name="type">Type of sync callback.</param>
        /// <param name="param">The sync parameter.</param>
        public ChannelSyncCallback(SyncHandler handler, SyncHandlerType type, UInt64 param) : base(handler)
        {
            Type = type;
            Param = param;
        }

        /// <summary>
        ///     Type of sync callback.
        /// </summary>
        public SyncHandlerType Type { get; private set; }

        /// <summary>
        ///     Parameter of callback.
        /// </summary>
        public UInt64 Param { get; private set; }

        internal override void AttachToChannel(Channel channel)
        {
            try
            {
                Handle = ((IChannelInternal)channel).SetSyncCallback(Type, Param, Callback, IntPtr.Zero);
                Channel = channel;
            }
            catch (Exception)
            {
                Dispose();
            }
        }

        internal override void DeattachToChannel()
        {
            if (Channel == null) return;
            if (Handle == IntPtr.Zero) return;

            try
            {
                ((IChannelInternal)Channel).RemoveSyncCallback(Handle);
            }
            catch (Exception)
            {

            }
        }
    }
}