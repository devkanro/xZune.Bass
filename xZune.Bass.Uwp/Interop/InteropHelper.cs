// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: InteropHelper.cs
// Version: 20160216

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace xZune.Bass.Interop
{
    /// <summary>
    ///     Some helper method of interoperate with unmanaged DLLs.
    /// </summary>
    public static class InteropHelper
    {
        /// <summary>
        ///     Convert a pointer of string to managed <see cref="string" />.
        /// </summary>
        /// <param name="ptr">pointer of string</param>
        /// <param name="count">count of string, -1 mean auto check the end char</param>
        /// <param name="encoding">encoding of string</param>
        /// <returns>result string</returns>
        public static String PtrToString(IntPtr ptr, Encoding encoding = null, int count = -1)
        {
            if (ptr == IntPtr.Zero)
            {
                return null;
            }

            if (encoding == null)
            {
                encoding = Encoding.Unicode;
            }

            List<byte> buffer = new List<byte>(1024);

            if (count == -1)
            {
                if (encoding == Encoding.Unicode || encoding == Encoding.BigEndianUnicode)
                {
                    int offset = 0;
                    byte tmp = 0;
                    bool zeroFlag = false;

                    while (true)
                    {
                        tmp = Marshal.ReadByte(ptr, offset);

                        if (tmp == 0)
                        {
                            if (zeroFlag)
                            {
                                break;
                            }
                            else
                            {
                                zeroFlag = true;
                                continue;
                            }
                        }

                        zeroFlag = false;
                        buffer.Add(tmp);
                        offset++;
                    }
                }
                else
                {
                    int offset = 0;
                    byte tmp = 0;

                    while (true)
                    {
                        tmp = Marshal.ReadByte(ptr, offset);

                        if (tmp == 0)
                        {
                            break;
                        }
                        
                        buffer.Add(tmp);
                        offset++;
                    }
                }
                
            }
            else
            {
                byte tmp = 0;
                for (int i = 0; i < count; i++)
                {
                    tmp = Marshal.ReadByte(ptr, i);
                    buffer.Add(tmp);
                }
            }

            return Encoding.UTF8.GetString(buffer.ToArray());
        }

        /// <summary>
        ///     Pinned a <see cref="String" /> to get pointer of this.
        /// </summary>
        /// <param name="str">string you need pinned</param>
        /// <returns>GCHandle of <see cref="String" />, you can call <see cref="GCHandle.AddrOfPinnedObject" /> to get pointer.</returns>
        public static AutoFreeGCHandle StringToPtr(String str)
        {
            return new AutoFreeGCHandle(Encoding.Unicode.GetBytes(str));
        }

        /// <summary>
        ///     Pinned a <see cref="String" /> to get pointer of this.
        /// </summary>
        /// <param name="str">string you need pinned</param>
        /// <returns>GCHandle of <see cref="String" />, you can call <see cref="GCHandle.AddrOfPinnedObject" /> to get pointer.</returns>
        public static AutoFreeGCHandle StringToPtr(String str, int length)
        {
            byte[] bytes = new byte[length];
            Encoding.Unicode.GetBytes(str, 0, str.Length, bytes, 0);
            return new AutoFreeGCHandle(bytes);
        }

        /// <summary>
        ///     Convert a pointer array to <see cref="String" /> array.
        /// </summary>
        /// <param name="ptrs">pointer array</param>
        /// <param name="length">length of pointer array</param>
        /// <returns><see cref="String" /> array</returns>
        public static String[] PtrsToStringArray(IntPtr[] ptrs, int length)
        {
            String[] result = new String[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = ptrs[i] == IntPtr.Zero ? null : PtrToString(ptrs[i]);
            }
            return result;
        }

        /// <summary>
        ///     Get a pointer of <see cref="String" /> array.
        /// </summary>
        /// <param name="strings"><see cref="String" /> array</param>
        /// <returns>pointer of <see cref="String" /> array</returns>
        public static IntPtr StringArrayToPtr(String[] strings)
        {
            IntPtr[] ptrs = new IntPtr[strings.Length];

            for (int i = 0; i < strings.Length; i++)
            {
                ptrs[i] = Marshal.StringToHGlobalAnsi(strings[i]);
            }

            return Marshal.UnsafeAddrOfPinnedArrayElement(ptrs, 0);
        }

        public static String[] PtrToStringArray(IntPtr ptr)
        {
            byte b = 0;
            List<Byte> buffer = new List<byte>(512);
            bool zeroFlag = false;
            List<String> result = new List<string>();

            while (true)
            {
                b = Marshal.ReadByte(ptr);

                if (b == 0)
                {
                    if (zeroFlag)
                    {
                        return result.ToArray();
                    }
                    else
                    {
                        zeroFlag = true;
                        result.Add(Encoding.UTF8.GetString(buffer.ToArray()));
                        continue;
                    }
                }

                zeroFlag = false;
                buffer.Add(b);
            }
        }
    }
}