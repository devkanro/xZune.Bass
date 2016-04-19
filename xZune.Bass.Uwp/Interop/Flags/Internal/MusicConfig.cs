// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: MusicConfig.cs
// Version: 20160215
namespace xZune.Bass.Interop.Flags.Internal
{
    internal enum MusicConfig : uint
    {
        Float = SampleConfig.Float,
        Mono = SampleConfig.Mono,
        Loop = SampleConfig.Loop,
        _3D = SampleConfig._3D,
        Fx = SampleConfig.Fx,
        Autofree = StreamConfig.AutoFree,
        Decode = StreamConfig.Decode,
        Prescan = StreamConfig.Prescan,
        Calclen = Prescan,
        Ramp = 0x200,
        Ramps = 0x400,
        Surround = 0x800,
        Surround2 = 0x1000,
        Ft2Mod = 0x2000,
        Pt1Mod = 0x4000,
        NonInter = 0x10000,
        SincInter = 0x800000,
        PosReset = 0x8000,
        PosResetEx = 0x400000,
        Stopback = 0x80000,
        NoSample = 0x100000
    }
}