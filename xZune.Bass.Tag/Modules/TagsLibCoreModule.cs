// Project: xZune.TagsLib (https://github.com/higankanshi/xZune.TagsLib)
// Filename: TagsLibCoreModule.cs
// Version: 20160317

using xZune.Bass.Tag.Interop;
using xZune.Bass.Tag.Interop.Core;

namespace xZune.Bass.Tag.Modules
{
    public class TagsLibCoreModule : TagsLibModule
    {
        public static TagsLibCoreModule Current { get; }

        internal static TagsLibFunction<Create> CreateFunction;
        internal static TagsLibFunction<Free> FreeFunction;
        internal static TagsLibFunction<LoadTags> LoadTagsFunction;
        internal static TagsLibFunction<LoadTagsFormMemory> LoadTagsFormMemoryFunction;
        internal static TagsLibFunction<LoadTagsFormBass> LoadTagsFormBassFunction;
        internal static TagsLibFunction<SaveTags> SaveTagsFunction;
        internal static TagsLibFunction<SaveTagsEx> SaveTagsExFunction;
        internal static TagsLibFunction<SaveTagsToMemory> SaveTagsToMemoryFunction;
        internal static TagsLibFunction<SaveTagsToMemoryEx> SaveTagsToMemoryExFunction;
        internal static TagsLibFunction<FreeSaveHandle> FreeSaveHandleFunction;
        internal static TagsLibFunction<RemoveTags> RemoveTagsFunction;
        internal static TagsLibFunction<RemoveTagFromMemory> RemoveTagFromMemoryFunction;
        internal static TagsLibFunction<GetTag> GetTagFunction;
        internal static TagsLibFunction<IsTagLoaded> IsTagLoadedFunction;
        internal static TagsLibFunction<GetTagEx> GetTagExFunction;
        internal static TagsLibFunction<GetExTagByIndex> GetExTagByIndexFunction;
        internal static TagsLibFunction<GetSimpleTagByIndex> GetSimpleTagByIndexFunction;
        internal static TagsLibFunction<GetID3V2TagExByIndex> GetID3V2TagExByIndexFunction;
        internal static TagsLibFunction<GetMp4TagExByIndex> GetMp4TagExByIndexFunction;
        internal static TagsLibFunction<SetTag> SetTagFunction;
        internal static TagsLibFunction<SetExTag> SetExTagFunction;
        internal static TagsLibFunction<SetSimpleTag> SetSimpleTagFunction;
        internal static TagsLibFunction<SetID3v2Tag> SetID3v2TagFunction;
        internal static TagsLibFunction<SetMP4Tag> SetMP4TagFunction;
        internal static TagsLibFunction<AddTag> AddTagFunction;
        internal static TagsLibFunction<AddExTag> AddExTagFunction;
        internal static TagsLibFunction<AddSimpleTag> AddSimpleTagFunction;
        internal static TagsLibFunction<AddID3v2Tag> AddID3v2TagFunction;
        internal static TagsLibFunction<AddMP4Tag> AddMP4TagFunction;
        internal static TagsLibFunction<GetTagCount> GetTagCountFunction;
        internal static TagsLibFunction<DeleteTag> DeleteTagFunction;
        internal static TagsLibFunction<DeleteTagByIndex> DeleteTagByIndexFunction;
        internal static TagsLibFunction<GetCoverArtCount> GetCoverArtCountFunction;
        internal static TagsLibFunction<GetCoverArt> GetCoverArtFunction;
        internal static TagsLibFunction<GetCoverArtToFile> GetCoverArtToFileFunction;
        internal static TagsLibFunction<DeleteCoverArt> DeleteCoverArtFunction;
        internal static TagsLibFunction<SetCoverArt> SetCoverArtFunction;
        internal static TagsLibFunction<SetCoverArtFromFile> SetCoverArtFromFileFunction;
        internal static TagsLibFunction<AddCoverArt> AddCoverArtFunction;
        internal static TagsLibFunction<SetTagLoadPriority> SetTagLoadPriorityFunction;
        internal static TagsLibFunction<GetTagData> GetTagDataFunction;
        internal static TagsLibFunction<SetTagData> SetTagDataFunction;
        internal static TagsLibFunction<GetCartPostTimer> GetCartPostTimerFunction;
        internal static TagsLibFunction<SetCartPostTimer> SetCartPostTimerFunction;
        internal static TagsLibFunction<ClearCartPostTimer> ClearCartPostTimerFunction;
        internal static TagsLibFunction<GetConfig> GetConfigFunction;
        internal static TagsLibFunction<SetConfig> SetConfigFunction;
        internal static TagsLibFunction<GetVendor> GetVendorFunction;
        internal static TagsLibFunction<SetVendor> SetVendorFunction;
        internal static TagsLibFunction<GetMPEGAudioAttributes> GetMPEGAudioAttributesFunction;
        internal static TagsLibFunction<GetFlacAudioAttributes> GetFlacAudioAttributesFunction;
        internal static TagsLibFunction<GetDSFAudioAttributes> GetDSFAudioAttributesFunction;
        internal static TagsLibFunction<GetOpusAudioAttributes> GetOpusAudioAttributesFunction;
        internal static TagsLibFunction<GetVorbisAudioAttributes> GetVorbisAudioAttributesFunction;
        internal static TagsLibFunction<GetWAVEAudioAttributes> GetWAVEAudioAttributesFunction;
        internal static TagsLibFunction<GetAiffAttributes> GetAiffAttributesFunction;
        internal static TagsLibFunction<GetMp4AudioAttributes> GetMp4AudioAttributesFunction;
        internal static TagsLibFunction<GetWMAAttributes> GetWMAAttributesFunction;
        internal static TagsLibFunction<GetAudioAttributes> GetAudioAttributesFunction;
        internal static TagsLibFunction<GetWAVPackAttributes> GetWAVPackAttributesFunction;
        internal static TagsLibFunction<GetMusePackAttributes> GetMusePackAttributesFunction;
        internal static TagsLibFunction<GetAudioAttribute> GetAudioAttributeFunction;
        internal static TagsLibFunction<GetTagSize> GetTagSizeFunction;
        internal static TagsLibFunction<GetAudioFormat> GetAudioFormatFunction;
        internal static TagsLibFunction<GetAudioFormatMemory> GetAudioFormatMemoryFunction;
        
        static TagsLibCoreModule()
        {
            Current = new TagsLibCoreModule();
        }

        private TagsLibCoreModule()
        {

        }

        internal override void InitializeModule()
        {
            if (!TagsLibManager.Available) throw new TagsLibNotLoadedException();

            CreateFunction = new TagsLibFunction<Create>();
            FreeFunction = new TagsLibFunction<Free>();
            LoadTagsFunction = new TagsLibFunction<LoadTags>();
            LoadTagsFormMemoryFunction = new TagsLibFunction<LoadTagsFormMemory>();
            LoadTagsFormBassFunction = new TagsLibFunction<LoadTagsFormBass>();
            SaveTagsFunction = new TagsLibFunction<SaveTags>();
            SaveTagsExFunction = new TagsLibFunction<SaveTagsEx>();
            SaveTagsToMemoryFunction = new TagsLibFunction<SaveTagsToMemory>();
            SaveTagsToMemoryExFunction = new TagsLibFunction<SaveTagsToMemoryEx>();
            FreeSaveHandleFunction = new TagsLibFunction<FreeSaveHandle>();
            RemoveTagsFunction = new TagsLibFunction<RemoveTags>();
            RemoveTagFromMemoryFunction = new TagsLibFunction<RemoveTagFromMemory>();
            GetTagFunction = new TagsLibFunction<GetTag>();
            IsTagLoadedFunction = new TagsLibFunction<IsTagLoaded>();
            GetTagExFunction = new TagsLibFunction<GetTagEx>();
            GetExTagByIndexFunction = new TagsLibFunction<GetExTagByIndex>();
            GetSimpleTagByIndexFunction = new TagsLibFunction<GetSimpleTagByIndex>();
            GetID3V2TagExByIndexFunction = new TagsLibFunction<GetID3V2TagExByIndex>();
            GetMp4TagExByIndexFunction = new TagsLibFunction<GetMp4TagExByIndex>();
            SetTagFunction = new TagsLibFunction<SetTag>();
            SetExTagFunction = new TagsLibFunction<SetExTag>();
            SetSimpleTagFunction = new TagsLibFunction<SetSimpleTag>();
            SetID3v2TagFunction = new TagsLibFunction<SetID3v2Tag>();
            SetMP4TagFunction = new TagsLibFunction<SetMP4Tag>();
            AddTagFunction = new TagsLibFunction<AddTag>();
            AddExTagFunction = new TagsLibFunction<AddExTag>();
            AddSimpleTagFunction = new TagsLibFunction<AddSimpleTag>();
            AddID3v2TagFunction = new TagsLibFunction<AddID3v2Tag>();
            AddMP4TagFunction = new TagsLibFunction<AddMP4Tag>();
            GetTagCountFunction = new TagsLibFunction<GetTagCount>();
            DeleteTagFunction = new TagsLibFunction<DeleteTag>();
            DeleteTagByIndexFunction = new TagsLibFunction<DeleteTagByIndex>();
            GetCoverArtCountFunction = new TagsLibFunction<GetCoverArtCount>();
            GetCoverArtFunction = new TagsLibFunction<GetCoverArt>();
            GetCoverArtToFileFunction = new TagsLibFunction<GetCoverArtToFile>();
            DeleteCoverArtFunction = new TagsLibFunction<DeleteCoverArt>();
            SetCoverArtFunction = new TagsLibFunction<SetCoverArt>();
            SetCoverArtFromFileFunction = new TagsLibFunction<SetCoverArtFromFile>();
            AddCoverArtFunction = new TagsLibFunction<AddCoverArt>();
            SetTagLoadPriorityFunction = new TagsLibFunction<SetTagLoadPriority>();
            GetTagDataFunction = new TagsLibFunction<GetTagData>();
            SetTagDataFunction = new TagsLibFunction<SetTagData>();
            GetCartPostTimerFunction = new TagsLibFunction<GetCartPostTimer>();
            SetCartPostTimerFunction = new TagsLibFunction<SetCartPostTimer>();
            ClearCartPostTimerFunction = new TagsLibFunction<ClearCartPostTimer>();
            GetConfigFunction = new TagsLibFunction<GetConfig>();
            SetConfigFunction = new TagsLibFunction<SetConfig>();
            GetVendorFunction = new TagsLibFunction<GetVendor>();
            SetVendorFunction = new TagsLibFunction<SetVendor>();
            GetMPEGAudioAttributesFunction = new TagsLibFunction<GetMPEGAudioAttributes>();
            GetFlacAudioAttributesFunction = new TagsLibFunction<GetFlacAudioAttributes>();
            GetDSFAudioAttributesFunction = new TagsLibFunction<GetDSFAudioAttributes>();
            GetOpusAudioAttributesFunction = new TagsLibFunction<GetOpusAudioAttributes>();
            GetVorbisAudioAttributesFunction = new TagsLibFunction<GetVorbisAudioAttributes>();
            GetWAVEAudioAttributesFunction = new TagsLibFunction<GetWAVEAudioAttributes>();
            GetAiffAttributesFunction = new TagsLibFunction<GetAiffAttributes>();
            GetMp4AudioAttributesFunction = new TagsLibFunction<GetMp4AudioAttributes>();
            GetWMAAttributesFunction = new TagsLibFunction<GetWMAAttributes>();
            GetAudioAttributesFunction = new TagsLibFunction<GetAudioAttributes>();
            GetWAVPackAttributesFunction = new TagsLibFunction<GetWAVPackAttributes>();
            GetMusePackAttributesFunction = new TagsLibFunction<GetMusePackAttributes>();
            GetAudioAttributeFunction = new TagsLibFunction<GetAudioAttribute>();
            GetTagSizeFunction = new TagsLibFunction<GetTagSize>();
            GetAudioFormatFunction = new TagsLibFunction<GetAudioFormat>();
            GetAudioFormatMemoryFunction = new TagsLibFunction<GetAudioFormatMemory>();

            ModuleAvailable = true;
            
        }

        /// <exception cref="TagsLibNotLoadedException">
        ///     TagsLib DLL not loaded, you must use TagsLib to load TagsLib DLL
        ///     first.
        /// </exception>
        internal override void FreeModule()
        {
            if (!TagsLibManager.Available) throw new TagsLibNotLoadedException();

            CreateFunction = null;
            FreeFunction = null;
            LoadTagsFunction = null;
            LoadTagsFormMemoryFunction = null;
            LoadTagsFormBassFunction = null;
            SaveTagsFunction = null;
            SaveTagsExFunction = null;
            SaveTagsToMemoryFunction = null;
            SaveTagsToMemoryExFunction = null;
            FreeSaveHandleFunction = null;
            RemoveTagsFunction = null;
            RemoveTagFromMemoryFunction = null;
            GetTagFunction = null;
            IsTagLoadedFunction = null;
            GetTagExFunction = null;
            GetExTagByIndexFunction = null;
            GetSimpleTagByIndexFunction = null;
            GetID3V2TagExByIndexFunction = null;
            GetMp4TagExByIndexFunction = null;
            SetTagFunction = null;
            SetExTagFunction = null;
            SetSimpleTagFunction = null;
            SetID3v2TagFunction = null;
            SetMP4TagFunction = null;
            AddTagFunction = null;
            AddExTagFunction = null;
            AddSimpleTagFunction = null;
            AddID3v2TagFunction = null;
            AddMP4TagFunction = null;
            GetTagCountFunction = null;
            DeleteTagFunction = null;
            DeleteTagByIndexFunction = null;
            GetCoverArtCountFunction = null;
            GetCoverArtFunction = null;
            GetCoverArtToFileFunction = null;
            DeleteCoverArtFunction = null;
            SetCoverArtFunction = null;
            SetCoverArtFromFileFunction = null;
            AddCoverArtFunction = null;
            SetTagLoadPriorityFunction = null;
            GetTagDataFunction = null;
            SetTagDataFunction = null;
            GetCartPostTimerFunction = null;
            SetCartPostTimerFunction = null;
            ClearCartPostTimerFunction = null;
            GetConfigFunction = null;
            SetConfigFunction = null;
            GetVendorFunction = null;
            SetVendorFunction = null;
            GetMPEGAudioAttributesFunction = null;
            GetFlacAudioAttributesFunction = null;
            GetDSFAudioAttributesFunction = null;
            GetOpusAudioAttributesFunction = null;
            GetVorbisAudioAttributesFunction = null;
            GetWAVEAudioAttributesFunction = null;
            GetAiffAttributesFunction = null;
            GetMp4AudioAttributesFunction = null;
            GetWMAAttributesFunction = null;
            GetAudioAttributesFunction = null;
            GetWAVPackAttributesFunction = null;
            GetMusePackAttributesFunction = null;
            GetAudioAttributeFunction = null;
            GetTagSizeFunction = null;
            GetAudioFormatFunction = null;
            GetAudioFormatMemoryFunction = null;

            ModuleAvailable = false;
            
        }
    }
}