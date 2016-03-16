// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: ErrorCode.cs
// Version: 20160316
namespace xZune.Bass.Tag.Interop.Core
{
    public enum ErrorCode
    {
        Success = 0,
        Error = 0xffff,
        ErrorNoTagFound = 1,
        ErrorFilenotfound = 2,
        ErrorEmptyTag = 3,
        ErrorEmptyFrames = 4,
        ErrorOpeningFile = 5,
        ErrorReadingFile = 6,
        ErrorWritingFile = 7,
        ErrorCorrupt = 8,
        ErrorNotSupportedVersion = 9,
        ErrorNotSupportedFormat = 10,
        ErrorBassNotLoaded = 11,
        ErrorBassChannelGetTagsNotFound = 12,
        ErrorDoesntFit = 13,
        ErrorNeedExclusiveAccess = 14,
        ErrorWmataglibraryCouldntloaddll = 15,
        ErrorWmataglibraryCouldnotcreatemetadataeditor = 16,
        ErrorWmataglibraryCouldnotqiforiwmheaderinfo3 = 17,
        ErrorWmataglibraryCouldnotqueryAttributeCount = 18,
        ErrorMp4TaglibraryUpdateStco = 19,
        ErrorMp4TaglibraryUpdateCo64 = 20,
        ErrorNotEnoughMemoryOrAv = 21

    }
}