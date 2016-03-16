// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: TagsLibFunctionAttribute.cs
// Version: 20160316
namespace xZune.Bass.Tag.Interop
{
    /// <summary>
    /// A attribute class of TagsLib function information.
    /// </summary>
    public class TagsLibFunctionAttribute : TagsLibAttribute
    {
        /// <summary>
        ///     Create a <see cref="TagsLibFunctionAttribute" /> with a function name.
        /// </summary>
        /// <param name="functionName"></param>
        public TagsLibFunctionAttribute(string functionName)
        {
            FunctionName = functionName;
        }

        /// <summary>
        ///     Name of Bass function.
        /// </summary>
        public string FunctionName { get; private set; }
    }
}