// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: SimpleTagList.cs
// Version: 20160318

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using xZune.Bass.Tag.Interop.Core;
using xZune.Bass.Tag.Modules;

namespace xZune.Bass.Tag
{
    public class SimpleTagList : IReadOnlyList<SimpleTag>
    {
        private TagsManager _target;
        private TagType _type;

        public SimpleTagList(TagsManager tag, TagType type)
        {
            _target = tag;
            _type = type;
        }

        public bool IsReadOnly => false;

        public IEnumerator<SimpleTag> GetEnumerator()
        {
            return new SimpleTagListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count => TagsLibCoreModule.GetTagCountFunction.Delegate(_target.Handle, _type);

        public SimpleTag this[int index]
        {
            get
            {
                SimpleTag result = new SimpleTag();
                TagsLibCoreModule.GetSimpleTagByIndexFunction.Delegate(_target.Handle, index, _type,
                    ref result.Struct);
                return result;
            }
        }

        public void Add(SimpleTag item)
        {
            TagsLibCoreModule.AddSimpleTagFunction.Delegate(_target.Handle, _type, ref item.Struct);
        }

        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                TagsLibCoreModule.DeleteTagByIndexFunction.Delegate(_target.Handle, i, _type);
            }
        }

        public bool Contains(SimpleTag item)
        {
            return this.Any(t => t == item);
        }

        public void CopyTo(SimpleTag[] array, int arrayIndex)
        {
            foreach (SimpleTag tag in this)
            {
                array[arrayIndex] = tag;
                arrayIndex++;
            }
        }

        public bool Remove(SimpleTag item)
        {
            if (!Contains(item))
                return false;

            return TagsLibCoreModule.DeleteTagByIndexFunction.Delegate(_target.Handle, item.Index, _type);
        }

        public int IndexOf(SimpleTag item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i] == item)
                    return i;
            }

            return -1;
        }

        public void Insert(int index, SimpleTag item)
        {
            throw new System.NotImplementedException();
        }

        public bool Change(SimpleTag item)
        {
            return TagsLibCoreModule.SetSimpleTagFunction.Delegate(_target.Handle, _type, ref item.Struct);
        }

        public void RemoveAt(int index)
        {
            TagsLibCoreModule.DeleteTagByIndexFunction.Delegate(_target.Handle, index, _type);
        }

        private class SimpleTagListEnumerator : IEnumerator<SimpleTag>
        {
            private int _index = -1;

            private SimpleTagList _target;

            public SimpleTagListEnumerator(SimpleTagList list)
            {
                _target = list;
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (_index < _target.Count - 1)
                {
                    _index++;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                _index = -1;
            }

            public SimpleTag Current => _target[_index];

            object IEnumerator.Current => Current;
        }
    }
}