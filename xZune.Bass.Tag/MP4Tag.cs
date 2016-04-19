using System;
using System.Text;
using xZune.Bass.Interop;
using xZune.Bass.Tag.Interop.Core;

namespace xZune.Bass.Tag
{
    /// <summary>
    /// Accessor for <see cref="Interop.Core.MP4Tag"/>.
    /// </summary>
    public class MP4Tag : IDisposable
    {
        /// <summary>
        /// Internal <see cref="Interop.Core.MP4Tag"/> structure.
        /// </summary>
        public Interop.Core.MP4Tag Struct;

        private AutoFreeGCHandle _nameHandle;
        private AutoFreeGCHandle _valueHandle;
        private AutoFreeGCHandle _meanHandle;
        private AutoFreeGCHandle _nameValueHandle;

        /// <summary>
        /// Create accessor for new <see cref="Interop.Core.MP4Tag"/>.
        /// </summary>
        public MP4Tag() : this(new Interop.Core.MP4Tag())
        {

        }

        /// <summary>
        /// Create accessor for a <see cref="Interop.Core.MP4Tag"/>.
        /// </summary>
        /// <param name="tag">Target structure.</param>
        public MP4Tag(Interop.Core.MP4Tag tag)
        {
            Struct = tag;
        }

        /// <summary>
        /// Get or set <see cref="Interop.Core.MP4Tag.Name"/> property.
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
        /// Get or set <see cref="Interop.Core.MP4Tag.Value"/> property.
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
        /// Get or set <see cref="Interop.Core.MP4Tag.MeanValue"/> property.
        /// </summary>
        public String MeanValue
        {
            get { return Struct.MeanValue; }
            set
            {
                _meanHandle?.Dispose();

                _meanHandle = InteropHelper.StringToPtr(value);

                Struct._meanValuePtr = _meanHandle.Handle;
            }
        }

        /// <summary>
        /// Get or set <see cref="Interop.Core.MP4Tag.NameValue"/> property.
        /// </summary>
        public String NameValue
        {
            get { return Struct.NameValue; }
            set
            {
                _nameValueHandle?.Dispose();

                _nameValueHandle = InteropHelper.StringToPtr(value);

                Struct._nameValuePtr = _nameValueHandle.Handle;
            }
        }

        /// <summary>
        /// Get <see cref="Interop.Core.MP4Tag.Index"/> property.
        /// </summary>
        public int Index => Struct.Index;

        /// <summary>
        /// Get or set <see cref="Interop.Core.MP4Tag.Type"/> property.
        /// </summary>
        public MP4TagType Type
        {
            get { return Struct._type; }
            set { Struct._type = value; }
        }

        /// <summary>
        /// Dispose accessor to release all resource.
        /// </summary>
        public void Dispose()
        {
            ((IDisposable) _nameHandle)?.Dispose();
            ((IDisposable) _valueHandle)?.Dispose();
            ((IDisposable) _meanHandle)?.Dispose();
            ((IDisposable) _nameValueHandle)?.Dispose();
        }

        public bool Equals(MP4Tag obj)
        {
            return obj.Struct == this.Struct;
        }

        public override bool Equals(object obj)
        {
            return Equals((MP4Tag) obj);
        }

        public static bool operator ==(MP4Tag tag1, MP4Tag tag2)
        {
            return tag1.Equals(tag2);
        }

        public static bool operator !=(MP4Tag tag1, MP4Tag tag2)
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
