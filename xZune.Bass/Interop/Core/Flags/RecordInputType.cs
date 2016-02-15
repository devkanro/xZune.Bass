// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: RecordInputType.cs
// Version: 20160216

using System;

namespace xZune.Bass.Interop.Core.Flags
{
    /// <summary>
    ///     Input type of record.
    /// </summary>
    [Flags]
    public enum RecordInputType : uint
    {
        /// <summary>
        ///     Type flag mask.
        /// </summary>
        Mask = Internal.RecordInputType.Mask,

        /// <summary>
        ///     Anything that is not covered by the other types.
        /// </summary>
        Undef = Internal.RecordInputType.Undef,

        /// <summary>
        ///     Digital input source, for example, a DAT or audio CD.
        /// </summary>
        Digital = Internal.RecordInputType.Digital,

        /// <summary>
        ///     Line-in. On some devices, "Line-in" may be combined with other analog sources into a single BASS_INPUT_TYPE_ANALOG
        ///     input.
        /// </summary>
        Line = Internal.RecordInputType.Line,

        /// <summary>
        ///     Microphone.
        /// </summary>
        Mic = Internal.RecordInputType.Mic,

        /// <summary>
        ///     Internal MIDI synthesizer.
        /// </summary>
        Synth = Internal.RecordInputType.Synth,

        /// <summary>
        ///     Analog audio CD.
        /// </summary>
        CD = Internal.RecordInputType.CD,

        /// <summary>
        ///     Telephone.
        /// </summary>
        Phone = Internal.RecordInputType.Phone,

        /// <summary>
        ///     PC speaker.
        /// </summary>
        Speaker = Internal.RecordInputType.Speaker,

        /// <summary>
        ///     The device's WAVE/PCM output.
        /// </summary>
        Wave = Internal.RecordInputType.Wave,

        /// <summary>
        ///     Auxiliary. Like "Line-in", "Aux" may be combined with other analog sources into a single BASS_INPUT_TYPE_ANALOG
        ///     input on some devices.
        /// </summary>
        Aux = Internal.RecordInputType.Aux,

        /// <summary>
        ///     Analog, typically a mix of all analog sources.
        /// </summary>
        Analog = Internal.RecordInputType.Analog
    }
}