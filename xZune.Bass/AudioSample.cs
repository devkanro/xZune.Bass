// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: AudioSample.cs
// Version: 20160218

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using xZune.Bass.Interop;
using xZune.Bass.Interop.Core;
using xZune.Bass.Interop.Flags;
using xZune.Bass.Modules;

namespace xZune.Bass
{
    /// <summary>
    ///     A audio sample.
    /// </summary>
    public class AudioSample : HandleObject, ISample
    {
        protected AudioSample()
        {
            IsAvailable = true;
        }

        /// <summary>
        ///     Creates a new sample.
        /// </summary>
        /// <param name="length">The sample's length, in bytes. </param>
        /// <param name="freq">The default sample rate. </param>
        /// <param name="channels">The number of channels... 1 = mono, 2 = stereo, etc. </param>
        /// <param name="max">
        ///     Maximum number of simultaneous playbacks... 1 (min) - 65535 (max)... use one of the
        ///     SampleConfig.OverXX flags to choose the override decider, in the case of there being no free channel available for
        ///     playback (ie. the sample is already playing max times).
        /// </param>
        /// <param name="config">Some configures of sample.</param>
        /// <exception cref="BassNotLoadedException">
        ///     Bass DLL not loaded, you must use <see cref="Initialize" /> to load Bass DLL
        ///     first.
        /// </exception>
        /// <exception cref="BassErrorException">
        ///     Some error occur to call a Bass function, check the error code and error message
        ///     to get more error information.
        /// </exception>
        public AudioSample(uint length, uint freq, uint channels, uint max, SampleConfig config) : this()
        {
            Handle = AudioSampleModule.SampleCreateFunction.CheckResult(
                AudioSampleModule.SampleCreateFunction.Delegate(length, freq, channels, max, config));
        }

        /// <summary>
        ///     Create a sample form a  WAV, AIFF, MP3, MP2, MP1, OGG or plug-in supported file sample.
        /// </summary>
        /// <param name="file">File name. </param>
        /// <param name="offset">File offset to load the sample from.</param>
        /// <param name="length">
        ///     Data length... 0 = use all data up to the end of file. If length over-runs the end of the file, it
        ///     will automatically be lowered to the end of the file.
        /// </param>
        /// <param name="max">
        ///     Maximum number of simultaneous playbacks... 1 (min) - 65535 (max)... use one of the
        ///     SampleConfig.OverXX flags to choose the override decider, in the case of there being no free channel available for
        ///     playback (ie. the sample is already playing max times).
        /// </param>
        /// <param name="config">Some configures of sample.</param>
        public AudioSample(String file, UInt64 offset, uint length, uint max, SampleLoadConfig config) : this()
        {
            config |= SampleLoadConfig.Unicode;

            using (var fileHandle = InteropHelper.StringToPtr(file))
            {
                Handle = AudioSampleModule.SampleLoadFunction.CheckResult(
                    AudioSampleModule.SampleLoadFunction.Delegate(false, fileHandle.Handle, offset, length,
                        max, config));
            }
        }

        /// <summary>
        ///     Create a sample form a  WAV, AIFF, MP3, MP2, MP1, OGG or plug-in supported file sample stream.
        /// </summary>
        /// <param name="stream">A .NET memory stream. </param>
        /// <param name="max">
        ///     Maximum number of simultaneous playbacks... 1 (min) - 65535 (max)... use one of the
        ///     SampleConfig.OverXX flags to choose the override decider, in the case of there being no free channel available for
        ///     playback (ie. the sample is already playing max times).
        /// </param>
        /// <param name="config">Some configures of sample.</param>
        public AudioSample(MemoryStream stream, uint max, SampleLoadConfig config) : this()
        {
            ArraySegment<byte> bufferSegment;
            byte[] buffer = null;
            if (stream.TryGetBuffer(out bufferSegment))
            {
                buffer = bufferSegment.Array;
            }
            else
            {
                buffer = stream.ToArray();
            }

            GCHandle bufferHandle = GCHandle.Alloc(buffer);

            Handle = AudioSampleModule.SampleLoadFunction.CheckResult(
                AudioSampleModule.SampleLoadFunction.Delegate(true, bufferHandle.AddrOfPinnedObject(), 0,
                    (uint) stream.Length, max, config));

            bufferHandle.Free();
        }

        /// <summary>
        ///     Get or a sample's default attributes and other information.
        /// </summary>
        /// <exception cref="NotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">
        ///     Some error occur to call a Bass function, check the error code and error message
        ///     to get more error information.
        /// </exception>
        /// <exception cref="BassNotLoadedException">
        ///     Bass DLL not loaded, you must use <see cref="Initialize" /> to load Bass DLL
        ///     first.
        /// </exception>
        public SampleInfo Information
        {
            get
            {
                CheckAvailable();

                SampleInfo info = new SampleInfo();
                AudioSampleModule.SampleGetInfoFunction.CheckResult(
                    AudioSampleModule.SampleGetInfoFunction.Delegate(Handle, ref info));
                return info;
            }
            set
            {
                CheckAvailable();

                AudioSampleModule.SampleSetInfoFunction.CheckResult(
                    AudioSampleModule.SampleSetInfoFunction.Delegate(Handle, ref value));
            }
        }

        /// <summary>
        ///     Get a copy of a sample's data, or set data to buffer of sample.
        /// </summary>
        /// <exception cref="InvalidSampleDataException" accessor="set">Invalid data for this sample.</exception>
        /// <exception cref="NotAvailableException" accessor="get">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException" accessor="get">
        ///     Some error occur to call a Bass function, check the error code and
        ///     error message to get more error information.
        /// </exception>
        /// <exception cref="BassNotLoadedException" accessor="get">
        ///     Bass DLL not loaded, you must use <see cref="Initialize" /> to
        ///     load Bass DLL first.
        /// </exception>
        public byte[] Data
        {
            get
            {
                CheckAvailable();

                byte[] result = new byte[Information.Length];
                GCHandle resultHandle = GCHandle.Alloc(result, GCHandleType.Pinned);

                AudioSampleModule.SampleGetDataFunction.CheckResult(
                    AudioSampleModule.SampleGetDataFunction.Delegate(Handle, resultHandle.AddrOfPinnedObject()));

                resultHandle.Free();
                return result;
            }
            set
            {
                CheckAvailable();

                var info = Information;
                if (info.Length != value.Length)
                {
                    throw new InvalidSampleDataException((uint) value.Length, info.Length);
                }

                GCHandle resultHandle = GCHandle.Alloc(value, GCHandleType.Pinned);
                AudioSampleModule.SampleSetDataFunction.CheckResult(
                    AudioSampleModule.SampleSetDataFunction.Delegate(Handle, resultHandle.AddrOfPinnedObject()));
                resultHandle.Free();
            }
        }

        /// <summary>
        ///     Stops all channels instances of a sample.
        /// </summary>
        /// <exception cref="NotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">
        ///     Some error occur to call a Bass function, check the error code and error message
        ///     to get more error information.
        /// </exception>
        /// <exception cref="BassNotLoadedException">
        ///     Bass DLL not loaded, you must use <see cref="Initialize" /> to load Bass DLL
        ///     first.
        /// </exception>
        public void Stop()
        {
            CheckAvailable();

            AudioSampleModule.SampleStopFunction.CheckResult(AudioSampleModule.SampleStopFunction.Delegate(Handle));
        }

        /// <summary>
        ///     Creates/initializes a playback channel for a sample.
        /// </summary>
        /// <param name="recycle">Recycle on of the existing channels, then to create a new.</param>
        /// <returns>A playback channel of the sample.</returns>
        /// <exception cref="NotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">
        ///     Some error occur to call a Bass function, check the error code and error message
        ///     to get more error information.
        /// </exception>
        /// <exception cref="BassNotLoadedException">
        ///     Bass DLL not loaded, you must use <see cref="Initialize" /> to load Bass DLL
        ///     first.
        /// </exception>
        public SampleChannel GetChannel(bool recycle)
        {
            CheckAvailable();

            return
                new SampleChannel(
                    AudioSampleModule.SampleGetChannelFunction.CheckResult(
                        AudioSampleModule.SampleGetChannelFunction.Delegate(Handle, !recycle)));
        }

        /// <summary>
        ///     Get all a sample's existing channels.
        /// </summary>
        /// <returns>A array of this sample's channels.</returns>
        /// <exception cref="NotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">
        ///     Some error occur to call a Bass function, check the error code and error message
        ///     to get more error information.
        /// </exception>
        /// <exception cref="BassNotLoadedException">
        ///     Bass DLL not loaded, you must use <see cref="Initialize" /> to load Bass DLL
        ///     first.
        /// </exception>
        public SampleChannel[] GetChannels()
        {
            CheckAvailable();

            var channels = AudioSampleModule.SampleGetChannelsFunction.CheckResult(
                AudioSampleModule.SampleGetChannelsFunction.Delegate(Handle, IntPtr.Zero));

            IntPtr[] result = new IntPtr[channels];
            List<SampleChannel> resultChannels = new List<SampleChannel>(channels + 1);

            GCHandle resultHandle = GCHandle.Alloc(result, GCHandleType.Pinned);

            AudioSampleModule.SampleGetChannelsFunction.CheckResult(
                AudioSampleModule.SampleGetChannelsFunction.Delegate(Handle, resultHandle.AddrOfPinnedObject()));

            resultHandle.Free();

            resultChannels.AddRange(from ptr in result
                let sampleChannel = (SampleChannel) HandleManager.GetHandleObject(ptr)
                select sampleChannel ?? new SampleChannel(ptr));

            return resultChannels.ToArray();
        }
        

        protected override void ReleaseManaged()
        {
        }

        protected override void ReleaseUnmanaged()
        {
            Free();
        }

        /// <exception cref="NotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassNotLoadedException">
        ///     Bass DLL not loaded, you must use <see cref="Initialize" /> to load Bass DLL
        ///     first.
        /// </exception>
        /// <exception cref="BassErrorException">
        ///     Some error occur to call a Bass function, check the error code and error message
        ///     to get more error information.
        /// </exception>
        protected void Free()
        {
            CheckAvailable();

            AudioSampleModule.SampleFreeFunction.CheckResult(
                AudioSampleModule.SampleFreeFunction.Delegate(Handle));

            Handle = IntPtr.Zero;
            IsAvailable = false;
        }
    }
}