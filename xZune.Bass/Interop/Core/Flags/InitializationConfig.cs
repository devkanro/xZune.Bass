// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: InitializationConfig.cs
// Version: 20160215

using System;

namespace xZune.Bass.Interop.Core.Flags
{
    /// <summary>
    /// Initialization configure of <see cref="Info"/> and <see cref="Initialize"/>.
    /// </summary>
    [Flags]
    public enum InitializationConfig
    {
        None,
        /// <summary>
        ///     Use 8-bit resolution, else 16-bit.
        /// </summary>
        _8Bits = Internal.InitializationConfig._8Bits,

        /// <summary>
        ///     Use mono, else stereo.
        /// </summary>
        Mono = Internal.InitializationConfig.Mono,

        /// <summary>
        ///     Enable 3D functionality.
        /// </summary>
        _3D = Internal.InitializationConfig._3D,

        /// <summary>
        ///     Calculates the latency of the device, that is the delay between requesting a sound to play and it actually being
        ///     heard. A recommended minimum buffer length is also calculated. Both values are retrievable in the
        ///     <see cref="Info" /> structure (latency & min-buffer members). These calculations can increase the time taken by
        ///     this function by 1-3 seconds.
        /// </summary>
        Latency = Internal.InitializationConfig.Latency,

        /// <summary>
        ///     Use the Windows control panel setting to detect the number of speakers. Soundcards generally have their own control
        ///     panel to set the speaker configure, so the Windows control panel setting may not be accurate unless it matches
        ///     that. This flag has no effect on Vista, as the speakers are already accurately detected.
        /// </summary>
        CpSpeakers = Internal.InitializationConfig.CpSpeakers,

        /// <summary>
        ///     Force the enabling of speaker assignment. With some devices/drivers, the number of speakers BASS detects may be 2,
        ///     when the device in fact supports more than 2 speakers. This flag forces the enabling of assignment to 8 possible
        ///     speakers. This flag has no effect with non-WDM drivers.
        /// </summary>
        Speakers = Internal.InitializationConfig.Speakers,

        /// <summary>
        ///     Ignore speaker arrangement. This flag tells BASS not to make any special consideration for speaker arrangements
        ///     when using the SPEAKER flags, eg. swapping the CENLFE and REAR speaker channels in 5/7.1 speaker output. This flag
        ///     should be used with plain multi-channel (rather than 5/7.1) devices.
        /// </summary>
        NoSpeaker = Internal.InitializationConfig.NoSpeaker,

        /// <summary>
        ///     Initialize the device using the ALSA "dmix" plug-in, else initialize the device for exclusive access.
        /// </summary>
        Dmix = Internal.InitializationConfig.Dmix,

        /// <summary>
        ///     Set the device's output rate to freq, otherwise leave it as it is.
        /// </summary>
        Freq = Internal.InitializationConfig.Freq
    }
}