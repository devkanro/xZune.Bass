// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: ChannelAttribute.cs
// Version: 20160215
namespace xZune.Bass.Interop.Core.Flags.Internal
{
    internal enum ChannelAttribute
    {
        Freq = 1,
        Volume = 2,
        Pan = 3,
        Eaxmix = 4,
        NoBuffer = 5,
        Vbr = 6,
        Cpu = 7,
        Src = 8,
        NetResume = 9,
        Scaninfo = 10,
        MusicAmplify = 0x100,
        MusicPansep = 0x101,
        MusicPscaler = 0x102,
        MusicBpm = 0x103,
        MusicSpeed = 0x104,
        MusicVolumeGlobal = 0x105,
        MusicActive = 0x106,
        MusicVolumeChannel = 0x200,
        MusicVolumeInstrument = 0x300
    }
}