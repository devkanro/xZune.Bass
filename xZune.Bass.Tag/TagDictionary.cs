using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using xZune.Bass.Tag.Interop.Core;
using xZune.Bass.Tag.Modules;

namespace xZune.Bass.Tag
{
    public class TagDictionary : IDictionary<String, String>
    {
        private class TagDictionaryEnumerator : IEnumerator<KeyValuePair<string, string>>
        {
            public TagDictionaryEnumerator(TagDictionary dic)
            {
                _target = dic;
            }

            private TagDictionary _target;
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

            public KeyValuePair<string, string> Current
            {
                get
                {
                    ExtTag tag = new ExtTag();

                    TagsLibCoreModule.GetExTagByIndexFunction.Delegate(_target._target.Handle, _index, TagType.Automatic, ref tag.Struct);

                    return new KeyValuePair<string, string>(tag.Name, tag.Value);
                }
            }

            object IEnumerator.Current => Current;
        }

        private TagsManager _target;

        public TagDictionary(TagsManager tag)
        {
            _target = tag;
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return new TagDictionaryEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<string, string> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                TagsLibCoreModule.DeleteTagByIndexFunction.Delegate(_target.Handle, i, TagType.Automatic);
            }
        }

        public bool Contains(KeyValuePair<string, string> item)
        {
            if (item.Key == null)
                return false;

            var value = this[item.Key];

            return value != null && value == item.Value;
        }

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            foreach (var tag in this)
            {
                array[arrayIndex] = tag;
                arrayIndex++;
            }
        }

        public bool Remove(KeyValuePair<string, string> item)
        {
            if (!Contains(item))
                return false;

            return Remove(item.Key);
        }

        public int Count => TagsLibCoreModule.GetTagCountFunction.Delegate(_target.Handle, TagType.Automatic);
        public bool IsReadOnly => false;
        public bool ContainsKey(string key)
        {
            if (key == null)
                return false;

            var value = this[key];

            return value != null;
        }

        public void Add(string key, string value)
        {
            TagsLibCoreModule.AddTagFunction.Delegate(_target.Handle, key, value, TagType.Automatic);
        }

        public bool Remove(string key)
        {
            return TagsLibCoreModule.DeleteTagFunction.Delegate(_target.Handle, key, TagType.Automatic);
        }

        public bool TryGetValue(string key, out string value)
        {
            value = this[key];
            return value != null;
        }

        public string this[string key]
        {
            get
            {
                var valueHandle = TagsLibCoreModule.GetTagFunction.Delegate(_target.Handle, key, TagType.Automatic);
                if (valueHandle == IntPtr.Zero)
                    return null;
                return Marshal.PtrToStringAuto(valueHandle);
            }
            set { TagsLibCoreModule.SetTagFunction.Delegate(_target.Handle, key, value, TagType.Automatic); }
        }

        public ICollection<string> Keys => this.ToList().Select(t => t.Key).ToList();
        public ICollection<string> Values => this.ToList().Select(t => t.Value).ToList();
    }
}
