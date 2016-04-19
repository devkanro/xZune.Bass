// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: TagDictionary.cs
// Version: 20160318

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using xZune.Bass.Tag.Interop.Core;
using xZune.Bass.Tag.Modules;

namespace xZune.Bass.Tag
{
    /// <summary>
    ///     Tag dictionary accessor for <see cref="TagsManager" />.
    /// </summary>
    public class TagDictionary : IDictionary<String, String>
    {
        private TagsManager _target;

        internal TagDictionary(TagsManager tag)
        {
            _target = tag;
        }

        /// <summary>
        ///     Get enumerator for <see cref="TagDictionary" />.
        /// </summary>
        /// <returns>Enumerator.</returns>
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return new TagDictionaryEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        ///     Add a new tag to <see cref="TagsManager" />.
        /// </summary>
        /// <param name="item">Tag which you want to add.</param>
        public void Add(KeyValuePair<string, string> item)
        {
            Add(item.Key, item.Value);
        }

        /// <summary>
        ///     Clear all tag from <see cref="TagsManager" />.
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                TagsLibCoreModule.DeleteTagByIndexFunction.Delegate(_target.Handle, i, TagType.Automatic);
            }
        }

        /// <summary>
        ///     Check if <see cref="TagsManager" /> contains a tag.
        /// </summary>
        /// <param name="item">Tag which you want to check.</param>
        /// <returns></returns>
        public bool Contains(KeyValuePair<string, string> item)
        {
            if (item.Key == null)
                return false;

            var value = this[item.Key];

            return value != null && value == item.Value;
        }

        /// <summary>
        ///     Copy all <see cref="SimpleTag" /> to a array.
        /// </summary>
        /// <param name="array">Array which you want to copy to.</param>
        /// <param name="arrayIndex">The first index of array.</param>
        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            foreach (var tag in this)
            {
                array[arrayIndex] = tag;
                arrayIndex++;
            }
        }

        /// <summary>
        ///     Remove a tag from <see cref="TagsManager" />.
        /// </summary>
        /// <param name="item">Tag which you want to remove.</param>
        /// <returns>True for success, false for fail.</returns>
        public bool Remove(KeyValuePair<string, string> item)
        {
            if (!Contains(item))
                return false;

            return Remove(item.Key);
        }

        /// <summary>
        ///     Get tag count of <see cref="TagsManager" />.
        /// </summary>
        public int Count => TagsLibCoreModule.GetTagCountFunction.Delegate(_target.Handle, TagType.Automatic);

        /// <summary>
        ///     Is it read only?
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        ///     Check if <see cref="TagsManager" /> contains a tag with a name.
        /// </summary>
        /// <param name="name">Tag name which you want to check.</param>
        /// <returns></returns>
        public bool ContainsKey(string name)
        {
            if (name == null)
                return false;

            var value = this[name];

            return value != null;
        }

        /// <summary>
        ///     Add a new tag to <see cref="TagsManager" />.
        /// </summary>
        /// <param name="key">Name of tag which you want to add.</param>
        /// <param name="value">Value of tag which you want to add.</param>
        public void Add(string key, string value)
        {
            TagsLibCoreModule.AddTagFunction.Delegate(_target.Handle, key, value, TagType.Automatic);
        }

        /// <summary>
        ///     Remove a tag from <see cref="TagsManager" />.
        /// </summary>
        /// <param name="key">Name of tag which you want to remove.</param>
        /// <returns>True for success, false for fail.</returns>
        public bool Remove(string key)
        {
            return TagsLibCoreModule.DeleteTagFunction.Delegate(_target.Handle, key, TagType.Automatic);
        }

        /// <summary>
        ///     Try to get value with a name.
        /// </summary>
        /// <param name="key">Name of tag which you want to get.</param>
        /// <param name="value">value of tag which you want to get.</param>
        /// <returns>If success to get value.</returns>
        public bool TryGetValue(string key, out string value)
        {
            value = this[key];
            return value != null;
        }

        /// <summary>
        ///     Get tag from name.
        /// </summary>
        /// <param name="key">Name of tag which you want to get.</param>
        /// <returns>Value of tag.</returns>
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

        /// <summary>
        ///     Get keys collection of <see cref="TagDictionary" />.
        /// </summary>
        public ICollection<string> Keys => this.ToList().Select(t => t.Key).ToList();

        /// <summary>
        ///     Get values collection of <see cref="TagDictionary" />.
        /// </summary>
        public ICollection<string> Values => this.ToList().Select(t => t.Value).ToList();

        private class TagDictionaryEnumerator : IEnumerator<KeyValuePair<string, string>>
        {
            private int _index = -1;

            private TagDictionary _target;

            public TagDictionaryEnumerator(TagDictionary dic)
            {
                _target = dic;
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

            public KeyValuePair<string, string> Current
            {
                get
                {
                    ExtTag tag = new ExtTag();

                    TagsLibCoreModule.GetExTagByIndexFunction.Delegate(_target._target.Handle, _index, TagType.Automatic,
                        ref tag.Struct);

                    return new KeyValuePair<string, string>(tag.Name, tag.Value);
                }
            }

            object IEnumerator.Current => Current;
        }
    }
}