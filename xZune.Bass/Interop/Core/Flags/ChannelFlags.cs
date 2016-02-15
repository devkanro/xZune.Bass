using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xZune.Bass.Interop.Core.Flags
{
    /// <summary>
    /// Some flags used in <see cref="Core.ChannelFlags"/>.
    /// </summary>
    public enum ChannelFlags : uint
    {
        /// <summary>
        /// Loop the channel. 
        /// </summary>
        Loop = Internal.SampleConfig.Loop,
        /// <summary>
        /// Automatically free the channel when playback ends. Note that the BASS_MUSIC_AUTOFREE flag is identical to this flag. (HSTREAM/HMUSIC only) 
        /// </summary>
        AutoFree = Internal.StreamConfig.AutoFree,
        /// <summary>
        /// Restrict the download rate. (HSTREAM) 
        /// </summary>
        RestRate = Internal.StreamConfig.RestRate,
        /// <summary>
        /// Use non-interpolated sample mixing. (HMUSIC) 
        /// </summary>
        NonInter = Internal.MusicConfig.NonInter,
        /// <summary>
        /// Use sinc interpolated sample mixing. (HMUSIC) 
        /// </summary>
        SincInter = Internal.MusicConfig.SincInter,
        /// <summary>
        /// Use "normal" ramping. (HMUSIC) 
        /// </summary>
        Ramp = Internal.MusicConfig.Ramp,
        /// <summary>
        /// Use "sensitive" ramping. (HMUSIC) 
        /// </summary>
        Ramps = Internal.MusicConfig.Ramps,
        /// <summary>
        /// Use surround sound. (HMUSIC) 
        /// </summary>
        Surround = Internal.MusicConfig.Surround,
        /// <summary>
        /// Use surround sound mode 2. (HMUSIC) 
        /// </summary>
        Surround2 = Internal.MusicConfig.Surround2,
        /// <summary>
        /// Use FastTracker 2 .MOD playback. (HMUSIC) 
        /// </summary>
        Ft2Mod = Internal.MusicConfig.Ft2Mod,
        /// <summary>
        /// Use ProTracker 1 .MOD playback. (HMUSIC) 
        /// </summary>
        Pt1Mod = Internal.MusicConfig.Pt1Mod,
        /// <summary>
        /// Stop all notes when seeking. (HMUSIC) 
        /// </summary>
        PosReset = Internal.MusicConfig.PosReset,
        /// <summary>
        /// Stop all notes and reset BPM/etc when seeking. (HMUSIC) 
        /// </summary>
        PosResetEX = Internal.MusicConfig.PosResetEX,
        /// <summary>
        /// Stop when a backward jump effect is played. (HMUSIC) 
        /// </summary>
        Stopback = Internal.MusicConfig.Stopback,
        /// <summary>
        ///     The front speakers.
        /// </summary>
        SpeakerFront = 0x1000000,

        /// <summary>
        ///     The rear/side speakers.
        /// </summary>
        SpeakerRear = 0x2000000,

        /// <summary>
        ///     The center and LFE (subwoofer) speakers in a 5.1 setup.
        /// </summary>
        SpeakerCenterLEF = 0x3000000,

        /// <summary>
        ///     The rear center speakers in a 7.1 setup.
        /// </summary>
        SpeakerRear2 = 0x4000000,

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft"/> or
        ///     <see cref="SpeakerRight"/> flags.
        /// </summary>
        Speaker05 = ((05) << 24),

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft"/> or
        ///     <see cref="SpeakerRight"/> flags.
        /// </summary>
        Speaker06 = ((06) << 24),

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft"/> or
        ///     <see cref="SpeakerRight"/> flags.
        /// </summary>
        Speaker07 = ((07) << 24),

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft"/> or
        ///     <see cref="SpeakerRight"/> flags.
        /// </summary>
        Speaker08 = ((08) << 24),

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft"/> or
        ///     <see cref="SpeakerRight"/> flags.
        /// </summary>
        Speaker09 = ((09) << 24),

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft"/> or
        ///     <see cref="SpeakerRight"/> flags.
        /// </summary>
        Speaker10 = ((10) << 24),

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft"/> or
        ///     <see cref="SpeakerRight"/> flags.
        /// </summary>
        Speaker11 = ((11) << 24),

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft"/> or
        ///     <see cref="SpeakerRight"/> flags.
        /// </summary>
        Speaker12 = ((12) << 24),

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft"/> or
        ///     <see cref="SpeakerRight"/> flags.
        /// </summary>
        Speaker13 = ((13) << 24),

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft"/> or
        ///     <see cref="SpeakerRight"/> flags.
        /// </summary>
        Speaker14 = ((14) << 24),

        /// <summary>
        ///     SpeakerN macro that can be used to access the extra speakers of soundcards that have more than 8 speakers, where N
        ///     is the N'th pair of speakers (up to a maximum of 15).To use a speaker in mono, add the <see cref="SpeakerLeft"/> or
        ///     <see cref="SpeakerRight"/> flags.
        /// </summary>
        Speaker15 = ((15) << 24),

        SpeakerLeft = 0x10000000,
        SpeakerRight = 0x20000000,

        /// <summary>
        ///     The left-front speaker.
        /// </summary>
        SpeakerFrontLeft = SpeakerFront | SpeakerLeft,

        /// <summary>
        ///     The right-front speaker.
        /// </summary>
        SpeakerFrontRight = SpeakerFront | SpeakerRight,

        /// <summary>
        ///     The left-rear/side speaker.
        /// </summary>
        SpeakerRearLeft = SpeakerRear | SpeakerLeft,

        /// <summary>
        ///     The right-rear/side speaker.
        /// </summary>
        SpeakerRearRight = SpeakerRear | SpeakerRight,

        /// <summary>
        ///     The center speaker in a 5.1 speaker setup.
        /// </summary>
        SpeakerCenter = SpeakerCenterLEF | SpeakerLeft,

        /// <summary>
        ///     The LFE (subwoofer) speaker in a 5.1 setup.
        /// </summary>
        SpeakerLFE = SpeakerCenterLEF | SpeakerRight,

        /// <summary>
        ///     The left-rear center speaker in a 7.1 setup.
        /// </summary>
        SpeakerRear2Left = SpeakerRear2 | SpeakerLeft,

        /// <summary>
        ///     The right-rear center speaker in a 7.1 setup.
        /// </summary>
        SpeakerRear2Right = SpeakerRear2 | SpeakerRight
    }
}
