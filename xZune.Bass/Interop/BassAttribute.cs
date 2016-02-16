using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xZune.Bass.Interop
{
    /// <summary>
    /// A base class of Bass attributes.
    /// </summary>
    [AttributeUsage(AttributeTargets.Delegate, AllowMultiple = true)]
    public abstract class BassAttribute : Attribute
    {
    }
}
