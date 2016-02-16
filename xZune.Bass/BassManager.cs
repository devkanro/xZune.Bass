// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: BassManager.cs
// Version: 20160216

using System;
using xZune.Bass.Interop.Core;

namespace xZune.Bass
{
    public static class BassManager
    {
        public static IntPtr BassLibraryHandle { get; private set; }

        public static bool Available => BassLibraryHandle != IntPtr.Zero;

        public static ErrorCode GetErrorCode()
        {
            
        }
    }
}