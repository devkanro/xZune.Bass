// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: MP4AudioAttributes.cs
// Version: 20160316

using System;
using System.Runtime.InteropServices;

namespace xZune.Bass.Tag.Interop.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MP4AudioAttributes
    {
        private int _channelCount;
        private int _sampleRate;
        private int _bitsPerSample;
        private double _playTime;
        private int _bitRate;

        public int ChannelCount => _channelCount;
        public int SampleRate => _sampleRate;
        public int BitsPerSample => _bitsPerSample;
        public TimeSpan Duration => TimeSpan.FromSeconds(_playTime);
        public int BitRate => _bitRate;
    }
}