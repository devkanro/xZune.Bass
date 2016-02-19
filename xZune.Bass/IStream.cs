// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: IStream.cs
// Version: 20160216

using System;
using xZune.Bass.Interop.Core.Flags;

namespace xZune.Bass
{
    public interface IStream : IChannel
    {
        int PutData(byte[] buffer);

        UInt64 GetFilePosition(FilePositionMode mode);
    }
}