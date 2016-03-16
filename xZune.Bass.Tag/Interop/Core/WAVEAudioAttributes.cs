// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: WAVEAudioAttributes.cs
// Version: 20160316

using System;
using System.Runtime.InteropServices;

namespace xZune.Bass.Tag.Interop.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WAVEAudioAttributes
    {
        private int _formatTag;
        private int _channelCount;
        private int _samplesPerSec;
        private int _avgBytesPerSec;
        private int _blockAlign;
        private int _bitsPerSample;
        private double _playTime;
        private UInt64 _sampleCount;
        private int _cbSize;
        private int _validBitsPerSample;
        private int _channelMask;
        [MarshalAs(UnmanagedType.U1, SizeConst = 15)]
        private byte _subFormat;
        private int _bitRate;

        /// <summary>
        ///     Format type.
        /// </summary>
        public int FormatTag => _formatTag;

        /// <summary>
        ///     Number of channels (i.e. mono, stereo, etc.)
        /// </summary>
        public int ChannelCount => _channelCount;

        /// <summary>
        ///     Sample rate.
        /// </summary>
        public int SamplesPerSec => _samplesPerSec;

        /// <summary>
        ///     For buffer estimation.
        /// </summary>
        public int AvgBytesPerSec => _avgBytesPerSec;

        /// <summary>
        ///     Block size of data.
        /// </summary>
        public int BlockAlign => _blockAlign;

        /// <summary>
        ///     Number of bits per sample of mono data.
        /// </summary>
        public int BitsPerSample => _bitsPerSample;

        public TimeSpan Duration => TimeSpan.FromSeconds(_playTime);
        public UInt64 SampleCount => _sampleCount;

        /// <summary>
        ///     Size of the extension: 22.
        /// </summary>
        public int CbSize => _cbSize;

        /// <summary>
        ///     at most 8 *  M.
        /// </summary>
        public int ValidBitsPerSample => _validBitsPerSample;

        /// <summary>
        ///     Speaker position mask: 0.
        /// </summary>
        public int ChannelMask => _channelMask;

        /// <summary>
        ///     16.
        /// </summary>
        public byte SubFormat => _subFormat;

        public int BitRate => _bitRate;
    }
}