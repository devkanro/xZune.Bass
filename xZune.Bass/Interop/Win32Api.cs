// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Win32Api.cs
// Version: 20160216

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;

namespace xZune.Bass.Interop
{
    /// <summary>
    ///     Some method of Win32 APIs.
    /// </summary>
    public static class Win32Api
    {
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Ansi, EntryPoint = "LoadLibrary")]
        private static extern IntPtr LoadLibraryStatic(string lpFileName);
        
        public static IntPtr LoadLibrary(string lpFileName)
        {
            if (!System.IO.File.Exists(lpFileName))
            {
                throw new FileNotFoundException("Dll file not found.", lpFileName);
            }
            var result = LoadLibraryStatic(lpFileName);
            if (result != IntPtr.Zero) return result;
            var error = GetLastError();
            if (error == 0)
            {
                throw new Win32Exception($"Can't load dynamic link library \"{lpFileName}\", unknown error.");
            }
            throw new Win32Exception(error, $"Can't load dynamic link library \"{lpFileName}\".");
        }

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true,
            EntryPoint = "GetProcAddress")]
        private static extern IntPtr GetProcAddressStatic(IntPtr hModule, string lpProcName);
        
        public static IntPtr GetProcAddress(IntPtr hModule, string lpProcName)
        {
            IntPtr result = GetProcAddressStatic(hModule, lpProcName);
            if (result == IntPtr.Zero)
            {
                int error = GetLastError();
                if (error == 0)
                {
                    throw new Win32Exception($"Can't get entry point of \"{lpProcName}\", unknown error.");
                }
                throw new Win32Exception(error, $"Can't get entry point of \"{lpProcName}\".");
            }
            return result;
        }
        
        public static extern bool FreeLibrary(IntPtr hModule);
        
        [DllImport("kernel32", SetLastError = true)]
        public static extern IntPtr CreateFileMapping(IntPtr hFile, IntPtr lpAttributes, PageAccess flProtect,
            int dwMaximumSizeHigh, int dwMaximumSizeLow, string lpName);
        
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr MapViewOfFile(IntPtr hFileMappingObject, FileMapAccess dwDesiredAccess,
            uint dwFileOffsetHigh, uint dwFileOffsetLow, uint dwNumberOfBytesToMap);

        [DllImport("kernel32", SetLastError = true)]
        public static extern bool UnmapViewOfFile(IntPtr lpBaseAddress);
        
        [DllImport("kernel32", SetLastError = true)]
        public static extern bool CloseHandle(IntPtr handle);

        [DllImport("kernel32")]
        public static extern int GetLastError();
    }

    public enum PageAccess
    {
        NoAccess = 0x01,
        ReadOnly = 0x02,
        ReadWrite = 0x04,
        WriteCopy = 0x08,
        Execute = 0x10,
        ExecuteRead = 0x20,
        ExecuteReadWrite = 0x40,
        ExecuteWriteCopy = 0x80,
        Guard = 0x100,
        NoCache = 0x200,
        WriteCombine = 0x400
    }

    public enum FileMapAccess : uint
    {
        Write = 0x00000002,
        Read = 0x00000004,
        AllAccess = 0x000f001f,
        Copy = 0x00000001,
        Execute = 0x00000020
    }
}