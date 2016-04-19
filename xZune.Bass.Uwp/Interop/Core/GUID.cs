// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Guid.cs
// Version: 20160214

using System.Runtime.InteropServices;

namespace xZune.Bass.Interop.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Guid
    {
        public ulong Data1;

        public ushort Data2;

        public ushort Data3;

        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 8)]
        public byte[] Data4;
    }
}