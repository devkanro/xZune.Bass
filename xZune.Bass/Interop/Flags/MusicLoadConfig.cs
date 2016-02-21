// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: MusicLoadConfig.cs
// Version: 20160216

using System;
using xZune.Bass.Interop.Core;

namespace xZune.Bass.Interop.Flags
{
    [Flags]
    public enum MusicLoadConfig : uint
    {
        None,

        /// <summary>
        ///     Use 8-bit resolution. If neither this or the BASS_SAMPLE_FLOAT flags are specified, then the stream is 16-bit.
        /// </summary>
        _8Bits = Internal.SampleConfig._8Bits,

        /// <summary>
        ///     Decode/play the stream (MP3/MP2/MP1 only) in mono, reducing the CPU usage (if it was originally stereo). This flag
        ///     is automatically applied if <see cref="InitializationConfig.Mono" /> was specified when calling
        ///     <see cref="Initialize" />.
        /// </summary>
        Mono = Internal.SampleConfig.Mono,

        /// <summary>
        ///     Use 32-bit floating-point sample data. See Floating-point channels for info.
        /// </summary>
        Float = Internal.SampleConfig.Float,

        /// <summary>
        ///     Enable 3D functionality. This requires that the <see cref="InitializationConfig._3D" /> flag was specified when
        ///     calling <see cref="Initialize" />, and the
        ///     stream must be mono (chans=1). The SPEAKER flags cannot be used together with this flag.
        /// </summary>
        _3D = Internal.SampleConfig._3D,

        /// <summary>
        ///     Force the stream to not use hardware mixing.
        /// </summary>
        Software = Internal.SampleConfig.Software,

        /// <summary>
        ///     Enable the old implementation of DirectX 8 effects. See the DX8 effect implementations section for details. Use
        ///     <see cref="ChannelSetFX" /> to add effects to the stream.
        /// </summary>
        Fx = Internal.SampleConfig.Fx,

        /// <summary>
        ///     Loop the file. This flag can be toggled at any time using BASS_ChannelFlags.
        /// </summary>
        Loop = Internal.SampleConfig.Loop,

        /// <summary>
        ///     Automatically free the music when playback ends. Note that some musics have infinite loops, so never actually end
        ///     on their own.
        /// </summary>
        Autofree = Internal.MusicConfig.Autofree,

        /// <summary>
        ///     Decode/render the sample data, without playing it. Use <see cref="ChannelGetData" /> to retrieve decoded sample
        ///     data. The <see cref="_3D" />, <see cref="Autofree" /> and SPEAKER flags cannot be used together with this flag. The
        ///     <see cref="Software" /> and <see cref="Fx" /> flags are also ignored.
        /// </summary>
        Decode = Internal.MusicConfig.Decode,

        /// <summary>
        ///     Calculate the playback length of the music, and enable seeking in bytes. This slightly increases the time taken to
        ///     load the music, depending on how long it is. In the case of musics that loop, the length until the loop occurs is
        ///     calculated. Use <see cref="ChannelGetLength" /> to retrieve the length.
        /// </summary>
        Prescan = Internal.MusicConfig.Prescan,

        Calclen = Internal.MusicConfig.Calclen,

        /// <summary>
        ///     Use "normal" ramping (as in FastTracker 2).
        /// </summary>
        Ramp = Internal.MusicConfig.Ramp,

        /// <summary>
        ///     Use "sensitive" ramping.
        /// </summary>
        Ramps = Internal.MusicConfig.Ramps,

        /// <summary>
        ///     Apply XMPlay's surround sound to the music. This is ignored if the BASS_SAMPLE_MONO flag is also specified.
        /// </summary>
        Surround = Internal.MusicConfig.Surround,

        /// <summary>
        ///     Apply XMPlay's surround sound mode 2 to the music. This is ignored if the BASS_SAMPLE_MONO flag is also specified.
        /// </summary>
        Surround2 = Internal.MusicConfig.Surround2,

        /// <summary>
        ///     Play .MOD file as FastTracker 2 would.
        /// </summary>
        Ft2Mod = Internal.MusicConfig.Ft2Mod,

        /// <summary>
        ///     Play .MOD file as ProTracker 1 would.
        /// </summary>
        Pt1Mod = Internal.MusicConfig.Pt1Mod,

        /// <summary>
        ///     Use non-interpolated sample mixing. This generally reduces the sound quality, but can be good for chip-tunes.
        /// </summary>
        NonInter = Internal.MusicConfig.NonInter,

        /// <summary>
        ///     Use sinc interpolated sample mixing. This increases the sound quality, but also requires more CPU. If neither this
        ///     or the BASS_MUSIC_NONINTER flag is specified, linear interpolation is used.
        /// </summary>
        SincInter = Internal.MusicConfig.SincInter,

        /// <summary>
        ///     Stop all notes when seeking (<see cref="ChannelSetPosition" />).
        /// </summary>
        PosReset = Internal.MusicConfig.PosReset,

        /// <summary>
        ///     Stop all notes and reset bpm/etc when seeking.
        /// </summary>
        PosResetEx = Internal.MusicConfig.PosResetEx,

        /// <summary>
        ///     Stop the music when a backward jump effect is played. This stops musics that never reach the end from going into
        ///     endless loops. Some MOD musics are designed to jump all over the place, so this flag would cause those to be
        ///     stopped prematurely. If this flag is used together with the <see cref="Loop" /> flag, then the music would not be
        ///     stopped but any <see cref="SyncHandlerType.End" /> sync would be triggered.
        /// </summary>
        Stopback = Internal.MusicConfig.Stopback,

        /// <summary>
        ///     Do not load the samples. This reduces the time (and memory) taken to load the music, notably with MO3 files, which
        ///     is useful if you just want to get the text and/or length of the music without playing it.
        /// </summary>
        NoSample = Internal.MusicConfig.NoSample,

        /// <summary>
        ///     The front speakers.
        /// </summary>
        SpeakerFront = Internal.SpeakerType.SpeakerFront,

        /// <summary>
        ///     The rear/side speakers.
        /// </summary>
        SpeakerRear = Internal.SpeakerType.SpeakerRear,

        /// <summary>
        ///     The center and LFE (subwoofer) speakers in a 5.1 setup.
        /// </summary>
        SpeakerCenterLEF = Internal.SpeakerType.SpeakerCenterLEF,

        /// <summary>
        ///     The rear center speakers in a 7.1 setup.
        /// </summary>
        SpeakerRear2 = Internal.SpeakerType.SpeakerRear2,

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft" />
        ///     or
        ///     <see cref="SpeakerRight" /> flags.
        /// </summary>
        Speaker05 = Internal.SpeakerType.Speaker05,

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft" />
        ///     or
        ///     <see cref="SpeakerRight" /> flags.
        /// </summary>
        Speaker06 = Internal.SpeakerType.Speaker06,

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft" />
        ///     or
        ///     <see cref="SpeakerRight" /> flags.
        /// </summary>
        Speaker07 = Internal.SpeakerType.Speaker07,

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft" />
        ///     or
        ///     <see cref="SpeakerRight" /> flags.
        /// </summary>
        Speaker08 = Internal.SpeakerType.Speaker08,

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft" />
        ///     or
        ///     <see cref="SpeakerRight" /> flags.
        /// </summary>
        Speaker09 = Internal.SpeakerType.Speaker09,

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft" />
        ///     or
        ///     <see cref="SpeakerRight" /> flags.
        /// </summary>
        Speaker10 = Internal.SpeakerType.Speaker10,

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft" />
        ///     or
        ///     <see cref="SpeakerRight" /> flags.
        /// </summary>
        Speaker11 = Internal.SpeakerType.Speaker11,

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft" />
        ///     or
        ///     <see cref="SpeakerRight" /> flags.
        /// </summary>
        Speaker12 = Internal.SpeakerType.Speaker12,

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft" />
        ///     or
        ///     <see cref="SpeakerRight" /> flags.
        /// </summary>
        Speaker13 = Internal.SpeakerType.Speaker13,

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft" />
        ///     or
        ///     <see cref="SpeakerRight" /> flags.
        /// </summary>
        Speaker14 = Internal.SpeakerType.Speaker14,

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft" />
        ///     or
        ///     <see cref="SpeakerRight" /> flags.
        /// </summary>
        Speaker15 = Internal.SpeakerType.Speaker15,

        SpeakerLeft = Internal.SpeakerType.SpeakerLeft,
        SpeakerRight = Internal.SpeakerType.SpeakerRight,

        /// <summary>
        ///     The left-front speaker.
        /// </summary>
        SpeakerFrontLeft = Internal.SpeakerType.SpeakerFrontLeft,

        /// <summary>
        ///     The right-front speaker.
        /// </summary>
        SpeakerFrontRight = Internal.SpeakerType.SpeakerFrontRight,

        /// <summary>
        ///     The left-rear/side speaker.
        /// </summary>
        SpeakerRearLeft = Internal.SpeakerType.SpeakerRearLeft,

        /// <summary>
        ///     The right-rear/side speaker.
        /// </summary>
        SpeakerRearRight = Internal.SpeakerType.SpeakerRearRight,

        /// <summary>
        ///     The center speaker in a 5.1 speaker setup.
        /// </summary>
        SpeakerCenter = Internal.SpeakerType.SpeakerCenter,

        /// <summary>
        ///     The LFE (subwoofer) speaker in a 5.1 setup.
        /// </summary>
        SpeakerLFE = Internal.SpeakerType.SpeakerLFE,

        /// <summary>
        ///     The left-rear center speaker in a 7.1 setup.
        /// </summary>
        SpeakerRear2Left = Internal.SpeakerType.SpeakerRear2Left,

        /// <summary>
        ///     The right-rear center speaker in a 7.1 setup.
        /// </summary>
        SpeakerRear2Right = Internal.SpeakerType.SpeakerRearRight,

        /// <summary>
        ///     file is in UTF-16 format. Otherwise it is ANSI on Windows or Windows CE, and UTF-8 on other platforms.
        /// </summary>
        Unicode = Internal.BassConfig.Unicode
    }
}