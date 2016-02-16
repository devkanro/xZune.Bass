// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: BassFunction.cs
// Version: 20160216

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using xZune.Bass.Interop.Core;

namespace xZune.Bass.Interop
{
    /// <summary>
    ///     A dynamic mapper of LibVlc functions.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BassFunction<T>
    {
        private readonly T _functionDelegate;
        private readonly Dictionary<ErrorCode, BassErrorAttribute> _errorDictionary = new Dictionary<ErrorCode, BassErrorAttribute>();

        /// <exception cref="NoBassFunctionAttributeException">Can't find <see cref="BassFunctionAttribute"/> in this Bass function.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        /// <exception cref="TypeLoadException">A custom attribute type cannot be loaded. </exception>
        /// <exception cref="FunctionNotFoundException">Can't find this function in Bass DLL.</exception>
        public BassFunction()
        {
            if(!BassManager.Available) throw new BassNotLoadedException();

            IsEnable = false;

            object[] attrs = typeof(T).GetCustomAttributes(typeof(BassAttribute), false);

            List<BassErrorAttribute> errors = new List<BassErrorAttribute>();
            foreach (var item in attrs)
            {
                if (item is BassErrorAttribute)
                {
                    _errorDictionary.Add(((BassErrorAttribute)item).ErrorCode, ((BassErrorAttribute)item));
                    errors.Add(item as BassErrorAttribute);
                    break;
                }

                if (item is BassFunctionAttribute)
                {
                    FunctionInfomation = item as BassFunctionAttribute;
                    break;
                }

                if (item is BassVerificationAttribute)
                {
                    Verifier = item as BassVerificationAttribute;
                    break;
                }
            }

            ErrorAttributes = new ReadOnlyList<BassErrorAttribute>(errors);

            if (FunctionInfomation == null)
            {
                throw new NoBassFunctionAttributeException();
            }

            IntPtr procAddress;
            try
            {
                procAddress = Win32Api.GetProcAddress(BassManager.BassLibraryHandle,
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
        ///     Get this <see cref="BassFunction{T}" /> is available or not.
        /// </summary>
        public bool IsEnable { get; private set; }

        /// <summary>
        ///     Get infomation of <see cref="BassFunction{T}" />.
        /// </summary>
        public BassFunctionAttribute FunctionInfomation { get; private set; }

        /// <summary>
        ///     Get error infomation of <see cref="BassFunction{T}" />.
        /// </summary>
        public ReadOnlyList<BassErrorAttribute> ErrorAttributes { get; private set; }

        /// <summary>
        ///     Get result verifier of <see cref="BassFunction{T}" />.
        /// </summary>
        public BassVerificationAttribute Verifier { get; private set; }

        /// <summary>
        ///     Get delegate of this <see cref="BassFunction{T}" />, if <see cref="IsEnable" /> is false, this method will throw
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

        /// <summary>
        /// Check the result of this function, if something go wrong, it will throw <see cref="BassErrorException"/>, check <see cref="BassErrorException.ErrorCode"/> and <see cref="BassErrorException.ErrorMessage"/> to get more infomation about error.
        /// </summary>
        /// <param name="result"></param>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        public object CheckResult(object result)
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            if (Verifier == null) return result;

            if (Verifier.VerifyResult(result)) return result;

            var errorCode = BassManager.GetErrorCode();

            if (errorCode == ErrorCode.OK) return result;

            BassErrorAttribute errorInfo;

            if (_errorDictionary.TryGetValue(errorCode, out errorInfo))
            {
                throw new BassErrorException(errorInfo);
            }
            else
            {
                throw new BassErrorException(errorCode);
            }
        }

        /// <summary>
        /// Check the result of this function, if something go wrong, it will throw <see cref="BassErrorException"/>, check <see cref="BassErrorException.ErrorCode"/> and <see cref="BassErrorException.ErrorMessage"/> to get more infomation about error.
        /// </summary>
        /// <param name="result"></param>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        public T CheckResult<T>(T result)
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            if (Verifier == null) return result;

            if (Verifier.VerifyResult(result)) return result;

            var errorCode = BassManager.GetErrorCode();

            if (errorCode == ErrorCode.OK) return result;

            BassErrorAttribute errorInfo;

            if (_errorDictionary.TryGetValue(errorCode, out errorInfo))
            {
                throw new BassErrorException(errorInfo);
            }
            else
            {
                throw new BassErrorException(errorCode);
            }
        }
    }
}