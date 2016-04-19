// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Record.cs
// Version: 20160219

using System;
using System.Runtime.InteropServices;
using xZune.Bass.Interop.Core;

namespace xZune.Bass
{
    /// <summary>
    ///     A recording channel, it will be auto free after stopped.
    /// </summary>
    public class Record : Channel, IRecord
    {
        private GCHandle _recordHandlerHandle;

        internal RecordHandler RecordHandler;

        internal Record()
        {
            RecordHandler = OnRecording;
            _recordHandlerHandle = GCHandle.Alloc(RecordHandler);
        }

        /// <summary>
        ///     On recording.
        /// </summary>
        public event RecordingEventHandler Recording;

        internal void SetHandle(IntPtr handle)
        {
            Handle = handle;
        }

        protected override void ReleaseManaged()
        {
        }

        protected override void ReleaseUnmanaged()
        {
            Free();
        }

        protected override void Free()
        {
            _recordHandlerHandle.Free();
        }

        private bool OnRecording(IntPtr handle, IntPtr buffer, uint length, IntPtr user)
        {
            if (Recording != null)
            {
                var e = new RecordingEventArgs(buffer, length);
                Recording?.Invoke(this, e);
                return !e.IsStopRecording;
            }
            return true;
        }
    }
    
    public delegate void RecordingEventHandler(object sender, RecordingEventArgs args);
}