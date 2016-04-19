// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: IRecord.cs
// Version: 20160218

namespace xZune.Bass
{
    public interface IRecord : IChannel
    {
        event RecordingEventHandler Recording;
    }

}