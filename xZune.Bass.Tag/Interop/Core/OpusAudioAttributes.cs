// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: OpusAudioAttributes.cs
// Version: 20160316

using System;
using System.Runtime.InteropServices;

namespace xZune.Bass.Tag.Interop.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public struct OpusAudioAttributes
    {
        private int _bitstreamVersion;
        private int _channelCount;
        private int _preSkip;
        private int _sampleRate;
        private int _outputGain;
        private int _mappingFamily;
        private double _playTime;
        private UInt64 _sampleCount;
        private int _bitRate;

        /// <summary>
        ///     Bitstream version number.
        /// </summary>
        public int BitstreamVersion => _bitstreamVersion;

        /// <summary>
        ///     Number of channels.
        /// </summary>
        public int ChannelCount => _channelCount;

        public int PreSkip => _preSkip;

        /// <summary>
        ///     Sample rate (hz).
        /// </summary>
        public int SampleRate => _sampleRate;

        public int OutputGain => _outputGain;

        /// <summary>
        ///     0,1,255.
        /// </summary>
        public int MappingFamily => _mappingFamily;
        public TimeSpan Duration => TimeSpan.FromSeconds(_playTime);
        public UInt64 SampleCount => _sampleCount;
        public int BitRate => _bitRate;
    }
}