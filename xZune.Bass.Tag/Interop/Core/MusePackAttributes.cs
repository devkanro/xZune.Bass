// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: MusePackAttributes.cs
// Version: 20160316

using System;
using System.Runtime.InteropServices;

namespace xZune.Bass.Tag.Interop.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MusePackAttributes
    {
        private byte _channelModeID;
        private IntPtr _channelModePtr;
        private int _frameCount;
        private ushort _bitRate;
        private byte _streamVersion;
        private IntPtr _streamVersionPtr;
        private int _sampleRate;
        private byte _profileID;
        private IntPtr _profilePtr;
        private double _playTime;
        private IntPtr _encoderPtr;
        private double _ratio;

        /// <summary>
        /// Channel mode code.
        /// </summary>
        public byte ChannelModeID => _channelModeID;
        /// <summary>
        /// Channel mode name.
        /// </summary>
        public String ChannelMode
        {
            get
            {
                if (_channelModePtr == IntPtr.Zero)
                    return null;
                return Marshal.PtrToStringAuto(_channelModePtr);
            }
        }
        /// <summary>
        /// Number of frames.
        /// </summary>
        public int FrameCount => _frameCount;
        /// <summary>
        /// Bit rate.
        /// </summary>
        public ushort BitRate => _bitRate;
        /// <summary>
        /// Stream version.
        /// </summary>
        public byte StreamVersion => _streamVersion;
        /// <summary>
        /// Stream version string.
        /// </summary>
        public String StreamVersionString
        {
            get
            {
                if (_streamVersionPtr == IntPtr.Zero)
                    return null;
                return Marshal.PtrToStringAuto(_streamVersionPtr);
            }
        }
        public int SampleRate => _sampleRate;
        /// <summary>
        /// Profile code.
        /// </summary>
        public byte ProfileID => _profileID;
        /// <summary>
        /// Profile name.
        /// </summary>
        public String Profile
        {
            get
            {
                if (_profilePtr == IntPtr.Zero)
                    return null;
                return Marshal.PtrToStringAuto(_profilePtr);
            }
        }
        /// <summary>
        /// Duration.
        /// </summary>
        public TimeSpan Duration => TimeSpan.FromSeconds(_playTime);
        /// <summary>
        /// Encoder used.
        /// </summary>
        public String Encoder
        {
            get
            {
                if (_encoderPtr == IntPtr.Zero)
                    return null;
                return Marshal.PtrToStringAuto(_encoderPtr);
            }
        }
        /// <summary>
        /// Compression ratio (%).
        /// </summary>
        public double Ratio => _ratio;
    }
}