// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: SyncHandlerType.cs
// Version: 20160215

namespace xZune.Bass.Interop.Flags.Internal
{
    internal enum SyncHandlerType : uint
    {
        Pos = 0,
        End = 2,
        Meta = 4,
        Slide = 5,
        Stall = 6,
        Download = 7,
        Free = 8,
        Setpos = 11,
        MusicPos = 10,
        MusicInst = 1,
        MusicFx = 3,
        OggChange = 12,
        Mixtime = 0x40000000,
        Onetime = 0x80000000
    }
}