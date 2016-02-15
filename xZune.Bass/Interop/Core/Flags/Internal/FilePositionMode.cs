// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: FilePositionMode.cs
// Version: 20160215

namespace xZune.Bass.Interop.Core.Flags.Internal
{
    internal enum FilePositionMode
    {
        Current = 0,
        Decode = Current,
        Download = 1,
        End = 2,
        Start = 3,
        Connected = 4,
        Buffer = 5,
        Socket = 6,
        AsyncBuffer = 7,
        Size = 8
    }
}