// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: BassFunctionAttribute.cs
// Version: 20160216

using System;

namespace xZune.Bass.Interop
{
    /// <summary>
    ///     A attribute class of Bass function infomation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Delegate)]
    public class BassFunctionAttribute : BassAttribute
    {
        /// <summary>
        ///     Create a <see cref="BassFunctionAttribute" /> with a function name.
        /// </summary>
        /// <param name="functionName"></param>
        public BassFunctionAttribute(string functionName)
        {
            FunctionName = functionName;
        }

        /// <summary>
        ///     Name of Bass function.
        /// </summary>
        public string FunctionName { get; private set; }
    }
}