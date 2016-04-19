// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: ChannelAttribute.cs
// Version: 20160215

namespace xZune.Bass.Interop.Flags
{
    /// <summary>
    ///     Channel's attribute.
    /// </summary>
    public enum ChannelAttribute
    {
        /// <summary>
        ///     The sample rate of a channel.
        /// </summary>
        Freq = Internal.ChannelAttribute.Freq,

        /// <summary>
        ///     The volume level of a channel.
        /// </summary>
        Volume = Internal.ChannelAttribute.Volume,

        /// <summary>
        ///     The panning/balance position of a channel.
        /// </summary>
        Pan = Internal.ChannelAttribute.Pan,

        /// <summary>
        ///     The wet (reverb) / dry (no reverb) mix ratio of a channel.
        /// </summary>
        Eaxmix = Internal.ChannelAttribute.Eaxmix,

        /// <summary>
        ///     Disable playback buffering?
        /// </summary>
        NoBuffer = Internal.ChannelAttribute.NoBuffer,

        Vbr = Internal.ChannelAttribute.Vbr,

        /// <summary>
        ///     The CPU usage of a channel.
        /// </summary>
        Cpu = Internal.ChannelAttribute.Cpu,

        /// <summary>
        ///     The sample rate conversion quality of a channel.
        /// </summary>
        Src = Internal.ChannelAttribute.Src,

        /// <summary>
        ///     The download buffer level required to resume stalled playback.
        /// </summary>
        NetResume = Internal.ChannelAttribute.NetResume,

        /// <summary>
        ///     The amplification level of a MOD music.
        /// </summary>
        MusicAmplify = Internal.ChannelAttribute.MusicAmplify,

        /// <summary>
        ///     The pan separation level of a MOD music.
        /// </summary>
        MusicPansep = Internal.ChannelAttribute.MusicPansep,

        /// <summary>
        ///     The position scaler of a MOD music.
        /// </summary>
        MusicPscaler = Internal.ChannelAttribute.MusicPscaler,

        /// <summary>
        ///     The BPM of a MOD music.
        /// </summary>
        MusicBpm = Internal.ChannelAttribute.MusicBpm,

        /// <summary>
        ///     The speed of a MOD music.
        /// </summary>
        MusicSpeed = Internal.ChannelAttribute.MusicSpeed,

        /// <summary>
        ///     The global volume level of a MOD music.
        /// </summary>
        MusicVolumeGlobal = Internal.ChannelAttribute.MusicVolumeGlobal,

        /// <summary>
        ///     The number of active channels in a MOD music.
        /// </summary>
        MusicActive = Internal.ChannelAttribute.MusicActive,

        /// <summary>
        ///     The volume level of a channel in a MOD music.
        /// </summary>
        MusicVolumeChannel = Internal.ChannelAttribute.MusicVolumeChannel,

        /// <summary>
        ///     The volume level of an instrument in a MOD music.
        /// </summary>
        MusicVolumeInstrument = Internal.ChannelAttribute.MusicVolumeInstrument
    }

    public enum ChannelAttributeEx
    {
        /// <summary>
        ///     The scanned info of a channel.
        /// </summary>
        Scaninfo = Internal.ChannelAttribute.Scaninfo
    }
}