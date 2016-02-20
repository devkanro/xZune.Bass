// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Exception.cs
// Version: 20160216

using System;
using xZune.Bass.Interop;
using xZune.Bass.Interop.Core;

namespace xZune.Bass
{
    /// <summary>
    ///     A base class of Bass exceptions.
    /// </summary>
    public class BassException : Exception
    {
        /// <summary>
        ///     Create exception with a message.
        /// </summary>
        /// <param name="message">exception message</param>
        public BassException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Create exception with a message and a inner exception.
        /// </summary>
        /// <param name="message">exception message</param>
        /// <param name="innerException">inner exception</param>
        public BassException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    ///     If a Bass function don't have <see cref="BassFunctionAttribute" />, this exception will be throwed.
    /// </summary>
    public class NoBassFunctionAttributeException : BassException
    {
        /// <summary>
        ///     Create a <see cref="NoBassFunctionAttributeException" />.
        /// </summary>
        public NoBassFunctionAttributeException()
            : base("For BassFunction, need BassFunctionAttribute to get Infomation of function.")
        {
        }
    }

    /// <summary>
    /// If you call some function which need Bass loaded, but Bass didn't load, this exception will be throwed.
    /// </summary>
    public class BassNotLoadedException : BassException
    {
        /// <summary>
        ///     Create a <see cref="BassNotLoadedException" />.
        /// </summary>
        public BassNotLoadedException()
            : base("Bass DLL not loaded, you must use BassManager.Initialize() to load Bass DLL first.")
        {
        }
    }

    /// <summary>
    ///     If a function can't be found in Bass DLL, this exception will be throwed, maybe we should check the Bass
    ///     version what the function need.
    /// </summary>
    public class FunctionNotFoundException : BassException
    {
        /// <summary>
        ///     Create a  <see cref="FunctionNotFoundException" /> with function's infomation.
        /// </summary>
        /// <param name="functionInfo">infomation of function</param>
        public FunctionNotFoundException(BassFunctionAttribute functionInfo)
            : this(functionInfo, null)
        {
        }

        /// <summary>
        ///     Create a  <see cref="FunctionNotFoundException" /> with function's infomation and a inner exception.
        /// </summary>
        /// <param name="functionInfo">infomation of function</param>
        /// <param name="innerException">inner exception</param>
        public FunctionNotFoundException(BassFunctionAttribute functionInfo,
            Exception innerException)
            : base(String.Format("Can't find function \"{0}\" in Bass DLL.", functionInfo.FunctionName), innerException)
        {
            FunctionInfomation = functionInfo;
        }

        /// <summary>
        ///     Infomation of function what not found.
        /// </summary>
        public BassFunctionAttribute FunctionInfomation { get; private set; }
    }

    /// <summary>
    /// If a function result can't be verified, this exception will be throwed. You can check the error code and error message to get error infomation. 
    /// </summary>
    public class BassErrorException : BassException
    {

        /// <summary>
        /// Create a <see cref="BassErrorException"/> with a error infomation.
        /// </summary>
        /// <param name="errorInfo">Error infomation.</param>
        public BassErrorException(BassErrorAttribute errorInfo) : this(errorInfo.ErrorCode, errorInfo.ErrorMessage)
        {
        }

        /// <summary>
        /// Create a <see cref="BassErrorException"/> with a error code.
        /// </summary>
        /// <param name="errorCode">Error code.</param>
        public BassErrorException(ErrorCode errorCode) : this(errorCode, "No error message.")
        {

        }

        /// <summary>
        /// Create a <see cref="BassErrorException"/> with error code and error message.
        /// </summary>
        /// <param name="errorCode">Error code.</param>
        /// <param name="errorMessage">Error message.</param>
        public BassErrorException(ErrorCode errorCode, String errorMessage) : base($"Some error occur to call a Bass function, Code:{errorCode}({(int)errorCode}) - {errorMessage}.")
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        public ErrorCode ErrorCode { get; private set; }
        public string ErrorMessage { get; private set; }
    }

    /// <summary>
    /// If you have called <see cref="BassManager.Initialize"/> to initialize Bass, you call it again, this exception will be throwed.
    /// </summary>
    public class BassAlreadyInitilizedException : BassException
    {
        /// <summary>
        ///     Create a <see cref="BassAlreadyInitilizedException" />.
        /// </summary>
        public BassAlreadyInitilizedException()
            : base("Bass has initialized, maybe you should call BassManager.ReleaseAll() to dispose all resource, then call BassManager.Initialize() initialize Bass again.")
        {
        }
    }

    /// <summary>
    ///     If some exception throwed when loading Bass, this exception will be throwed. Maybe you should check the Bass
    ///     target platform and your APP target platform.
    /// </summary>
    public class BassLoadLibraryException : BassException
    {
        /// <summary>
        ///     Create a <see cref="BassLoadLibraryException" />.
        /// </summary>
        public BassLoadLibraryException() : this(null)
        {
        }

        /// <summary>
        ///     Create a <see cref="BassLoadLibraryException" /> with a inner exception.
        /// </summary>
        public BassLoadLibraryException(Exception innerException)
            : base(
                "Can't load Bass DLL, check the platform and Bass target platform (should be same, x86 or x64).",
                innerException)
        {
        }
    }

    /// <summary>
    /// If we can't find "bass.dll" in your provided path, this exception will be throwed.
    /// </summary>
    public class BassLibraryNotFoundException : BassException
    {
        /// <summary>
        ///     Create a <see cref="BassLibraryNotFoundException" /> with <see cref="BassManager.BassLibraryDirectory"/>.
        /// </summary>
        public BassLibraryNotFoundException() : this(BassManager.BassLibraryDirectory)
        {
        }

        /// <summary>
        ///     Create a <see cref="BassLibraryNotFoundException" /> with Bass library directory path.
        /// </summary>
        public BassLibraryNotFoundException(string bassLibraryDirectory)
            : base($"Can't find Bass DLL, make sure there are \"bass.dll\" in \"{bassLibraryDirectory}\".")
        {
            BassLibraryDirectory = bassLibraryDirectory;
        }

        public String BassLibraryDirectory { get; private set; }
    }

    /// <summary>
    /// If you use an unavailable <see cref="HandleObject"/>, this exception will be throwed.
    /// </summary>
    public class NotAvailableException : BassException
    {
        /// <summary>
        ///     Create a <see cref="NotAvailableException" />.
        /// </summary>
        public NotAvailableException(): base("Handle object is no longer available.")
        {

        }
    }


    /// <summary>
    /// If you set a invalid data to a sample, this exception will be throwed, check the length of <see cref="AudioSample.Infomation"/> and your data.
    /// </summary>
    public class InvalidSampleDataException : BassException
    {
        /// <summary>
        ///  Create a <see cref="InvalidSampleDataException" />.
        /// </summary>
        public InvalidSampleDataException(uint length, uint correctLength) : base($"Invalid data for this sample, the length of data is {length}, and it should be {correctLength}.")
        {

        }
    }
}