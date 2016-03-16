// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: DSFAudioAttributes.cs
// Version: 20160316

using System;
using System.Runtime.InteropServices;

namespace xZune.Bass.Tag.Interop.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DSFAudioAttributes
    {
        private int _formatVersion;
        private int _formatID;
        private DSFChannelType _channelType;
        private int _channelNumber;
        private int _samplingFrequency;
        private int _bitsPerSample;
        private int _blockSizePerChannel;
        private double _playTime;
        private UInt64 _sampleCount;
        private int _bitRate;


        public int FormatVersion => _formatVersion;
        public int FormatID => _formatID;
        public DSFChannelType ChannelType => _channelType;
        public int ChannelNumber => _channelNumber;
        public int SamplingFrequency => _samplingFrequency;
        public int BitsPerSample => _bitsPerSample;
        public int BlockSizePerChannel => _blockSizePerChannel;
        public TimeSpan Duration => TimeSpan.FromSeconds(_playTime);
        public UInt64 SampleCount => _sampleCount;
        public int Bitrate => _bitRate;
    }
}