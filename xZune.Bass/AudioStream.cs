// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: AudioStream.cs
// Version: 20160216

using System;
using System.Runtime.InteropServices;
using xZune.Bass.Interop.Core;
using xZune.Bass.Interop.Core.Flags;
using xZune.Bass.Modules;

namespace xZune.Bass
{
    /// <summary>
    ///     A audio sample stream.
    /// </summary>
    public class AudioStream : Channel, IStream
    {
        #region -- Protected creator --

        protected AudioStream()
        {
        }

        #endregion -- Protected creator --

        #region -- Creator --

        /// <summary>
        ///     Creates a user sample stream.
        /// </summary>
        /// <param name="freq">The default sample rate. The sample rate can be changed using <see cref="Channel.SetAttribute" />. </param>
        /// <param name="channels">The number of channels... 1 = mono, 2 = stereo, 4 = quadraphonic, 6 = 5.1, 8 = 7.1. </param>
        /// <param name="configs">Configure of create a steam. </param>
        /// <param name="handler">
        ///     The user defined stream writing function, or one of the <see cref="PresetStreamPushHandler" />
        ///     and <see cref="PresetStreamDummyHandler" />.
        /// </param>
        /// <param name="user">User instance data to pass to the callback function. Unused when creating a dummy or push stream. </param>
        /// <returns>
        ///     If successful, the new stream's handle is returned, else 0 is returned. Use <see cref="GetErrorCode" /> to get the
        ///     error code.
        /// </returns>
        /// <remarks>
        ///     Sample streams allow any sample data to be played through Bass, and are particularly useful for playing a large
        ///     amount of sample data without requiring a large amount of memory. If you wish to play a sample format that BASS
        ///     does not support, then you can create a stream and decode the sample data into it.
        ///     BASS can automatically stream MP3, MP2, MP1, OGG, WAV and AIFF files, using <see cref="CreateFile" />, and also
        ///     from HTTP and FTP servers, using <see cref="CreateURL" />. <see cref="CreateFileUser" /> allows streaming from
        ///     other sources too.
        /// </remarks>
        public AudioStream(StreamHandler handler, int freq, int channels, StreamCreateConfig configs, IntPtr user)
        {
            IntPtr handlerHandle = IntPtr.Zero;

            if (handler == PresetStreamDummyHandler)
            {
                handlerHandle = PresetStreamProcess.Dummy;
            }
            else if (handler == PresetStreamPushHandler)
            {
                handlerHandle = PresetStreamProcess.Push;
            }
            else
            {
                handlerHandle = Marshal.GetFunctionPointerForDelegate(handlerHandle);
            }

            Handle =
                AudioStreamModule.StreamCreateFunction.CheckResult(
                    AudioStreamModule.StreamCreateFunction.Delegate(freq, channels, configs,
                        handlerHandle, user));
        }

        #endregion -- Creator --

        /// <summary>
        ///     Adds sample data to a "push" stream.
        /// </summary>
        /// <param name="buffer">
        ///     Pointer to the sample data... NULL = allocate space in the queue buffer so that there is at least
        ///     length bytes of free space. Empty array can be used to just check how much data is queued.
        /// </param>
        /// <returns>The number of bytes read from buffer.</returns>
        /// <exception cref="BassErrorException">
        ///     Some error occur to call a Bass function, check the error code and error message
        ///     to get more error infomation.
        /// </exception>
        /// <exception cref="BassNotLoadedException">
        ///     Bass DLL not loaded, you must use <see cref="BassManager.Initialize" /> to
        ///     load Bass DLL first.
        /// </exception>
        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        public virtual int PutData(byte[] buffer)
        {
            CheckAvailable();

            GCHandle? bufferHandle = (buffer != null && buffer.Length != 0)
                ? GCHandle.Alloc(buffer, GCHandleType.Pinned)
                : (GCHandle?) null;

            return AudioStreamModule.StreamPutDataFunction.CheckResult(
                AudioStreamModule.StreamPutDataFunction.Delegate(Handle,
                    bufferHandle?.AddrOfPinnedObject() ?? IntPtr.Zero,
                    buffer?.Length ?? 0));
        }

        /// <summary>
        ///     Frees a sample stream's resources, including any sync/DSP/FX it has.
        /// </summary>
        /// <exception cref="BassErrorException">
        ///     Some error occur to call a Bass function, check the error code and error message
        ///     to get more error infomation.
        /// </exception>
        /// <exception cref="BassNotLoadedException">
        ///     Bass DLL not loaded, you must use <see cref="BassManager.Initialize" /> to
        ///     load Bass DLL first.
        /// </exception>
        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        protected override void Free()
        {
            CheckAvailable();
            
            AudioStreamModule.StreamFreeFunction.CheckResult(
                AudioStreamModule.StreamFreeFunction.Delegate(Handle));

            Handle = IntPtr.Zero;
            IsAvailable = false;
        }

        #region -- Release --

        protected override void ReleaseManaged()
        {
        }

        protected override void ReleaseUnmanaged()
        {
            Free();
        }

        #endregion
        
        #region -- Preset stream handler --

        /// <summary>
        ///     Create a "dummy" stream. A dummy stream does not have any sample data of its own, but a decoding dummy stream (with
        ///     <see cref="StreamCreateConfig.Decode" /> flag) can be used to apply DSP/FX processing to any sample data, by
        ///     setting DSP/FX on the stream and feeding the data through <see cref="Channel.GetData" />. The dummy stream should
        ///     have the same sample format as the data being fed through it.
        /// </summary>
        public static StreamHandler PresetStreamDummyHandler => (handle, buffer, length, user) => 0;

        /// <summary>
        ///     Create a "push" stream. Instead of Bass pulling data from a <see cref="StreamHandler" /> function, data is pushed
        ///     to Bass via <see cref="PutData" />.
        /// </summary>
        public static StreamHandler PresetStreamPushHandler => (handle, buffer, length, user) => 0xFFFFFFFF;

        #endregion -- Preset stream handler --
    }
}