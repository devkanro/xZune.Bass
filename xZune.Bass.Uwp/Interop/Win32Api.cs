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
        [DllImport("Kernel32", SetLastError = true, CharSet = CharSet.Ansi, EntryPoint = "LoadPackagedLibrary")]
        private static extern IntPtr LoadLibraryStatic(string lpFileName);
        
        public static IntPtr LoadLibrary(string lpFileName)
        {
            if (!System.IO.File.Exists(lpFileName))
            {
                throw new FileNotFoundException("Dll file not found.", lpFileName);
            }
            var result = Win32.LoadPackedLibrary(lpFileName);
            if (result != 0) return (IntPtr)result;
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
            IntPtr result =(IntPtr)Win32.GetFuncAddress(hModule.ToInt32(), lpProcName);

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


        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Ansi, EntryPoint = "FreeLibrary")]
        public static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("kernel32")]
        public static extern int GetLastError();
    }
}