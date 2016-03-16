// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: VorbisAudioAttributes.cs
// Version: 20160316

using System;
using System.Runtime.InteropServices;

namespace xZune.Bass.Tag.Interop.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public struct VorbisAudioAttributes
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] _bitstreamVersion;
        private int _channelCount;
        private int _sampleRate;
        private int _bitRateMaximal;
        private int _bitRateNominal;
        private int _bitRateMinimal;
        private int _blockSize;
        private double _playTime;
        private UInt64 _sampleCount;
        private int _bitRate;

        /// <summary>
        /// Bitstream version number.
        /// </summary>
        public byte[] BitstreamVersion => _bitstreamVersion;
        /// <summary>
        /// Number of channels .
        /// </summary>
        public int ChannelCount => _channelCount;
        /// <summary>
        /// Sample rate (hz).
        /// </summary>
        public int SampleRate => _sampleRate;
        /// <summary>
        /// Bit rate upper limit.
        /// </summary>
        public int BitRateMaximal => _bitRateMaximal;
        /// <summary>
        /// Nominal bit rate.
        /// </summary>
        public int BitRateNominal => _bitRateNominal;
        /// <summary>
        /// Bit rate lower limit.
        /// </summary>
        public int BitRateMinimal => _bitRateMinimal;
        /// <summary>
        /// Coded size for small and long blocks.
        /// </summary>
        public int BlockSize => _blockSize;
        public TimeSpan Duration => TimeSpan.FromSeconds(_playTime);
        public UInt64 SampleCount => SampleCount;
        public int BitRate => _bitRate;
    }
}