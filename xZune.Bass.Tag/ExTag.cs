// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: ExTag.cs
// Version: 20160318

using System;
using System.Text;
using xZune.Bass.Interop;
using xZune.Bass.Tag.Interop.Core;

namespace xZune.Bass.Tag
{
    public class ExtTag : IDisposable
    {
        public Interop.Core.ExtTag Struct;
        
        private AutoFreeGCHandle _nameHandle;
        private AutoFreeGCHandle _valueHandle;
        private AutoFreeGCHandle _languageHandle;
        private AutoFreeGCHandle _descriptionHandle;


        public ExtTag() : this(new Interop.Core.ExtTag())
        {

        }

        public ExtTag(Interop.Core.ExtTag tag)
        {
            Struct = tag;
        }

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

        public int Index => Struct.Index;

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

        public override string ToString()
        {
            return $"[{Name}, {Value}]";
        }
    }
}