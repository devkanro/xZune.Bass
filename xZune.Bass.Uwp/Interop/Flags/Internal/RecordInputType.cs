// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: RecordInputType.cs
// Version: 20160216

namespace xZune.Bass.Interop.Flags.Internal
{
    internal enum RecordInputType : uint
    {
        Mask = 0xff000000,
        Undef = 0x00000000,
        Digital = 0x01000000,
        Line = 0x02000000,
        Mic = 0x03000000,
        Synth = 0x04000000,
        CD = 0x05000000,
        Phone = 0x06000000,
        Speaker = 0x07000000,
        Wave = 0x08000000,
        Aux = 0x09000000,
        Analog = 0x0a000000
    }
}