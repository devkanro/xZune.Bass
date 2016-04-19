// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Functions.cs
// Version: 20160316

using System;
using System.Runtime.InteropServices;

namespace xZune.Bass.Tag.Interop.Core
{
    /// <summary>
    ///     Create a tag library object.
    /// </summary>
    /// <returns>value is a handle to the object. </returns>
    [TagsLibFunction("TagsLibrary_Create")]
    public delegate IntPtr Create();

    /// <summary>
    ///     Free the object created with <see cref="Create" />.
    /// </summary>
    /// <returns>value is a true means success.</returns>
    /// <remarks>
    ///     there's no clear function for the object,
    ///     always re-create the tags library object if you want to clear it.
    /// </remarks>
    [TagsLibFunction("TagsLibrary_Free")]
    public delegate bool Free(IntPtr tagsHandle);

    /// <summary>
    ///     Loads the tags from the specified 'FileName'. When 'TagType' is '<see cref="TagType.Automatic"/>'
    ///     all the supported tag types are loaded (in the order specified by '<see cref="SetTagLoadPriority"/>'),
    ///     to load a particular tag type, specify 'TagType' to something other then '<see cref="TagType.Automatic"/>'.
    ///     To check if tags are found use the function '<see cref="IsTagLoaded"/>'.
    ///     'ParseTags' should be always 'True',
    ///     but if you want to load a particular tag type then this flag specifies wheather to parse the tags to be used by
    ///     '<see cref="TagType.Automatic"/>'.
    ///     In other words, set 'ParseTags' to 'False' if you will use for example 'ID3v2' in all function calls (so then
    ///     there's no need to parse the tags).
    /// </summary>
    /// <returns>value is an error code of '<see cref="ErrorCode" />', '<see cref="ErrorCode.Success" />' means success. </returns>
    [TagsLibFunction("TagsLibrary_Load")]
    public delegate ErrorCode LoadTags(
        IntPtr tags, [In, MarshalAs(UnmanagedType.LPWStr)] string fileName, TagType tagType, bool parseTags);

    /// <summary>
    ///     Load the tags from a memory "file". This function allocates 'Size' bytes to load the tags.
    ///     So if the 'Size' variable is 100MB then this function will allocate another 100MBs.
    /// </summary>
    /// <param name="memoryAddress">pointer to start of data.</param>
    /// <param name="size">size of memory object.</param>
    /// <returns>value is an error code of '<see cref="ErrorCode" />', '<see cref="ErrorCode.Success" />' means success. </returns>
    [TagsLibFunction("TagsLibrary_LoadFromMemory")]
    public delegate ErrorCode LoadTagsFormMemory(
        IntPtr tags, IntPtr memoryAddress, UInt64 size, TagType tagType, bool parseTags);

    /// <summary>
    ///     Load the tags from a BASS channel handle. Usefull for URL (internet) streams.
    ///     But can be used for local (file) streams also.
    /// </summary>
    /// <returns>value is an error code of '<see cref="ErrorCode" />', '<see cref="ErrorCode.Success" />' means success. </returns>
    [TagsLibFunction("TagsLibrary_LoadFromBASS")]
    public delegate ErrorCode LoadTagsFormBass(IntPtr tags, IntPtr bassChannel);

    /// <summary>
    ///     Save the tags to file specified by 'FileName'. Using <see cref="TagType.Automatic" /> will decide the format by the
    ///     following:
    /// <para/>
    ///     - If the 'FileName' is the same as the one used for loading, the tags will be saved in all formats which were
    ///     present in the source file.
    /// <para/>
    ///     - Try to detect the following formats: <see cref="AudioFileFormat" /> and use the usual tagging format for the
    ///     detected specific format
    /// <para/>
    ///     - If the 'FileName' is different, format will be decided by the file extension.
    /// <para/>
    ///     To save a particular tag type specify it with <see cref="TagType" /> as eg. <see cref="TagType.ID3v2" />.
    /// </summary>
    /// <returns>value is an error code of '<see cref="ErrorCode" />', '<see cref="ErrorCode.Success" />' means success. </returns>
    [TagsLibFunction("TagsLibrary_Save")]
    public delegate ErrorCode SaveTags(
        IntPtr tags, [In, MarshalAs(UnmanagedType.LPWStr)] string fileName, TagType tagType);

    /// <summary>
    /// Save the tags without conversion ('ParseTag' and tags set with <see cref="TagType.Automatic" /> option will not have effect).
    /// Usefull if you want to work with a particular tag type.
    /// </summary>
    /// <returns>value is an error code of '<see cref="ErrorCode" />', '<see cref="ErrorCode.Success" />' means success. </returns>
    [TagsLibFunction("TagsLibrary_SaveEx")]
    public delegate ErrorCode SaveTagsEx(
        IntPtr tags, [In, MarshalAs(UnmanagedType.LPWStr)] string fileName, TagType tagType);

    /// <summary>
    /// Save the tags to a file in memory.
    /// This function allocates 'Size' bytes to save the tags and if the new tag doesn't fit in the file, it will allocate
    /// 'Size' bytes again. So if the 'Size' variable is 100MB then this function might allocate another 200MBs.
    /// </summary>
    /// <param name="memoryAddress">pointer to start of data.</param>
    /// <param name="size">size of memory object.</param>
    /// <param name="tagType">if <see cref="TagType.Automatic" /> then try to detect the following formats:
    /// <see cref="AudioFileFormat"/> and use the usual tagging format for the detected specific format</param>
    /// <param name="savedAddress">pointer to the saved "file" object. Is nil (null) on error.</param>
    /// <param name="savedSize">size of the new object. Is '0' on error.</param>
    /// <param name="saveHandle">use this handle with <see cref="FreeSaveHandle"/> to free the saved object.</param>
    /// <returns>value is an error code of '<see cref="ErrorCode" />', '<see cref="ErrorCode.Success" />' means success. </returns>
    [TagsLibFunction("TagsLibrary_SaveToMemory")]
    public delegate ErrorCode SaveTagsToMemory(
        IntPtr tags, IntPtr memoryAddress, UInt64 size, TagType tagType, ref IntPtr savedAddress, ref UInt64 savedSize,
        ref IntPtr saveHandle);

    /// <summary>
    /// Save a specific tag type directly to a file in memory.
    /// </summary>
    /// <param name="memoryAddress">pointer to start of data.</param>
    /// <param name="size">size of memory object.</param>
    /// <param name="tagType">if '<see cref="TagType.Automatic" />' then try to detect the following formats:
    /// '<see cref="AudioFileFormat"/>' and use the usual tagging format for the detected specific format</param>
    /// <param name="savedAddress">pointer to the saved "file" object. Is nil (null) on error.</param>
    /// <param name="savedSize">size of the new object. Is '0' on error.</param>
    /// <param name="saveHandle">use this handle with <see cref="FreeSaveHandle"/> to free the saved object.</param>
    /// <returns>value is an error code of '<see cref="ErrorCode" />', '<see cref="ErrorCode.Success" />' means success. </returns>
    [TagsLibFunction("TagsLibrary_SaveToMemoryEx")]
    public delegate ErrorCode SaveTagsToMemoryEx(
        IntPtr tags, IntPtr memoryAddress, UInt64 size, TagType tagType, ref IntPtr savedAddress, ref UInt64 savedSize,
        ref IntPtr saveHandle);

    /// <summary>
    /// 	Free the generated (tagged) saved object.
    /// 	It is needed to free the save handle to free memory allocated for the in-memory saving.
    /// </summary>
    /// <returns>value is an error code of '<see cref="ErrorCode" />', '<see cref="ErrorCode.Success" />' means success. </returns>
    [TagsLibFunction("TagsLibrary_FreeSaveHandle")]
    public delegate ErrorCode FreeSaveHandle(ref IntPtr saveHandle);
      
    /// <summary>
    /// Remove all tags from 'FileName',
    /// to delete a particular tags type set it with 'TagType'.
    /// </summary>
    /// <returns>value is an error code of '<see cref="ErrorCode" />', '<see cref="ErrorCode.Success" />' means success. </returns>
    [TagsLibFunction("TagsLibrary_RemoveTag")]
    public delegate ErrorCode RemoveTags([In, MarshalAs(UnmanagedType.LPWStr)] string fileName, TagType tagType);

    /// <summary>
    /// Remove all tags from memory "file", to delete a particular tags type set it with <see cref="TagType"/>.
    /// </summary>
    /// <param name="memoryAddress">pointer to start of data.</param>
    /// <param name="size">size of memory object.</param>
    /// <param name="tagType">'<see cref="TagType.Automatic"/>' is not supported, specify a tag format explicitly.</param>
    /// <param name="savedAddress">pointer to the saved "file" object. Is nil (null) on error.</param>
    /// <param name="savedSize">size of the new object. Is '0' on error.</param>
    /// <param name="saveHandle">use this handle with <see cref="FreeSaveHandle"/> to free the saved object.</param>
    /// <returns>value is an error code of '<see cref="ErrorCode" />', '<see cref="ErrorCode.Success" />' means success. </returns>
    [TagsLibFunction("TagsLibrary_RemoveTagFromMemory")]
    public delegate ErrorCode RemoveTagFromMemory(
        IntPtr memoryAddress, UInt64 size, TagType tagType, ref IntPtr savedAddress,
        ref UInt64 savedSize, ref IntPtr saveHandle);

    /// <summary>
    /// Get a pointer to a unicode (wide) string tag specified by 'Name' (for example 'TITLE').
    /// </summary>
    /// <returns>value is pointing to an empty string if no such tag found. </returns>
    [TagsLibFunction("TagsLibrary_GetTag")]
    public delegate IntPtr GetTag(IntPtr tags, [In, MarshalAs(UnmanagedType.LPWStr)] string name, TagType tagType);

    /// <summary>
    /// Test if tags are loaded. If 'TagType' is '<see cref="TagType.Automatic"/>' then the return value is 'False'
    /// </summary>
    /// <returns>value is 'False' if no tag exists in the file at all, 'True' otherwise</returns>
    [TagsLibFunction("TagsLibrary_Loaded")]
    public delegate bool IsTagLoaded(IntPtr tags, TagType tagType);

    /// <summary>
    /// Get extended (detailed) information about a tag. Usefull for 'ttID3v2' TXXX, WXXX, COMM frames and MP4 tags.
    /// </summary>
    /// <returns>value is 'False' if no tag specified by 'Name' (eg. 'TITLE') is present in the tags.</returns>
    /// <remarks>TagType' values need a specific 'ExtTag' pointer to different structures:</remarks>
    [TagsLibFunction("TagsLibrary_GetTagEx")]
    public delegate ErrorCode GetTagEx(
        IntPtr tags, [In, MarshalAs(UnmanagedType.LPWStr)] string name, TagType tagType, ref ExtTag extTag);

    /// <summary>
    /// Get extended (detailed) information about a ExtTag.
    /// </summary>
    /// <returns>value is 'False' if 'Index' is invalid..</returns>
    [TagsLibFunction("TagsLibrary_GetTagByIndexEx")]
    public delegate bool GetExTagByIndex(IntPtr tags, int index, TagType tagType, ref ExtTag extTag);

    /// <summary>
    /// Get extended (detailed) information about a SimpleTag.
    /// </summary>
    /// <returns>value is 'False' if 'Index' is invalid..</returns>
    [TagsLibFunction("TagsLibrary_GetTagByIndexEx")]
    public delegate bool GetSimpleTagByIndex(IntPtr tags, int index, TagType tagType, ref SimpleTag simpleTag);

    /// <summary>
    /// Get extended (detailed) information about a ID3v2TagEx.
    /// </summary>
    /// <returns>value is 'False' if 'Index' is invalid..</returns>
    [TagsLibFunction("TagsLibrary_GetTagByIndexEx")]
    public delegate bool GetID3v2TagExByIndex(IntPtr tags, int index, TagType tagType, ref ID3v2Tag id3V2TagEx);

    /// <summary>
    /// Get extended (detailed) information about a MP4TagEx.
    /// </summary>
    /// <returns>value is 'False' if 'Index' is invalid..</returns>
    [TagsLibFunction("TagsLibrary_GetTagByIndexEx")]
    public delegate bool GetMp4TagExByIndex(IntPtr tags, int index, TagType tagType, ref MP4Tag mp4TagEx);

    /// <summary>
    /// Simply set a tag specified by 'Name' to value specified by 'Value'.
    /// If there's already a field with the specified name it will be replaced with the new value.
    ///	When using with a particular tag type, eg. '<see cref="TagType.ID3v2"/>', 'Name'
    ///	specifies an ID3v2 frame type, eg. 'TIT2' (which is title), or an MP4 tag atom name, for example '©ART' (artist).
    /// </summary>
    /// <returns>value is 'True' on success.</returns>
    [TagsLibFunction("TagsLibrary_SetTag")]
    public delegate bool SetTag(IntPtr tags, [In, MarshalAs(UnmanagedType.LPWStr)] string name,
        [In, MarshalAs(UnmanagedType.LPWStr)] string value, TagType tagType);

    /// <summary>
    /// Set a tag with extended (detailed) attributes. '<see cref="ExtTag.Name"/>' specifies the tag's name, an ID3v2 frame type,
    /// eg. 'TIT2' (which is title), or an MP4 tag atom name, for example '©ART' (artist).
    ///	ExtTag.ValueSize specifies ExtTag.Value length in bytes.
    /// </summary>
    /// <returns>value is 'True' on success.</returns>
    [TagsLibFunction("TagsLibrary_SetTagEx")]
    public delegate bool SetExTag(IntPtr tags, TagType tagType, ref ExtTag extTag);

    /// <summary>
    /// Set a tag with extended (detailed) attributes. '<see cref="SimpleTag.Name"/>' specifies the tag's name, an ID3v2 frame type,
    /// eg. 'TIT2' (which is title), or an MP4 tag atom name, for example '©ART' (artist).
    ///	ExtTag.ValueSize specifies ExtTag.Value length in bytes.
    /// </summary>
    /// <returns>value is 'True' on success.</returns>
    [TagsLibFunction("TagsLibrary_SetTagEx")]
    public delegate bool SetSimpleTag(IntPtr tags, TagType tagType, ref SimpleTag simpleTag);

    /// <summary>
    /// Set a tag with extended (detailed) attributes. '<see cref="ExtTag.Name"/>' specifies the tag's name, an ID3v2 frame type,
    /// eg. 'TIT2' (which is title), or an MP4 tag atom name, for example '©ART' (artist).
    ///	ExtTag.ValueSize specifies ExtTag.Value length in bytes.
    /// </summary>
    /// <returns>value is 'True' on success.</returns>
    [TagsLibFunction("TagsLibrary_SetTagEx")]
    public delegate bool SetID3v2Tag(IntPtr tags, TagType tagType, ref ID3v2Tag tag);

    /// <summary>
    /// Set a tag with extended (detailed) attributes. '<see cref="MP4Tag.Name"/>' specifies the tag's name, an ID3v2 frame type,
    /// eg. 'TIT2' (which is title), or an MP4 tag atom name, for example '©ART' (artist).
    ///	ExtTag.ValueSize specifies ExtTag.Value length in bytes.
    /// </summary>
    /// <returns>value is 'True' on success.</returns>
    [TagsLibFunction("TagsLibrary_SetTagEx")]
    public delegate bool SetMP4Tag(IntPtr tags, TagType tagType, ref MP4Tag tag);
    
    /// <summary>
    /// Add a tag specified by 'Name' to value specified by 'Value'.
    /// If there's already a field with the specified name a new one will added, and the previous is preserved.
    ///	When using with a particular tag type, eg. 'ttID3v2', 'Name' specifies an ID3v2 frame type,
    ///	eg. 'TIT2' (which is title), or an MP4 tag atom name, for example '©ART' (artist).
    ///	But be carefull because eg. MP4 tags can't contain multiple atoms of the same type.
    /// </summary>
    /// <returns>value is 'True' on success.</returns>
    [TagsLibFunction("TagsLibrary_AddTag")]
    public delegate int AddTag(
        IntPtr tags, [In, MarshalAs(UnmanagedType.LPWStr)] string name,
        [In, MarshalAs(UnmanagedType.LPWStr)] string value, TagType tagType);

    /// <summary>
    /// Add a tag with extended (detailed) attributes. '<see cref="ExtTag.Name"/>' specifies the tag's name, an ID3v2 frame type,
    /// eg. 'TIT2' (which is title), or an MP4 tag atom name, for example '©ART' (artist).
    /// </summary>
    /// <returns>Return value is 'True' on success</returns>
    [TagsLibFunction("TagsLibrary_AddTagEx")]
    public delegate int AddExTag(IntPtr tags, TagType tagType, ref ExtTag extTag);

    /// <summary>
    /// Add a tag with extended (detailed) attributes. '<see cref="SimpleTag.Name"/>' specifies the tag's name, an ID3v2 frame type,
    /// eg. 'TIT2' (which is title), or an MP4 tag atom name, for example '©ART' (artist).
    /// </summary>
    /// <returns>Return value is 'True' on success</returns>
    [TagsLibFunction("TagsLibrary_AddTagEx")]
    public delegate int AddSimpleTag(IntPtr tags, TagType tagType, ref SimpleTag simpleTag);

    /// <summary>
    /// Add a tag with extended (detailed) attributes. '<see cref="ID3v2Tag.Name"/>' specifies the tag's name, an ID3v2 frame type,
    /// eg. 'TIT2' (which is title), or an MP4 tag atom name, for example '©ART' (artist).
    /// </summary>
    /// <returns>Return value is 'True' on success</returns>
    [TagsLibFunction("TagsLibrary_AddTagEx")]
    public delegate int AddID3v2Tag(IntPtr tags, TagType tagType, ref ID3v2Tag tag);

    /// <summary>
    /// Add a tag with extended (detailed) attributes. '<see cref="MP4Tag.Name"/>' specifies the tag's name, an ID3v2 frame type,
    /// eg. 'TIT2' (which is title), or an MP4 tag atom name, for example '©ART' (artist).
    /// </summary>
    /// <returns>Return value is 'True' on success</returns>
    [TagsLibFunction("TagsLibrary_AddTagEx")]
    public delegate int AddMP4Tag(IntPtr tags, TagType tagType, ref MP4Tag tag);

    /// <summary>
    /// Retrieve the tag count for the specified 'TagType' tag type.
    /// </summary>
    /// <returns>value Tag Count</returns>
    [TagsLibFunction("TagsLibrary_TagCount")]
    public delegate int GetTagCount(IntPtr tags, TagType tagType);

    /// <summary>
    /// Delete the first occurance of tag specified by 'Name'.
    /// </summary>
    /// <returns>is 'False' if no such tag found.</returns>
    [TagsLibFunction("TagsLibrary_DeleteTag")]
    public delegate bool DeleteTag(IntPtr tags, [In, MarshalAs(UnmanagedType.LPWStr)] string name, TagType tagType);

    /// <summary>
    /// Delete the tag specified by 'Index'.
    /// </summary>
    /// <returns>is 'False' if 'Index' is out of bounds.</returns>
    [TagsLibFunction("TagsLibrary_DeleteTagByIndex")]
    public delegate bool DeleteTagByIndex(IntPtr tags, int index, TagType tagType);

    /// <summary>
    /// Retrieve the cover art count for the 'TagType'.
    /// </summary>
    /// <returns>cover art count</returns>
    [TagsLibFunction("TagsLibrary_CoverArtCount")]
    public delegate int GetCoverArtCount(IntPtr tags, TagType tagType);

    /// <summary>
    ///  Extract the cover art specified by 'Index' into the 'CoverArt' structure.
    ///	'CoverArt.Data' points to the cover art data bytes, 'CoverArt.DataSize' specifies the data size.
    ///	You can use 'CoverArt.MIMEType' or 'CoverArt.PictureFormat' to identify the cover art picture format.
    /// </summary>
    /// <returns>value is 'True' on success.</returns>
    [TagsLibFunction("TagsLibrary_GetCoverArt")]
    public delegate bool GetCoverArt(IntPtr tags, TagType tagType, int index, ref CoverArtData coverArt);

    /// <summary>
    /// Save cover art to specified path which can load then from Path in a PictureBox
    /// </summary>
    /// <returns>value is 'True' on success.</returns>
    [TagsLibFunction("TagsLibrary_GetCoverArtToFile")]
    public delegate bool GetCoverArtToFile(IntPtr tags, TagType tagType, int index, [In, MarshalAs(UnmanagedType.LPWStr)] string fileName);

    /// <summary>
    /// Delete a cover art specified by 'Index'. Use 'TagsLibrary_CoverArtCount'
    /// to check how many cover arts are in the tag.
    /// </summary>
    /// <returns>value is 'True' on success.</returns>
    [TagsLibFunction("TagsLibrary_DeleteCoverArt")]
    public delegate bool DeleteCoverArt(IntPtr tags, TagType tagType, int index);

    /// <summary>
    /// Set cover art specified by 'Index'.
    ///	Try to fill in all the attributes in 'CoverArt', although not all are needed for all the tag types.
    /// </summary>
    /// <returns>value is 'True' on success</returns>
    [TagsLibFunction("TagsLibrary_SetCoverArt")]
    public delegate bool SetCoverArt(IntPtr tags, TagType tagType, int index, ref CoverArtData coverArt);

    /// <summary>
    /// Set cover art specified by 'Index' to a file which load before.
    /// </summary>
    /// <returns>value is 'True' on success</returns>
    [TagsLibFunction("TagsLibrary_SetCoverArtFromFile")]
    public delegate bool SetCoverArtFromFile(IntPtr tags, TagType tagType, int index, [In, MarshalAs(UnmanagedType.LPWStr)] string fileName, CoverArtData coverArt);

    /// <summary>
    /// Add a new cover art.
    /// Try to fill in all the attributes in 'CoverArt', although not all are needed for all the tag types.
    /// </summary>
    /// <returns>value is 'True' on success.  </returns>
    [TagsLibFunction("TagsLibrary_AddCoverArt")]
    public delegate int AddCoverArt(IntPtr tags, TagType tagType, CoverArtData coverArt);

    /// <summary>
    /// Set the tag loading priority array. The value in 'TagPriorities[0]' has the highest priority.
    ///	Use 'Tags' = 'nil' or 'null' to set the global tag load priority.
    ///	All tag library classes created after calling this function will use these settings.
    /// </summary>
    /// <returns>value should be always 'True'.</returns>
    [TagsLibFunction("TagsLibrary_SetTagLoadPriority")]
    public delegate bool SetTagLoadPriority(IntPtr tags, TagPriority tagPriorities);

    /// <summary>
    /// Get binary data of a tag frame. Usefull for ID3v2 GEOB, etc. binary frames and MP4 binary atoms.
    /// </summary>
    /// <returns>value is 'True' on success.</returns>
    [TagsLibFunction("TagsLibrary_GetTagData")]
    public delegate bool GetTagData(IntPtr tags, int index, TagType tagType, ref TagData tagData);

    /// <summary>
    /// Set binary data of a tag frame. Usefull for ID3v2 GEOB, APEv2 binary frames, etc. and MP4 tags.
    /// </summary>
    /// <returns>value is 'True' on success.</returns>
    [TagsLibFunction("TagsLibrary_SetTagData")]
    public delegate bool SetTagData(IntPtr tags, int index, TagType tagType, TagData tagData);

    /// <summary>
    /// Get WAV CART post timer specified by 'Index'. There are 8 CART post timers, Index range is 0 to 7.
    /// </summary>
    /// <returns>is 'False' if 'Index' is out of bounds.</returns>
    [TagsLibFunction("TagsLibrary_GetCARTPostTimer")]
    public delegate bool GetCartPostTimer(IntPtr tags, int index, ref CARTPostTimer postTimer);

    /// <summary>
    /// Set WAV CART post timer specified by 'Index'. There are 8 CART post timers, Index range is 0 to 7.
    /// </summary>
    /// <returns>is 'False' if 'Index' is out of bounds.</returns>
    [TagsLibFunction("TagsLibrary_SetCARTPostTimer")]
    public delegate bool SetCartPostTimer(IntPtr tags, int index, CARTPostTimer postTimer);

    /// <summary>
    /// Clear WAV CART post timer specified by 'Index'. There are 8 CART post timers, Index range is 0 to 7.
    /// </summary>
    /// <returns>is 'False' if 'Index' is out of bounds.</returns>
    [TagsLibFunction("TagsLibrary_ClearCARTPostTimer")]
    public delegate bool ClearCartPostTimer(IntPtr tags, int index);

    /// <summary>
    /// configuration settings. If 'Tags' = nil then means global parameters.
    /// </summary>
    [TagsLibFunction("TagsLibrary_GetConfig")]
    public delegate IntPtr GetConfig(IntPtr tags, ConfigFlags config, TagType tagType);

    /// <summary>
    /// configuration settings. If 'Tags' = nil then means global parameters.
    /// </summary>
    /// <returns>value is 'True' on success.</returns>
    [TagsLibFunction("TagsLibrary_SetConfig")]
    public delegate bool SetConfig(IntPtr tags, IntPtr value, ConfigFlags config, TagType tagType);

    /// <summary>
    /// Vendor string. Applies to Ogg Vorbis, Opus and Flac.
    /// </summary>
    /// <returns>value is null otherwise string.</returns>
    [TagsLibFunction("TagsLibrary_GetVendor")]
    public delegate IntPtr GetVendor(IntPtr tags, TagType tagType);

    /// <summary>
    /// Vendor string. Applies to Ogg Vorbis, Opus and Flac.
    /// </summary>
    /// <returns>value is 'True' on success.</returns>
    [TagsLibFunction("TagsLibrary_SetVendor")]
    public delegate bool SetVendor(IntPtr tags, [In, MarshalAs(UnmanagedType.LPWStr)] string vendor, TagType tagType);

    /// <summary>
    /// Get MPEGAudioAttributes audio file's attributes.
    /// </summary>
    /// <returns>value is 'True' on success.</returns>
    [TagsLibFunction("TagsLibrary_GetAudioAttributes")]
    public delegate ErrorCode GetMPEGAudioAttributes(IntPtr tags, AudioType audioType, ref MPEGAudioAttributes attributes);

    /// <summary>
    /// Get FlacAudioAttributes audio file's attributes.
    /// </summary>
    /// <returns>value is 'True' on success.</returns>
    [TagsLibFunction("TagsLibrary_GetAudioAttributes")]
    public delegate ErrorCode GetFlacAudioAttributes(IntPtr tags, AudioType audioType, ref FlacAudioAttributes attributes);

    /// <summary>
    /// Get DSFAudioAttributes audio file's attributes.
    /// </summary>
    /// <returns>value is 'True' on success.</returns>
    [TagsLibFunction("TagsLibrary_GetAudioAttributes")]
    public delegate ErrorCode GetDSFAudioAttributes(IntPtr tags, AudioType audioType, ref DSFAudioAttributes attributes);

    /// <summary>
    /// Get OpusAudioAttributes audio file's attributes.
    /// </summary>
    /// <returns>value is 'True' on success.</returns>
    [TagsLibFunction("TagsLibrary_GetAudioAttributes")]
    public delegate ErrorCode GetOpusAudioAttributes(IntPtr tags, AudioType audioType, ref OpusAudioAttributes attributes);

    /// <summary>
    /// Get VorbisAudioAttributes audio file's attributes.
    /// </summary>
    /// <returns>value is 'True' on success.</returns>
    [TagsLibFunction("TagsLibrary_GetAudioAttributes")]
    public delegate ErrorCode GetVorbisAudioAttributes(IntPtr tags, AudioType audioType, ref VorbisAudioAttributes attributes);

    /// <summary>
    /// Get WAVEAudioAttributes audio file's attributes.
    /// </summary>
    /// <returns>value is 'True' on success.</returns>
    [TagsLibFunction("TagsLibrary_GetAudioAttributes")]
    public delegate ErrorCode GetWAVEAudioAttributes(IntPtr tags, AudioType audioType, ref WAVEAudioAttributes attributes);

    /// <summary>
    /// Get AIFFAttributes audio file's attributes.
    /// </summary>
    /// <returns>value is 'True' on success.</returns>
    [TagsLibFunction("TagsLibrary_GetAudioAttributes")]
    public delegate ErrorCode GetAiffAttributes(IntPtr tags, AudioType audioType, ref AIFFAttributes attributes);

    /// <summary>
    /// Get MP4AudioAttributes audio file's attributes.
    /// </summary>
    /// <returns>value is 'True' on success.</returns>
    [TagsLibFunction("TagsLibrary_GetAudioAttributes")]
    public delegate ErrorCode GetMp4AudioAttributes(IntPtr tags, AudioType audioType, ref MP4AudioAttributes attributes);

    /// <summary>
    /// Get WMAAttributes audio file's attributes.
    /// </summary>
    /// <returns>value is 'True' on success.</returns>
    [TagsLibFunction("TagsLibrary_GetAudioAttributes")]
    public delegate ErrorCode GetWMAAttributes(IntPtr tags, AudioType audioType, ref WMAAttributes attributes);

    /// <summary>
    /// Get AudioAttributes audio file's attributes.
    /// </summary>
    /// <returns>value is 'True' on success.</returns>
    [TagsLibFunction("TagsLibrary_GetAudioAttributes")]
    public delegate ErrorCode GetAudioAttributes(IntPtr tags, AudioType audioType, ref AudioAttributes attributes);

    /// <summary>
    /// Get WAVPackAttributes audio file's attributes.
    /// </summary>
    /// <returns>value is 'True' on success.</returns>
    [TagsLibFunction("TagsLibrary_GetAudioAttributes")]
    public delegate ErrorCode GetWAVPackAttributes(IntPtr tags, AudioType audioType, ref WAVPackAttributes attributes);

    /// <summary>
    /// Get MusePackAttributes audio file's attributes.
    /// </summary>
    /// <returns>value is 'True' on success.</returns>
    [TagsLibFunction("TagsLibrary_GetAudioAttributes")]
    public delegate ErrorCode GetMusePackAttributes(IntPtr tags, AudioType audioType, ref MusePackAttributes attributes);

    /// <summary>
    /// Get source audio file's attributes.
    /// </summary>
    [TagsLibFunction("TagsLibrary_GetAudioAttribute")]
    public delegate double GetAudioAttribute(IntPtr tags, AudioAttribute attribute);

    [TagsLibFunction("TagsLibrary_GetTagSize")]
    public delegate int GetTagSize(IntPtr tags, TagType tagType);

    [TagsLibFunction("TagsLibrary_GetAudioFormat")]
    public delegate AudioFileFormat GetAudioFormat([In, MarshalAs(UnmanagedType.LPWStr)] string fileName);

    [TagsLibFunction("TagsLibrary_GetAudioFormatMemory")]
    public delegate AudioFileFormat GetAudioFormatMemory(IntPtr memoryAddress, UInt64 size);
}