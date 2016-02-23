// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: ChannelType.cs
// Version: 20160215

using System;
using xZune.Bass.Interop.Core;

namespace xZune.Bass.Interop.Flags
{
    /// <summary>
    ///     Channel types.
    /// </summary>
    [Flags]
    public enum ChannelType
    {
        /// <summary>
        ///     Sample channel. (HCHANNEL)
        /// </summary>
        Sample = Internal.ChannelType.Sample,

        /// <summary>
        ///     Recording channel. (HRECORD)
        /// </summary>
        Record = Internal.ChannelType.Record,

        /// <summary>
        ///     User sample stream. This can also be used as a flag to test if the channel is any kind of HSTREAM.
        /// </summary>
        Stream = Internal.ChannelType.Stream,

        /// <summary>
        ///     Ogg Vorbis format stream.
        /// </summary>
        StreamOgg = Internal.ChannelType.StreamOgg,

        /// <summary>
        ///     MPEG layer 1 format stream.
        /// </summary>
        StreamMp1 = Internal.ChannelType.StreamMp1,

        /// <summary>
        ///     MPEG layer 2 format stream.
        /// </summary>
        StreamMp2 = Internal.ChannelType.StreamMp2,

        /// <summary>
        ///     MPEG layer 3 format stream.
        /// </summary>
        StreamMp3 = Internal.ChannelType.StreamMp3,

        /// <summary>
        ///     Audio IFF format stream.
        /// </summary>
        StreamAiff = Internal.ChannelType.StreamAiff,

        /// <summary>
        ///     CoreAudio codec stream. Additional format information is available from <see cref="ChannelGetTags" /> (
        ///     <see cref="TagType.CaCodec" />).
        /// </summary>
        StreamCa = Internal.ChannelType.StreamCa,

        /// <summary>
        ///     Media Foundation codec stream. Additional v format information is available from <see cref="ChannelGetTags" />
        /// </summary>
        StreamMf = Internal.ChannelType.StreamMf,
        /// <summary>
        /// Monkey's audio stream.
        /// </summary>
        StreamApe = Internal.ChannelType.StreamApe,
        /// <summary>
        /// Free Lossless Audio Codec stream.
        /// </summary>
        StreamFlac = Internal.ChannelType.StreamFlac,
        /// <summary>
        /// 
        /// </summary>
        StreamFlacOgg = Internal.ChannelType.StreamFlacOgg,
        /// <summary>
        ///     WAVE format flag. This can be used to test if the channel is any kind of WAVE format. The codec (the file's
        ///     "wFormatTag") is specified in the LOWORD. Additional information is also available
        /// </summary>
        StreamWav = Internal.ChannelType.StreamWav,

        /// <summary>
        ///     Integer PCM WAVE format stream.
        /// </summary>
        StreamWavPcm = Internal.ChannelType.StreamWavPcm,

        /// <summary>
        ///     Floating-point PCM WAVE format stream.
        /// </summary>
        StreamWavFloat = Internal.ChannelType.StreamWavFloat,

        /// <summary>
        ///     Generic MOD format music. This can also be used as a flag to test if the channel is any kind of HMUSIC.
        /// </summary>
        MusicMod = Internal.ChannelType.MusicMod,

        /// <summary>
        ///     MultiTracker format music.
        /// </summary>
        MusicMtm = Internal.ChannelType.MusicMtm,

        /// <summary>
        ///     ScreamTracker 3 format music.
        /// </summary>
        MusicS3M = Internal.ChannelType.MusicS3M,

        /// <summary>
        ///     FastTracker 2 format music.
        /// </summary>
        MusicXm = Internal.ChannelType.MusicXm,

        /// <summary>
        ///     Impulse Tracker format music.
        /// </summary>
        MusicIt = Internal.ChannelType.MusicIt,

        /// <summary>
        ///     MO3 format flag, used in combination with one of the BASS_CTYPE_MUSIC types.
        /// </summary>
        MusicMo3 = Internal.ChannelType.MusicMo3
    }
}