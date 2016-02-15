// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: TagType.cs
// Version: 20160215

namespace xZune.Bass.Interop.Core.Flags.Internal
{
    internal enum TagType
    {
        ID3 = 0,
        ID3V2 = 1,
        Ogg = 2,
        Http = 3,
        Icy = 4,
        Meta = 5,
        Ape = 6,
        Mp4 = 7,
        Vendor = 9,
        Lyrics3 = 10,
        CaCodec = 11,
        Mf = 13,
        Waveformat = 14,
        RiffInfo = 0x100,
        RiffBext = 0x101,
        RiffCart = 0x102,
        RiffDisp = 0x103,
        ApeBinary = 0x1000,
        MusicName = 0x10000,
        MusicMessage = 0x10001,
        MusicOrders = 0x10002,
        MusicInst = 0x10100,
        MusicSample = 0x10300
    }
}