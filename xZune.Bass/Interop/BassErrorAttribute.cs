// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: BassErrorAttribute.cs
// Version: 20160216

using System;
using xZune.Bass.Interop.Core;

namespace xZune.Bass.Interop
{
    /// <summary>
    ///     A attribute class for get Bass function error infomation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Delegate, AllowMultiple = true)]
    public class BassErrorAttribute : BassAttribute
    {
        /// <summary>
        ///     Create a <see cref="BassErrorAttribute" /> with a error code and a message.
        /// </summary>
        /// <param name="error">Error code.</param>
        /// <param name="message">Error message.</param>
        public BassErrorAttribute(ErrorCode error, String message)
        {
            ErrorCode = error;
            ErrorMessage = message;
        }

        /// <summary>
        ///     Create a <see cref="BassErrorAttribute" /> with a error code and a message.
        /// </summary>
        /// <param name="error">Error code.</param>
        /// <param name="message">Error message.</param>
        public BassErrorAttribute(uint error, String message) : this((ErrorCode) error, message)
        {
        }

        /// <summary>
        ///     Error code.
        /// </summary>
        public ErrorCode ErrorCode { get; private set; }

        /// <summary>
        ///     Error message.
        /// </summary>
        public string ErrorMessage { get; private set; }
    }
}