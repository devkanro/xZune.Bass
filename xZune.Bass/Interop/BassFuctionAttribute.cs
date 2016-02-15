// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: BassFuctionAttribute.cs
// Version: 20160214

using System;

namespace xZune.Bass.Interop
{
    [AttributeUsage(AttributeTargets.Delegate)]
    internal class BassFuctionAttribute : Attribute
    {
        public BassFuctionAttribute(string functionName)
        {
            FunctionName = functionName;
        }

        public string FunctionName { get; private set; }
    }
}