// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: HandleObject.cs
// Version: 20160218

using System;

namespace xZune.Bass
{
    /// <summary>
    /// A object with handle.
    /// </summary>
    public abstract class HandleObject : IHandleObject
    {
        /// <summary>
        /// Handle of <see cref="HandleObject"/>.
        /// </summary>
        public virtual IntPtr Handle
        {
            get { return _handle; }
            protected set
            {
                HandleManager.Remove(this);
                _handle = value;
                HandleManager.Add(this);
            }
        }

        #region IDisposable Support

        private bool disposedValue;
        private IntPtr _handle;

        /// <summary>
        /// Release managed resource.
        /// </summary>
        protected abstract void ReleaseManaged();

        /// <summary>
        /// Release unmanaged resource.
        /// </summary>
        protected abstract void ReleaseUnmanaged();

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    ReleaseManaged();
                }

                ReleaseUnmanaged();
                Handle = IntPtr.Zero;

                disposedValue = true;
            }
        }

        ~HandleObject()
        {
            Dispose(false);
        }

        /// <summary>
        /// Release all resource.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support
    }
}