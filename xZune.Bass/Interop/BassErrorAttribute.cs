// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: BassErrorAttribute.cs
// Version: 20160214

using System;
using xZune.Bass.Interop.Core;

namespace xZune.Bass.Interop
{
    [AttributeUsage(AttributeTargets.Delegate, AllowMultiple = true)]
    internal class BassErrorAttribute : Attribute
    {
        public BassErrorAttribute(ErrorCode error, String message)
        {
            ErrorCode = error;
            ErrorMessage = message;
        }

        public BassErrorAttribute(uint error, String message) : this((ErrorCode) error, message)
        {
        }

        public ErrorCode ErrorCode { get; private set; }
        public string ErrorMessage { get; private set; }
    }
}