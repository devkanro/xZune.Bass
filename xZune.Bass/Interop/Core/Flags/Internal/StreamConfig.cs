// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: StreamFlags.cs
// Version: 20160215

using System;

namespace xZune.Bass.Interop.Core.Flags.Internal
{
    [Flags]
    internal enum StreamConfig : uint
    {
        Prescan = 0x20000,
        Setpos = Prescan,
        AutoFree = 0x40000,
        RestRate = 0x80000,
        Block = 0x100000,
        Decode = 0x200000,
        Status = 0x800000
    }
}