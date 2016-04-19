// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: AutoFreeGCHandle.cs
// Version: 20160221

using System;
using System.Runtime.InteropServices;

namespace xZune.Bass
{
    public class AutoFreeGCHandle : IDisposable
    {
        private GCHandle _handle;

        public AutoFreeGCHandle(object targetObject, GCHandleType type = GCHandleType.Pinned)
        {
            _handle = GCHandle.Alloc(targetObject, type);
        }

        public IntPtr Handle => _handle.AddrOfPinnedObject();

        public void Dispose()
        {
            _handle.Free();
        }
    }
}