// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: BassAttribute.cs
// Version: 20160312

using System;

namespace xZune.Bass.Interop
{
    /// <summary>
    ///     A base class of Bass attributes.
    /// </summary>
    [AttributeUsage(AttributeTargets.Delegate, AllowMultiple = true)]
    public abstract class BassAttribute : Attribute
    {
    }
}