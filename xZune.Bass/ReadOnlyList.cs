using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace xZune.Bass
{
    /// <summary>
    /// A readonly list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ReadOnlyList<T> : IReadOnlyList<T>
    {
        private T[] _array;

        /// <summary>
        /// Create a readonly list with items.
        /// </summary>
        /// <param name="list"></param>
        public ReadOnlyList(params T[] list) : this((IEnumerable<T>)list)
        {
        }

        /// <summary>
        /// Create a readonly list with a <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <param name="list"></param>
        public ReadOnlyList(IEnumerable<T> list)
        {
            _array = list.ToArray();
        }

        /// <summary>
        /// Return <see cref="IEnumerator{T}"/> of <see cref="ReadOnlyList{T}"/>.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)_array.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Get count of <see cref="ReadOnlyList{T}"/>.
        /// </summary>
        public int Count => _array.Length;

        public T this[int index] => _array[index];
    }
}