// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: ChannelType.cs
// Version: 20160313

namespace xZune.Bass.Interop.Flags.Internal
{
    internal enum ChannelType
    {
        Sample = 1,
        Record = 2,
        Stream = 0x10000,
        StreamOgg = 0x10002,
        StreamMp1 = 0x10003,
        StreamMp2 = 0x10004,
        StreamMp3 = 0x10005,
        StreamAiff = 0x10006,
        StreamCa = 0x10007,
        StreamMf = 0x10008,
        StreamApe = 0x10700,
        StreamFlac = 0x10900,
        StreamFlacOgg = 0x10901,
        StreamWav = 0x40000,
        StreamWavPcm = 0x50001,
        StreamWavFloat = 0x50003,
        MusicMod = 0x20000,
        MusicMtm = 0x20001,
        MusicS3M = 0x20002,
        MusicXm = 0x20003,
        MusicIt = 0x20004,
        MusicMo3 = 0x00100,
        StreamWma = 0x10300,
        StreamWmaMp3 = 0x10301
    }
}