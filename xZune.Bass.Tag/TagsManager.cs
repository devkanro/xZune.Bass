// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: TagsManager.cs
// Version: 20160317

using System;
using xZune.Bass.Tag.Interop.Core;
using xZune.Bass.Tag.Modules;

namespace xZune.Bass.Tag
{
    public class TagsManager : HandleObject
    {
        protected TagsManager(IntPtr handle)
        {
            Handle = handle;
            IsAvailable = true;

            TagDictionary = new TagDictionary(this);
            TagList = new ExTagList(this);
            APETagList = new SimpleTagList(this, TagType.APEv2);
            FLACTagList = new SimpleTagList(this, TagType.Flac);
            ID3v1TagList = new SimpleTagList(this, TagType.ID3v1);
            OpusVorbisList = new SimpleTagList(this, TagType.OpusVorbis);
            WMATagList = new SimpleTagList(this, TagType.WMA);
            WAVTagList = new SimpleTagList(this, TagType.WAV);
        }

        public static TagsManager CreateFormFile(String file, TagType type = TagType.Automatic, bool parseTags = true)
        {
            var handle = TagsLibCoreModule.CreateFunction.Delegate();
            var result = new TagsManager(handle);

            TagsLibCoreModule.LoadTagsFunction.Delegate(handle, file, type, parseTags);

            return result;
        }

        public static TagsManager CreateFormMemory(IntPtr memory, ulong size, TagType type = TagType.Automatic, bool parseTags = true)
        {
            var handle = TagsLibCoreModule.CreateFunction.Delegate();
            var result = new TagsManager(handle);

            TagsLibCoreModule.LoadTagsFormMemoryFunction.Delegate(handle, memory, size, type, parseTags);

            return result;
        }

        public static TagsManager CreateFormBass(Channel bassChannel)
        {
            var handle = TagsLibCoreModule.CreateFunction.Delegate();
            var result = new TagsManager(handle);

            TagsLibCoreModule.LoadTagsFormBassFunction.Delegate(handle, bassChannel.Handle);

            return result;
        }

        protected override void ReleaseManaged()
        {

        }

        protected override void ReleaseUnmanaged()
        {
            TagsLibCoreModule.FreeFunction.Delegate(Handle);
        }

        public bool IsTagLoaded => TagsLibCoreModule.IsTagLoadedFunction.Delegate(Handle, TagType.Automatic);
        public bool IsID3v1TagLoaded => TagsLibCoreModule.IsTagLoadedFunction.Delegate(Handle, TagType.ID3v1);
        public bool IsID3v2TagLoaded => TagsLibCoreModule.IsTagLoadedFunction.Delegate(Handle, TagType.ID3v2);
        public bool IsAPEv2TagLoaded => TagsLibCoreModule.IsTagLoadedFunction.Delegate(Handle, TagType.APEv2);
        public bool IsFlacTagLoaded => TagsLibCoreModule.IsTagLoadedFunction.Delegate(Handle, TagType.Flac);
        public bool IsMP4TagLoaded => TagsLibCoreModule.IsTagLoadedFunction.Delegate(Handle, TagType.MP4);
        public bool IsOpusVorbisTagLoaded => TagsLibCoreModule.IsTagLoadedFunction.Delegate(Handle, TagType.OpusVorbis);
        public bool IsWAVTagLoaded => TagsLibCoreModule.IsTagLoadedFunction.Delegate(Handle, TagType.WAV);
        public bool IsWMATagLoaded => TagsLibCoreModule.IsTagLoadedFunction.Delegate(Handle, TagType.WMA);

        public TagDictionary TagDictionary { get; private set; }
        public ExTagList TagList { get; private set; }
        public SimpleTagList APETagList { get; private set; }
        public SimpleTagList FLACTagList { get; private set; }
        public SimpleTagList ID3v1TagList { get; private set; }
        public SimpleTagList OpusVorbisList { get; private set; }
        public SimpleTagList WAVTagList { get; private set; }
        public SimpleTagList WMATagList { get; private set; }
    }
}