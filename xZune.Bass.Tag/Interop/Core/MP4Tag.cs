// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: MP4TagEx.cs
// Version: 20160316

using System;
using System.Runtime.InteropServices;

namespace xZune.Bass.Tag.Interop.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MP4Tag
    {
        private IntPtr _namePtr;
        private IntPtr _valuePtr;
        private int _valueSize;
        private IntPtr _nameValuePtr;
        private IntPtr _meanValuePtr;
        private MP4TagType _type;
        private int _dataType;
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
                    return Marshal.PtrToStringAuto(_valuePtr);
            }
        }

        public string NameValue
        {
            get
            {
                if (_nameValuePtr == IntPtr.Zero)
                    return null;
                else
                    return Marshal.PtrToStringAuto(_nameValuePtr);
            }
        }

        public string MeanValue
        {
            get
            {
                if (_meanValuePtr == IntPtr.Zero)
                    return null;
                else
                    return Marshal.PtrToStringAuto(_meanValuePtr);
            }
        }

        public MP4TagType Type => _type;

        public int DateType => _dataType;

        public int Index => _index;
    }
}