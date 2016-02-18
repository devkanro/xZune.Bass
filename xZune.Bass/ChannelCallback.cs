// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: ChannelCallback.cs
// Version: 20160218

using System;
using System.Runtime.InteropServices;

namespace xZune.Bass
{
    /// <summary>
    ///     Manage a channel callback handle.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ChannelCallback<T> : HandleObject
    {
        private GCHandle _callbackHandle;

        /// <summary>
        ///     Create a <see cref="ChannelCallback{T}" /> with a handle of callback.
        /// </summary>
        /// <param name="handler"></param>
        public ChannelCallback(T handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }
            Callback = handler;
            _callbackHandle = GCHandle.Alloc(Callback);
        }

        /// <summary>
        ///     Get the delegate of callback.
        /// </summary>
        public T Callback { get; private set; }

        /// <summary>
        ///     Get target channel.
        /// </summary>
        public Channel Channel { get; protected set; }

        internal abstract void AttachToChannel(Channel channel);

        internal abstract void DeattachToChannel();

        protected override void ReleaseManaged()
        {
        }

        protected override void ReleaseUnmanaged()
        {
            DeattachToChannel();
            Channel = null;
            _callbackHandle.Free();
        }
    }
}