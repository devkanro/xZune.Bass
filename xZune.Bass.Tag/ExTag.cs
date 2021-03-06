﻿// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: ExTag.cs
// Version: 20160318

using System;
using System.Text;
using xZune.Bass.Interop;
using xZune.Bass.Tag.Interop.Core;

namespace xZune.Bass.Tag
{
    /// <summary>
    /// Accessor for <see cref="Interop.Core.ExtTag"/>.
    /// </summary>
    public class ExtTag : IDisposable
    {
        /// <summary>
        /// Internal <see cref="Interop.Core.ExtTag"/> structure.
        /// </summary>
        public Interop.Core.ExtTag Struct;
        
        private AutoFreeGCHandle _nameHandle;
        private AutoFreeGCHandle _valueHandle;
        private AutoFreeGCHandle _languageHandle;
        private AutoFreeGCHandle _descriptionHandle;

        /// <summary>
        /// Create accessor for new <see cref="Interop.Core.ExtTag"/>.
        /// </summary>
        public ExtTag() : this(new Interop.Core.ExtTag())
        {

        }

        /// <summary>
        /// Create accessor for a <see cref="Interop.Core.ExtTag"/>.
        /// </summary>
        /// <param name="tag">Target structure.</param>
        public ExtTag(Interop.Core.ExtTag tag)
        {
            Struct = tag;
        }

        /// <summary>
        /// Get or set <see cref="Interop.Core.ExtTag.Name"/> property.
        /// </summary>
        public String Name
        {
            get
            {
                return Struct.Name;
            }
            set
            {
                _nameHandle?.Dispose();
                
                _nameHandle = InteropHelper.StringToPtr(value);

                Struct._namePtr = _nameHandle.Handle;
            }
        }

        /// <summary>
        /// Get or set <see cref="Interop.Core.ExtTag.Value"/> property.
        /// </summary>
        public String Value
        {
            get
            {
                return Struct.Value;
            }
            set
            {
                _valueHandle?.Dispose();
                
                _valueHandle = InteropHelper.StringToPtr(value);
                Struct._valueSize = Encoding.Unicode.GetByteCount(value);

                Struct._valuePtr = _valueHandle.Handle;
            }
        }

        /// <summary>
        /// Get or set <see cref="Interop.Core.ExtTag.Language"/> property.
        /// </summary>
        public String Language
        {
            get
            {
                return Struct.Language;
            }
            set
            {
                _languageHandle?.Dispose();

                _languageHandle = InteropHelper.StringToPtr(value);

                Struct._languagePtr = _languageHandle.Handle;
            }
        }

        /// <summary>
        /// Get or set <see cref="Interop.Core.ExtTag.Description"/> property.
        /// </summary>
        public String Description
        {
            get
            {
                return Struct.Description;
            }
            set
            {
                _descriptionHandle?.Dispose();

                _descriptionHandle = InteropHelper.StringToPtr(value);

                Struct._descriptionPtr = _descriptionHandle.Handle;
            }
        }

        /// <summary>
        /// Get <see cref="Interop.Core.ExtTag.Index"/> property.
        /// </summary>
        public int Index => Struct.Index;

        /// <summary>
        /// Get or set <see cref="Interop.Core.ExtTag.Type"/> property.
        /// </summary>
        public ExtTagType Type
        {
            get
            {
                return Struct._type;
            }
            set
            {
                Struct._type = value;
            }
        }

        /// <summary>
        /// Dispose accessor to release all resource.
        /// </summary>
        public void Dispose()
        {
            ((IDisposable)_nameHandle)?.Dispose();
            ((IDisposable)_valueHandle)?.Dispose();
            ((IDisposable)_languageHandle)?.Dispose();
            ((IDisposable)_descriptionHandle)?.Dispose();
        }
        
        public bool Equals(ExtTag obj)
        {
            return obj.Struct == this.Struct;
        }

        public override bool Equals(object obj)
        {
            return Equals((ExtTag)obj);
        }

        public static bool operator ==(ExtTag tag1, ExtTag tag2)
        {
            return tag1.Equals(tag2);
        }

        public static bool operator !=(ExtTag tag1, ExtTag tag2)
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