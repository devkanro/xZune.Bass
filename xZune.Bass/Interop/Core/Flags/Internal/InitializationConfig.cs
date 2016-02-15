// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: InitializationFlags.cs
// Version: 20160215

using System;

namespace xZune.Bass.Interop.Core.Flags.Internal
{
    [Flags]
    internal enum InitializationConfig
    {
        /// <summary>
        ///     Use 8-bit resolution, else 16-bit.
        /// </summary>
        _8Bits = 1,

        /// <summary>
        ///     Use mono, else stereo.
        /// </summary>
        Mono = 2,

        /// <summary>
        ///     Enable 3D functionality.
        /// </summary>
        _3D = 4,

        /// <summary>
        ///     Calculates the latency of the device, that is the delay between requesting a sound to play and it actually being
        ///     heard. A recommended minimum buffer length is also calculated. Both values are retrievable in the
        ///     <see cref="Info" /> structure (latency & min-buffer members). These calculations can increase the time taken by
        ///     this function by 1-3 seconds.
        /// </summary>
        Latency = 0x100,

        /// <summary>
        ///     Use the Windows control panel setting to detect the number of speakers. Soundcards generally have their own control
        ///     panel to set the speaker configure, so the Windows control panel setting may not be accurate unless it matches
        ///     that. This flag has no effect on Vista, as the speakers are already accurately detected.
        /// </summary>
        CpSpeakers = 0x400,

        /// <summary>
        ///     Force the enabling of speaker assignment. With some devices/drivers, the number of speakers BASS detects may be 2,
        ///     when the device in fact supports more than 2 speakers. This flag forces the enabling of assignment to 8 possible
        ///     speakers. This flag has no effect with non-WDM drivers.
        /// </summary>
        Speakers = 0x800,

        /// <summary>
        ///     Ignore speaker arrangement. This flag tells BASS not to make any special consideration for speaker arrangements
        ///     when using the SPEAKER flags, eg. swapping the CENLFE and REAR speaker channels in 5/7.1 speaker output. This flag
        ///     should be used with plain multi-channel (rather than 5/7.1) devices.
        /// </summary>
        NoSpeaker = 0x1000,

        /// <summary>
        ///     Initialize the device using the ALSA "dmix" plug-in, else initialize the device for exclusive access.
        /// </summary>
        Dmix = 0x2000,

        /// <summary>
        ///     Set the device's output rate to freq, otherwise leave it as it is.
        /// </summary>
        Freq = 0x4000
    }
}