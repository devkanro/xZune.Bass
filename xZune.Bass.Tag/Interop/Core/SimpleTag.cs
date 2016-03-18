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
        internal IntPtr _namePtr;
        internal IntPtr _valuePtr;
        internal int _valueSize;
        internal int _index;
        
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
                    return Marshal.PtrToStringAuto(_valuePtr);
            }
        }

        public int Index => _index;

        public bool Equals(SimpleTag obj)
        {
            return
                obj._namePtr == _namePtr &&
                obj._valuePtr == _valuePtr &&
                obj._valueSize == _valueSize &&
                obj._index == _index;
        }

        public override bool Equals(object obj)
        {
            return Equals((ExtTag)obj);
        }

        public static bool operator ==(SimpleTag tag1, SimpleTag tag2)
        {
            return tag1.Equals(tag2);
        }

        public static bool operator !=(SimpleTag tag1, SimpleTag tag2)
        {
            return !(tag1 == tag2);
        }
    }
}