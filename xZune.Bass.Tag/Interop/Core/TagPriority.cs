// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: TagPriority.cs
// Version: 20160317

using System.Runtime.InteropServices;

namespace xZune.Bass.Tag.Interop.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TagPriority
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public TagType[] Values;
    }
}