// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: StringType.cs
// Version: 20160215

using System;

namespace xZune.Bass.Interop.Core.Flags.Internal
{
    [Flags]
    internal enum BassConfig : uint
    {
        None,
        AsyncFile = 0x40000000,
        Unicode = 0x80000000
    }
}