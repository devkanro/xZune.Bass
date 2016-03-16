// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: WAVPackAttributes.cs
// Version: 20160316

using System;
using System.Runtime.InteropServices;

namespace xZune.Bass.Tag.Interop.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WAVPackAttributes
    {
        private int _formatTag;
        private int _version;
        private int _channelCount;
        private IntPtr _channelModePtr;
        private int _sampleRate;
        private int _bits;
        private double _bitRate;
        private double _playTime;
        private long _samples;
        private long _bSamples;
        private double _ratio;
        private IntPtr _encoderPtr;


        public int FormatTag => _formatTag;
        public int Version => _version;
        public int ChannelCount => _channelCount;

        public String ChannelMode
        {
            get
            {
                if (_channelModePtr == IntPtr.Zero)
                    return null;
                return Marshal.PtrToStringAuto(_channelModePtr);
            }
        }
        public int SampleRate => _sampleRate;
        public int Bits => _bits;
        public double BitRate => _bitRate;
        public TimeSpan Duration => TimeSpan.FromSeconds(_playTime);
        public long Samples => _samples;
        public long BSamples => _bSamples;
        public double Ratio => _ratio;
        public String Encoder
        {
            get
            {
                if (_encoderPtr == IntPtr.Zero)
                    return null;
                return Marshal.PtrToStringAuto(_encoderPtr);
            }
        }
    }
}