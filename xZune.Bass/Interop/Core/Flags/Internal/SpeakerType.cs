// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: SpeakerType.cs
// Version: 20160215

using System;

namespace xZune.Bass.Interop.Core.Flags.Internal
{
    [Flags]
    internal enum SpeakerType
    {
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