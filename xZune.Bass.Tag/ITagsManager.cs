// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: ITagsManager.cs
// Version: 20160317

using System;

namespace xZune.Bass.Tag
{
    internal interface ITagsManager
    {
        String this[String name] { get; set; }

        double ChannelCount { get; }

        double SamplesPerSec { get; }

        double BitsPerSample { get; }

        TimeSpan Duration { get; }

        double SampleCount { get; }

        double BitRate { get; }

        int CoverCount { get; }
        

        bool SetTag(String name, String value);

        bool AddTag(String name, String value);

        bool RemoveTag(String name);

        bool RemoveTagAt(int index);
    }

    internal interface ITagsManager<T> : ITagsManager
    {

        T this[int index] { get; }

        bool SetTag(T tag);

        bool AddTag(T tag);
    }
}