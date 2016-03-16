// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: FlacAudioAttributes.cs
// Version: 20160316

using System;
using System.Runtime.InteropServices;

namespace xZune.Bass.Tag.Interop.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FlacAudioAttributes
    {
        private int _channels;
        private int _sampleRate;
        private int _bitsPerSample;
        private long _sampleCount;
        private double _playTime;
        private double _ratio; 
        private IntPtr _channelModePtr;
        private int _bitRate;

        public int Channels => _channels;

        public int SampleRate => _sampleRate;

        public int BitsPerSample => _bitsPerSample;

        public long SampleCount => _sampleCount;

        public TimeSpan Duration => TimeSpan.FromSeconds(_playTime);

        /// <summary>
        /// Compression ratio (%).
        /// </summary>
        public double CompressionRatio => _ratio;

        public String ChannelMode
        {
            get
            {
                if (_channelModePtr == IntPtr.Zero)
                    return null;
                return Marshal.PtrToStringAuto(_channelModePtr);
            }
        }

        public int BitRate => _bitRate ;
    }
}