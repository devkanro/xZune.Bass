using System.Collections;
using System.Collections.Generic;
using System.Linq;
using xZune.Bass.Tag.Interop.Core;
using xZune.Bass.Tag.Modules;

namespace xZune.Bass.Tag
{
    public class ExTagList : IReadOnlyList<ExtTag>
    {
        private class ExTagListEnumerator : IEnumerator<ExtTag>
        {
            public ExTagListEnumerator(ExTagList list)
            {
                _target = list;
            }

            private ExTagList _target;
            private int _index = -1;

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

            public ExtTag Current => _target[_index];

            object IEnumerator.Current => Current;
        }

        private TagsManager _target;

        public ExTagList(TagsManager tag)
        {
            _target = tag;
        }

        public IEnumerator<ExtTag> GetEnumerator()
        {
            return new ExTagListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(ExtTag item)
        {
            TagsLibCoreModule.AddExTagFunction.Delegate(_target.Handle, TagType.Automatic, ref item.Struct);
        }

        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                TagsLibCoreModule.DeleteTagByIndexFunction.Delegate(_target.Handle, i, TagType.Automatic);
            }
        }

        public bool Contains(ExtTag item)
        {
            return this.Any(t => t == item);
        }

        public void CopyTo(ExtTag[] array, int arrayIndex)
        {
            foreach (ExtTag tag in this)
            {
                array[arrayIndex] = tag;
                arrayIndex++;
            }
        }

        public bool Remove(ExtTag item)
        {
            if (!Contains(item))
                return false;

            return TagsLibCoreModule.DeleteTagByIndexFunction.Delegate(_target.Handle, item.Index, TagType.Automatic);
        }

        public int Count => TagsLibCoreModule.GetTagCountFunction.Delegate(_target.Handle, TagType.Automatic);
        public bool IsReadOnly => false;
        public int IndexOf(ExtTag item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i] == item)
                    return i;
            }

            return -1;
        }

        public void Insert(int index, ExtTag item)
        {
            throw new System.NotImplementedException();
        }

        public bool Change(ExtTag item)
        {
            return TagsLibCoreModule.SetExTagFunction.Delegate(_target.Handle, TagType.Automatic, ref item.Struct);
        }

        public void RemoveAt(int index)
        {
            TagsLibCoreModule.DeleteTagByIndexFunction.Delegate(_target.Handle, index, TagType.Automatic);
        }

        public ExtTag this[int index]
        {
            get
            {
                ExtTag result = new ExtTag();
                TagsLibCoreModule.GetExTagByIndexFunction.Delegate(_target.Handle, index, TagType.Automatic, ref result.Struct);
                return result;
            }
        }
    }
}