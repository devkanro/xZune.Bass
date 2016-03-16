// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: SimpleTag.cs
// Version: 20160316

using System;
using System.Runtime.InteropServices;

namespace xZune.Bass.Tag.Interop.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SimpleTag
    {
        private IntPtr _namePtr;
        private IntPtr _valuePtr;
        private int _valueSize;
        private int _index;
        
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

        public string Value
        {
            get
            {
                if (_valuePtr == IntPtr.Zero)
                    return null;
                else
                    return Marshal.PtrToStringAuto(_valuePtr, _valueSize);
            }
        }

        public int Index => _index;
    }
}