// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: WaveForamt.cs
// Version: 20160216

namespace xZune.Bass.Interop.Flags.Internal
{
    internal enum WaveForamt : uint
    {
        Format1M08 = 0x00000001,
        Format1S08 = 0x00000002,
        Format1M16 = 0x00000004,
        Format1S16 = 0x00000008,
        Format2M08 = 0x00000010,
        Format2S08 = 0x00000020,
        Format2M16 = 0x00000040,
        Format2S16 = 0x00000080,
        Format4M08 = 0x00000100,
        Format4S08 = 0x00000200,
        Format4M16 = 0x00000400,
        Format4S16 = 0x00000800
    }
}