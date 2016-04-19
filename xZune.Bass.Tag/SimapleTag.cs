// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: SimapleTag.cs
// Version: 20160318

using System;
using System.Text;
using xZune.Bass.Interop;

namespace xZune.Bass.Tag
{
    /// <summary>
    /// Accessor for <see cref="Interop.Core.SimpleTag"/>.
    /// </summary>
    public class SimpleTag : IDisposable
    {
        /// <summary>
        /// Internal <see cref="Interop.Core.SimpleTag"/> structure.
        /// </summary>
        public Interop.Core.SimpleTag Struct;

        private AutoFreeGCHandle _nameHandle;
        private AutoFreeGCHandle _valueHandle;

        /// <summary>
        /// Create accessor for new <see cref="Interop.Core.SimpleTag"/>.
        /// </summary>
        public SimpleTag() : this(new Interop.Core.SimpleTag())
        {
        }

        /// <summary>
        /// Create accessor for a <see cref="Interop.Core.SimpleTag"/>.
        /// </summary>
        /// <param name="tag">Target structure.</param>
        public SimpleTag(Interop.Core.SimpleTag tag)
        {
            Struct = tag;
        }

        /// <summary>
        /// Get or set <see cref="Interop.Core.SimpleTag.Name"/> property.
        /// </summary>
        public String Name
        {
            get { return Struct.Name; }
            set
            {
                _nameHandle?.Dispose();

                _nameHandle = InteropHelper.StringToPtr(value);

                Struct._namePtr = _nameHandle.Handle;
            }
        }

        /// <summary>
        /// Get or set <see cref="Interop.Core.SimpleTag.Value"/> property.
        /// </summary>
        public String Value
        {
            get { return Struct.Value; }
            set
            {
                _valueHandle?.Dispose();

                _valueHandle = InteropHelper.StringToPtr(value);
                Struct._valueSize = Encoding.Unicode.GetByteCount(value);

                Struct._valuePtr = _valueHandle.Handle;
            }
        }

        /// <summary>
        /// Get <see cref="Interop.Core.SimpleTag.Index"/> property.
        /// </summary>
        public int Index => Struct._index;

        /// <summary>
        /// Dispose accessor to release all resource.
        /// </summary>
        public void Dispose()
        {
            ((IDisposable) _nameHandle)?.Dispose();
            ((IDisposable) _valueHandle)?.Dispose();
        }

        public bool Equals(SimpleTag obj)
        {
            return obj.Struct == Struct;
        }

        public override bool Equals(object obj)
        {
            return Equals((SimpleTag) obj);
        }

        public static bool operator ==(SimpleTag tag1, SimpleTag tag2)
        {
            return tag1.Equals(tag2);
        }

        public static bool operator !=(SimpleTag tag1, SimpleTag tag2)
        {
            return !(tag1 == tag2);
        }

        /// <summary>
        /// Convert to string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"[{Name}, {Value}]";
        }

        public override int GetHashCode()
        {
            return Struct.GetHashCode();
        }
    }
}