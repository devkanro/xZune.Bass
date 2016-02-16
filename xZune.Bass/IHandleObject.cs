// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: IHandleObject.cs
// Version: 20160216

using System;

namespace xZune.Bass
{
    public interface IHandleObject : IDisposable
    {
        IntPtr Handle { get; }
    }
}