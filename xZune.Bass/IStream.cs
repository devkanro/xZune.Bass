// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: IStream.cs
// Version: 20160216

using System;

namespace xZune.Bass
{
    public interface IStream : IChannel
    {
        int PutData(byte[] buffer);
    }
}