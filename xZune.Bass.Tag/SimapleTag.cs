// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: SimapleTag.cs
// Version: 20160318

using System;
using System.Text;
using xZune.Bass.Interop;

namespace xZune.Bass.Tag
{
    public class SimpleTag : IDisposable
    {
        private AutoFreeGCHandle _nameHandle;
        private AutoFreeGCHandle _valueHandle;
        public Interop.Core.SimpleTag Struct;

        public SimpleTag() : this(new Interop.Core.SimpleTag())
        {
        }

        public SimpleTag(Interop.Core.SimpleTag tag)
        {
            Struct = tag;
        }

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

        public int Index => Struct._index;

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

        public override string ToString()
        {
            return $"[{Name}, {Value}]";
        }
    }
}