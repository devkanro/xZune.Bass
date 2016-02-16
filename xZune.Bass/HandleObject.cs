using System;

namespace xZune.Bass
{
    public abstract class HandleObject : IHandleObject
    {
        public HandleObject()
        {
        }

        public IntPtr Handle
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

                HandleManager.Remove(this);
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
}