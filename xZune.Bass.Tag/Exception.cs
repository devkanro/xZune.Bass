// Project: xZune.TagsLib (https://github.com/higankanshi/xZune.TagsLib)
// Filename: Exception.cs
// Version: 20160316

using System;
using xZune.Bass.Tag.Interop;

namespace xZune.Bass.Tag
{
    /// <summary>
    ///     A base class of TagsLib exceptions.
    /// </summary>
    public class TagsLibException : Exception
    {
        /// <summary>
        ///     Create exception with a message.
        /// </summary>
        /// <param name="message">exception message</param>
        public TagsLibException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Create exception with a message and a inner exception.
        /// </summary>
        /// <param name="message">exception message</param>
        /// <param name="innerException">inner exception</param>
        public TagsLibException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    ///     If a TagsLib function don't have <see cref="TagsLibFunctionAttribute" />, this exception will be throwed.
    /// </summary>
    public class NoTagsLibFunctionAttributeException : TagsLibException
    {
        /// <summary>
        ///     Create a <see cref="NoTagsLibFunctionAttributeException" />.
        /// </summary>
        public NoTagsLibFunctionAttributeException()
            : base("For TagsLibFunction, need TagsLibFunctionAttribute to get Information of function.")
        {
        }
    }

    /// <summary>
    /// If you call some function which need TagsLib loaded, but TagsLib didn't load, this exception will be throwed.
    /// </summary>
    public class TagsLibNotLoadedException : TagsLibException
    {
        /// <summary>
        ///     Create a <see cref="TagsLibNotLoadedException" />.
        /// </summary>
        public TagsLibNotLoadedException()
            : base("TagsLib DLL not loaded, you must use TagsLibManager.Initialize() to load TagsLib DLL first.")
        {
        }
    }

    /// <summary>
    ///     If a function can't be found in TagsLib DLL, this exception will be throwed, maybe we should check the TagsLib
    ///     version what the function need.
    /// </summary>
    public class FunctionNotFoundException : TagsLibException
    {
        /// <summary>
        ///     Create a  <see cref="FunctionNotFoundException" /> with function's information.
        /// </summary>
        /// <param name="functionInfo">information of function</param>
        public FunctionNotFoundException(TagsLibFunctionAttribute functionInfo)
            : this(functionInfo, null)
        {
        }

        /// <summary>
        ///     Create a  <see cref="FunctionNotFoundException" /> with function's information and a inner exception.
        /// </summary>
        /// <param name="functionInfo">information of function</param>
        /// <param name="innerException">inner exception</param>
        public FunctionNotFoundException(TagsLibFunctionAttribute functionInfo,
            Exception innerException)
            : base(String.Format("Can't find function \"{0}\" in TagsLib DLL.", functionInfo.FunctionName), innerException)
        {
            FunctionInfomation = functionInfo;
        }

        /// <summary>
        ///     Information of function what not found.
        /// </summary>
        public TagsLibFunctionAttribute FunctionInfomation { get; private set; }
    }

    /// <summary>
    ///     If some exception throwed when loading TagsLib, this exception will be throwed. Maybe you should check the TagsLib
    ///     target platform and your APP target platform.
    /// </summary>
    public class TagsLibLoadLibraryException : TagsLibException
    {
        /// <summary>
        ///     Create a <see cref="TagsLibLoadLibraryException" />.
        /// </summary>
        public TagsLibLoadLibraryException() : this(null)
        {
        }

        /// <summary>
        ///     Create a <see cref="TagsLibLoadLibraryException" /> with a inner exception.
        /// </summary>
        public TagsLibLoadLibraryException(Exception innerException)
            : base(
                "Can't load TagsLib DLL, check the platform and TagsLib target platform (should be same, x86 or x64).",
                innerException)
        {
        }
    }

    /// <summary>
    /// If we can't find "TagsLib.dll" in your provided path, this exception will be throwed.
    /// </summary>
    public class TagsLibNotFoundException : TagsLibException
    {
        /// <summary>
        ///     Create a <see cref="TagsLibNotFoundException" /> with <see cref="TagsLibManager.TagsLibDirectory"/>.
        /// </summary>
        public TagsLibNotFoundException() : this(TagsLibManager.TagsLibDirectory)
        {
        }

        /// <summary>
        ///     Create a <see cref="TagsLibNotFoundException" /> with TagsLib library directory path.
        /// </summary>
        public TagsLibNotFoundException(string tagsLibDirectory)
            : base($"Can't find TagsLib DLL, make sure there are \"TagsLib.dll\" in \"{tagsLibDirectory}\".")
        {
            TagsLibDirectory = tagsLibDirectory;
        }

        public String TagsLibDirectory { get; private set; }
    }

    /// <summary>
    /// If you use an unavailable <see cref="HandleObject"/>, this exception will be throwed.
    /// </summary>
    public class NotAvailableException : TagsLibException
    {
        /// <summary>
        ///     Create a <see cref="NotAvailableException" />.
        /// </summary>
        public NotAvailableException() : base("Handle object is no longer available.")
        {

        }
    }
}