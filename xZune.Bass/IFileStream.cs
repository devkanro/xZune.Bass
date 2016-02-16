// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: IFileStream.cs
// Version: 20160216

using System;
using xZune.Bass.Interop.Core.Flags;

namespace xZune.Bass
{
    public interface IFileStream : IStream
    {
        UInt64 GetFilePosition(FilePositionMode mode);
    }
}