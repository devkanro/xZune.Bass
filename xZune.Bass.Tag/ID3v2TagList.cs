// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: ID3v2TagList.cs
// Version: 20160319

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using xZune.Bass.Tag.Interop.Core;
using xZune.Bass.Tag.Modules;

namespace xZune.Bass.Tag
{
    /// <summary>
    ///     ID3v2Tag list accessor for <see cref="TagsManager" />.
    /// </summary>
    public class ID3v2TagList : IReadOnlyList<ID3v2Tag>
    {
        private readonly TagsManager _target;

        internal ID3v2TagList(TagsManager tag)
        {
            _target = tag;
        }

        /// <summary>
        ///     Is it read only?
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        ///     Get enumerator for <see cref="ID3v2TagList" />.
        /// </summary>
        /// <returns>Enumerator.</returns>
        public IEnumerator<ID3v2Tag> GetEnumerator()
        {
            return new ID3v2TagListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        ///     Get <see cref="ID3v2Tag" /> count of <see cref="TagsManager" />.
        /// </summary>
        public int Count => TagsLibCoreModule.GetTagCountFunction.Delegate(_target.Handle, TagType.ID3v2);

        /// <summary>
        ///     Get <see cref="ID3v2Tag" /> from index.
        /// </summary>
        /// <param name="index">Index of tag which you want to get.</param>
        /// <returns>Tag.</returns>
        public ID3v2Tag this[int index]
        {
            get
            {
                ID3v2Tag result = new ID3v2Tag();
                TagsLibCoreModule.GetID3v2TagExByIndexFunction.Delegate(_target.Handle, index, TagType.ID3v2,
                    ref result.Struct);
                return result;
            }
        }

        /// <summary>
        ///     Add a new <see cref="ID3v2Tag" /> to <see cref="TagsManager" />.
        /// </summary>
        /// <param name="item">Tag which you want to add.</param>
        public void Add(ID3v2Tag item)
        {
            TagsLibCoreModule.AddID3v2TagFunction.Delegate(_target.Handle, TagType.ID3v2, ref item.Struct);
        }

        /// <summary>
        ///     Clear all tag from <see cref="TagsManager" />.
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                TagsLibCoreModule.DeleteTagByIndexFunction.Delegate(_target.Handle, i, TagType.ID3v2);
            }
        }

        /// <summary>
        ///     Check if <see cref="TagsManager" /> contains a tag.
        /// </summary>
        /// <param name="item">Tag which you want to check.</param>
        /// <returns></returns>
        public bool Contains(ID3v2Tag item)
        {
            return this.Any(t => t == item);
        }

        /// <summary>
        ///     Copy all <see cref="ID3v2Tag" /> to a array.
        /// </summary>
        /// <param name="array">Array which you want to copy to.</param>
        /// <param name="arrayIndex">The first index of array.</param>
        public void CopyTo(ID3v2Tag[] array, int arrayIndex)
        {
            foreach (ID3v2Tag tag in this)
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
        public bool Remove(ID3v2Tag item)
        {
            if (!Contains(item))
                return false;

            return TagsLibCoreModule.DeleteTagByIndexFunction.Delegate(_target.Handle, item.Index, TagType.ID3v2);
        }

        /// <summary>
        ///     Get index of a tag.
        /// </summary>
        /// <param name="item">Tag which you want to check.</param>
        /// <returns>Index of tag.</returns>
        public int IndexOf(ID3v2Tag item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i] == item)
                    return i;
            }

            return -1;
        }

        /// <summary>
        ///     Save all changes of <see cref="ID3v2Tag" />, it will recover tag which has same name as
        ///     <see cref="ID3v2Tag.Name" />.
        /// </summary>
        /// <param name="item">Tag which you want to save changes.</param>
        /// <returns></returns>
        public bool Change(ID3v2Tag item)
        {
            return TagsLibCoreModule.SetID3v2TagFunction.Delegate(_target.Handle, TagType.ID3v2, ref item.Struct);
        }

        /// <summary>
        ///     Remove tag at index.
        /// </summary>
        /// <param name="index">Index of tag which you want to remove.</param>
        public void RemoveAt(int index)
        {
            TagsLibCoreModule.DeleteTagByIndexFunction.Delegate(_target.Handle, index, TagType.ID3v2);
        }

        private class ID3v2TagListEnumerator : IEnumerator<ID3v2Tag>
        {
            private int _index = -1;

            private ID3v2TagList _target;

            public ID3v2TagListEnumerator(ID3v2TagList list)
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

            public ID3v2Tag Current => _target[_index];

            object IEnumerator.Current => Current;
        }
    }
}