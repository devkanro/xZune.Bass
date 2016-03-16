// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: TagsLibFunction.cs
// Version: 20160316
namespace xZune.Bass.Tag.Interop
{
    /// <summary>
    ///     A dynamic mapper of TagsLib functions.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TagsLibFunction<T>
    {
        private readonly T _functionDelegate;

        public TagsLibFunction()
        {
            
        }

        /// <summary>
        ///     Get this <see cref="TagsLibFunction{T}" /> is available or not.
        /// </summary>
        public bool IsEnable { get; }

        /// <summary>
        ///     Get delegate of this <see cref="TagsLibFunction{T}" />, if <see cref="IsEnable" /> is false, this method will throw
        ///     exception.
        /// </summary>
        public T Delegate
        {
            get
            {
                if (!IsEnable)
                {
                }
                return _functionDelegate;
            }
        }
    }
}