// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: RecordingEventArgs.cs
// Version: 20160219

using System;

namespace xZune.Bass
{
    /// <summary>
    ///     Some infomation of recording.
    /// </summary>
    public class RecordingEventArgs : EventArgs
    {
        internal RecordingEventArgs(IntPtr buffer, uint length)
        {
            Buffer = buffer;
            Length = length;
            IsStopRecording = false;
        }

        /// <summary>
        ///     Pointer to the recorded sample data. The sample data is in standard Windows PCM format, that is 8-bit samples are
        ///     unsigned, 16-bit samples are signed, 32-bit floating-point samples range from -1 to +1.
        /// </summary>
        public IntPtr Buffer { get; private set; }

        /// <summary>
        ///     The number of bytes in the buffer.
        /// </summary>
        public uint Length { get; private set; }

        /// <summary>
        ///     Set true to stop recording.
        /// </summary>
        public bool IsStopRecording { get; set; }
    }
}