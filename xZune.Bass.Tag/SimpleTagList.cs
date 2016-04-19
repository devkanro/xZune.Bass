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
    /// <summary>
    ///     SimpleTag list accessor for <see cref="TagsManager" />.
    /// </summary>
    public class SimpleTagList : IReadOnlyList<SimpleTag>
    {
        private TagsManager _target;
        private TagType _type;

        internal SimpleTagList(TagsManager tag, TagType type)
        {
            _target = tag;
            _type = type;
        }

        /// <summary>
        ///     Is it read only?
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        ///     Get enumerator for <see cref="SimpleTagList" />.
        /// </summary>
        /// <returns>Enumerator.</returns>
        public IEnumerator<SimpleTag> GetEnumerator()
        {
            return new SimpleTagListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        ///     Get <see cref="SimpleTag" /> count of <see cref="TagsManager" />.
        /// </summary>
        public int Count => TagsLibCoreModule.GetTagCountFunction.Delegate(_target.Handle, _type);

        /// <summary>
        ///     Get <see cref="SimpleTag" /> from index.
        /// </summary>
        /// <param name="index">Index of tag which you want to get.</param>
        /// <returns>Tag.</returns>
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

        /// <summary>
        ///     Add a new <see cref="SimpleTag" /> to <see cref="TagsManager" />.
        /// </summary>
        /// <param name="item">Tag which you want to add.</param>
        public void Add(SimpleTag item)
        {
            TagsLibCoreModule.AddSimpleTagFunction.Delegate(_target.Handle, _type, ref item.Struct);
        }

        /// <summary>
        ///     Clear all tag from <see cref="TagsManager" />.
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                TagsLibCoreModule.DeleteTagByIndexFunction.Delegate(_target.Handle, i, _type);
            }
        }

        /// <summary>
        ///     Check if <see cref="TagsManager" /> contains a tag.
        /// </summary>
        /// <param name="item">Tag which you want to check.</param>
        /// <returns></returns>
        public bool Contains(SimpleTag item)
        {
            return this.Any(t => t == item);
        }

        /// <summary>
        ///     Copy all <see cref="SimpleTag" /> to a array.
        /// </summary>
        /// <param name="array">Array which you want to copy to.</param>
        /// <param name="arrayIndex">The first index of array.</param>
        public void CopyTo(SimpleTag[] array, int arrayIndex)
        {
            foreach (SimpleTag tag in this)
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
        public bool Remove(SimpleTag item)
        {
            if (!Contains(item))
                return false;

            return TagsLibCoreModule.DeleteTagByIndexFunction.Delegate(_target.Handle, item.Index, _type);
        }

        /// <summary>
        ///     Get index of a tag.
        /// </summary>
        /// <param name="item">Tag which you want to check.</param>
        /// <returns>Index of tag.</returns>
        public int IndexOf(SimpleTag item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i] == item)
                    return i;
            }

            return -1;
        }
        
        /// <summary>
        ///     Save all changes of <see cref="SimpleTag" />, it will recover tag which has same name as <see cref="SimpleTag.Name" />.
        /// </summary>
        /// <param name="item">Tag which you want to save changes.</param>
        /// <returns></returns>
        public bool Change(SimpleTag item)
        {
            return TagsLibCoreModule.SetSimpleTagFunction.Delegate(_target.Handle, _type, ref item.Struct);
        }

        /// <summary>
        ///     Remove tag at index.
        /// </summary>
        /// <param name="index">Index of tag which you want to remove.</param>
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