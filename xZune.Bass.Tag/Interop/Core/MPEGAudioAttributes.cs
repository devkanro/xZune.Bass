// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: MPEGAudioAttributes.cs
// Version: 20160316

using System.Runtime.InteropServices;

namespace xZune.Bass.Tag.Interop.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MPEGAudioAttributes
    {
        private long _position;
        private int _header;
        private int _frameSize;
        private MPEGVersion _version;
        private MPEGLayer _layer;
        private bool _hasCRC;
        private int _bitRate;
        private int _sampleRate;
        private bool _isPadding;
        private bool _private;
        private MPEGChannelMode _channelMode;
        private MPEGModeExtension _modeExtension;
        private bool _copyrighted;
        private bool _original;
        private MPEGEmphasis _emphasis;
        private bool _vbr;
        private long _frameCount;
        private int _quality;
        private long _bytes;

        /// <summary>
        /// Position of header in bytes.
        /// </summary>
        public long Position => _position;

        /// <summary>
        /// The Headers bytes.
        /// </summary>
        public int Header => _header;

        /// <summary>
        /// Frame's length.
        /// </summary>
        public int FrameSize => _frameSize;

        /// <summary>
        /// MPEG Version.
        /// </summary>
        public MPEGVersion Version => _version;

        /// <summary>
        ///  MPEG Layer.
        /// </summary>
        public MPEGLayer Layer => _layer;

        /// <summary>
        /// Frame has CRC.
        /// </summary>
        public bool HasCRC => _hasCRC;

        /// <summary>
        /// Frame's bitrate.
        /// </summary>
        public int BitRate => _bitRate;

        /// <summary>
        /// Frame's sample rate.
        /// </summary>
        public int SampleRate => _sampleRate;

        /// <summary>
        /// Frame is padded.
        /// </summary>
        public bool IsPadding => _isPadding;

        /// <summary>
        /// Frame's private bit is set.
        /// </summary>
        public bool Private => _private;

        /// <summary>
        /// Frame's channel mode.
        /// </summary>
        public MPEGChannelMode ChannelMode => _channelMode;

        /// <summary>
        /// Joint stereo only.
        /// </summary>
        public MPEGModeExtension ModeExtension => _modeExtension;

        /// <summary>
        /// Frame's Copyright bit is set.
        /// </summary>
        public bool Copyrighted => _copyrighted;

        /// <summary>
        /// Frame's Original bit is set.
        /// </summary>
        public bool Original => _original;

        /// <summary>
        /// Frame's emphasis mode.
        /// </summary>
        public MPEGEmphasis Emphasis => _emphasis;

        /// <summary>
        /// Stream is probably VBR.
        /// </summary>
        public bool VBR => _vbr;

        /// <summary>
        /// Total number of MPEG frames (by header).
        /// </summary>
        public long FrameCount => _frameCount;

        /// <summary>
        /// MPEG quality.
        /// </summary>
        public int Quality => _quality;

        /// <summary>
        /// Total bytes.
        /// </summary>
        public long Bytes => _bytes;
    }
}