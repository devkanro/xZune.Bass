// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: DeviceType.cs
// Version: 20160215

namespace xZune.Bass.Interop.Core.Flags.Internal
{
    internal enum DeviceType : uint
    {
        /// <summary>
        ///     An audio endpoint device that the user accesses remotely through a network.
        /// </summary>
        Network = 0x01000000,

        /// <summary>
        ///     A set of speakers.
        /// </summary>
        Speakers = 0x02000000,

        /// <summary>
        ///     An audio endpoint device that sends a line-level analog signal to a line-input jack on an audio adapter or that
        ///     receives a line-level analog signal from a line-output jack on the adapter.
        /// </summary>
        Line = 0x03000000,

        /// <summary>
        ///     A set of headphones.
        /// </summary>
        Headphones = 0x04000000,

        /// <summary>
        ///     A microphone.
        /// </summary>
        Microphone = 0x05000000,

        /// <summary>
        ///     An earphone or a pair of earphones with an attached mouthpiece for two-way communication.
        /// </summary>
        Headset = 0x06000000,

        /// <summary>
        ///     The part of a telephone that is held in the hand and that contains a speaker and a microphone for two-way
        ///     communication.
        /// </summary>
        Handset = 0x07000000,

        /// <summary>
        ///     An audio endpoint device that connects to an audio adapter through a connector for a digital interface of unknown
        ///     type.
        /// </summary>
        Digital = 0x08000000,

        /// <summary>
        ///     An audio endpoint device that connects to an audio adapter through a Sony/Philips Digital Interface (S/PDIF)
        ///     connector.
        /// </summary>
        Spdif = 0x09000000,

        /// <summary>
        ///     An audio endpoint device that connects to an audio adapter through a High-Definition Multimedia Interface (HDMI)
        ///     connector.
        /// </summary>
        Hdmi = 0x0a000000,

        /// <summary>
        ///     An audio endpoint device that connects to an audio adapter through a DisplayPort connector.
        /// </summary>
        Displayport = 0x40000000,

        /// <summary>
        ///     A mask of device types.
        /// </summary>
        Mask = 0xff000000
    }
}