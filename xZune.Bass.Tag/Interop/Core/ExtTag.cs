// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: ExtTag.cs
// Version: 20160316

using System;
using System.Runtime.InteropServices;

namespace xZune.Bass.Tag.Interop.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ExtTag
    {
        private IntPtr _namePtr;
        private IntPtr _valuePtr;
        private int _valueSize;
        private IntPtr _languagePtr;
        private IntPtr _descriptionPtr;
        private ExtTagType _type;
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

        public string Language
        {
            get
            {
                if (_languagePtr == IntPtr.Zero)
                    return null;
                else
                    return Marshal.PtrToStringAuto(_languagePtr);
            }
        }

        public string Description
        {
            get
            {
                if (_descriptionPtr == IntPtr.Zero)
                    return null;
                else
                    return Marshal.PtrToStringAuto(_descriptionPtr);
            }
        }

        public ExtTagType Type => _type;

        public int Index => _index;
    }
}