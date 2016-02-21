// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: PositionConfig.cs
// Version: 20160215

namespace xZune.Bass.Interop.Flags.Internal
{
    internal enum PositionConfig
    {
        Byte = 0,
        MusicOrder = 1,
        Ogg = 3,
        Inexact = 0x8000000,
        Decode = 0x10000000,
        DecodeTo = 0x20000000,
        Scan = 0x40000000
    }
}