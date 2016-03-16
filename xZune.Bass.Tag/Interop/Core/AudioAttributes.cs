// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: AudioAttributes.cs
// Version: 20160316

using System;
using System.Runtime.InteropServices;

namespace xZune.Bass.Tag.Interop.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AudioAttributes
    {
        private int _channelCount;
        private int _samplesPerSec;
        private int _bitsPerSample;
        private double _playTime;
        private UInt64 _sampleCount;
        private int _bitRate;


        public int ChannelCount => _channelCount;
        public int SamplesPerSec => _samplesPerSec;
        public int BitsPerSample => _bitsPerSample;
        public TimeSpan Duration => TimeSpan.FromSeconds(_playTime);
        public UInt64 SampleCount => _sampleCount;
        public int BitRate => _bitRate;
    }
}