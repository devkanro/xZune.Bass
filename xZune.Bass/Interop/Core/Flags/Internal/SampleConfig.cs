// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: SampleConfig.cs
// Version: 20160215

namespace xZune.Bass.Interop.Core.Flags.Internal
{
    internal enum SampleConfig
    {
        _8Bits = 1,
        Float = 256,
        Mono = 2,
        Loop = 4,
        _3D = 8,
        Software = 16,
        Mutemax = 32,
        Vam = 64,
        Fx = 128,
        OverVol = 0x10000,
        OverPos = 0x20000,
        OverDist = 0x30000
    }
}