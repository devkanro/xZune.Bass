// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: CoverArtData.cs
// Version: 20160316

using System;
using System.Runtime.InteropServices;

namespace xZune.Bass.Tag.Interop.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CoverArtData
    {
        private IntPtr _namePtr;
        private IntPtr _data;
        private long _dataSize;
        private IntPtr _descriptionPtr;
        private CoverType _coverType;
        private IntPtr _mimeTypePtr;
        private PictureFormat _pictureFormat;
        private int _width;
        private int _height;
        private int _colorDepth;
        private int _colorsCount;
        private int _id3V2TextEncoding;
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

        public IntPtr DataPtr => _data;

        public long DataSize => _dataSize;

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

        public CoverType Type => _coverType;
        
        public string MIMEType
        {
            get
            {
                if (_mimeTypePtr == IntPtr.Zero)
                    return null;
                else
                    return Marshal.PtrToStringAuto(_mimeTypePtr);
            }
        }

        public PictureFormat Format => _pictureFormat;

        public int Width => _width;

        public int Height => _height;

        public int ColorDepth => _colorDepth;

        public int ColorsCountCount => _colorsCount;

        public int TextEncoding => _id3V2TextEncoding;

        public int Index => _index;
    }
}