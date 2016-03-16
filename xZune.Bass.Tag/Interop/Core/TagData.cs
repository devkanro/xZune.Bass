// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: TagData.cs
// Version: 20160316

using System;
using System.Runtime.InteropServices;

namespace xZune.Bass.Tag.Interop.Core
{
    public struct TagData
    {
        private IntPtr _namePtr;
        private IntPtr _data;
        private long _dataSize;
        private int _dataType;

        public string Name
        {
            get
            {
                if (_namePtr == IntPtr.Zero)
                    return null;
                else
                    return Marshal.PtrToStringAuto(_namePtr);
            }
        }

        public IntPtr DataPtr => _data;

        public long DataSize => _dataSize;

        public int Type => _dataType;

    }
}