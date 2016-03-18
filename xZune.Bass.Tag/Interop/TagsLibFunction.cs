// Project: xZune.TagsLib (https://github.com/higankanshi/xZune.TagsLib)
// Filename: TagsLibFunction.cs
// Version: 20160316

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using xZune.Bass.Interop;

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
            if (!TagsLibManager.Available) throw new TagsLibNotLoadedException();

            IsEnable = false;

            object[] attrs = typeof(T).GetCustomAttributes(typeof(TagsLibAttribute), false);

            foreach (var item in attrs)
            {
                if (item is TagsLibFunctionAttribute)
                {
                    FunctionInfomation = item as TagsLibFunctionAttribute;
                    continue;
                }
            }
            
            if (FunctionInfomation == null)
            {
                throw new NoTagsLibFunctionAttributeException();
            }

            IntPtr procAddress = IntPtr.Zero;
            try
            {
                procAddress = Win32Api.GetProcAddress(TagsLibManager.TagsLibHandle,
                    FunctionInfomation.FunctionName.Trim());
            }
            catch (Win32Exception e)
            {
                throw new FunctionNotFoundException(FunctionInfomation, e);
            }

            var del = Marshal.GetDelegateForFunctionPointer(procAddress, typeof(T));
            _functionDelegate = (T)Convert.ChangeType(del, typeof(T));
            IsEnable = true;
        }

        /// <summary>
        ///     Get information of <see cref="TagsLibFunction{T}" />.
        /// </summary>
        public TagsLibFunctionAttribute FunctionInfomation { get; }

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