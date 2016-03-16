// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: AIFFAttributes.cs
// Version: 20160316

using System;
using System.Runtime.InteropServices;

namespace xZune.Bass.Tag.Interop.Core
{
    public struct AIFFAttributes
    {
        private int _channelCount;
        private int _sampleCount;
        private int _sampleSize;
        private double _sampleRate;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] private byte[] _compressionID;
        private IntPtr _compressionPtr;
        private double _playTime;
        private int _bitRate;

        public int ChannelCount => _channelCount;
        public int SampleCount => _sampleCount;
        public int SampleSize => _sampleSize;
        public double SampleRate => _sampleRate;
        public byte[] CompressionID => _compressionID;

        public String Compression
        {
            get
            {
                if (_compressionPtr == IntPtr.Zero)
                    return null;
                return Marshal.PtrToStringAuto(_compressionPtr);
            }
        }

        public TimeSpan Duration => TimeSpan.FromSeconds(_playTime);
        public int BitRate => _bitRate;
    }
}