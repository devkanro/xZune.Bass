using System;
using System.Runtime.InteropServices;
using xZune.Bass.Interop.Core;
using xZune.Bass.Interop.Core.Flags;

namespace xZune.Bass
{
    public abstract class HandleObject : IHandleObject
    {
        public HandleObject()
        {
        }

        public virtual IntPtr Handle
        {
            get
            {
                return _handle;
            }
            protected set
            {
                HandleManager.Remove(this);
                _handle = value;
                HandleManager.Add(this);
            }
        }

        #region IDisposable Support

        private bool disposedValue = false;
        private IntPtr _handle;

        protected abstract void ReleaseManaged();

        protected abstract void ReleaseUnmanaged();

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    ReleaseManaged();
                }
                
                Handle = IntPtr.Zero;
                ReleaseUnmanaged();

                disposedValue = true;
            }
        }

        ~HandleObject()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support
    }

    public abstract class ChannelCallback<T> : HandleObject
    {
        public ChannelCallback(T handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }
            Callback = handler;
            _callbackHandle = GCHandle.Alloc(Callback);
        }
        
        public T Callback { get; private set; }
        public Channel Channel { get; protected set; }

        private GCHandle _callbackHandle;

        internal abstract void AttachToChannel(Channel channel);
        internal abstract void DeattachToChannel();

        protected override void ReleaseManaged()
        {

        }

        protected override void ReleaseUnmanaged()
        {
            DeattachToChannel();
            _callbackHandle.Free();
        }


    }

    public class ChannelSyncCallback : ChannelCallback<SyncHandler>
    {
        public ChannelSyncCallback(SyncHandler handler, SyncHandlerType type, UInt64 param) : base(handler)
        {
            Type = type;
            Param = param;
        }

        public SyncHandlerType Type { get; private set; }
        public UInt64 Param { get; private set; }
        internal override void AttachToChannel(Channel channel)
        {
            Handle = ((IChannelInternal) channel).SetSyncCallback(Type, Param, Callback, IntPtr.Zero);
            Channel = channel;
        }

        internal override void DeattachToChannel()
        {
            if (Channel == null) return;
            if(Handle == IntPtr.Zero) return;
            
            ((IChannelInternal)Channel).RemoveSyncCallback(Handle);
        }
    }

    public class ChannelDisplayCallback : ChannelCallback<DisplayHandler>
    {
        public ChannelDisplayCallback(DisplayHandler handler, int priority) : base(handler)
        {
            Priority = priority;
        }

        public int Priority { get; private set; }

        internal override void AttachToChannel(Channel channel)
        {
            Handle = ((IChannelInternal)channel).SetDisplayCallback(Callback, IntPtr.Zero, Priority);
            Channel = channel;
        }

        internal override void DeattachToChannel()
        {
            if (Channel == null) return;
            if (Handle == IntPtr.Zero) return;

            ((IChannelInternal)Channel).RemoveDisplayCallback(Handle);
        }
    }
}