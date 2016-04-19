// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: HandleManager.cs
// Version: 20160216

using System;
using System.Collections.Generic;

namespace xZune.Bass
{
    internal static class HandleManager
    {
        private static readonly Dictionary<IntPtr, IHandleObject> HandleDic = new Dictionary<IntPtr, IHandleObject>();

        public static IHandleObject GetHandleObject(IntPtr pointer)
        {
            if (HandleDic.ContainsKey(pointer))
            {
                return HandleDic[pointer];
            }
            return null;
        }

        public static void Add(IHandleObject handleObject)
        {
            if (handleObject.Handle == IntPtr.Zero) return;

            if (!HandleDic.ContainsKey(handleObject.Handle))
            {
                HandleDic.Add(handleObject.Handle, handleObject);
            }
        }

        public static void Remove(IHandleObject handleObject)
        {
            if (HandleDic.ContainsKey(handleObject.Handle))
            {
                HandleDic.Remove(handleObject.Handle);
            }
        }
    }
}