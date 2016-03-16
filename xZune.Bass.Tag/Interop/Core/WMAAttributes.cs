// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: WMAAttributes.cs
// Version: 20160316

using System;
using System.Runtime.InteropServices;

namespace xZune.Bass.Tag.Interop.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WMAAttributes
    {
        private double _playTime;
        private int _bitRate;


        public TimeSpan Duration => TimeSpan.FromSeconds(_playTime);
        public int BitRate => _bitRate;
    }
}