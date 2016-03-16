// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: ID3v2TagType.cs
// Version: 20160316

namespace xZune.Bass.Tag.Interop.Core
{
    public enum ID3v2TagType
    {
        Unknown = 0,
        Text = 1,
        TextWithDescription = 2,
        TextWithDescriptionAndLangugageID = 3,
        URL = 4,
        UserDefinedURL = 5,
        PlayCount = 6,
        Binary = 7
    }
}