// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: CARTPostTimer.cs
// Version: 20160316

using System;
using System.Runtime.InteropServices;

namespace xZune.Bass.Tag.Interop.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CARTPostTimer
    {
        private IntPtr _usagePtr;
        private int _value;

        public String Usage
        {
            get
            {
                if (_usagePtr == IntPtr.Zero)
                    return null;
                else
                    return Marshal.PtrToStringAuto(_usagePtr);
            }
        }

        public int Value => _value;
    }
}