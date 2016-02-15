// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: ChannelInfo.cs
// Version: 20160215

using System;
using System.Runtime.InteropServices;
using xZune.Bass.Interop.Core.Flags;

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     Used with <see cref="ChannelGetInfo" /> to retrieve information on a channel.
    /// </summary>
    /// <remarks>
    ///     The <see cref="ChannelConfig.Software" /> flag indicates whether or not the channel's sample data is being mixed
    ///     into the final output by the hardware. It does not indicate (in the case of a stream or MOD music) whether the
    ///     processing required to generate the sample data is being done by the hardware; this processing is always done in
    ///     software.
    ///     <para />
    ///     With a recording channel, the <see cref="ChannelConfig.Decode" /> flag indicates that it is not using a
    ///     <see cref="RecordHandler" /> callback function.
    ///     <para />
    ///     BASS supports 8/16/32-bit sample data, so if a WAV file, for example, uses another sample resolution, it will have
    ///     to be converted by BASS. The origres member can be used to check what the resolution originally was.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct ChannelInfo
    {
        /// <summary>
        ///     Default playback rate.
        /// </summary>
        public uint Freq;

        /// <summary>
        ///     Number of channels... 1=mono, 2=stereo, etc.
        /// </summary>
        public uint Channels;

        /// <summary>
        ///     Configure of channel.
        /// </summary>
        public ChannelConfig Config;

        /// <summary>
        ///     The type of channel.
        /// </summary>
        public ChannelType Type;

        /// <summary>
        ///     The original resolution (bits per sample)... 0 = undefined.
        /// </summary>
        public uint Origres;

        /// <summary>
        ///     The plug-in that is handling the channel... 0 = not using a plug-in. Note this is only available with streams
        ///     created using the plug-in system via the standard BASS stream creation functions, not those created by add-on
        ///     functions. Information on the plug-in can be retrieved via <see cref="PluginGetInfo" />.
        /// </summary>
        public uint Plugin;

        /// <summary>
        ///     The sample that is playing on the channel. (HCHANNEL only)
        /// </summary>
        public uint Sample;

        /// <summary>
        ///     The filename associated with the channel. (HSTREAM only)
        /// </summary>
        public IntPtr FileName;
    }
}