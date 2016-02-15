// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: ChannelConfig.cs
// Version: 20160215

using xZune.Bass.Interop.Core.Flags.Internal;

namespace xZune.Bass.Interop.Core.Flags
{
    /// <summary>
    ///     Some configure used in <see cref="ChannelInfo" />.
    /// </summary>
    public enum ChannelConfig : uint
    {
        /// <summary>
        ///     The channel's resolution is 8-bit. If neither this or the <see cref="Float" /> flags are present, then the
        ///     channel's resolution is 16-bit.
        /// </summary>
        _8Bit = Internal.SampleConfig._8Bits,

        /// <summary>
        ///     The channel's resolution is 32-bit floating-point.
        /// </summary>
        Float = Internal.SampleConfig.Float,

        /// <summary>
        ///     The channel is looped.
        /// </summary>
        Loop = Internal.SampleConfig.Loop,

        /// <summary>
        ///     The channel has 3D functionality enabled.
        /// </summary>
        _3D = Internal.SampleConfig._3D,

        /// <summary>
        ///     The channel is NOT using hardware mixing.
        /// </summary>
        Software = Internal.SampleConfig.Software,

        /// <summary>
        ///     The channel is using the DX7 voice allocation and management features. (HCHANNEL only)
        /// </summary>
        Vam = Internal.SampleConfig.Vam,

        /// <summary>
        ///     The channel is muted when at (or beyond) its max distance. (HCHANNEL)
        /// </summary>
        Mutemax = Internal.SampleConfig.Mutemax,

        /// <summary>
        ///     The channel has the "with FX flag" DX8 effect implementation enabled. (HSTREAM/HMUSIC)
        /// </summary>
        Fx = Internal.SampleConfig.Fx,

        /// <summary>
        ///     The Internet file download rate is restricted. (HSTREAM)
        /// </summary>
        RestRate = StreamConfig.RestRate,

        /// <summary>
        ///     The Internet file (or "buffered" user file) is streamed in small blocks. (HSTREAM)
        /// </summary>
        Block = StreamConfig.Block,

        /// <summary>
        ///     The channel will automatically be freed when it ends. (HSTREAM/HMUSIC)
        /// </summary>
        AutoFree = StreamConfig.AutoFree,

        /// <summary>
        ///     The channel is a "decoding channel". (HSTREAM/HMUSIC/HRECORD)
        /// </summary>
        Decode = StreamConfig.Decode,

        /// <summary>
        ///     The MOD music is using "normal" ramping. (HMUSIC)
        /// </summary>
        Ramp = MusicConfig.Ramp,

        /// <summary>
        ///     The MOD music is using "sensitive" ramping. (HMUSIC)
        /// </summary>
        Ramps = MusicConfig.Ramps,

        /// <summary>
        ///     The MOD music is using surround sound. (HMUSIC)
        /// </summary>
        Surround = MusicConfig.Surround,

        /// <summary>
        ///     The MOD music is using surround sound mode 2. (HMUSIC)
        /// </summary>
        Surround2 = MusicConfig.Surround2,

        /// <summary>
        ///     The MOD music is using non-interpolated mixing. (HMUSIC)
        /// </summary>
        NonInter = MusicConfig.NonInter,

        /// <summary>
        ///     The MOD music is using FastTracker 2 .MOD playback. (HMUSIC)
        /// </summary>
        Ft2Mod = MusicConfig.Ft2Mod,

        /// <summary>
        ///     The MOD music is using ProTracker 1 .MOD playback. (HMUSIC)
        /// </summary>
        Pt1Mod = MusicConfig.Pt1Mod,

        /// <summary>
        ///     The MOD music will be stopped when a backward jump effect is played. (HMUSIC)
        /// </summary>
        Stopback = MusicConfig.Stopback,

        /// <summary>
        ///     The front speakers.
        /// </summary>
        SpeakerFront = SpeakerType.SpeakerFront,

        /// <summary>
        ///     The rear/side speakers.
        /// </summary>
        SpeakerRear = SpeakerType.SpeakerRear,

        /// <summary>
        ///     The center and LFE (subwoofer) speakers in a 5.1 setup.
        /// </summary>
        SpeakerCenterLEF = SpeakerType.SpeakerCenterLEF,

        /// <summary>
        ///     The rear center speakers in a 7.1 setup.
        /// </summary>
        SpeakerRear2 = SpeakerType.SpeakerRear2,

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft" />
        ///     or
        ///     <see cref="SpeakerRight" /> flags.
        /// </summary>
        Speaker05 = SpeakerType.Speaker05,

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft" />
        ///     or
        ///     <see cref="SpeakerRight" /> flags.
        /// </summary>
        Speaker06 = SpeakerType.Speaker06,

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft" />
        ///     or
        ///     <see cref="SpeakerRight" /> flags.
        /// </summary>
        Speaker07 = SpeakerType.Speaker07,

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft" />
        ///     or
        ///     <see cref="SpeakerRight" /> flags.
        /// </summary>
        Speaker08 = SpeakerType.Speaker08,

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft" />
        ///     or
        ///     <see cref="SpeakerRight" /> flags.
        /// </summary>
        Speaker09 = SpeakerType.Speaker09,

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft" />
        ///     or
        ///     <see cref="SpeakerRight" /> flags.
        /// </summary>
        Speaker10 = SpeakerType.Speaker10,

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft" />
        ///     or
        ///     <see cref="SpeakerRight" /> flags.
        /// </summary>
        Speaker11 = SpeakerType.Speaker11,

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft" />
        ///     or
        ///     <see cref="SpeakerRight" /> flags.
        /// </summary>
        Speaker12 = SpeakerType.Speaker12,

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft" />
        ///     or
        ///     <see cref="SpeakerRight" /> flags.
        /// </summary>
        Speaker13 = SpeakerType.Speaker13,

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft" />
        ///     or
        ///     <see cref="SpeakerRight" /> flags.
        /// </summary>
        Speaker14 = SpeakerType.Speaker14,

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft" />
        ///     or
        ///     <see cref="SpeakerRight" /> flags.
        /// </summary>
        Speaker15 = SpeakerType.Speaker15,

        SpeakerLeft = SpeakerType.SpeakerLeft,
        SpeakerRight = SpeakerType.SpeakerRight,

        /// <summary>
        ///     The left-front speaker.
        /// </summary>
        SpeakerFrontLeft = SpeakerType.SpeakerFrontLeft,

        /// <summary>
        ///     The right-front speaker.
        /// </summary>
        SpeakerFrontRight = SpeakerType.SpeakerFrontRight,

        /// <summary>
        ///     The left-rear/side speaker.
        /// </summary>
        SpeakerRearLeft = SpeakerType.SpeakerRearLeft,

        /// <summary>
        ///     The right-rear/side speaker.
        /// </summary>
        SpeakerRearRight = SpeakerType.SpeakerRearRight,

        /// <summary>
        ///     The center speaker in a 5.1 speaker setup.
        /// </summary>
        SpeakerCenter = SpeakerType.SpeakerCenter,

        /// <summary>
        ///     The LFE (subwoofer) speaker in a 5.1 setup.
        /// </summary>
        SpeakerLFE = SpeakerType.SpeakerLFE,

        /// <summary>
        ///     The left-rear center speaker in a 7.1 setup.
        /// </summary>
        SpeakerRear2Left = SpeakerType.SpeakerRear2Left,

        /// <summary>
        ///     The right-rear center speaker in a 7.1 setup.
        /// </summary>
        SpeakerRear2Right = SpeakerType.SpeakerRearRight,

        /// <summary>
        ///     filename is in UTF-16 format.
        /// </summary>
        Unicode = BassConfig.Unicode
    }
}