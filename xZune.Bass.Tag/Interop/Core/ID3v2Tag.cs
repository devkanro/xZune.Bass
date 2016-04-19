// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: ID3v2Tag.cs
// Version: 20160319

using System;
using System.Runtime.InteropServices;

namespace xZune.Bass.Tag.Interop.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ID3v2Tag
    {
        internal IntPtr _namePtr;
        internal IntPtr _valuePtr;
        internal int _valueSize;
        internal IntPtr _languagePtr;
        internal IntPtr _descriptionPtr;
        internal ID3v2TagType _type;
        internal int _index;

        public string Name
        {
            get
            {
                if (_namePtr == IntPtr.Zero)
                    return null;
                return Marshal.PtrToStringAuto(_namePtr);
            }
        }

        public string Value
        {
            get
            {
                if (_valuePtr == IntPtr.Zero)
                    return null;
                return Marshal.PtrToStringAuto(_valuePtr);
            }
        }

        public string Language
        {
            get
            {
                if (_languagePtr == IntPtr.Zero)
                    return null;
                return Marshal.PtrToStringAuto(_languagePtr);
            }
        }

        public string Description
        {
            get
            {
                if (_descriptionPtr == IntPtr.Zero)
                    return null;
                return Marshal.PtrToStringAuto(_descriptionPtr);
            }
        }

        public ID3v2TagType Type => _type;

        public int Index => _index;

        public bool Equals(ID3v2Tag obj)
        {
            return
                obj._descriptionPtr == _descriptionPtr &&
                obj._languagePtr == _languagePtr &&
                obj._namePtr == _namePtr &&
                obj._valuePtr == _valuePtr &&
                obj._valueSize == _valueSize &&
                obj._index == _index &&
                obj._type == _type;
        }

        public override bool Equals(object obj)
        {
            return Equals((ID3v2Tag) obj);
        }

        public static bool operator ==(ID3v2Tag tag1, ID3v2Tag tag2)
        {
            return tag1.Equals(tag2);
        }

        public static bool operator !=(ID3v2Tag tag1, ID3v2Tag tag2)
        {
            return !(tag1 == tag2);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _namePtr.GetHashCode();
                hashCode = (hashCode*397) ^ _valuePtr.GetHashCode();
                hashCode = (hashCode*397) ^ _valueSize;
                hashCode = (hashCode*397) ^ _languagePtr.GetHashCode();
                hashCode = (hashCode*397) ^ _descriptionPtr.GetHashCode();
                hashCode = (hashCode*397) ^ (int) _type;
                hashCode = (hashCode*397) ^ _index;
                return hashCode;
            }
        }
    }
}